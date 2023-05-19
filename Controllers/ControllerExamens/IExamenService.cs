using LYRA.Models.Examens;
using LYRA.Models.Maternites;

namespace LYRA.Controllers.ControllerExamens
{
    public interface IExamenService
    {
        public Task<List<EchoEcg>> GetAllEchoEcgByFichiste(long idFichiste);
        public Task<EchoEcg> GetEchoEcgByFichiste(long idFichiste);
        public Task<AvoirLaboratoire> GetAvoirLaboratoireByFichiste(long idFichiste);
        public Task<List<Laboratoire>> GetAllLaboratoireByFichiste(long idFichiste);
        public Task<Laboratoire?> GetLaboratoireByFichiste(long idFichiste);

        public Task<Laboratoire?> GetLaboratoireByFichisteMaternite(long idFichiste);
        public Task<Laboratoire?> GetLaboratoireByCpnId(long idCpn);
        public Task<List<EchoEcg>> GetAllEchoEcgNonTerminer();
        public Task<List<EchoEcg>> GetAllEchoEcg();
        public Task<List<Laboratoire>> GetAllLaboratoireNonTerminer();
        public Task<List<AvoirLaboratoire>> GetAllAvoirLaboratoireEncours();
        public Task<List<AvoirLaboratoire>> GetAllAvoirLaboratoire();
        public Task<List<AvoirLaboratoire>> GetAllAvoirLaboratoireNonTerminer();
        public Task<bool> CreateEchoEcg(EchoEcg echoEcg);
        public Task<bool> CreateLaboratoire(Laboratoire labo);
        public Task<Laboratoire> CreateLaboratoireLabo(Laboratoire labo);

        public Task<bool> CreateAvoirLaboratoire(AvoirLaboratoire labo);
        public Task<bool> UpdateEchoEcg(EchoEcg echoEcg);
        public Task<bool> UpdateLaboratoire(Laboratoire labo);
        public Task<bool> UpdateAvoirLaboratoire(AvoirLaboratoire avLabo);

        public Task<bool> CheckAvoirLaboByFichiste(long idFichiste);
    }
}
