using Microsoft.AspNetCore.Http;

namespace Company.Service.Helper;

public class DocumentSettings
{
    public static string UploadFile(IFormFile file, string folderName)
    {
        var folderPath = Path.Combine(
            Directory.GetCurrentDirectory(), @"wwwroot\Files", folderName);

        var fileExtension = new FileInfo(file.FileName).Extension;
        var fileName = $"{Guid.NewGuid()}{fileExtension}";

        var filePath = Path.Combine(folderPath, fileName);

        using var fileStream = new FileStream(filePath, FileMode.Create);
        file.CopyTo(fileStream);

        return fileName;
    }
}
