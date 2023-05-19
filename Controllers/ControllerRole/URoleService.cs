using LYRA.Models.Administration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LYRA.Controllers.ControllerRole
{
    public class URoleService : IURoleService
    {
        readonly UtilisateurContext context;

        public URoleService(UtilisateurContext _context)
        {
            context = _context;
        }

        public bool DeleteUroleById(Urole urole)
        {
            context.Uroles.Remove(urole);
            return context.SaveChanges() > 0 ? true : false;
        }

        public async Task<List<Urole>> GetAllRole()
        {
            return await context.Uroles.ToListAsync();
        }

        public async Task<Urole> GetUroleById(int id)
        {
            Urole? urole = await context.Uroles.FindAsync(id);
            context.Entry(urole).State = EntityState.Detached;
            return urole;
        }

        public async Task<Urole> InsertRole(Urole urole)
        {
            context.Uroles.Add(urole);
            await context.SaveChangesAsync();

            return urole;
        }

        public async Task<Urole> UpdateRole(Urole urole)
        {
            context.Entry(urole).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return urole;
        }
    }
}
