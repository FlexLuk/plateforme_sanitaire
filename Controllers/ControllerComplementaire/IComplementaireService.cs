using LYRA.Models.Complementaire;

namespace LYRA.Controllers.ControllerComplementaire
{
    public interface IComplementaireService
    {
        public Task<bool> CreateTdr(Tdr tdr);
        public Task<List<Tdr>> GetAllTdr();
        public Task<List<Tdr>> GetAllTdrBySoins(long idSoins);
    }
}
