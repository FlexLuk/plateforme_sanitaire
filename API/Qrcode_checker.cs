using Blazorise.Extensions;
using LYRA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LYRA.API
{
    [Route("[controller]")]
    [ApiController]
    public class Qrcode_checker : ControllerBase
    {
        private String categorie = string.Empty;
        private String id = string.Empty;
        private String numOSIET = string.Empty;
        private String nom = string.Empty;
        private String prenom = string.Empty;
        private String status = string.Empty;
        private String message = string.Empty;
        private readonly ADHESIONContext? affiliService;

        public Qrcode_checker(ADHESIONContext adContext)
        {
            affiliService = adContext;
        }

        // GET: api/<Qrcode_checker>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "OSIET", "Taolagnaro" };
        }

        // POST api/<Qrcode_checker>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Payload payload)
        {
            QRCode _qrcode = new QRCode();

            if (payload == null)
            {
                return BadRequest("Payload is null.");
            }

            categorie = payload.Categorie ?? string.Empty;

            if (categorie == "Travailleur")
            {
                _qrcode = await GetResultStatusEmployerAsync(payload);
            }
            else
            {
                if (String.IsNullOrEmpty(categorie))
                    return BadRequest("Category is null.");
                else
                    _qrcode = await GetResultStatusFamilleAsync(payload);
            }

            // ✅ Retourner un JSON avec les données
            // Message = "Success"
            return Ok(_qrcode);
        }

        private async Task<QRCode> GetResultStatusFamilleAsync(Payload payload)
        {
            Famille famille = new Famille();
            Employer employer = new Employer();
            Employeur employeur = new Employeur();
            QRCode _qrcode = new QRCode();

            try
            {
                famille = await affiliService.Familles.FirstOrDefaultAsync(f => f.Familleid == int.Parse(payload.ID) && f.Numeroosiet == payload.NumOSIET);
                employer = await affiliService.Employers.FirstOrDefaultAsync(e => e.Numeroosiet == payload.NumOSIET && e.Employerid == famille.Employerid);
                employeur = await affiliService.Employeurs.FirstOrDefaultAsync(e => e.Numemployeur == employer.Numemployeur);
                _qrcode = new QRCode
                {
                    Message = status == "OK" ? "Success" : "Failed",
                    NomEmployeur = employeur.Raisonsociale,
                    NumOSIET = payload.NumOSIET,
                    Categorie = payload.Categorie,
                    Nom = famille?.Nom ?? string.Empty,
                    Prenom = famille?.Prenom ?? string.Empty,
                };
                return _qrcode;
            }catch(Exception ex)
            {
                _qrcode = new QRCode
                {
                    Message = "Failed",
                    NomEmployeur = "",
                    NumOSIET = "",
                    Categorie = "",
                    Nom = "",
                    Prenom = "",
                };
                return _qrcode;
            }
        }

        private async Task<QRCode> GetResultStatusEmployerAsync(Payload payload)
        {
            Employer employer = new Employer();
            Employeur employeur = new Employeur();
            QRCode _qrcode = new QRCode();

            try
            {
                employer = await affiliService.Employers.FirstOrDefaultAsync(e => e.Numeroosiet == payload.NumOSIET);
                employeur = await affiliService.Employeurs.FirstOrDefaultAsync(e => e.Numemployeur == employer.Numemployeur);
                _qrcode = new QRCode
                {
                    Message = status == "OK" ? "Success" : "Failed",
                    NomEmployeur = employeur.Raisonsociale,
                    NumOSIET = payload.NumOSIET,
                    Categorie = payload.Categorie,
                    Nom = employer?.Nom ?? string.Empty,
                    Prenom = employer?.Prenom ?? string.Empty,
                };
                return _qrcode;
            }
            catch (Exception ex)
            {
                _qrcode = new QRCode
                {
                    Message = "Failed",
                    NomEmployeur = "",
                    NumOSIET = "",
                    Categorie = "",
                    Nom = "",
                    Prenom = "",
                };
                return _qrcode;
            }
        }
    }
}
