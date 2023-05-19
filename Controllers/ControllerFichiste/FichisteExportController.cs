using Blazored.LocalStorage;
using LYRA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LYRA.Controllers.ControllerFichiste
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FichisteExportController : ControllerBase
    {
        private const string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        private readonly FICHISTEContext? _context;
        private readonly ADHESIONContext? _adContext;
        public FichisteExportController(FICHISTEContext context, ADHESIONContext adContext)
        {
            _context = context;
            _adContext = adContext;
        }

        public async Task<IActionResult> DownloadAllJournalier()
        {

            List<Fichiste> fichistes = await _context.Fichistes.Where(f => f.Date.Date == DateTime.Now.Date).ToListAsync();
            List<FichisteModel> fModels = new();

            foreach (var data in fichistes)
            {
                Employer emp = new();
                Famille fam = new();
                FichisteModel fModel = new();

                if (data.Categorie == "Famille")
                {
                    fam = await _adContext.Familles.Where(x => x.Familleid == Convert.ToInt32(data.Affiliationid)).FirstOrDefaultAsync();
                    fModel.FId = data.Fichisteid;
                    fModel.FName = fam.Nom.Trim() + " " + fam.Prenom.Trim();
                    fModel.FNomfichiste = data.Username.Trim();
                    fModel.FDateCreate = data.Date;
                    fModel.FDateNaissance = fam.Datenaissance;
                    emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();
                    Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                    fModel.FEtablissement = empr.Raisonsociale;
                    fModel.FFrequenceM = data.Frequencemois;
                    fModel.FFrequenceY = data.Frequenceannee;
                    fModel.FLieuNaissance = fam.Lieunaissance;
                    fModel.FNumero = data.Numjour;
                    fModel.FNumeroosiet = fam.Numeroosiet;
                    fModel.FParametre = data.Parametreid;
                    fModel.FCategorie = "Famille";
                    fModels.Add(fModel);
                }
                else
                {
                    emp = await _adContext.Employers.Where(x => x.Employerid == Convert.ToInt32(data.Affiliationid)).FirstAsync();
                    fModel.FId = data.Fichisteid;
                    fModel.FName = emp.Nom.Trim() + " " + emp.Prenom.Trim();
                    fModel.FNomfichiste = data.Username.Trim();
                    fModel.FDateCreate = data.Date;
                    fModel.FDateNaissance = emp.Datenaissance;
                    Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                    fModel.FEtablissement = empr.Raisonsociale;
                    fModel.FFrequenceM = data.Frequencemois;
                    fModel.FFrequenceY = data.Frequenceannee;
                    fModel.FLieuNaissance = emp.Lieunaissance;
                    fModel.FNumero = data.Numjour;
                    fModel.FNumeroosiet = emp.Numeroosiet;
                    fModel.FParametre = data.Parametreid;
                    fModel.FCategorie = "Travailleur";
                    fModels.Add(fModel);
                }
            }
            byte[] reportBytes;
            using (var package = Utils.DownloadAllJournalier(fModels))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MyReport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }

        public async Task<IActionResult> DownloadFamJournalier()
        {
            List<Fichiste> fichistes = await _context.Fichistes.Where(f => f.Date.Date == DateTime.Now.Date && f.Categorie == "Famille").ToListAsync();
            List<FichisteModel> fModels = new();

            foreach (var data in fichistes)
            {
                Employer emp = new();
                Famille fam = new();
                FichisteModel fModel = new();

                if (data.Categorie == "Famille")
                {
                    fam = await _adContext.Familles.Where(x => x.Familleid == Convert.ToInt32(data.Affiliationid)).FirstOrDefaultAsync();
                    fModel.FId = data.Fichisteid;
                    fModel.FName = fam.Nom.Trim() + " " + fam.Prenom.Trim();
                    fModel.FNomfichiste = data.Username.Trim();
                    fModel.FDateCreate = data.Date;
                    fModel.FDateNaissance = fam.Datenaissance;
                    emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();
                    Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                    fModel.FEtablissement = empr.Raisonsociale;
                    fModel.FFrequenceM = data.Frequencemois;
                    fModel.FFrequenceY = data.Frequenceannee;
                    fModel.FLieuNaissance = fam.Lieunaissance;
                    fModel.FNumero = data.Numjour;
                    fModel.FNumeroosiet = fam.Numeroosiet;
                    fModel.FParametre = data.Parametreid;
                    fModel.FCategorie = "Famille";
                    fModels.Add(fModel);
                }

            }
            byte[] reportBytes;
            using (var package = Utils.DownloadFamJournalier(fModels))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MyReport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }

        public async Task<IActionResult> DownloadTravJournalier()
        {
            List<Fichiste> fichistes = await _context.Fichistes.Where(f => f.Date.Date == DateTime.Now.Date && f.Categorie == "Travailleur").ToListAsync();
            List<FichisteModel> fModels = new();

            foreach (var data in fichistes)
            {
                Employer emp = new();
                Famille fam = new();
                FichisteModel fModel = new();

                if (data.Categorie != "Famille")
                {
                    emp = await _adContext.Employers.Where(x => x.Employerid == Convert.ToInt32(data.Affiliationid)).FirstAsync();
                    fModel.FId = data.Fichisteid;
                    fModel.FName = emp.Nom.Trim() + " " + emp.Prenom.Trim();
                    fModel.FNomfichiste = data.Username.Trim();
                    fModel.FDateCreate = data.Date;
                    fModel.FDateNaissance = emp.Datenaissance;
                    Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                    fModel.FEtablissement = empr.Raisonsociale;
                    fModel.FFrequenceM = data.Frequencemois;
                    fModel.FFrequenceY = data.Frequenceannee;
                    fModel.FLieuNaissance = emp.Lieunaissance;
                    fModel.FNumero = data.Numjour;
                    fModel.FNumeroosiet = emp.Numeroosiet;
                    fModel.FParametre = data.Parametreid;
                    fModel.FCategorie = "Travailleur";
                    fModels.Add(fModel);
                }
            }
            byte[] reportBytes;
            using (var package = Utils.DownloadTravJournalier(fModels))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MyReport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }

        public async Task<IActionResult> DownloadAllInDate(DateClass date)
        {
            DateTime d00 = new();
            if (date.d0 != null)
            {
                d00 = DateTime.Parse(date.d0);
            }

            List<Fichiste> fichistes = await _context.Fichistes.Where(f => f.Date.Date == d00).ToListAsync();
            List<FichisteModel> fModels = new();

            foreach (var data in fichistes)
            {
                Employer emp = new();
                Famille fam = new();
                FichisteModel fModel = new();

                if (data.Categorie == "Famille")
                {
                    fam = await _adContext.Familles.Where(x => x.Familleid == Convert.ToInt32(data.Affiliationid)).FirstOrDefaultAsync();
                    fModel.FId = data.Fichisteid;
                    fModel.FName = fam.Nom.Trim() + " " + fam.Prenom.Trim();
                    fModel.FNomfichiste = data.Username.Trim();
                    fModel.FDateCreate = data.Date;
                    fModel.FDateNaissance = fam.Datenaissance;
                    emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();
                    Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                    fModel.FEtablissement = empr.Raisonsociale;
                    fModel.FFrequenceM = data.Frequencemois;
                    fModel.FFrequenceY = data.Frequenceannee;
                    fModel.FLieuNaissance = fam.Lieunaissance;
                    fModel.FNumero = data.Numjour;
                    fModel.FNumeroosiet = fam.Numeroosiet;
                    fModel.FParametre = data.Parametreid;
                    fModel.FCategorie = "Famille";
                    fModels.Add(fModel);
                }
                else
                {
                    emp = await _adContext.Employers.Where(x => x.Employerid == Convert.ToInt32(data.Affiliationid)).FirstAsync();
                    fModel.FId = data.Fichisteid;
                    fModel.FName = emp.Nom.Trim() + " " + emp.Prenom.Trim();
                    fModel.FNomfichiste = data.Username.Trim();
                    fModel.FDateCreate = data.Date;
                    fModel.FDateNaissance = emp.Datenaissance;
                    Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                    fModel.FEtablissement = empr.Raisonsociale;
                    fModel.FFrequenceM = data.Frequencemois;
                    fModel.FFrequenceY = data.Frequenceannee;
                    fModel.FLieuNaissance = emp.Lieunaissance;
                    fModel.FNumero = data.Numjour;
                    fModel.FNumeroosiet = emp.Numeroosiet;
                    fModel.FParametre = data.Parametreid;
                    fModel.FCategorie = "Travailleur";
                    fModels.Add(fModel);
                }
            }
            byte[] reportBytes;
            using (var package = Utils.DownloadTravInDate(fModels, d00))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MyReport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }

        public async Task<IActionResult> DownloadAllInTwoDate(DateClass date)
        {
            DateTime d01 = new();
            DateTime d02 = new();
            if (date.d1 != null && date.d2 != null)
            {
                d01 = DateTime.Parse(date.d1);
                d02 = DateTime.Parse(date.d2);
            }

            List<Fichiste> fichistes = await _context.Fichistes.Where(f => f.Date.Date >= d01 && f.Date.Date <= d02).ToListAsync();
            List<FichisteModel> fModels = new();

            foreach (var data in fichistes)
            {
                Employer emp = new();
                Famille fam = new();
                FichisteModel fModel = new();

                if (data.Categorie == "Famille")
                {
                    fam = await _adContext.Familles.Where(x => x.Familleid == Convert.ToInt32(data.Affiliationid)).FirstOrDefaultAsync();
                    fModel.FId = data.Fichisteid;
                    fModel.FName = fam.Nom.Trim() + " " + fam.Prenom.Trim();
                    fModel.FNomfichiste = data.Username.Trim();
                    fModel.FDateCreate = data.Date;
                    fModel.FDateNaissance = fam.Datenaissance;
                    emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();
                    Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                    fModel.FEtablissement = empr.Raisonsociale;
                    fModel.FFrequenceM = data.Frequencemois;
                    fModel.FFrequenceY = data.Frequenceannee;
                    fModel.FLieuNaissance = fam.Lieunaissance;
                    fModel.FNumero = data.Numjour;
                    fModel.FNumeroosiet = fam.Numeroosiet;
                    fModel.FParametre = data.Parametreid;
                    fModel.FCategorie = "Famille";
                    fModels.Add(fModel);
                }
                else
                {
                    emp = await _adContext.Employers.Where(x => x.Employerid == Convert.ToInt32(data.Affiliationid)).FirstAsync();
                    fModel.FId = data.Fichisteid;
                    fModel.FName = emp.Nom.Trim() + " " + emp.Prenom.Trim();
                    fModel.FNomfichiste = data.Username.Trim();
                    fModel.FDateCreate = data.Date;
                    fModel.FDateNaissance = emp.Datenaissance;
                    Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                    fModel.FEtablissement = empr.Raisonsociale;
                    fModel.FFrequenceM = data.Frequencemois;
                    fModel.FFrequenceY = data.Frequenceannee;
                    fModel.FLieuNaissance = emp.Lieunaissance;
                    fModel.FNumero = data.Numjour;
                    fModel.FNumeroosiet = emp.Numeroosiet;
                    fModel.FParametre = data.Parametreid;
                    fModel.FCategorie = "Travailleur";
                    fModels.Add(fModel);
                }
            }
            byte[] reportBytes;
            using (var package = Utils.DownloadTravInTwoDate(fModels, d01, d02))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MyReport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }

        public async Task<IActionResult> DownloadInTwoDateEmployer(DateClass date)
        {
            DateTime d01 = new();
            DateTime d02 = new();

            if (date.d1 != null && date.d2 != null)
            {
                d01 = DateTime.Parse(date.d1);
                d02 = DateTime.Parse(date.d2);
            }

            List<Fichiste> fichistes = await _context.Fichistes.Where(f => f.Date.Date >= d01 && f.Date.Date <= d02).ToListAsync();
            List<FichisteModel> fModels = new();

            foreach (var data in fichistes)
            {
                Employer emp = new();
                Famille fam = new();
                FichisteModel fModel = new();

                if (data.Categorie == "Travailleur")
                {

                    emp = await _adContext.Employers.Where(x => x.Employerid == Convert.ToInt32(data.Affiliationid)).FirstAsync();
                    fModel.FId = data.Fichisteid;
                    fModel.FName = emp.Nom.Trim() + " " + emp.Prenom.Trim();
                    fModel.FNomfichiste = data.Username.Trim();
                    fModel.FDateCreate = data.Date;
                    fModel.FDateNaissance = emp.Datenaissance;
                    Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                    fModel.FEtablissement = empr.Raisonsociale;
                    fModel.FFrequenceM = data.Frequencemois;
                    fModel.FFrequenceY = data.Frequenceannee;
                    fModel.FLieuNaissance = emp.Lieunaissance;
                    fModel.FNumero = data.Numjour;
                    fModel.FNumeroosiet = emp.Numeroosiet;
                    fModel.FParametre = data.Parametreid;
                    fModel.FCategorie = "Travailleur";
                    fModels.Add(fModel);
                }

            }
            byte[] reportBytes;
            using (var package = Utils.DownloadTravInTwoDate(fModels, d01, d02))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MyReport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }
        public async Task<IActionResult> DownloadInTwoDateEmployerParEtab(DateClass date)
        {
            DateTime d01 = new();
            DateTime d02 = new();
            string numEmployeur = date.numEmployeur;

            if (date.d1 != null && date.d2 != null)
            {
                d01 = DateTime.Parse(date.d1);
                d02 = DateTime.Parse(date.d2);
            }

            List<Fichiste> fichistes = await _context.Fichistes.Where(f => f.Date.Date >= d01 && f.Date.Date <= d02).ToListAsync();
            List<FichisteModel> fModels = new();

            foreach (var data in fichistes)
            {
                Employer emp = new();
                Famille fam = new();
                FichisteModel fModel = new();

                if (data.Categorie == "Travailleur")
                {
                    emp = await _adContext.Employers.Where(x => x.Employerid == Convert.ToInt32(data.Affiliationid)).FirstAsync();
                    if (emp.Numemployeur == numEmployeur)
                    {
                        fModel.FId = data.Fichisteid;
                        fModel.FName = emp.Nom.Trim() + " " + emp.Prenom.Trim();
                        fModel.FNomfichiste = data.Username.Trim();
                        fModel.FDateCreate = data.Date;
                        fModel.FDateNaissance = emp.Datenaissance;
                        Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                        fModel.FEtablissement = empr.Raisonsociale;
                        fModel.FFrequenceM = data.Frequencemois;
                        fModel.FFrequenceY = data.Frequenceannee;
                        fModel.FLieuNaissance = emp.Lieunaissance;
                        fModel.FNumero = data.Numjour;
                        fModel.FNumeroosiet = emp.Numeroosiet;
                        fModel.FParametre = data.Parametreid;
                        fModel.FCategorie = "Travailleur";
                        fModels.Add(fModel);
                    }
                }
            }
            byte[] reportBytes;
            using (var package = Utils.DownloadTravInTwoDate(fModels, d01, d02))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MyReport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }

        public async Task<IActionResult> DownloadInTwoDateAllParEtab(DateClass date)
        {
            DateTime d01 = new();
            DateTime d02 = new();
            string numEmployeur = date.numEmployeur;

            if (date.d1 != null && date.d2 != null)
            {
                d01 = DateTime.Parse(date.d1);
                d02 = DateTime.Parse(date.d2);
            }

            List<Fichiste> fichistes = await _context.Fichistes.Where(f => f.Date.Date >= d01 && f.Date.Date <= d02).ToListAsync();
            List<FichisteModel> fModels = new();

            foreach (var data in fichistes)
            {
                Employer emp = new();
                Famille fam = new();
                FichisteModel fModel = new();

                if (data.Categorie == "Travailleur")
                {
                    emp = await _adContext.Employers.Where(x => x.Employerid == Convert.ToInt32(data.Affiliationid)).FirstAsync();
                    if (emp.Numemployeur == numEmployeur)
                    {
                        fModel.FId = data.Fichisteid;
                        fModel.FName = emp.Nom.Trim() + " " + emp.Prenom.Trim();
                        fModel.FNomfichiste = data.Username.Trim();
                        fModel.FDateCreate = data.Date;
                        fModel.FDateNaissance = emp.Datenaissance;
                        Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                        fModel.FEtablissement = empr.Raisonsociale;
                        fModel.FFrequenceM = data.Frequencemois;
                        fModel.FFrequenceY = data.Frequenceannee;
                        fModel.FLieuNaissance = emp.Lieunaissance;
                        fModel.FNumero = data.Numjour;
                        fModel.FNumeroosiet = emp.Numeroosiet;
                        fModel.FParametre = data.Parametreid;
                        fModel.FCategorie = "Travailleur";
                        fModels.Add(fModel);
                    }
                }
                else if (data.Categorie == "Famille")
                {
                    fam = await _adContext.Familles.Where(x => x.Familleid == Convert.ToInt32(data.Affiliationid)).FirstOrDefaultAsync();
                    emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();
                    if (emp.Numemployeur == numEmployeur)
                    {
                        fModel.FId = data.Fichisteid;
                        fModel.FName = fam.Nom.Trim() + " " + fam.Prenom.Trim();
                        fModel.FNomfichiste = data.Username.Trim();
                        fModel.FDateCreate = data.Date;
                        fModel.FDateNaissance = fam.Datenaissance;
                        emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();
                        Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                        fModel.FEtablissement = empr.Raisonsociale;
                        fModel.FFrequenceM = data.Frequencemois;
                        fModel.FFrequenceY = data.Frequenceannee;
                        fModel.FLieuNaissance = fam.Lieunaissance;
                        fModel.FNumero = data.Numjour;
                        fModel.FNumeroosiet = fam.Numeroosiet;
                        fModel.FParametre = data.Parametreid;
                        fModel.FCategorie = "Famille";
                        fModels.Add(fModel);
                    }
                }
            }
            byte[] reportBytes;
            using (var package = Utils.DownloadTravInTwoDate(fModels, d01, d02))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MyReport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }

        public async Task<IActionResult> DownloadInDateAllParEtab(DateClass date)
        {
            DateTime d00 = new();
            if (date.d0 != null)
            {
                d00 = DateTime.Parse(date.d0);
            }

            string numEmployeur = date.numEmployeur;

            List<Fichiste> fichistes = await _context.Fichistes.Where(f => f.Date.Date == d00).ToListAsync();
            List<FichisteModel> fModels = new();

            foreach (var data in fichistes)
            {
                Employer emp = new();
                Famille fam = new();
                FichisteModel fModel = new();

                if (data.Categorie == "Travailleur")
                {
                    emp = await _adContext.Employers.Where(x => x.Employerid == Convert.ToInt32(data.Affiliationid)).FirstAsync();
                    if (emp.Numemployeur == numEmployeur)
                    {
                        fModel.FId = data.Fichisteid;
                        fModel.FName = emp.Nom.Trim() + " " + emp.Prenom.Trim();
                        fModel.FNomfichiste = data.Username.Trim();
                        fModel.FDateCreate = data.Date;
                        fModel.FDateNaissance = emp.Datenaissance;
                        Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                        fModel.FEtablissement = empr.Raisonsociale;
                        fModel.FFrequenceM = data.Frequencemois;
                        fModel.FFrequenceY = data.Frequenceannee;
                        fModel.FLieuNaissance = emp.Lieunaissance;
                        fModel.FNumero = data.Numjour;
                        fModel.FNumeroosiet = emp.Numeroosiet;
                        fModel.FParametre = data.Parametreid;
                        fModel.FCategorie = "Travailleur";
                        fModels.Add(fModel);
                    }
                }
                else if (data.Categorie == "Famille")
                {
                    fam = await _adContext.Familles.Where(x => x.Familleid == Convert.ToInt32(data.Affiliationid)).FirstOrDefaultAsync();
                    emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();
                    if (emp.Numemployeur == numEmployeur)
                    {
                        fModel.FId = data.Fichisteid;
                        fModel.FName = fam.Nom.Trim() + " " + fam.Prenom.Trim();
                        fModel.FNomfichiste = data.Username.Trim();
                        fModel.FDateCreate = data.Date;
                        fModel.FDateNaissance = fam.Datenaissance;
                        emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();
                        Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                        fModel.FEtablissement = empr.Raisonsociale;
                        fModel.FFrequenceM = data.Frequencemois;
                        fModel.FFrequenceY = data.Frequenceannee;
                        fModel.FLieuNaissance = fam.Lieunaissance;
                        fModel.FNumero = data.Numjour;
                        fModel.FNumeroosiet = fam.Numeroosiet;
                        fModel.FParametre = data.Parametreid;
                        fModel.FCategorie = "Famille";
                        fModels.Add(fModel);
                    }
                }
            }
            byte[] reportBytes;
            using (var package = Utils.DownloadTravInDate(fModels, d00))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MyReport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }
        public async Task<IActionResult> DownloadInTwoDateFamille(DateClass date)
        {
            DateTime d01 = new();
            DateTime d02 = new();

            if (date.d1 != null && date.d2 != null)
            {
                d01 = DateTime.Parse(date.d1);
                d02 = DateTime.Parse(date.d2);
            }

            List<Fichiste> fichistes = await _context.Fichistes.Where(f => f.Date.Date >= d01 && f.Date.Date <= d02).ToListAsync();
            List<FichisteModel> fModels = new();

            foreach (var data in fichistes)
            {
                Employer emp = new();
                Famille fam = new();
                FichisteModel fModel = new();

                if (data.Categorie == "Famille")
                {
                    fam = await _adContext.Familles.Where(x => x.Familleid == Convert.ToInt32(data.Affiliationid)).FirstOrDefaultAsync();
                    fModel.FId = data.Fichisteid;
                    fModel.FName = fam.Nom.Trim() + " " + fam.Prenom.Trim();
                    fModel.FNomfichiste = data.Username.Trim();
                    fModel.FDateCreate = data.Date;
                    fModel.FDateNaissance = fam.Datenaissance;
                    emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();
                    Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                    fModel.FEtablissement = empr.Raisonsociale;
                    fModel.FFrequenceM = data.Frequencemois;
                    fModel.FFrequenceY = data.Frequenceannee;
                    fModel.FLieuNaissance = fam.Lieunaissance;
                    fModel.FNumero = data.Numjour;
                    fModel.FNumeroosiet = fam.Numeroosiet;
                    fModel.FParametre = data.Parametreid;
                    fModel.FCategorie = "Famille";
                    fModels.Add(fModel);
                }

            }
            byte[] reportBytes;
            using (var package = Utils.DownloadTravInTwoDate(fModels, d01, d02))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MyReport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }

        public async Task<IActionResult> DownloadInTwoDateFamilleParEtab(DateClass date)
        {
            DateTime d01 = new();
            DateTime d02 = new();
            string numEmployeur = date.numEmployeur;

            if (date.d1 != null && date.d2 != null)
            {
                d01 = DateTime.Parse(date.d1);
                d02 = DateTime.Parse(date.d2);
            }

            List<Fichiste> fichistes = await _context.Fichistes.Where(f => f.Date.Date >= d01 && f.Date.Date <= d02).ToListAsync();
            List<FichisteModel> fModels = new();

            foreach (var data in fichistes)
            {
                Employer emp = new();
                Famille fam = new();
                FichisteModel fModel = new();

                if (data.Categorie == "Famille")
                {
                    fam = await _adContext.Familles.Where(x => x.Familleid == Convert.ToInt32(data.Affiliationid)).FirstOrDefaultAsync();
                    emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();
                    if (emp.Numemployeur == numEmployeur)
                    {
                        fModel.FId = data.Fichisteid;
                        fModel.FName = fam.Nom.Trim() + " " + fam.Prenom.Trim();
                        fModel.FNomfichiste = data.Username.Trim();
                        fModel.FDateCreate = data.Date;
                        fModel.FDateNaissance = fam.Datenaissance;
                        Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                        fModel.FEtablissement = empr.Raisonsociale;
                        fModel.FFrequenceM = data.Frequencemois;
                        fModel.FFrequenceY = data.Frequenceannee;
                        fModel.FLieuNaissance = fam.Lieunaissance;
                        fModel.FNumero = data.Numjour;
                        fModel.FNumeroosiet = fam.Numeroosiet;
                        fModel.FParametre = data.Parametreid;
                        fModel.FCategorie = "Famille";
                        fModels.Add(fModel);
                    }
                }

            }
            byte[] reportBytes;
            using (var package = Utils.DownloadTravInTwoDate(fModels, d01, d02))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MyReport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }

        public async Task<IActionResult> DownloadInDateEmployer(DateClass date)
        {
            DateTime d00 = new();
            if (date.d0 != null)
            {
                d00 = DateTime.Parse(date.d0);
            }

            List<Fichiste> fichistes = await _context.Fichistes.Where(f => f.Date.Date == d00).ToListAsync();
            List<FichisteModel> fModels = new();

            foreach (var data in fichistes)
            {
                Employer emp = new();
                Famille fam = new();
                FichisteModel fModel = new();

                if (data.Categorie == "Travailleur")
                {
                    emp = await _adContext.Employers.Where(x => x.Employerid == Convert.ToInt32(data.Affiliationid)).FirstAsync();
                    fModel.FId = data.Fichisteid;
                    fModel.FName = emp.Nom.Trim() + " " + emp.Prenom.Trim();
                    fModel.FNomfichiste = data.Username.Trim();
                    fModel.FDateCreate = data.Date;
                    fModel.FDateNaissance = emp.Datenaissance;
                    Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                    fModel.FEtablissement = empr.Raisonsociale;
                    fModel.FFrequenceM = data.Frequencemois;
                    fModel.FFrequenceY = data.Frequenceannee;
                    fModel.FLieuNaissance = emp.Lieunaissance;
                    fModel.FNumero = data.Numjour;
                    fModel.FNumeroosiet = emp.Numeroosiet;
                    fModel.FParametre = data.Parametreid;
                    fModel.FCategorie = "Travailleur";
                    fModels.Add(fModel);
                }
            }
            byte[] reportBytes;
            using (var package = Utils.DownloadTravInDate(fModels, d00))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MyReport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }

        public async Task<IActionResult> DownloadInDateEmployerParEtab(DateClass date)
        {
            DateTime d00 = new();
            if (date.d0 != null)
            {
                d00 = DateTime.Parse(date.d0);
            }

            string numEmployeur = date.numEmployeur;

            List<Fichiste> fichistes = await _context.Fichistes.Where(f => f.Date.Date == d00).ToListAsync();
            List<FichisteModel> fModels = new();

            foreach (var data in fichistes)
            {
                Employer emp = new();
                Famille fam = new();
                FichisteModel fModel = new();

                if (data.Categorie == "Travailleur")
                {
                    emp = await _adContext.Employers.Where(x => x.Employerid == Convert.ToInt32(data.Affiliationid)).FirstAsync();
                    if (emp.Numemployeur == numEmployeur)
                    {
                        fModel.FId = data.Fichisteid;
                        fModel.FName = emp.Nom.Trim() + " " + emp.Prenom.Trim();
                        fModel.FNomfichiste = data.Username.Trim();
                        fModel.FDateCreate = data.Date;
                        fModel.FDateNaissance = emp.Datenaissance;
                        Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                        fModel.FEtablissement = empr.Raisonsociale;
                        fModel.FFrequenceM = data.Frequencemois;
                        fModel.FFrequenceY = data.Frequenceannee;
                        fModel.FLieuNaissance = emp.Lieunaissance;
                        fModel.FNumero = data.Numjour;
                        fModel.FNumeroosiet = emp.Numeroosiet;
                        fModel.FParametre = data.Parametreid;
                        fModel.FCategorie = "Travailleur";
                        fModels.Add(fModel);
                    }
                }
            }
            byte[] reportBytes;
            using (var package = Utils.DownloadTravInDate(fModels, d00))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MyReport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }

        public async Task<IActionResult> DownloadInDateFamille(DateClass date)
        {
            DateTime d00 = new();
            if (date.d0 != null)
            {
                d00 = DateTime.Parse(date.d0);
            }

            List<Fichiste> fichistes = await _context.Fichistes.Where(f => f.Date.Date == d00).ToListAsync();
            List<FichisteModel> fModels = new();

            foreach (var data in fichistes)
            {
                Employer emp = new();
                Famille fam = new();
                FichisteModel fModel = new();

                if (data.Categorie == "Famille")
                {
                    fam = await _adContext.Familles.Where(x => x.Familleid == Convert.ToInt32(data.Affiliationid)).FirstOrDefaultAsync();
                    fModel.FId = data.Fichisteid;
                    fModel.FName = fam.Nom.Trim() + " " + fam.Prenom.Trim();
                    fModel.FNomfichiste = data.Username.Trim();
                    fModel.FDateCreate = data.Date;
                    fModel.FDateNaissance = fam.Datenaissance;
                    emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();
                    Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                    fModel.FEtablissement = empr.Raisonsociale;
                    fModel.FFrequenceM = data.Frequencemois;
                    fModel.FFrequenceY = data.Frequenceannee;
                    fModel.FLieuNaissance = fam.Lieunaissance;
                    fModel.FNumero = data.Numjour;
                    fModel.FNumeroosiet = fam.Numeroosiet;
                    fModel.FParametre = data.Parametreid;
                    fModel.FCategorie = "Famille";
                    fModels.Add(fModel);
                }
            }
            byte[] reportBytes;
            using (var package = Utils.DownloadTravInDate(fModels, d00))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MyReport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }

        public async Task<IActionResult> DownloadInDateFamilleParEtab(DateClass date)
        {
            DateTime d00 = new();
            if (date.d0 != null)
            {
                d00 = DateTime.Parse(date.d0);
            }

            List<Fichiste> fichistes = await _context.Fichistes.Where(f => f.Date.Date == d00).ToListAsync();
            List<FichisteModel> fModels = new();
            string numEmployeur = date.numEmployeur;

            foreach (var data in fichistes)
            {
                Employer emp = new();
                Famille fam = new();
                FichisteModel fModel = new();

                if (data.Categorie == "Famille")
                {
                    fam = await _adContext.Familles.Where(x => x.Familleid == Convert.ToInt32(data.Affiliationid)).FirstOrDefaultAsync();
                    emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();
                    if (emp.Numemployeur == numEmployeur)
                    {
                        fModel.FId = data.Fichisteid;
                        fModel.FName = fam.Nom.Trim() + " " + fam.Prenom.Trim();
                        fModel.FNomfichiste = data.Username.Trim();
                        fModel.FDateCreate = data.Date;
                        fModel.FDateNaissance = fam.Datenaissance;
                        Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                        fModel.FEtablissement = empr.Raisonsociale;
                        fModel.FFrequenceM = data.Frequencemois;
                        fModel.FFrequenceY = data.Frequenceannee;
                        fModel.FLieuNaissance = fam.Lieunaissance;
                        fModel.FNumero = data.Numjour;
                        fModel.FNumeroosiet = fam.Numeroosiet;
                        fModel.FParametre = data.Parametreid;
                        fModel.FCategorie = "Famille";
                        fModels.Add(fModel);
                    }
                }

            }
            byte[] reportBytes;
            using (var package = Utils.DownloadTravInDate(fModels, d00))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MyReport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }

        public class DateClass
        {
            public string? d0 { get; set; }
            public string? d1 { get; set; }
            public string? d2 { get; set; }
            public string? numEmployeur { get; set; }
            public string? categorie { get; set; }
        }

    }



}
