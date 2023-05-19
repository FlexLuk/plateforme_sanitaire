using LYRA.Models.Maternites;
using LYRA.Models.Pharmacie;
using Microsoft.EntityFrameworkCore;

namespace LYRA.Controllers.SoinsController
{
    public class SoinsService : ISoinsService
    {
        readonly PHARMACIEContext context;

        public SoinsService(PHARMACIEContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreateAvoirSoins(AvoirSoins AvSoins)
        {
            await context.AvoirSoinss.AddAsync(AvSoins);
            int result = context.SaveChanges();
            return result > 0;
        }

        public async Task<bool> CreatePassageSoins(PassageSoin passageSoin)
        {
            await context.PassageSoins.AddAsync(passageSoin);
            int result = context.SaveChanges();
            return result > 0;
        }

        public async Task<bool> CreateSoins(Soins soins)
        {
            await context.Soinss.AddAsync(soins);
            int result = context.SaveChanges();
            return result > 0;
        }

        public async Task<List<AvoirSoins>> GetAllAvoirSoins()
        {
            List<AvoirSoins> soins = new List<AvoirSoins>();
            soins = await context.AvoirSoinss.ToListAsync();
            return soins;
        }

        public async Task<List<Soins>> GetAllSoins()
        {
            List<Soins> avSoins = new List<Soins>();
            avSoins = await context.Soinss.Where(s => s.Fin == "non").ToListAsync();
            return avSoins;
        }
        public async Task<List<Soins>> GetSoinsAll()
        {
            List<Soins> avSoins = new List<Soins>();
            avSoins = await context.Soinss.ToListAsync();
            return avSoins;
        }

        public async Task<AvoirSoins> GetAvoirSoinsById(long idAvoirSoins)
        {
            AvoirSoins avSoins = new AvoirSoins();
            avSoins = await context.AvoirSoinss.FindAsync(idAvoirSoins);
            return avSoins;
        }

        public async Task<List<AvoirSoins>> GetAvoirSoinsBySoins(long idSoins)
        {
            List<AvoirSoins> avSoins = new List<AvoirSoins>();
            avSoins = await context.AvoirSoinss.Where(c => c.Soinsid == idSoins).ToListAsync<AvoirSoins>();
            return avSoins;
        }
        public async Task<List<PassageSoin>> GetPassageSoinsBySoin(long idSoins)
        {
            List<PassageSoin> pSoins = new List<PassageSoin>();
            pSoins = await context.PassageSoins.Where(c => c.SoinsId == idSoins).ToListAsync<PassageSoin>();
            return pSoins;
        }

        public async Task<Soins> GetSoinsByFichisteId(long idFichiste)
        {
            Soins soins = new Soins();
            soins = await context.Soinss.Where(c => c.Fichisteid == idFichiste).FirstOrDefaultAsync();
            return soins;
        }

        public async Task<Soins> GetSoinsById(long idSoins)
        {
            Soins soins = new Soins();
            soins = await context.Soinss.FindAsync(idSoins);
            return soins;
        }

        public async Task<bool> UpdateAvoirSoins(AvoirSoins avoirSoins)
        {
            AvoirSoins avs = new AvoirSoins();
            avs = await context.AvoirSoinss.FindAsync(avoirSoins.Avoirsoinsid);
            if (avs != null)
            {
                avs = avoirSoins;
                context.Update(avs);
                int i = await context.SaveChangesAsync();
                return i > 0;
            }
            else return false;
        }

        public async Task<bool> UpdateSoinsFin(Soins soins)
        {
            context.Entry(soins).State = EntityState.Modified;
            int i = await context.SaveChangesAsync();
            return i > 0;
            
        }
    }
}
