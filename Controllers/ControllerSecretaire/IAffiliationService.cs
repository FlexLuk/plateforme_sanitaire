using LYRA.Models;

namespace LYRA.Controllers.ControllerSecretaire
{
    public interface IAffiliationService
    {
        // Employer
        public Task<IEnumerable<Employer>> GetAllEmployer();
        public Task<Employer> GetEmployerById(int idEmployer);
        public Task<Employer> GetEmployerByNumOsiet(string numosiet);
        public Task<List<Employer>> GetEmployerByEmployeur(string numEmployeur);
        public Task<Employer> DeleteEmployer(int idEmployer);
        public Task<bool> UpdateEmployer(Employer employer);
        public Task<int> InsertEmployer(Employer employer);
        //Famille
        public Task<IEnumerable<Famille>> GetAllFamille();
        public Task<Famille> GetFamilleById(int idFamille);
        public Task<string> GetNameFamilleById(int idFamille);
        public Task<IEnumerable<Famille>> GetFamilleByNumOsiet(string numosiet);
        public Task<Famille> DeleteFamille(int idFamille);
        public Task<Famille> UpdateFamille(Famille famille);
        public Task<Famille> InsertFamille(Famille famille);


        //Emploi
        public Task<bool> CreateHistoEmploi(HistoEmploi emploi);
    }
}
