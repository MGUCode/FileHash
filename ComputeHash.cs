using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FileHash
{
    public class ComputeHash
    {
        public string hashValue;

        /// <summary>
        ///     Get the SHA256 value of a file
        /// </summary>
        /// <param name="filePath">Path to the file to test</param>
        /// <returns>
        ///     true: success
        ///     false: error
        /// </returns>
        public bool GetSHA256value(string filePath)
        {
            hashValue = string.Empty;

            try
            {
                using (var sha256 = SHA256.Create())
                {
                    using (var stream = File.OpenRead(filePath))
                    {
                        hashValue = BitConverter.ToString(sha256.ComputeHash(stream)).Replace("-", "").ToLower();
                    }
                }

                return true;
            }
            catch (Exception)
            {
                InfoMessages.DisplayError(ErrorCode.Compute);
                return false;
            }
        }
    }
}
