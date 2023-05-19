using LYRA.Models;
using LYRA.Models.Pharmacie;

namespace LYRA.Controllers.PharmacieController
{
    public interface IPharmacieService
    {

        public Task<bool> InsertArticle(Medicament medicament);
        public Task<bool> InsertEntree(Entree entree);
        public Task<Medicament> GetMedicamentById(long idMedicament);
        public Task<string> GetDesignstionMedicamentById(long idMedicament);
        public Task<Medicament> GetMedicamentByName(string name);
        public Task DeleteMedicamentById(long idMedicament);
        public Task<bool> UpdateMedicament(Medicament medicament);
        public Task<List<Medicament>> GetListMedicament();
        public Task<List<Entree>> GetListEntree();
        public Task<List<Ordonnance>> GetAllOrdonnance();
        public Task<List<Ordonnance>> GetAllOrdonnanceListe();
    }
}
