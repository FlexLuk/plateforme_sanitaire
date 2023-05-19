using LYRA.Models;

namespace LYRA.Controllers.ControllerFichiste
{
    public interface IFichisteService
    {
        public Task<long> InsertFichiste(Fichiste fichiste);
        public Task<int> GetNumJour();
        public Task<int> GetFrequenceYear(string categorie, string affiliation);
        public Task<int> GetFrequenceMounth(string categorie, string affiliation, DateOnly date);
        public Task<int> GetFrequenceMonth(string categorie, string affiliation);
        public Task<List<Fichiste>> getAllFichiste();
        public Task<Fichiste> getFichisteById(long id);
        public Task<List<Fichiste>> getFichistesEntreDates(DateTime d1, DateTime d2);
        public Task<List<Fichiste>> getAllFichisteJournalier(DateTime date);
        public Task<List<Fichiste>> getAllFichisteJournalierFam();
        public Task<List<Fichiste>> getAllFichisteJournalierTrav();
    }
}
