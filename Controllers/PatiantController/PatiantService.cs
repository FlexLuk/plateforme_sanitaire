using LYRA.Models;
using Microsoft.EntityFrameworkCore;

namespace LYRA.Controllers.PatiantController
{
    public class PatiantService : IPatiantService
    {

        readonly PARAMETREContext context;

        public PatiantService(PARAMETREContext _context)
        {
            context = _context;
        }

        public async Task<List<Patiant>> GetListPassageFichiste()
        {
            List<Patiant> patiants = new List<Patiant>();
            //patiants = await context.Patiants.Where(p => p.Datepassage.Date == DateTime.Now.Date).ToListAsync();
            patiants = await context.Patiants.ToListAsync();
            return patiants;
        }

        public async Task<Patiant> GetPatiantById(long idPatiant)
        {
            Patiant patiant = new();
            patiant = await context.Patiants.Where(p => p.Patiantid == idPatiant).FirstAsync();
            return patiant;
        }

        public async Task<Patiant> GetPatiantByIdFichiste(long idFichiste)
        {
            Patiant patiant = new();
            patiant = await context.Patiants.Where(p => p.Fichisteid == idFichiste).FirstAsync();
            return patiant;
        }

        public async Task<bool> InsertPatiant(Patiant patiant)
        {
            context.SaveChanges();
            await context.Patiants.AddAsync(patiant);
            int result = context.SaveChanges();
            return result > 0;
        }

        public async Task<bool> UpdatePatiantStatut(long idPatiant)
        {
            var entity = await context.Patiants.FirstOrDefaultAsync(p => p.Patiantid == idPatiant);

            bool retour = false;
            if (entity == null)
            {
                retour = false;
            }
            else if (entity != null)
            {
                entity.Statut = "TERMINER";
                retour = true;
            }
            context.SaveChanges();
            return retour;
        }
    }
}
