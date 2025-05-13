using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileHash
{
    public enum ErrorCode
    {
        Compute = 1,
        FileNotFound = 2,
        Clipboard = 3,
        FileWriteError = 4,
        HashEmpty = 5
    }

    public enum InfoCode
    {
        FileOK = 1000
    }


    static class InfoMessages
    {
        public static void DisplayError(ErrorCode msgId)
        {
            switch (msgId)
            {
                case ErrorCode.Compute: 
                    MessageBox.Show("Compute Error","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                    break;
                case ErrorCode.FileNotFound: 
                    MessageBox.Show("Specified file not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case ErrorCode.Clipboard: 
                    MessageBox.Show("Error during copy in clipboard", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case ErrorCode.FileWriteError: 
                    MessageBox.Show("Error during writing file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case ErrorCode.HashEmpty: 
                    MessageBox.Show("No hash value to copy in clîpboard", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
        }

        public static void DisplayInfo(InfoCode msgId)
        {
            switch (msgId)
            {
                case InfoCode.FileOK:
                    MessageBox.Show("File generated with success!","Info", MessageBoxButtons.OK,MessageBoxIcon.Information); 
                    break;
                default:
                    break;
            }
        }
    }
}
