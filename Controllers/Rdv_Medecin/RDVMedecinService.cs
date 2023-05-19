using LYRA.Models.Rendez_vous;
using Microsoft.EntityFrameworkCore;

namespace LYRA.Controllers.Rdv_Medecin
{
    public class RDVMedecinService : IRDVMedecinService
    {

        readonly RDVContext context;

        public RDVMedecinService(RDVContext _context)
        {
            context = _context;
        }
        public async Task<bool> InsertRdvMedecin(MedecinRdv medRdv)
        {
            await context.MedecinRdvs.AddAsync(medRdv);
            int result = context.SaveChanges();
            return result > 0;
        }

        public async Task<List<MedecinRdv>> medecinRdvs(int idMedecin)
        {
            List<MedecinRdv> medecinRdvs = new List<MedecinRdv>();
            medecinRdvs = await context.MedecinRdvs.Where(m => m.Medecinid == idMedecin).ToListAsync();
            return medecinRdvs;
        }

        public async Task<List<MedecinRdv>> medecinRdvs()
        {
            List<MedecinRdv> medecinRdvs = new List<MedecinRdv>();
            medecinRdvs = await context.MedecinRdvs.ToListAsync();
            return medecinRdvs;
        }

        public Task<bool> UpdateRdvMedecin(int idRdv, MedecinRdv medRdv)
        {
            throw new NotImplementedException();
        }
    }
}
