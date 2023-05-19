using LYRA.Models.Maternites;

namespace LYRA.Controllers.ControllerMaternite
{
    public interface IMaterniteService
    {
        public Task<bool> CreateMaternite(Maternite maternite);
        public Task<Maternite?> CreateMaternite2(Maternite maternite);
        public Task<bool> CreateAvoirMaternite(AvoirMaternite avoirMaternite);
        public Task<bool> CreateCPN(Cpn cpn);
        public Task<bool> CreateBebe(Bebe bebe);
        public Task<bool> CreateMere(Mere mere);
        public Task<VaccinMere> CreateVaccinMere(VaccinMere vaccMere);
        public Task<bool> CreateVaccinBebe(VaccinEnfant vaccBebe);
        public Task<bool> CreateAvoirEcho(AvoirEcho avoirEcho);
        public Task<bool> UpdateMaternite(Maternite maternite);
        public Task<Maternite> UpdateMaternite2(Maternite maternite);
        public Task<bool> UpdateAvoirMaternite(AvoirMaternite avoirMaternite);
        public Task<bool> UpdateAvoirEchoEcho(AvoirEcho avoirEcho);
        public Task<bool> UpdateAvoirEchoLabo(AvoirEcho avoirEcho);
        public Task<bool> UpdateMere(Mere mere);
        public Task<List<AvoirMaternite>> GetAllAvoirMaternite();
        public Task<List<AvoirMaternite>> GetAllAvoirMaterniteListe();
        public Task<AvoirMaternite> GetAvoirMaternite(long idFichiste);
        public Task<List<AvoirMaternite>> GetAllAvoirMaterniteNonTerminer();
        public Task<List<EchoMaternite>> GetEchoMaterniteNonTerminer();
        public Task<Maternite> GetMaterniteByFichiste(long fichisteID);
        public Task<List<Maternite>> GetMaterniteByAffiliation(string categorie, string affiliation);
        public Task<EchoMaternite> GetEchoMaterniteByCpnId(long idCon);
        public Task<Maternite> GetMaterniteByID(long idMaternite);
        public Task<Maternite> GetMAterniteByAvoirMAternite(long idAvoirMAternite);
        public Task<List<Cpn>> GetAllCpnByFichiste(long fichisteID);
        public Task<List<Cpn>> GetAllCpnByMaternite(long idMaternite);
        public Task<Cpn?> GetCpnByID(long idCpn);
        public Task<int> GetNombreCpnByMaternite(long idMaternite);
        public Task<Bebe> GetBebeByCpn(long cpnID);
        public Task<Mere> GetMereByCpn(long cpnID);
        public Task<List<VaccinMere>> GetAllVaccinMereByIdMaternite(long MaterniteId);
        public Task<AvoirEcho> GetAvoirEchoByCpn(long cpnID);
        public Task<bool> CheckMaterniteExist(long idFichiste);
        public Task<Maternite> CheckMaterniteExistByEmployer(long idEmployer);
        public Task<Maternite> CheckMaterniteExistByFamille(long idFamille);
        public Task<bool> ChangeValidationGrossesse(int value, long idAvoirMaternite);
        public Task<EchoMaternite> CreateEchoMaternite(EchoMaternite echo);
        public Task<bool> CreateEchoMaterniteBool(EchoMaternite echoMaternite);
        public Task<bool>UpdateEchoMaternite(EchoMaternite echoMaternite);
        public Task<EchoMaternite?> GetEchoMaterniteByFichiste(long idFichiste);
    }
}
