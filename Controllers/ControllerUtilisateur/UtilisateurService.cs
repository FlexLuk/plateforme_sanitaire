using LYRA.Models.Administration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace LYRA.Controllers.ControllerUtilisateur
{
    public class UtilisateurService : IUtilisateurService
    {
        protected UtilisateurContext context;

        public UtilisateurService(UtilisateurContext _context)
        {
            context = _context;
        }


        public async Task<Utilisateur> DeleteUtilisateur(int id)
        {
            Int16 ids = Convert.ToInt16(id);
            Utilisateur user = context.Utilisateurs.Find(ids);
            context.Utilisateurs.Remove(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<Utilisateur>> GetAllUtilisateur()
        {
            List<Utilisateur> utilisateur = await context.Utilisateurs.ToListAsync();
            return utilisateur;
        }

        public async Task<List<Utilisateur>> GetAllUtilisateurs()
        {
            List<Utilisateur> utilisateur = await context.Utilisateurs.ToListAsync();
            return utilisateur;
        }

        public async Task<Utilisateur> GetUtilisateurByEmail(string email)
        {
            Utilisateur user = new();
            user = await context.Utilisateurs.Where(u => u.Email == email).FirstAsync();
            return user;
        }

        public async Task<Utilisateur> GetUtilisateurById(int id)
        {
            var user = await context.Utilisateurs.FindAsync(id);
            context.Entry(user).State = EntityState.Detached;
            return user;
        }

        public async Task<Utilisateur> GetUtilisateurByIdShort(short id)
        {
            var user = await context.Utilisateurs.FindAsync(id);
            context.Entry(user).State = EntityState.Detached;
            return user;
        }

        public async Task<Utilisateur> InsertUtilisateur(Utilisateur user)
        {
            context.SaveChanges();
            await context.Utilisateurs.AddAsync(user);
            context.SaveChanges();
            return user;
        }

        public Task<Utilisateur> UpdateUtilisateur(Utilisateur user)
        {
            context.SaveChanges();
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
            return Task.FromResult<Utilisateur>(user);
        }


    }
}
