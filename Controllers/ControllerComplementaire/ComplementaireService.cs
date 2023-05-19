using LYRA.Models.Complementaire;
using LYRA.Models.Examens;
using Microsoft.EntityFrameworkCore;

namespace LYRA.Controllers.ControllerComplementaire
{
    public class ComplementaireService : IComplementaireService
    {
        readonly COMPLEMENTAIREContext context;

        public ComplementaireService(COMPLEMENTAIREContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreateTdr(Tdr tdr)
        {
            await context.Tdrs.AddAsync(tdr);
            int result = context.SaveChanges();
            return result > 0;
        }

        public async Task<List<Tdr>> GetAllTdr()
        {
            List<Tdr> tdrs = new List<Tdr>();
            tdrs = await context.Tdrs.ToListAsync();
            return tdrs;
        }

        public async Task<List<Tdr>> GetAllTdrBySoins(long idAvoirSoins)
        {
            List<Tdr> tdrs = new List<Tdr>();
            tdrs = await context.Tdrs.Where(t => t.AvoirSoinsId == idAvoirSoins).ToListAsync();
            return tdrs;
        }

        
    }
}
