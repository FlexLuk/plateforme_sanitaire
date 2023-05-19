using LYRA.Models.Pharmacie;

namespace LYRA.Controllers.SoinsController
{
    public interface ISoinsService
    {
        public Task<bool> CreateSoins(Soins soins);
        public Task<bool> CreateAvoirSoins(AvoirSoins AvSoins);
        public Task<bool> CreatePassageSoins(PassageSoin passageSoin);
        public Task<List<AvoirSoins>> GetAllAvoirSoins();
        public Task<List<Soins>> GetAllSoins();
        public Task<List<Soins>> GetSoinsAll();
        public Task<AvoirSoins> GetAvoirSoinsById(long idAvoirSoins);
        public Task<Soins> GetSoinsById(long idSoins);
        public Task<Soins> GetSoinsByFichisteId(long idFichiste);
        public Task<List<PassageSoin>> GetPassageSoinsBySoin(long soinID);
        public Task<bool> UpdateSoinsFin(Soins soins);
        public Task<bool> UpdateAvoirSoins(AvoirSoins avoirSoins);
        public Task<List<AvoirSoins>> GetAvoirSoinsBySoins(long idSoins);


    }
}
