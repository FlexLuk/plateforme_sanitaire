using Blazored.LocalStorage;
using LYRA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;
using Blazored.LocalStorage.StorageOptions;

namespace LYRA.Controllers
{
    [DisableRequestSizeLimit]
    public class UploadController : Controller
    {
        private string _nomDossier;

        [HttpPost("upload/{nom_dossier}")]
        public IActionResult Multiple(IFormFile[] files, string nom_dossier)
        {
            _nomDossier = nom_dossier;
            try
            {
                foreach (var file in files)
                {
                    UploadFile(file);
                }
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public async Task UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\archives\" + _nomDossier + "\\");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                var fullPath = Path.Combine(uploadPath, file.FileName);
                using (FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    //await file.CopyToAsync(fileStream);
                    file.CopyTo(fileStream);
                }
            }
        }
    }
}
