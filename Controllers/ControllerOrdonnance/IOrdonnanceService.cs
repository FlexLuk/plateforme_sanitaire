using LYRA.Models.Pharmacie;

namespace LYRA.Controllers.ControllerOrdonnance
{
    public interface IOrdonnanceService
    {
        public Task<bool> CreateOrdonnance(Ordonnance ordonnance);
        public Task<bool> CreateSortie(Sortie sortie);
        public Task<bool> CreateAvoirOrdonnance(OrdonnanceAvoir ordonnanceAvoir);
        public Task<bool> DeleteOrdonnance(long idOrdonnance);
        public Task<bool> DeleteAvoirOrdonnance(long idAvoirOrdonnance);
        public Task<bool> DeleteAvoirOrdonnanceEntity(OrdonnanceAvoir OrdoAvoir);
        public Task<bool> UpdateAvoirOrdonnance(OrdonnanceAvoir ordonnanceAvoir);
        public Task<bool> UpdateAvoirOrdonnanceSoins(OrdonnanceAvoir ordonnanceAvoir);
        public Task<bool> UpdateMedicament(Medicament medicament);
        public Task<bool> UpdateOrdonance(Ordonnance ordonnance);
        public Task<List<Ordonnance>> GetAllOrdonnance();
        public Task<List<OrdonnanceAvoir>> GetAllAvoirOrdonnance();
        public Task<Ordonnance> GetOrdonnancesById(long idOrdonnance);
        public Task<OrdonnanceAvoir> GetAvoirOrdonnancesById(long idAvoirOrdonnance);
        public Task<Ordonnance> GetOrdonnancesByFichisteId(long idFichiste);
        public Task<List<OrdonnanceAvoir>> GetAvoirOrdonnancesByOrdonnanceId(long idOrdonnnace);

    }
}
