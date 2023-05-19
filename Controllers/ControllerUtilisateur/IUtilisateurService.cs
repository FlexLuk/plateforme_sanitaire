using LYRA.Models.Administration;
using System.Security.Claims;

namespace LYRA.Controllers.ControllerUtilisateur
{
    public interface IUtilisateurService
    {
        public Task<IEnumerable<Utilisateur>> GetAllUtilisateur();
        public Task<List<Utilisateur>> GetAllUtilisateurs();
        public Task<Utilisateur> GetUtilisateurById(int id);
        public Task<Utilisateur> GetUtilisateurByIdShort(short id);
        public Task<Utilisateur> GetUtilisateurByEmail(string email);
        public Task<Utilisateur> DeleteUtilisateur(int id);
        public Task<Utilisateur> UpdateUtilisateur(Utilisateur user);
        public Task<Utilisateur> InsertUtilisateur(Utilisateur user);
    }
}
