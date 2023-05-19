using Blazored.LocalStorage;
using DocumentFormat.OpenXml.Office2010.Excel;
using LYRA.Controllers.ComtrollerMedecin;
using LYRA.Models;
using LYRA.Models.Administration;
using LYRA.Models.RapportModele;
using LYRA.Pages.Fichiste;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

namespace LYRA.Controllers.ControllerParametre
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ParametreExportController : ControllerBase
    {
        private const string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        private readonly FICHISTEContext? _context;
        private readonly ADHESIONContext? _adContext;
        private readonly PARAMETREContext? _paramContext;
        private readonly UtilisateurContext? _userContext;
        private readonly CONSULTATIONContext? _medContext;
        Utilisateur utilisateur = new();
        List<Utilisateur> utilisateurs = new List<Utilisateur>();
        public ParametreExportController(FICHISTEContext context, ADHESIONContext adContext,
            PARAMETREContext paramContext, UtilisateurContext userContext, CONSULTATIONContext medContext)
        {
            _context = context;
            _adContext = adContext;
            _paramContext = paramContext;
            _userContext = userContext;
            _medContext = medContext;
        }

        public async Task<IActionResult> DownloadAllInDate(DateClass date)
        {
            DateTime d0 = new();
            if (date.d0 != null)
            {
                d0 = DateTime.Parse(date.d0);
            }
            List<RapportParamList> paramList = new List<RapportParamList>();
            List<Parametre> parametres = new List<Parametre>();
            parametres = await _paramContext.Parametres.Where(f => f.Datecreation.Date == d0.Date).ToListAsync();
            Fichiste fichiste = new();
            foreach (var data in parametres)
            {
                Employer emp = new();
                Famille fam = new();
                RapportParamList fModel = new();
                try
                {
                    fichiste = await _context.Fichistes.Where(f => f.Fichisteid == data.Fichisteid).FirstAsync();
                    if (fichiste.Categorie == "Famille")
                    {
                        fam = await _adContext.Familles.Where(x => x.Familleid == Convert.ToInt32(fichiste.Affiliationid)).FirstOrDefaultAsync();
                        emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();
                        Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                        fModel.Date = data.Datecreation;
                        fModel.NumJour = fichiste.Numjour;
                        fModel.NomComplet = fam.Nom.Trim() + " " + fam.Prenom.Trim();
                        fModel.Etablissement = empr.Raisonsociale;
                        fModel.Categorie = fichiste.Categorie;
                        fModel.NumOSIET = fam.Numeroosiet;
                        fModel.TD = data.Tad;
                        fModel.TG = data.Tag;
                        fModel.Temperature = Convert.ToDecimal(data.Temperature);
                        fModel.Poids = Convert.ToDecimal(data.Poids);
                        if (data.Medecinid != null)
                        {
                            med = new();
                            await GetMedecin(data.Medecinid);
                            if (med != null)
                                fModel.Medecin = med.NomMedecin + " " + med.PrenomMedecin;
                        }
                        fModel.Observation = data.Observation;
                        paramList.Add(fModel);
                    }
                    else
                    {
                        emp = await _adContext.Employers.Where(x => x.Employerid == Convert.ToInt32(fichiste.Affiliationid)).FirstAsync();
                        Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                        fModel.Date = data.Datecreation;
                        fModel.NumJour = fichiste.Numjour;
                        fModel.NomComplet = emp.Nom.Trim() + " " + emp.Prenom.Trim();
                        fModel.Etablissement = empr.Raisonsociale;
                        fModel.Categorie = fichiste.Categorie;
                        fModel.NumOSIET = emp.Numeroosiet;
                        fModel.TD = data.Tad;
                        fModel.TG = data.Tag;
                        fModel.Temperature = Convert.ToDecimal(data.Temperature);
                        fModel.Poids = Convert.ToDecimal(data.Poids);
                        if (data.Medecinid != null)
                        {
                            med = new();
                            await GetMedecin(data.Medecinid);
                            if (med != null)
                                fModel.Medecin = med.NomMedecin + " " + med.PrenomMedecin;
                        }
                        fModel.Observation = data.Observation;
                        paramList.Add(fModel);
                    }
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
            }
            byte[] reportBytes;
            using (var package = UtilsParam.DownloadTravInDate(paramList, d0))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MonRapport{DateTime.Now:dd-MM-yyyy}.xlsx");
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
            List<RapportParamList> paramList = new List<RapportParamList>();
            List<Parametre> parametres = new List<Parametre>();
            parametres = await _paramContext.Parametres.Where(f => f.Datecreation >= d01 && f.Datecreation <= d02).ToListAsync();
            Fichiste fichiste = new();
            foreach (var data in parametres)
            {
                Employer emp = new();
                Famille fam = new();
                RapportParamList fModel = new();
                try
                {
                    fichiste = await _context.Fichistes.Where(f => f.Fichisteid == data.Fichisteid).FirstAsync();
                    if (fichiste.Categorie == "Famille")
                    {
                        fam = await _adContext.Familles.Where(x => x.Familleid == Convert.ToInt32(fichiste.Affiliationid)).FirstOrDefaultAsync();
                        emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();
                        Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                        fModel.Date = data.Datecreation;
                        fModel.NumJour = fichiste.Numjour;
                        fModel.NomComplet = fam.Nom.Trim() + " " + fam.Prenom.Trim();
                        fModel.Etablissement = empr.Raisonsociale;
                        fModel.Categorie = fichiste.Categorie;
                        fModel.NumOSIET = fam.Numeroosiet;
                        fModel.TD = data.Tad;
                        fModel.TG = data.Tag;
                        fModel.Temperature = Convert.ToDecimal(data.Temperature);
                        fModel.Poids = Convert.ToDecimal(data.Poids);
                        if (data.Medecinid != null)
                        {
                            med = new();
                            await GetMedecin(data.Medecinid);
                            if (med != null)
                                fModel.Medecin = med.NomMedecin + " " + med.PrenomMedecin;
                        }
                        fModel.Observation = data.Observation;
                        paramList.Add(fModel);
                    }
                    else
                    {
                        emp = await _adContext.Employers.Where(x => x.Employerid == Convert.ToInt32(fichiste.Affiliationid)).FirstAsync();
                        Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                        fModel.Date = data.Datecreation;
                        fModel.NumJour = fichiste.Numjour;
                        fModel.NomComplet = emp.Nom.Trim() + " " + emp.Prenom.Trim();
                        fModel.Etablissement = empr.Raisonsociale;
                        fModel.Categorie = fichiste.Categorie;
                        fModel.NumOSIET = emp.Numeroosiet;
                        fModel.TD = data.Tad;
                        fModel.TG = data.Tag;
                        fModel.Temperature = Convert.ToDecimal(data.Temperature);
                        fModel.Poids = Convert.ToDecimal(data.Poids);
                        if (data.Medecinid != null)
                        {
                            med = new();
                            await GetMedecin(data.Medecinid);
                            if (med != null)
                                fModel.Medecin = med.NomMedecin + " " + med.PrenomMedecin;
                        }
                        fModel.Observation = data.Observation;
                        paramList.Add(fModel);
                    }
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
            }
            byte[] reportBytes;
            using (var package = UtilsParam.DownloadTravInTwoDate(paramList, d01, d02))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MonRapport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }
        public async Task<IActionResult> DownloadInDateAllParEtab(DateClass date)
        {
            DateTime d0 = new();
            if (date.d0 != null)
            {
                d0 = DateTime.Parse(date.d0);
            }
            string numEmployeur = date.numEmployeur;

            List<RapportParamList> paramList = new List<RapportParamList>();
            List<Parametre> parametres = new List<Parametre>();
            parametres = await _paramContext.Parametres.Where(f => f.Datecreation.Date == d0.Date).ToListAsync();

            Fichiste fichiste = new();

            foreach (var data in parametres)
            {
                Employer emp = new();
                Famille fam = new();

                RapportParamList fModel = new();
                try
                {
                    fichiste = await _context.Fichistes.Where(f => f.Fichisteid == data.Fichisteid).FirstAsync();

                    if (fichiste.Categorie == "Famille")
                    {
                        fam = await _adContext.Familles.Where(x => x.Familleid == Convert.ToInt32(fichiste.Affiliationid)).FirstOrDefaultAsync();
                        emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();

                        if (emp.Numemployeur == numEmployeur)
                        {
                            Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                            fModel.Date = data.Datecreation;
                            fModel.NumJour = fichiste.Numjour;
                            fModel.NomComplet = fam.Nom.Trim() + " " + fam.Prenom.Trim();
                            fModel.Etablissement = empr.Raisonsociale;
                            fModel.Categorie = fichiste.Categorie;
                            fModel.NumOSIET = fam.Numeroosiet;
                            fModel.TD = data.Tad;
                            fModel.TG = data.Tag;
                            fModel.Temperature = Convert.ToDecimal(data.Temperature);
                            fModel.Poids = Convert.ToDecimal(data.Poids);
                            if (data.Medecinid != null)
                            {
                                med = new();
                                await GetMedecin(data.Medecinid);
                                if (med != null)
                                    fModel.Medecin = med.NomMedecin + " " + med.PrenomMedecin;
                            }
                            fModel.Observation = data.Observation;
                            paramList.Add(fModel);
                        }
                    }
                    else
                    {
                        emp = await _adContext.Employers.Where(x => x.Employerid == Convert.ToInt32(fichiste.Affiliationid)).FirstAsync();
                        if (emp.Numemployeur == numEmployeur)
                        {
                            Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                            fModel.Date = data.Datecreation;
                            fModel.NumJour = fichiste.Numjour;
                            fModel.NomComplet = emp.Nom.Trim() + " " + emp.Prenom.Trim();
                            fModel.Etablissement = empr.Raisonsociale;
                            fModel.Categorie = fichiste.Categorie;
                            fModel.NumOSIET = emp.Numeroosiet;
                            fModel.TD = data.Tad;
                            fModel.TG = data.Tag;
                            fModel.Temperature = Convert.ToDecimal(data.Temperature);
                            fModel.Poids = Convert.ToDecimal(data.Poids);
                            if (data.Medecinid != null)
                            {
                                med = new();
                                await GetMedecin(data.Medecinid);
                                if (med != null)
                                    fModel.Medecin = med.NomMedecin + " " + med.PrenomMedecin;
                            }
                            fModel.Observation = data.Observation;
                            paramList.Add(fModel);
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
            }
            byte[] reportBytes;
            using (var package = UtilsParam.DownloadTravInDate(paramList, d0))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MonRapport{DateTime.Now:dd-MM-yyyy}.xlsx");
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

            List<RapportParamList> paramList = new List<RapportParamList>();
            List<Parametre> parametres = new List<Parametre>();
            parametres = await _paramContext.Parametres.Where(f => f.Datecreation >= d01 && f.Datecreation <= d02).ToListAsync();

            Fichiste fichiste = new();

            foreach (var data in parametres)
            {
                Employer emp = new();
                Famille fam = new();

                RapportParamList fModel = new();
                try
                {
                    fichiste = await _context.Fichistes.Where(f => f.Fichisteid == data.Fichisteid).FirstAsync();
                    if (fichiste.Categorie == "Famille")
                    {
                        fam = await _adContext.Familles.Where(x => x.Familleid == Convert.ToInt32(fichiste.Affiliationid)).FirstOrDefaultAsync();
                        emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();

                        if (emp.Numemployeur == numEmployeur)
                        {
                            Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                            fModel.Date = data.Datecreation;
                            fModel.NumJour = fichiste.Numjour;
                            fModel.NomComplet = fam.Nom.Trim() + " " + fam.Prenom.Trim();
                            fModel.Etablissement = empr.Raisonsociale;
                            fModel.Categorie = fichiste.Categorie;
                            fModel.NumOSIET = fam.Numeroosiet;
                            fModel.TD = data.Tad;
                            fModel.TG = data.Tag;
                            fModel.Temperature = Convert.ToDecimal(data.Temperature);
                            fModel.Poids = Convert.ToDecimal(data.Poids);
                            if (data.Medecinid != null)
                            {
                                med = new();
                                await GetMedecin(data.Medecinid);
                                if (med != null)
                                    fModel.Medecin = med.NomMedecin + " " + med.PrenomMedecin;
                            }
                            fModel.Observation = data.Observation;
                            paramList.Add(fModel);
                        }
                    }
                    else
                    {
                        emp = await _adContext.Employers.Where(x => x.Employerid == Convert.ToInt32(fichiste.Affiliationid)).FirstAsync();
                        if (emp.Numemployeur == numEmployeur)
                        {
                            Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                            fModel.Date = data.Datecreation;
                            fModel.NumJour = fichiste.Numjour;
                            fModel.NomComplet = emp.Nom.Trim() + " " + emp.Prenom.Trim();
                            fModel.Etablissement = empr.Raisonsociale;
                            fModel.Categorie = fichiste.Categorie;
                            fModel.NumOSIET = emp.Numeroosiet;
                            fModel.TD = data.Tad;
                            fModel.TG = data.Tag;
                            fModel.Temperature = Convert.ToDecimal(data.Temperature);
                            fModel.Poids = Convert.ToDecimal(data.Poids);
                            if (data.Medecinid != null)
                            {
                                med = new();
                                await GetMedecin(data.Medecinid);
                                if (med != null)
                                    fModel.Medecin = med.NomMedecin + " " + med.PrenomMedecin;
                            }
                            fModel.Observation = data.Observation;
                            paramList.Add(fModel);
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
            }
            byte[] reportBytes;
            using (var package = UtilsParam.DownloadTravInTwoDate(paramList, d01, d02))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MonRapport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }

        public async Task<IActionResult> DownloadInDateEmployer(DateClass date)
        {
            DateTime d0 = new();
            if (date.d0 != null)
            {
                d0 = DateTime.Parse(date.d0);
            }
            List<RapportParamList> paramList = new List<RapportParamList>();
            List<Parametre> parametres = new List<Parametre>();
            parametres = await _paramContext.Parametres.Where(f => f.Datecreation.Date == d0.Date).ToListAsync();
            Fichiste fichiste = new();
            foreach (var data in parametres)
            {
                Employer emp = new();
                Famille fam = new();
                RapportParamList fModel = new();
                try
                {
                    fichiste = await _context.Fichistes.Where(f => f.Fichisteid == data.Fichisteid).FirstAsync();
                    if (fichiste.Categorie == "Travailleur")
                    {
                        emp = await _adContext.Employers.Where(x => x.Employerid == Convert.ToInt32(fichiste.Affiliationid)).FirstAsync();
                        Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                        fModel.Date = data.Datecreation;
                        fModel.NumJour = fichiste.Numjour;
                        fModel.NomComplet = emp.Nom.Trim() + " " + emp.Prenom.Trim();
                        fModel.Etablissement = empr.Raisonsociale;
                        fModel.Categorie = fichiste.Categorie;
                        fModel.NumOSIET = emp.Numeroosiet;
                        fModel.TD = data.Tad;
                        fModel.TG = data.Tag;
                        fModel.Temperature = Convert.ToDecimal(data.Temperature);
                        fModel.Poids = Convert.ToDecimal(data.Poids);
                        if (data.Medecinid != null)
                        {
                            med = new();
                            await GetMedecin(data.Medecinid);
                            if (med != null)
                                fModel.Medecin = med.NomMedecin + " " + med.PrenomMedecin;
                        }
                        fModel.Observation = data.Observation;
                        paramList.Add(fModel);
                    }
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
            }
            byte[] reportBytes;
            using (var package = UtilsParam.DownloadTravInDate(paramList, d0))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MonRapport{DateTime.Now:dd-MM-yyyy}.xlsx");
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
            List<RapportParamList> paramList = new List<RapportParamList>();
            List<Parametre> parametres = new List<Parametre>();
            parametres = await _paramContext.Parametres.Where(f => f.Datecreation.Date >= d01.Date && f.Datecreation.Date <= d02.Date).ToListAsync();
            Fichiste fichiste = new();
            foreach (var data in parametres)
            {
                Employer emp = new();
                Famille fam = new();
                RapportParamList fModel = new();
                try
                {
                    fichiste = await _context.Fichistes.Where(f => f.Fichisteid == data.Fichisteid).FirstAsync();
                    if (fichiste.Categorie == "Travailleur")
                    {
                        emp = await _adContext.Employers.Where(x => x.Employerid == Convert.ToInt32(fichiste.Affiliationid)).FirstAsync();
                        Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                        fModel.Date = data.Datecreation;
                        fModel.NumJour = fichiste.Numjour;
                        fModel.NomComplet = emp.Nom.Trim() + " " + emp.Prenom.Trim();
                        fModel.Etablissement = empr.Raisonsociale;
                        fModel.Categorie = fichiste.Categorie;
                        fModel.NumOSIET = emp.Numeroosiet;
                        fModel.TD = data.Tad;
                        fModel.TG = data.Tag;
                        fModel.Temperature = Convert.ToDecimal(data.Temperature);
                        fModel.Poids = Convert.ToDecimal(data.Poids);
                        if (data.Medecinid != null)
                        {
                            med = new();
                            await GetMedecin(data.Medecinid);
                            if (med != null)
                                fModel.Medecin = med.NomMedecin + " " + med.PrenomMedecin;
                        }
                        fModel.Observation = data.Observation;
                        paramList.Add(fModel);
                    }
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
            }
            byte[] reportBytes;
            using (var package = UtilsParam.DownloadTravInTwoDate(paramList, d01, d02))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MonRapport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }
        public async Task<IActionResult> DownloadInDateEmployerParEtab(DateClass date)
        {
            DateTime d0 = new();
            if (date.d0 != null)
            {
                d0 = DateTime.Parse(date.d0);
            }
            string numEmployeur = date.numEmployeur;

            List<RapportParamList> paramList = new List<RapportParamList>();
            List<Parametre> parametres = new List<Parametre>();
            parametres = await _paramContext.Parametres.Where(f => f.Datecreation.Date == d0.Date).ToListAsync();

            Fichiste fichiste = new();

            foreach (var data in parametres)
            {
                Employer emp = new();
                Famille fam = new();

                RapportParamList fModel = new();
                try
                {
                    fichiste = await _context.Fichistes.Where(f => f.Fichisteid == data.Fichisteid).FirstAsync();

                    if (fichiste.Categorie == "Travailleur")
                    {
                        emp = await _adContext.Employers.Where(x => x.Employerid == Convert.ToInt32(fichiste.Affiliationid)).FirstAsync();
                        if (emp.Numemployeur == numEmployeur)
                        {
                            Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                            fModel.Date = data.Datecreation;
                            fModel.NumJour = fichiste.Numjour;
                            fModel.NomComplet = emp.Nom.Trim() + " " + emp.Prenom.Trim();
                            fModel.Etablissement = empr.Raisonsociale;
                            fModel.Categorie = fichiste.Categorie;
                            fModel.NumOSIET = emp.Numeroosiet;
                            fModel.TD = data.Tad;
                            fModel.TG = data.Tag;
                            fModel.Temperature = Convert.ToDecimal(data.Temperature);
                            fModel.Poids = Convert.ToDecimal(data.Poids);
                            if (data.Medecinid != null)
                            {
                                med = new();
                                await GetMedecin(data.Medecinid);
                                if (med != null)
                                    fModel.Medecin = med.NomMedecin + " " + med.PrenomMedecin;
                            }
                            fModel.Observation = data.Observation;
                            paramList.Add(fModel);
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
            }
            byte[] reportBytes;
            using (var package = UtilsParam.DownloadTravInDate(paramList, d0))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MonRapport{DateTime.Now:dd-MM-yyyy}.xlsx");
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

            List<RapportParamList> paramList = new List<RapportParamList>();
            List<Parametre> parametres = new List<Parametre>();
            parametres = await _paramContext.Parametres.Where(f => f.Datecreation >= d01 && f.Datecreation <= d02).ToListAsync();

            Fichiste fichiste = new();

            foreach (var data in parametres)
            {
                Employer emp = new();
                Famille fam = new();

                RapportParamList fModel = new();
                try
                {
                    fichiste = await _context.Fichistes.Where(f => f.Fichisteid == data.Fichisteid).FirstAsync();
                    if (fichiste.Categorie == "Travailleur")
                    {
                        emp = await _adContext.Employers.Where(x => x.Employerid == Convert.ToInt32(fichiste.Affiliationid)).FirstAsync();
                        if (emp.Numemployeur == numEmployeur)
                        {
                            Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                            fModel.Date = data.Datecreation;
                            fModel.NumJour = fichiste.Numjour;
                            fModel.NomComplet = emp.Nom.Trim() + " " + emp.Prenom.Trim();
                            fModel.Etablissement = empr.Raisonsociale;
                            fModel.Categorie = fichiste.Categorie;
                            fModel.NumOSIET = emp.Numeroosiet;
                            fModel.TD = data.Tad;
                            fModel.TG = data.Tag;
                            fModel.Temperature = Convert.ToDecimal(data.Temperature);
                            fModel.Poids = Convert.ToDecimal(data.Poids);
                            if (data.Medecinid != null)
                            {
                                med = new();
                                await GetMedecin(data.Medecinid);
                                if (med != null)
                                    fModel.Medecin = med.NomMedecin + " " + med.PrenomMedecin;
                            }
                            fModel.Observation = data.Observation;
                            paramList.Add(fModel);
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
            }
            byte[] reportBytes;
            using (var package = UtilsParam.DownloadTravInTwoDate(paramList, d01, d02))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MonRapport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }

        public async Task<IActionResult> DownloadInDateFamille(DateClass date)
        {
            DateTime d0 = new();
            if (date.d0 != null)
            {
                d0 = DateTime.Parse(date.d0);
            }
            List<RapportParamList> paramList = new List<RapportParamList>();
            List<Parametre> parametres = new List<Parametre>();
            parametres = await _paramContext.Parametres.Where(f => f.Datecreation.Date == d0.Date).ToListAsync();
            Fichiste fichiste = new();
            foreach (var data in parametres)
            {
                Employer emp = new();
                Famille fam = new();
                RapportParamList fModel = new();
                try
                {
                    fichiste = await _context.Fichistes.Where(f => f.Fichisteid == data.Fichisteid).FirstAsync();
                    if (fichiste.Categorie == "Famille")
                    {
                        fam = await _adContext.Familles.Where(x => x.Familleid == Convert.ToInt32(fichiste.Affiliationid)).FirstOrDefaultAsync();
                        emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();
                        Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                        fModel.Date = data.Datecreation;
                        fModel.NumJour = fichiste.Numjour;
                        fModel.NomComplet = fam.Nom.Trim() + " " + fam.Prenom.Trim();
                        fModel.Etablissement = empr.Raisonsociale;
                        fModel.Categorie = fichiste.Categorie;
                        fModel.NumOSIET = fam.Numeroosiet;
                        fModel.TD = data.Tad;
                        fModel.TG = data.Tag;
                        fModel.Temperature = Convert.ToDecimal(data.Temperature);
                        fModel.Poids = Convert.ToDecimal(data.Poids);
                        if (data.Medecinid != null)
                        {
                            med = new();
                            await GetMedecin(data.Medecinid);
                            if (med != null)
                                fModel.Medecin = med.NomMedecin + " " + med.PrenomMedecin;
                        }
                        fModel.Observation = data.Observation;
                        paramList.Add(fModel);
                    }
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
            }
            byte[] reportBytes;
            using (var package = UtilsParam.DownloadTravInDate(paramList, d0))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MonRapport{DateTime.Now:dd-MM-yyyy}.xlsx");
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
            List<RapportParamList> paramList = new List<RapportParamList>();
            List<Parametre> parametres = new List<Parametre>();
            parametres = await _paramContext.Parametres.Where(f => f.Datecreation.Date >= d01.Date && f.Datecreation.Date <= d02.Date).ToListAsync();
            Fichiste fichiste = new();
            foreach (var data in parametres)
            {
                Employer emp = new();
                Famille fam = new();
                RapportParamList fModel = new();
                try
                {
                    fichiste = await _context.Fichistes.Where(f => f.Fichisteid == data.Fichisteid).FirstAsync();
                    if (fichiste.Categorie == "Famille")
                    {
                        fam = await _adContext.Familles.Where(x => x.Familleid == Convert.ToInt32(fichiste.Affiliationid)).FirstOrDefaultAsync();
                        emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();
                        Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                        fModel.Date = data.Datecreation;
                        fModel.NumJour = fichiste.Numjour;
                        fModel.NomComplet = fam.Nom.Trim() + " " + fam.Prenom.Trim();
                        fModel.Etablissement = empr.Raisonsociale;
                        fModel.Categorie = fichiste.Categorie;
                        fModel.NumOSIET = fam.Numeroosiet;
                        fModel.TD = data.Tad;
                        fModel.TG = data.Tag;
                        fModel.Temperature = Convert.ToDecimal(data.Temperature);
                        fModel.Poids = Convert.ToDecimal(data.Poids);
                        if (data.Medecinid != null)
                        {
                            med = new();
                            await GetMedecin(data.Medecinid);
                            if (med != null)
                                fModel.Medecin = med.NomMedecin + " " + med.PrenomMedecin;
                        }
                        fModel.Observation = data.Observation;
                        paramList.Add(fModel);
                    }
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
            }
            byte[] reportBytes;
            using (var package = UtilsParam.DownloadTravInTwoDate(paramList, d01, d02))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MonRapport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }
        public async Task<IActionResult> DownloadInDateFamilleParEtab(DateClass date)
        {
            DateTime d0 = new();
            if (date.d0 != null)
            {
                d0 = DateTime.Parse(date.d0);
            }
            string numEmployeur = date.numEmployeur;

            List<RapportParamList> paramList = new List<RapportParamList>();
            List<Parametre> parametres = new List<Parametre>();
            parametres = await _paramContext.Parametres.Where(f => f.Datecreation.Date == d0.Date).ToListAsync();

            Fichiste fichiste = new();

            foreach (var data in parametres)
            {
                Employer emp = new();
                Famille fam = new();

                RapportParamList fModel = new();
                try
                {
                    if (fichiste.Categorie == "Famille")
                    {
                        fam = await _adContext.Familles.Where(x => x.Familleid == Convert.ToInt32(fichiste.Affiliationid)).FirstOrDefaultAsync();
                        emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();

                        if (emp.Numemployeur == numEmployeur)
                        {
                            Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                            fModel.Date = data.Datecreation;
                            fModel.NumJour = fichiste.Numjour;
                            fModel.NomComplet = fam.Nom.Trim() + " " + fam.Prenom.Trim();
                            fModel.Etablissement = empr.Raisonsociale;
                            fModel.Categorie = fichiste.Categorie;
                            fModel.NumOSIET = fam.Numeroosiet;
                            fModel.TD = data.Tad;
                            fModel.TG = data.Tag;
                            fModel.Temperature = Convert.ToDecimal(data.Temperature);
                            fModel.Poids = Convert.ToDecimal(data.Poids);
                            if (data.Medecinid != null)
                            {
                                med = new();
                                await GetMedecin(data.Medecinid);
                                if (med != null)
                                    fModel.Medecin = med.NomMedecin + " " + med.PrenomMedecin;
                            }
                            fModel.Observation = data.Observation;
                            paramList.Add(fModel);
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
            }
            byte[] reportBytes;
            using (var package = UtilsParam.DownloadTravInDate(paramList, d0))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MonRapport{DateTime.Now:dd-MM-yyyy}.xlsx");
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

            List<RapportParamList> paramList = new List<RapportParamList>();
            List<Parametre> parametres = new List<Parametre>();
            parametres = await _paramContext.Parametres.Where(f => f.Datecreation >= d01 && f.Datecreation <= d02).ToListAsync();

            Fichiste fichiste = new();

            foreach (var data in parametres)
            {
                Employer emp = new();
                Famille fam = new();

                RapportParamList fModel = new();
                try
                {
                    fichiste = await _context.Fichistes.Where(f => f.Fichisteid == data.Fichisteid).FirstAsync();
                    if (fichiste.Categorie == "Famille")
                    {
                        fam = await _adContext.Familles.Where(x => x.Familleid == Convert.ToInt32(fichiste.Affiliationid)).FirstOrDefaultAsync();
                        emp = await _adContext.Employers.Where(x => x.Numeroosiet == fam.Numeroosiet).FirstOrDefaultAsync();

                        if (emp.Numemployeur == numEmployeur)
                        {
                            Employeur empr = await _adContext.Employeurs.Where(x => x.Numemployeur == emp.Numemployeur).FirstOrDefaultAsync();
                            fModel.Date = data.Datecreation;
                            fModel.NumJour = fichiste.Numjour;
                            fModel.NomComplet = fam.Nom.Trim() + " " + fam.Prenom.Trim();
                            fModel.Etablissement = empr.Raisonsociale;
                            fModel.Categorie = fichiste.Categorie;
                            fModel.NumOSIET = fam.Numeroosiet;
                            fModel.TD = data.Tad;
                            fModel.TG = data.Tag;
                            fModel.Temperature = Convert.ToDecimal(data.Temperature);
                            fModel.Poids = Convert.ToDecimal(data.Poids);
                            if (data.Medecinid != null)
                            {
                                med = new();
                                await GetMedecin(data.Medecinid);
                                if (med != null)
                                    fModel.Medecin = med.NomMedecin + " " + med.PrenomMedecin;
                            }
                            fModel.Observation = data.Observation;
                            paramList.Add(fModel);
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
            }
            byte[] reportBytes;
            using (var package = UtilsParam.DownloadTravInTwoDate(paramList, d01, d02))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"MonRapport{DateTime.Now:dd-MM-yyyy}.xlsx");
        }

        public class DateClass
        {
            public string? d0 { get; set; }
            public string? d1 { get; set; }
            public string? d2 { get; set; }
            public string? numEmployeur { get; set; }
            public string? categorie { get; set; }
        }
        Medecin med = new();
        public async Task GetMedecin(long? idMedecin) => med = await _medContext.Medecins.Where(m => m.Medecinid == idMedecin).FirstOrDefaultAsync();
    }

}
