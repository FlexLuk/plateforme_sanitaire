using LYRA.Models.Examens;

namespace LYRA.Controllers.ControllerDentiste
{
    public interface IDentisteService
    {
        public Task<List<Dentiste>> GetAllDentisteByFichiste(long idFichiste);
        public Task<List<Dentiste>> GetDentisteListeByFichiste(long idFichiste);
        public Task<List<Dentiste>> GetAllDentiste();
        public Task<bool> CreateDentiste(Dentiste dentiste);
        public Task<bool> DeleteDentiste(Dentiste dentiste);
        public Task<bool> UpdateDentiste(Dentiste dentiste);
        public Task<Dentiste> GetDentiste(long idDentiste);
        public Task<Dentiste> GetDentistByIde(long idDentiste);
        public Task<Dentiste> GetDentisteByFichiste(long idFichiste);
        public Task<List<Dentiste>> GetAllDentisteNonTerminer();
        
    }
}
