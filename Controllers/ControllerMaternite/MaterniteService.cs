using LYRA.Models;
using LYRA.Models.Examens;
using LYRA.Models.Maternites;
using LYRA.Models.Pharmacie;
using LYRA.Pages.EchoEcg;
using LYRA.Pages.Fichiste;
using LYRA.Pages.Maternite;
using LYRA.Pages.Pharmacie;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Migrations;
using System.Drawing;

namespace LYRA.Controllers.ControllerMaternite
{
    public class MaterniteService : IMaterniteService
    {
        readonly MATERNITEContext context;

        public MaterniteService(MATERNITEContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreateAvoirEcho(AvoirEcho avoirEcho)
        {
            context.AvoirEchoes.Add(avoirEcho);
            int i = await context.SaveChangesAsync();
            return i > 0;
        }
        public async Task<bool> CreateEchoMaterniteBool(EchoMaternite echoMaternite)
        {
            context.EchoMaternites.Add(echoMaternite);
            int i = await context.SaveChangesAsync();
            return i > 0;
        }
        public async Task<bool> CreateAvoirMaternite(AvoirMaternite avoirMaternite)
        {
            await context.AvoirMaternites.AddAsync(avoirMaternite);
            int i = context.SaveChanges();
            return i > 0;
        }
        public async Task<bool> CreateBebe(Bebe bebe)
        {
            await context.Bebes.AddAsync(bebe);
            int i = context.SaveChanges();
            return i > 0;
        }
        public async Task<bool> CreateCPN(Cpn cpn)
        {
            await context.Cpns.AddAsync(cpn);
            int i = context.SaveChanges();
            return i > 0;
        }
        public async Task<bool> CreateMaternite(Maternite maternite)
        {
            await context.Maternites.AddAsync(maternite);
            int i = context.SaveChanges();
            return i > 0;
        }
        public async Task<bool> CreateMere(Mere mere)
        {
            await context.Meres.AddAsync(mere);
            int i = context.SaveChanges();
            return i > 0;
        }
        public async Task<bool> CreateVaccinBebe(VaccinEnfant vaccEfant)
        {
            await context.VaccinEnfants.AddAsync(vaccEfant);
            int i = context.SaveChanges();
            return i > 0;
        }
        public async Task<VaccinMere> CreateVaccinMere(VaccinMere vaccMere)
        {
            await context.VaccinMeres.AddAsync(vaccMere);
            int i = context.SaveChanges();
            return vaccMere;
        }
        public async Task<List<AvoirMaternite>> GetAllAvoirMaternite()
        {
            List<AvoirMaternite> avMaternites = await context.AvoirMaternites.Where(avm => avm.Etat != "Terminer" && avm.Date.Date == DateTime.Now.Date).ToListAsync();
            return avMaternites;
        }

        public async Task<List<AvoirMaternite>> GetAllAvoirMaterniteListe()
        {
            List<AvoirMaternite> avMaternites = await context.AvoirMaternites.ToListAsync();
            return avMaternites;
        }

        public async Task<List<AvoirMaternite>> GetAllAvoirMaterniteNonTerminer()
        {
            List<AvoirMaternite> avMaterniteNonTerminer = new List<AvoirMaternite>();
            //avMaterniteNonTerminer = await context.AvoirMaternites.Where(avm => avm.Etat != "Terminer" && avm.Date.Date < DateTime.Now.Date).ToListAsync();
            avMaterniteNonTerminer = await context.AvoirMaternites.Where(avm => avm.Etat != "Terminer" && avm.Date.Date < DateTime.Now.Date).ToListAsync();
            return avMaterniteNonTerminer;
        }

        public async Task<List<Cpn>> GetAllCpnByFichiste(long fichisteID)
        {
            List<Cpn> cpns = await context.Cpns.ToListAsync();
            return cpns;
        }
        public async Task<AvoirEcho> GetAvoirEchoByCpn(long cpnID)
        {
            AvoirEcho avEcho = new();
            try
            {
                avEcho = await context.AvoirEchoes.Where(p => p.CpnId == cpnID).FirstAsync();
                return avEcho;
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }
        public async Task<Bebe> GetBebeByCpn(long cpnID)
        {
            Bebe bb = new();
            try
            {
                bb = await context.Bebes.Where(p => p.CpnId == cpnID).FirstAsync();
                return bb;
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }
        public async Task<Maternite> GetMaterniteByFichiste(long fichisteID)
        {
            Maternite mr = new();
            try
            {
                mr = await context.Maternites.Where(p => p.FichisteId == fichisteID).FirstAsync();
                return mr;
            }
            catch (InvalidOperationException ex)
            {
                mr = null;
                return mr;
            }
        }
        public async Task<Mere> GetMereByCpn(long cpnID)
        {
            Mere mr = new();
            try
            {
                mr = await context.Meres.Where(p => p.CpnId == cpnID).FirstAsync();
                return mr;
            }
            catch (InvalidOperationException)
            {
                return mr;
            }
        }

        public async Task<bool> UpdateAvoirMaternite(AvoirMaternite avoirMaternite)
        {
            AvoirMaternite av = await context.AvoirMaternites.FindAsync(avoirMaternite.AvoirMaterniteId);
            av = avoirMaternite;
            context.Entry(av).State = EntityState.Modified;
            int i = context.SaveChanges();
            return i > 0;
        }

        public async Task<bool> UpdateMaternite(Maternite maternite)
        {
            Maternite av = context.Maternites.Find(maternite.MaterniteId);
            av = maternite;
            context.Entry(av).State = EntityState.Modified;
            int i = await context.SaveChangesAsync();
            return i > 0;
        }

        public async Task<bool> CheckMaterniteExist(long idFichiste)
        {
            try
            {
                Maternite mat = await context.Maternites.Where(m => m.FichisteId == idFichiste).FirstAsync();
                if (mat != null && mat.FichisteId > 0)
                    return true;
                else
                    return false;
            }
            catch (InvalidOperationException ex)
            {
                return false;
            }
        }

        public async Task<bool> ChangeValidationGrossesse(int value, long idAvoirMaternite)
        {
            AvoirMaternite avMa = new();
            try
            {
                avMa = await context.AvoirMaternites.Where(av => av.AvoirMaterniteId == idAvoirMaternite).FirstAsync();
                avMa.Validation = value;
                context.Entry(avMa).State = EntityState.Modified;
                int i = await context.SaveChangesAsync();
                return i > 0;
            }
            catch (InvalidOperationException ex)
            {
                return false;
            }
        }

        public async Task<AvoirMaternite> GetAvoirMaternite(long idFichiste)
        {
            try
            {
                return await context.AvoirMaternites.Where(a => a.FichisteId == idFichiste).FirstAsync();
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        public async Task<Maternite> CheckMaterniteExistByEmployer(long idEmployer)
        {
            try
            {
                Maternite mat = new();
                mat = await context.Maternites.Where(m => m.Categorie.Trim() == "Travailleur" && m.Affiliationid.Value == idEmployer).OrderBy(m => m.MaterniteId).LastAsync();
                return mat;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Maternite> CheckMaterniteExistByFamille(long idFamille)
        {
            try
            {
                Maternite mat = await context.Maternites.Where(m => m.Categorie.Trim() == "Famille" && m.Affiliationid == idFamille).LastAsync();
                if (mat != null && mat.FichisteId > 0)
                    return mat;
                else
                    return null;
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        public async Task<Maternite?> CreateMaternite2(Maternite maternite)
        {
            Maternite mat = maternite;
            context.Maternites.Add(mat);
            int i = await context.SaveChangesAsync();
            if (i > 0) return mat;
            else return null;
        }

        public async Task<Maternite> GetMaterniteByID(long idMaternite)
        {
            try
            {
                Maternite mat = new();
                mat = await context.Maternites.Where(m => m.MaterniteId == idMaternite).FirstAsync();
                return mat;
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        public async Task<List<Cpn>> GetAllCpnByMaternite(long idMaternite)
        {
            List<Cpn> cpns = new List<Cpn>();
            cpns = await context.Cpns.Where(c => c.MaterniteId == idMaternite).ToListAsync();
            return cpns;
        }

        public async Task<Cpn?> GetCpnByID(long idCpn)
        {
            Cpn cpn = new();
            try
            {
                cpn = await context.Cpns.Where(c => c.CpnId == idCpn).FirstAsync();
                return cpn;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<bool> UpdateAvoirEcho(AvoirEcho avoirEcho)
        {
            int i = 0;
            AvoirEcho avE = new();
            try
            {
                avE = context.AvoirEchoes.Where(av => av.AvoirEchoId == avoirEcho.AvoirEchoId).First();
                avE.EchoId = avoirEcho.EchoId;
                context.Update(avE);
                i = await context.SaveChangesAsync();
            }
            catch (InvalidOperationException ex)
            {
                context.AvoirEchoes.Add(avoirEcho);
                i = await context.SaveChangesAsync();
            }
            return i > 0;
        }

        public async Task<List<EchoMaternite>> GetEchoMaterniteNonTerminer()
        {
            List<EchoMaternite> echoMaterniteNonTerminer = new List<EchoMaternite>();
            echoMaterniteNonTerminer = await context.EchoMaternites.Where(avm => avm.Statut != "Terminer").ToListAsync();
            return echoMaterniteNonTerminer;
        }

        public async Task<EchoMaternite> CreateEchoMaternite(EchoMaternite echo)
        {
            EchoMaternite echoMaternite = new();
            await context.AddAsync(echo);
            context.SaveChanges();
            echoMaternite = echo;
            return echoMaternite;
        }

        public async Task<EchoMaternite> GetEchoMaterniteByFichiste(long idFichiste)
        {
            EchoMaternite ec = new EchoMaternite();
            try
            {
                ec = await context.EchoMaternites.Where(e => e.FichisteId == idFichiste).FirstAsync();
            }
            catch (InvalidOperationException)
            {
                ec = new();
            }
            return ec;
        }

        public async Task<EchoMaternite?> GetEchoMaterniteByCpnId(long idCon)
        {
            EchoMaternite ec = new EchoMaternite();
            try
            {
                ec = await context.EchoMaternites.Where(e => e.CpnId == idCon).FirstAsync();
            }
            catch (InvalidOperationException ex)
            {
                ec = null;
            }
            return ec;
        }

        public async Task<bool> UpdateAvoirEchoEcho(AvoirEcho avoirEcho)
        {
            int i = 0;
            AvoirEcho avE = new();
            try
            {
                avE = context.AvoirEchoes.Where(av => av.AvoirEchoId == avoirEcho.AvoirEchoId).First();
                avE.EchoId = avoirEcho.EchoId;
                context.Update(avE);
                i = await context.SaveChangesAsync();
            }
            catch (InvalidOperationException ex)
            {
                context.AvoirEchoes.Add(avoirEcho);
                i = await context.SaveChangesAsync();
            }
            return i > 0;
        }

        public async Task<bool> UpdateAvoirEchoLabo(AvoirEcho avoirEcho)
        {
            int i = 0;
            AvoirEcho avE = new();
            try
            {
                avE = context.AvoirEchoes.Where(av => av.AvoirEchoId == avoirEcho.AvoirEchoId).First();
                avE.LaboratoireId = avoirEcho.LaboratoireId;
                context.Update(avE);
                i = await context.SaveChangesAsync();
            }
            catch (InvalidOperationException ex)
            {
                context.AvoirEchoes.Add(avoirEcho);
                i = await context.SaveChangesAsync();
            }
            return i > 0;
        }

        public async Task<List<VaccinMere>> GetAllVaccinMereByIdMaternite(long MaterniteId)
        {
            List<VaccinMere> vcc = new();
            vcc = await context.VaccinMeres.Where(v => v.MaterniteId == MaterniteId).ToListAsync();
            return vcc;
        }

        public async Task<bool> UpdateEchoMaternite(EchoMaternite echoMaternite)
        {
            context.Entry(echoMaternite).State = EntityState.Modified;
            int i = await context.SaveChangesAsync();
            return i > 0;
        }

        public async Task<Maternite> GetMAterniteByAvoirMAternite(long idAvoirMaternite)
        {
            Maternite ec ;
            try
            {
                ec = new Maternite();
                ec = await context.Maternites.Where(e => e.AvoirMaterniteId == idAvoirMaternite).FirstAsync();
            }
            catch (InvalidOperationException ex)
            {
                ec = new();
            }
            return ec;
        }

        public async Task<Maternite> UpdateMaternite2(Maternite maternite)
        {
            context.Entry(maternite).State = EntityState.Detached;
            context.Update(maternite);
            await context.SaveChangesAsync();
            return maternite;
        }

        public async Task<List<Maternite>> GetMaterniteByAffiliation(string categorie, string affiliation)
        {
            List<Maternite> maters = new List<Maternite>();
            maters = await context.Maternites.Where(m => m.Categorie == categorie && m.Affiliationid == Convert.ToInt64(affiliation)).ToListAsync();
            return maters;
        }

        public async Task<int> GetNombreCpnByMaternite(long idMaternite)
        {
            return context.Cpns.Where(c => c.MaterniteId == idMaternite).Count();
        }

        public async Task<bool> UpdateMere(Mere mere)
        {
            context.Entry(mere).State = EntityState.Detached;
            context.Update(mere);
            int i = await context.SaveChangesAsync();
            return i> 0;
        }
    }
}
