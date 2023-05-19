using LYRA.Models.Rendez_vous;

namespace LYRA.Controllers.Rdv_Medecin
{
    public interface IRDVMedecinService
    {
        public Task<bool> InsertRdvMedecin(MedecinRdv medRdv);
        public Task<bool> UpdateRdvMedecin(int idRdv, MedecinRdv medRdv);

        public Task<List<MedecinRdv>> medecinRdvs(int idMedecin);
        public Task<List<MedecinRdv>> medecinRdvs();
    }
}
