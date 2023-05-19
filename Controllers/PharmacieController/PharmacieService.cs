using LYRA.Models;
using LYRA.Models.Pharmacie;
using Microsoft.EntityFrameworkCore;

namespace LYRA.Controllers.PharmacieController
{
    public class PharmacieService : IPharmacieService
    {

        readonly PHARMACIEContext context;

        public PharmacieService(PHARMACIEContext _context)
        {
            context = _context;
        }

        public Task DeleteMedicamentById(long idMedicament)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ordonnance>> GetAllOrdonnance()
        {
            List<Ordonnance> result = new List<Ordonnance>();
            result = await context.Ordonnances.Where(o=>o.Etat!="Terminer").ToListAsync();
            return result;
        }

        public async Task<List<Ordonnance>> GetAllOrdonnanceListe()
        {
            List<Ordonnance> result = new List<Ordonnance>();
            result = await context.Ordonnances.ToListAsync();
            return result;
        }

        public async Task<string> GetDesignstionMedicamentById(long idMedicament)
        {
            Medicament medicament = new Medicament();
            medicament = await context.Medicaments.FindAsync(idMedicament);
            return medicament.Designation + " " + medicament.Presentation;
        }

        public async Task<List<Entree>> GetListEntree()
        {
            List<Entree> entrees = new List<Entree>();
            entrees = await context.Entrees.ToListAsync();
            return entrees;
        }

        public async Task<List<Medicament>> GetListMedicament()
        {
            List<Medicament> medicaments = new();
            medicaments = await context.Medicaments.ToListAsync();
            return medicaments;
        }

        public async Task<Medicament> GetMedicamentById(long idMedicament)
        {
            Medicament medicament = new Medicament();
            try
            {
                medicament = await context.Medicaments.FindAsync(idMedicament);
            }
            catch (InvalidOperationException)
            {

            }
            return medicament;
        }

        public Task<Medicament> GetMedicamentByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertArticle(Medicament medicament)
        {
            await context.Medicaments.AddAsync(medicament);
            int result = context.SaveChanges();
            return result > 0;
        }

        public async Task<bool> InsertEntree(Entree entree)
        {
            await context.Entrees.AddAsync(entree);
            int result = context.SaveChanges();
            return result > 0;
        }

        public async Task<bool> UpdateMedicament(Medicament medicament)
        {
            context.Entry(medicament).State = EntityState.Modified;
            int i = await context.SaveChangesAsync();
            return i > 0;
        }

        
    }
}
