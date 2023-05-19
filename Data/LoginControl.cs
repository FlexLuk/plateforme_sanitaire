using LYRA.Models.Administration;
using Microsoft.EntityFrameworkCore;

namespace LYRA.Data
{
    public class LoginControl : ILoginControl
    {

        protected UtilisateurContext context;

        public LoginControl(UtilisateurContext _context)
        {
            context = _context;
        }

        public async Task<List<int>> GetRoleIdUSer(Utilisateur utilisateur)
        {
            List<AvoirRole> avRoles = new List<AvoirRole>();
            avRoles = await context.AvoirRoles.Where(x => x.Utilisateurid == utilisateur.Utilisateurid).ToListAsync();
            List<int> roleIDs = new List<int>();
            foreach (var item in avRoles)
            {
                roleIDs.Add(item.Roleid);
            }
            return roleIDs;
        }

        public async Task<List<Urole>> GetRoleUserAuthentified(Utilisateur utilisateur)
        {
            List<int> roleIDs = await GetRoleIdUSer(utilisateur);
            List<Urole> roleNames = new List<Urole>();
            foreach (var item in roleIDs)
            {
                Urole urole = new Urole();
                urole = await context.Uroles.Where(x => x.Roleid == item).FirstOrDefaultAsync();
                if (urole != null)
                    roleNames.Add(urole);
            }
            return roleNames;
        }

        public async Task<Utilisateur?> VerificationUtilisateur(string email, string passswordHash)
        {
            Utilisateur? user = await context.Utilisateurs.Where(x => x.Email == email).FirstOrDefaultAsync();
            if (user != null && BCrypt.Net.BCrypt.Verify(passswordHash, user.Passwordhash))
                return user;
            else
                return null;
        }
    }
}
