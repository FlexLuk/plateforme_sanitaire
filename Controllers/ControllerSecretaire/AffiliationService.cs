using DocumentFormat.OpenXml.Office2010.Excel;
using LYRA.Models;
using Microsoft.EntityFrameworkCore;

namespace LYRA.Controllers.ControllerSecretaire
{
    public class AffiliationService : IAffiliationService
    {

        readonly ADHESIONContext context;

        public AffiliationService(ADHESIONContext _context)
        {
            context = _context;
        }

        public Task<Employer> DeleteEmployer(int idEmployer)
        {
            throw new NotImplementedException();
        }

        public Task<Famille> DeleteFamille(int idFamille)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employer>> GetAllEmployer()
        {
            return await context.Employers.ToListAsync();
        }

        public async Task<IEnumerable<Famille>> GetAllFamille()
        {
            return await context.Familles.ToListAsync();
        }

        public async Task<Employer> GetEmployerById(int idEmployer)
        {
            return await context.Employers.Where(x => x.Employerid == idEmployer).FirstAsync();
        }
        public async Task<List<Employer>> GetEmployerByEmployeur(string numEmployeur)
        {
            List<Employer> employers = new List<Employer>();
            employers = await context.Employers.Where(e => e.Numemployeur == numEmployeur).ToListAsync();
            return employers;
        }

        public async Task<Employer> GetEmployerByNumOsiet(string numosiet)
        {
            Employer employer = null;
            employer = await context.Employers.Where(x => x.Numeroosiet == numosiet).FirstOrDefaultAsync();
            return employer;
        }

        public async Task<Famille> GetFamilleById(int idFamille)
        {
            Famille famille = null;
            famille = await context.Familles.Where(x => x.Familleid == idFamille).FirstOrDefaultAsync();
            return famille;
        }

        public async Task<IEnumerable<Famille>> GetFamilleByNumOsiet(string numosiet)
        {
            return await context.Familles.Where(x => x.Numeroosiet == numosiet).ToListAsync();
        }

        public async Task<int> InsertEmployer(Employer employer)
        {
            context.SaveChanges();
            await context.Employers.AddAsync(employer);
            context.SaveChanges();
            context.Entry(employer).GetDatabaseValues();
            return employer.Employerid;
        }

        public async Task<Famille> InsertFamille(Famille famille)
        {
            context.SaveChanges();
            await context.Familles.AddAsync(famille);
            context.SaveChanges();
            context.Entry(famille).GetDatabaseValues();
            return famille;
        }

        public async Task<bool> UpdateEmployer(Employer employer)
        {
            Employer emp = await context.Employers.Where(item => item.Employerid == employer.Employerid).FirstOrDefaultAsync();
            emp = employer;
            context.Entry(emp).State = EntityState.Modified;
            int i = context.SaveChanges();
            return i > 0;
        }

        public async Task<Famille> UpdateFamille(Famille famille)
        {
            context.Entry(famille).State = EntityState.Modified;
            int i = await context.SaveChangesAsync();
            return famille;
        }

        public async Task<bool> CreateHistoEmploi(HistoEmploi histEmploi)
        {
            context.SaveChanges();
            await context.HistoEmplois.AddAsync(histEmploi);
            int i = context.SaveChanges();
            return i > 0;
        }

        public async Task<string> GetNameFamilleById(int idFamille)
        {
            Famille fam = await context.Familles.Where(x => x.Familleid == idFamille).FirstOrDefaultAsync();
            return fam.Nom + " " + fam.Prenom;
        }
    }
}
