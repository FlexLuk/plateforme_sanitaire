using LYRA.Models.Pharmacie;
using Microsoft.EntityFrameworkCore;

namespace LYRA.Controllers.ControllerOrdonnance
{
    public class OrdonnanceService : IOrdonnanceService
    {
        readonly PHARMACIEContext context;

        public OrdonnanceService(PHARMACIEContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreateAvoirOrdonnance(OrdonnanceAvoir ordonnanceAvoir)
        {
            await context.OrdonnanceAvoirs.AddAsync(ordonnanceAvoir);
            int i = context.SaveChanges();
            return i > 0;
        }

        public async Task<bool> CreateOrdonnance(Ordonnance ordonnance)
        {
            await context.Ordonnances.AddAsync(ordonnance);
            int i = context.SaveChanges();
            return i > 0;
        }

        public async Task<bool> DeleteAvoirOrdonnance(long idAvoirOrdonnance)
        {
            OrdonnanceAvoir oAv = context.OrdonnanceAvoirs.Find(idAvoirOrdonnance);
            context.OrdonnanceAvoirs.Remove(oAv);
            int i = await context.SaveChangesAsync();
            return i > 0;
        }

        public Task<bool> DeleteOrdonnance(long idOrdonnance)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrdonnanceAvoir>> GetAllAvoirOrdonnance()
        {
            throw new NotImplementedException();
        }

        public Task<List<Ordonnance>> GetAllOrdonnance()
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrdonnanceAvoir>> GetAvoirOrdonnancesByOrdonnanceId(long idOrdonnnace)
        {
            List<OrdonnanceAvoir> av = await context.OrdonnanceAvoirs.Where(c => c.Ordonnanceid == idOrdonnnace).ToListAsync();
            return av;
        }

        public async Task<OrdonnanceAvoir> GetAvoirOrdonnancesById(long idAvoirOrdonnance)
        {
            OrdonnanceAvoir ordonnanceAvoir = new();
            ordonnanceAvoir = await context.OrdonnanceAvoirs.Where(c => c.Ordonnanceavoirid == idAvoirOrdonnance).FirstOrDefaultAsync();
            return ordonnanceAvoir;
        }

        public async Task<Ordonnance> GetOrdonnancesByFichisteId(long idFichiste)
        {
            Ordonnance ordonnance = new();
            ordonnance = await context.Ordonnances.Where(c => c.Fichistteid == idFichiste).FirstOrDefaultAsync();
            return ordonnance;
        }

        public async Task<Ordonnance> GetOrdonnancesById(long idOrdonnance)
        {
            Ordonnance ordonnance = new();
            ordonnance = await context.Ordonnances.Where(c => c.Ordonnanceid == idOrdonnance).FirstOrDefaultAsync();
            return ordonnance;
        }

        public async Task<bool> UpdateAvoirOrdonnanceSoins(OrdonnanceAvoir ordonnanceAvoir)
        {
            context.Entry(ordonnanceAvoir).State = EntityState.Modified;
            int i = await context.SaveChangesAsync();
            return i > 0;
        }
        public async Task<bool> UpdateOrdonance(Ordonnance ordonnance)
        {
            context.Entry(ordonnance).State = EntityState.Modified;
            int i = await context.SaveChangesAsync();
            return i > 0;
        }

        public async Task<bool> UpdateAvoirOrdonnance(OrdonnanceAvoir ordonnanceAvoir)
        {
            var entity = context.OrdonnanceAvoirs.FirstOrDefault(item => item.Ordonnanceavoirid == ordonnanceAvoir.Ordonnanceavoirid);
            if (entity != null)
            {
                entity.Sortie = ordonnanceAvoir.Sortie;
                entity.Soins = ordonnanceAvoir.Soins;
                context.Update(entity);
            }
            int i = await context.SaveChangesAsync();

            return i > 0;
        }

        public async Task<bool> DeleteAvoirOrdonnanceEntity(OrdonnanceAvoir OrdoAvoir)
        {
            context.OrdonnanceAvoirs.Remove(OrdoAvoir);
            int i = await context.SaveChangesAsync();
            return i > 0;
        }

        public async Task<bool> CreateSortie(Sortie sortie)
        {
            await context.Sorties.AddAsync(sortie);
            int i = context.SaveChanges();
            return i > 0;
        }

        public async Task<bool> UpdateMedicament(Medicament medicament)
        {
            var entity = context.Medicaments.FirstOrDefault(item => item.Medicamentid == medicament.Medicamentid);
            if (entity != null)
            {
                entity = medicament;
                context.Update(entity);
            }
            int i = await context.SaveChangesAsync();

            return i > 0;
        }
    }
}
