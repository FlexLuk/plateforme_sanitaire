using LYRA.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LYRA.Controllers.ControllerSecretaire
{
    public class AdhesionService : IAdhesionService
    {

        readonly ADHESIONContext context;

        public AdhesionService(ADHESIONContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Employeur>> GetAllAdhesion()
        {
            return await context.Employeurs.ToListAsync();
        }

        public async Task<Employeur> DeleteAdhesion(int id)
        {
            Employeur employeur = context.Employeurs.Find(id);
            context.Employeurs.Remove(employeur);
            await context.SaveChangesAsync();
            return employeur;
        }

        public async Task<Employeur?> InsertAdhesion(Employeur employeur)
        {
            Employeur? employeurChecker = new();

            try
            {
                employeurChecker = await context.Employeurs.Where(x => x.Numemployeur.Trim() == employeur.Numemployeur.Trim()).FirstAsync();
                return null;
            }
            catch (InvalidOperationException)
            {
                Employeur? empl = new();
                empl = employeur;
                await context.Employeurs.AddAsync(empl);
                int i = context.SaveChanges();
                if (i > 0)
                {
                    return empl;

                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Employeur> GetEmployeurByEmployer(string numEmployeur)
        {
            Employeur employeur = new();
            employeur = await context.Employeurs
            .Where(x => x.Numemployeur == numEmployeur)
            .FirstOrDefaultAsync();

            return employeur;
        }
    }
}
