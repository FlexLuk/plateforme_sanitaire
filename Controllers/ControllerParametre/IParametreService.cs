using LYRA.Models;

namespace LYRA.Controllers.ControllerParametre
{
    public interface IParametreService
    {
        public Task<bool> AddParametre(Parametre parametre);
        public Task<bool> AddPatiant(Patiant patiant);

        public Task<bool> UpdateParametre(Parametre parametre);
        public Task DeleteParametre(int id);
        public Task<Parametre> GetParametre(int id);
        public Task<Parametre> GetParametreByFichiste(long idFichiste);
        public Task<ListeParametre> GetListeParametre(int id);
        public Task<ListeParametre> GetListParamByUser(int id);
        public Task<List<ListeParametre>> GetListAllParamByUser(int id);
        public Task<List<Parametre>> GetAllParametre();

        //LISTE PARAM
        public Task<List<ListeParametre>> GetAllListParametre();
        public Task<List<ListeParametre>> getParametreActif();
        public Task<List<Patiant>> getListPatiantInParam(int numParam);
        public Task<List<Patiant>> getListPatiantInParamNonTerminer(int numParam);
        public Task<bool> AddListParametre(ListeParametre listParametre);
        public Task<bool> DesactiverListeParametre(int id);
        public Task<bool> ActiverListeParametre(int id);
        public Task<bool> ModifierListePArametre(int id, ListeParametre listeParametre);
    }
}
