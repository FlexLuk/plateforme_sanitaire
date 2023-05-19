using LYRA.Models.Administration;

namespace LYRA.Data
{
    public interface ILoginControl
    {
        public Task<Utilisateur?> VerificationUtilisateur(string email, string passswordHash);
        public Task<List<Int32>> GetRoleIdUSer(Utilisateur utilisateur);
        public Task<List<Urole>> GetRoleUserAuthentified(Utilisateur utilisateur);
    }
}
