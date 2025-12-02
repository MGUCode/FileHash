using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileHash
{
    public partial class Form1 : Form
    {
        string oldPath;
        ComputeHash compute = new ComputeHash();
        IOManagement fileSystem = new IOManagement();
        bool computeresult;
        bool writeresult;

        public Form1()
        {
            InitializeComponent();

            ///
            /// At first start, disable all components except 
            /// the select file button and
            /// the associated textbox
            /// 
            Computebutton.Enabled = false;
            Copybutton.Enabled = false;
            Writebutton.Enabled = false;
            ResulttextBox.Enabled = false;
            statusLabel.Text = "";
        }


        /// <summary>
        /// Select file with the file browser dialog
        /// Return the full path to the associated textbox
        /// </summary>
        private void OpenFilebutton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            PathToFiletextBox.Text = openFileDialog1.FileName;
        }


        /// <summary>
        /// Compute hash result
        /// </summary>
        private void Computebutton_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                if (fileSystem.FileExists(PathToFiletextBox.Text))
                {
                    statusLabel.Text = "Computing...";
                    Computebutton.Enabled = false;
                    Copybutton.Enabled = false;
                    Writebutton.Enabled = false;
                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    InfoMessages.DisplayError(ErrorCode.FileNotFound);
                }
            }
        }

       /// <summary>
       /// Enable/disable buttons when the content of the PathToFileTextbox changed
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void PathToFiletextBox_TextChanged(object sender, EventArgs e)
        {
            if (PathToFiletextBox.Text.Length > 0)
            {
                Computebutton.Enabled = true;
            }

            if (PathToFiletextBox.Text.Length == 0)
            {
                Computebutton.Enabled = false;
            }

            if (oldPath != PathToFiletextBox.Text)
            {
                Copybutton.Enabled = false;
                Writebutton.Enabled = false;
                ResulttextBox.Text = "";
                statusLabel.Text = "";
            }
        }

        /// <summary>
        /// Copy the hashvalue in clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Copybutton_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(ResulttextBox.Text);
                statusLabel.Text = "Result copied to clipboard";
            }
            catch (ArgumentNullException)
            {
                InfoMessages.DisplayError(ErrorCode.HashEmpty);
            }  
            catch (Exception)
            {
                InfoMessages.DisplayError(ErrorCode.Clipboard);
            }
        }

        /// <summary>
        /// Write the hash value to a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Writebutton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Writing file";

            writeresult = fileSystem.WriteHashFile(PathToFiletextBox.Text, ResulttextBox.Text);

            if (writeresult)
            {
                statusLabel.Text = "Writing complete";
            }
            else
            {
                statusLabel.Text = "Write error";
            }
            
        }

        /// <summary>
        /// Set the file path for a drag-and-drop action
        /// In case of multiple selected files, only the first one is use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PathToFiletextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 0)
            {
                PathToFiletextBox.Text = files[0];
            }
        }

        /// <summary>
        /// Add cursor effect when drag a file in textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PathToFiletextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }             
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            computeresult = false;
            computeresult = compute.GetSHA256value(PathToFiletextBox.Text);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Computebutton.Text = "Compute";
            Computebutton.Enabled = true;

            //start compute of the hash
            if (computeresult)
            {
                statusLabel.Text = "Finish!";

                //display result
                ResulttextBox.Text = compute.hashValue;

                //Enable actions buttons
                Copybutton.Enabled = true;
                Writebutton.Enabled = true;

                oldPath = PathToFiletextBox.Text;
            }
            else 
            {
                statusLabel.Text = "Error";
            }
        }
    }
}
