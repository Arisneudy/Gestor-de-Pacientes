using Microsoft.AspNetCore.Http;

namespace GestorDePaciente.Core.Application.Helpers;

public class UploadsFile
{
    public static string UploadImage(IFormFile file, int id, string type = "", bool idEditing = false, string ImageUrl = "")
    {
        string basePath = "";
        if (idEditing && file == null) return ImageUrl;
        
        if (type == "doctor")
        {
            basePath = $"wwwroot/images/doctors/{id}";
        }
        
        if (type == "patient")
        {
            basePath = $"wwwroot/images/patients/{id}";
        }
        
        string path = Path.Combine(Directory.GetCurrentDirectory(), basePath);

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        Guid guid = Guid.NewGuid();
        FileInfo fileinfo = new(file.FileName);
        string fileName = guid + fileinfo.Extension;

        string fullPath = Path.Combine(path, fileName);
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            file.CopyTo(stream);
        }
        
        if (type == "doctor")
        {
            return $"/images/doctors/{id}/{fileName}";
        }

        if (type == "patient")
        {
            return $"/images/patients/{id}/{fileName}";
        }
        
        return $"/images/{id}/{fileName}";
    }

}