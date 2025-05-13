using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace FileHash
{

    public class IOManagement
    {
        /// <summary>
        ///     Write the hash value to a file.
        ///     The file name is the same as the file in "hashFileFullPath" parameter
        ///     Write the file to the same folder, or Document folder, or finally let user choose
        /// </summary>
        /// <param name="hashFileFullPath">Path to the file used to calculate the hash</param>
        /// <param name="hashValue">Hash value</param>
        /// <returns>
        ///     true: success
        ///     false: error
        /// </returns>
        public bool WriteHashFile(string hashFileFullPath, string hashValue)
        {
            //extract file name
            string fileName = Path.GetFileNameWithoutExtension(hashFileFullPath);


            //Get the directory name of the file
            //next, build the file name with the final extension
            string directoryPath = Path.GetDirectoryName(hashFileFullPath);
            string fileNameWithExtension = fileName + ".sha256.txt";


            //write content to file
            return WriteFile(directoryPath, fileNameWithExtension, hashValue);
        }

        /// <summary>
        ///     Write content to file
        /// </summary>
        /// <param name="directoryPath">Path to the folder where the file will be written</param>
        /// <param name="fileNameWithExtension">The file name with his extension (separated by a .)</param>
        /// <param name="content">Content to write</param>
        /// <returns>
        ///     true: success
        ///     false: error
        /// </returns>
        private bool WriteFile(string directoryPath, string fileNameWithExtension, string content)
        {
            //Test if the current user have the right to write a file in this directory
            //if we can write, build the full path with actual directory, file name and extension
            //else, ask the user what to do
            string fullPath = "";
            if (CanWriteInDirectory(directoryPath))
            {
                fullPath = Path.Combine(directoryPath, fileNameWithExtension);
            }
            else
            {
                //ask user where to write the file
                DialogResult answer = MessageBox.Show(
                    "Cannot write in the same directory as your file. Do you want to write the file in your Documents folder?",
                    "Choice",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                //1st choice : user's Document folder
                if (answer == DialogResult.Yes)
                {
                    fullPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                        fileNameWithExtension
                        );
                }
                //2nd choice : asking user where to write the file
                else
                {
                    FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                    DialogResult folderDialogResult = folderDialog.ShowDialog();

                    //build the full path with user's choice
                    if (folderDialogResult == DialogResult.OK)
                    {
                        fullPath = Path.Combine(folderDialog.SelectedPath, fileNameWithExtension);
                    }
                    //if user don't choose a directory, end of the function!
                    else
                    {
                        return false;
                    }
                }
            }


            //Check if the file already exist
            //Next, write the file at the good location
            if (!CheckForExistingFile(fullPath))
            {
                LaunchWriteFile(fullPath, content);

                return true;
            }

            return false;
        }

        /// <summary>
        ///     Test if the current user have the right to write a file in a directory
        /// </summary>
        /// <param name="path">Directory to test</param>
        /// <returns>
        ///     true: allow
        ///     false: deny
        /// </returns>
        private bool CanWriteInDirectory(string path)
        {
            //get current user's informations
            WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
            WindowsPrincipal currentUserInfos = new WindowsPrincipal(currentUser);


            //Get the ACL of the folder
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            DirectorySecurity dirSecurity = dirInfo.GetAccessControl();
            AuthorizationRuleCollection dirACLs = dirSecurity.GetAccessRules(true, true, typeof(NTAccount));


            //For each ACL of "Allow type", search if current user
            //is the member of the windows group found in ACL
            foreach (FileSystemAccessRule item in dirACLs)
            {
                if (item.AccessControlType == AccessControlType.Allow)
                {
                    string groupOrUser = item.IdentityReference.ToString();

                    if (currentUserInfos.IsInRole(groupOrUser))
                    {
                        //Check if the user have the rights to write a file in the folder
                        if ((item.FileSystemRights == FileSystemRights.Write) || (item.FileSystemRights == FileSystemRights.FullControl))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        ///     Check in the file already exist and ask for overwrite if it's the case
        /// </summary>
        /// <param name="filePath">Path to the file to test</param>
        /// <returns>
        ///     true: file exist and user don't want to overwite 
        ///     false: file not exist or user wants to overwrite
        /// </returns>
        private bool CheckForExistingFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                DialogResult answer = MessageBox.Show(
                    "File already exist. Do you want to overwrite?",
                    "Choice",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                if (answer == DialogResult.Yes)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///     Execute the write process
        /// </summary>
        /// <param name="fullPath"></param>
        /// <param name="content"></param>
        private void LaunchWriteFile(string fullPath, string content)
        {
            try
            {
                using (var writer = new StreamWriter(fullPath, false))
                {
                    writer.WriteLine(content);
                }

                InfoMessages.DisplayInfo(InfoCode.FileOK);
            }
            catch (Exception)
            {
                InfoMessages.DisplayError(ErrorCode.FileWriteError);
            }
        }       

        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }       
    }
}
