using System;
using System.IO;
using System.Text.RegularExpressions;

namespace FreelanceTaskManager.Services
{
    public class FolderService
    {
        public string CreateProjectFolder(string baseDirectory, string orderNumber, string projectTitle)
        {
            if (string.IsNullOrWhiteSpace(baseDirectory))
            {
                throw new Exception("Не вибрано основну папку для збереження проєктів.");
            }

            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }

            string formattedOrderNumber = FormatOrderNumber(orderNumber);
            string safeTitle = MakeSafeFileName(projectTitle);

            string folderName = $"{formattedOrderNumber} - {safeTitle}";
            string fullPath = Path.Combine(baseDirectory, folderName);

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            return fullPath;
        }

        public string FormatOrderNumber(string orderNumber)
        {
            if (string.IsNullOrWhiteSpace(orderNumber))
            {
                return "NO-ID";
            }

            return orderNumber.Replace("id-", "ID").Replace("ID-", "ID").ToUpper();
        }

        private string MakeSafeFileName(string fileName)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(c, '_');
            }

            return fileName.Trim();
        }
    }
}