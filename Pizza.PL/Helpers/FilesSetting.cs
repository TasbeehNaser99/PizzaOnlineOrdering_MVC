namespace Pizza.PL.Helpers
{
    public class FilesSetting
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            // Correct path concatenation using Path.Combine
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", folderName);

            // Ensure the directory exists
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Generate a unique file name
            string fileName = $"{Guid.NewGuid()}_{file.FileName}";
            string filePath = Path.Combine(folderPath, fileName);

            // Use 'using' to ensure the file stream is disposed properly
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return fileName;
        }

        public static void DeleteFile(string fileName, string folderName)
        {
            // Correct path concatenation using Path.Combine
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", folderName, fileName);

            // Check if the file exists and delete it
            if (File.Exists(folderPath))
            {
                File.Delete(folderPath);
            }
        }
    }

}
