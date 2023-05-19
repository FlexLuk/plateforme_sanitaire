using LYRA.Models;

namespace LYRA.Controllers.PatiantController
{
    public interface IPatiantService
    {
        public Task<Patiant> GetPatiantById(long idPatiant);
        public Task<Patiant> GetPatiantByIdFichiste(long idFichiste);
        public Task<List<Patiant>> GetListPassageFichiste();
        public Task<bool> InsertPatiant(Patiant patiant);

        public Task<bool> UpdatePatiantStatut(long idPatiant);
    }
}
