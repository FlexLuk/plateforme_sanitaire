using LYRA.Models;

namespace LYRA.Controllers.ComtrollerMedecin
{
    public interface IMedecinService
    {
        public Task<List<Medecin>> GetMedecin();
        public Task<Medecin> GetMedecinById(int idMedecin);
        public Task<Medecin> GetMedecinByIdUtilisateur(int idUtil);
        public Task<bool> UpdateMedecin(Medecin medecin);
        public Task<bool> DeleteMedecinById(int idMedecin);
        public Task<bool> InsertMedecin(Medecin medecin);
        public Task<int> GetConsultationCountByMedecin(int idMedecin);
        public Task<Consultation> GetConsultationById(long idConsultation);
        public Task<Consultation> GetConsultationByFichisteId(long idFichiste);
        public Task<List<Consultation>> GetConsultationByMedecinEnAttente(int idMedecin);
        public Task<List<Consultation>> GetConsultationByMedecin(int idMedecin);
        public Task<List<Consultation>> GetConsultationFinishOrLoad();
        public Task<bool> CreerConsultation(Consultation consultation);
        public Task<bool> UpdateConsultation(long idConsultation, Consultation consultation);
        public Task<bool> UpdateConsultationByFichiste(long fichisteid, Consultation consultation);
        public Task<bool> UpdateConsultation(Consultation consultation);
        public Task<List<Diagnostic>> GetAllDiagnostic();
        public Task<List<DiagnosticAvoir>> GetDiagnosticAvoirsByFichiste(long idFichiste, long idConsultation);
        public Task<bool> CreateDiagnosticAvoir(DiagnosticAvoir diagAvoir);
        
    }
}
