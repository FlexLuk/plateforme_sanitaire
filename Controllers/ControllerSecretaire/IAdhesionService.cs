using LYRA.Models;

namespace LYRA.Controllers.ControllerSecretaire
{
    public interface IAdhesionService
    {
        public Task<IEnumerable<Employeur>> GetAllAdhesion();
        ////public Task<Employeur> GetAdhesionById(int id);
        public Task<Employeur> DeleteAdhesion(int id);
        ////public Task<Employeur> UpdateAdhesion(Employeur employeur);
        public Task<Employeur?> InsertAdhesion(Employeur employeur);
        public Task<Employeur> GetEmployeurByEmployer(string numEmployeur);
        


    }
}
