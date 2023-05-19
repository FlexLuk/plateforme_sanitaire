using LYRA.Models.Examens;
using LYRA.Models.Maternites;
using LYRA.Pages.Dentiste;
using LYRA.Pages.EchoEcg;
using Microsoft.EntityFrameworkCore;

namespace LYRA.Controllers.ControllerExamens
{
    public class ExamenService : IExamenService
    {
        readonly EXAMENSContext context;

        public ExamenService(EXAMENSContext _context)
        {
            context = _context;
        }

        public async Task<bool> UpdateEchoEcg(EchoEcg echoEcg)
        {
            EchoEcg ec = await context.EchoEcgs.Where(item => item.EchoEcgId == echoEcg.EchoEcgId).FirstOrDefaultAsync();
            ec = echoEcg;
            context.Entry(ec).State = EntityState.Modified;
            int i = await context.SaveChangesAsync();
            return i > 0;
        }
        public async Task<bool> CreateEchoEcg(EchoEcg echoEcg)
        {
            await context.EchoEcgs.AddAsync(echoEcg);
            int i = context.SaveChanges();
            return i > 0;
        }

        public async Task<List<EchoEcg>> GetAllEchoEcgByFichiste(long idFichiste)
        {
            List<EchoEcg> echoecgs = new List<EchoEcg>();
            echoecgs = await context.EchoEcgs.Where(d => d.Fichisteid == idFichiste).ToListAsync();
            return echoecgs;
        }

        public async Task<List<EchoEcg>> GetAllEchoEcgNonTerminer()
        {
            List<EchoEcg> echoecgs = new List<EchoEcg>();
            echoecgs = await context.EchoEcgs.Where(d => d.Statut != "Terminer").ToListAsync();
            return echoecgs;
        }

        public async Task<List<EchoEcg>> GetAllEchoEcg()
        {
            List<EchoEcg> echoecgs = new List<EchoEcg>();
            echoecgs = await context.EchoEcgs.ToListAsync();
            return echoecgs;
        }

        public async Task<List<Laboratoire>> GetAllLaboratoireByFichiste(long idFichiste)
        {
            List<Laboratoire> labs = new List<Laboratoire>();
            labs = await context.Laboratoires.Where(lab => lab.FichisteId == idFichiste).ToListAsync();
            return labs;
        }

        public async Task<Laboratoire?> GetLaboratoireByFichiste(long idFichiste)
        {
            Laboratoire lab = new Laboratoire();
            try
            {
                lab = await context.Laboratoires.Where(lab => lab.FichisteId == idFichiste).FirstAsync();
                return lab;
            }
            catch (InvalidOperationException)
            {
                return null;
            }

        }
        public async Task<Laboratoire?> GetLaboratoireByCpnId(long idCpn)
        {
            Laboratoire lab = new Laboratoire();
            try
            {
                lab = await context.Laboratoires.Where(lab => lab.CpnId == idCpn).FirstAsync();
                return lab;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public async Task<Laboratoire?> GetLaboratoireByFichisteMaternite(long idFichiste)
        {
            Laboratoire lab = new Laboratoire();
            try
            {
                lab = await context.Laboratoires.Where(lab => lab.FichisteId == idFichiste).FirstOrDefaultAsync();
            }
            catch (InvalidOperationException)
            {
                lab = new();
            }
            return lab;
        }

        public Task<List<Laboratoire>> GetAllLaboratoireNonTerminer()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateLaboratoire(Laboratoire labo)
        {
            await context.Laboratoires.AddAsync(labo);
            int i = context.SaveChanges();
            return i > 0;
        }

        public async Task<bool> UpdateLaboratoire(Laboratoire labo)
        {
            try
            {
                Laboratoire lab = await context.Laboratoires.Where(item => item.LaboratoireId == labo.LaboratoireId).FirstAsync();
                lab = labo;
                context.Entry(lab).State = EntityState.Modified;
                int i = context.SaveChanges();
                return i > 0;
            }
            catch (InvalidOperationException ex)
            {
                return false;
            }

        }

        public async Task<AvoirLaboratoire> GetAvoirLaboratoireByFichiste(long idFichiste)
        {
            AvoirLaboratoire avLabo = new();
            try
            {
                avLabo = await context.AvoirLaboratoires.Where(av => av.FichisteId == idFichiste && av.Statut == "En cours").FirstAsync();
            }
            catch (InvalidOperationException)
            {
                avLabo = new();
            }
            return avLabo;
        }

        public async Task<bool> CreateAvoirLaboratoire(AvoirLaboratoire labo)
        {
            await context.AvoirLaboratoires.AddAsync(labo);
            int i = context.SaveChanges();
            return i > 0;
        }

        public async Task<bool> CheckAvoirLaboByFichiste(long idFichiste)
        {
            AvoirLaboratoire avLabo = new();
            try
            {
                avLabo = await context.AvoirLaboratoires.Where(av => av.FichisteId == idFichiste).FirstAsync();
                return true;
            }
            catch (InvalidOperationException ex)
            {
                return false;
            }
        }

        public async Task<List<AvoirLaboratoire>> GetAllAvoirLaboratoireEncours()
        {
            List<AvoirLaboratoire> avLabo = new List<AvoirLaboratoire>();
            avLabo = await context.AvoirLaboratoires.Where(av => av.Statut == "En cours" && av.Date.Date >= DateTime.Now.Date).ToListAsync();
            return avLabo;
        }

        public async Task<List<AvoirLaboratoire>> GetAllAvoirLaboratoire()
        {
            List<AvoirLaboratoire> avLabo = new List<AvoirLaboratoire>();
            avLabo = await context.AvoirLaboratoires.ToListAsync();
            return avLabo;
        }

        public async Task<List<AvoirLaboratoire>> GetAllAvoirLaboratoireNonTerminer()
        {
            List<AvoirLaboratoire> avLabo = new List<AvoirLaboratoire>();
            avLabo = await context.AvoirLaboratoires.Where(av => (av.Statut == "En cours" || av.Statut == "En attente") && av.Date.Date < DateTime.Now.Date).ToListAsync();
            return avLabo;
        }

        public async Task<bool> UpdateAvoirLaboratoire(AvoirLaboratoire avLabo)
        {
            try
            {
                AvoirLaboratoire lab = await context.AvoirLaboratoires.Where(item => item.AvoirLaboratoireId == avLabo.AvoirLaboratoireId).FirstAsync();
                lab = avLabo;
                context.Entry(lab).State = EntityState.Modified;
                int i = context.SaveChanges();
                return i > 0;
            }
            catch (InvalidOperationException ex)
            {
                return false;
            }
        }

        public async Task<EchoEcg> GetEchoEcgByFichiste(long idFichiste)
        {
            EchoEcg echoEcg = new();
            try
            {
                echoEcg = await context.EchoEcgs.Where(ec => ec.Fichisteid == idFichiste).FirstAsync();
                return echoEcg;
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        public async Task<Laboratoire> CreateLaboratoireLabo(Laboratoire labo)
        {
            Laboratoire laboratoire = new();
            await context.Laboratoires.AddAsync(labo);
            context.SaveChanges();
            laboratoire = labo;
            return laboratoire;
        }

    }
}
