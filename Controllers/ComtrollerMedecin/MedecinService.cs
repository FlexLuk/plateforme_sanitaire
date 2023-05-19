using LYRA.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace LYRA.Controllers.ComtrollerMedecin
{
    public class MedecinService : IMedecinService
    {
        readonly CONSULTATIONContext context;

        public MedecinService(CONSULTATIONContext _context)
        {
            context = _context;
        }

        public async Task<bool> CreateDiagnosticAvoir(DiagnosticAvoir diagAvoir)
        {
            DiagnosticAvoir d = await context.DiagnosticAvoirs.FindAsync(diagAvoir.DiagnosticAvoirId);
            if (d == null)
            {
                await context.DiagnosticAvoirs.AddAsync(diagAvoir);
                int i = context.SaveChanges();
                return i > 0;
            }
            else
            {
                context.Update(diagAvoir);
                int i = await context.SaveChangesAsync();
                return i > 0;
            }
        }

        public async Task<bool> CreerConsultation(Consultation con)
        {
            Consultation cons = new();
            cons.Programmer = con.Programmer;
            cons.Numjour = con.Numjour;
            cons.Observations = con.Observations;
            cons.Dateconsultation = con.Dateconsultation;
            cons.DateRdv = con.DateRdv;
            cons.Fichisteid = con.Fichisteid;
            cons.ListeAttente = con.ListeAttente;
            cons.Symptomes = con.Symptomes;
            cons.Statut = con.Statut;
            cons.Soinsid = con.Soinsid;
            cons.Plainte = con.Plainte;
            cons.Passage = con.Passage;
            cons.Medecinid = con.Medecinid;

            await context.Consultations.AddAsync(cons);
            int i = context.SaveChanges();
            return i > 0;
        }

        public async Task<bool> UpdateConsultation(long idConsultation, Consultation con)
        {
            var entity = context.Consultations.FirstOrDefault(item => item.Consultationid == idConsultation);
            if (entity != null)
            {
                entity = con;
                context.Update(entity);
            }
            int i = await context.SaveChangesAsync();

            return i > 0;
        }

        public Task<bool> DeleteMedecinById(int idMedecin)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Diagnostic>> GetAllDiagnostic()
        {
            List<Diagnostic> diags = await context.Diagnostics.ToListAsync();
            return diags;
        }

        public async Task<Consultation> GetConsultationByFichisteId(long idFichiste)
        {
            Consultation consultation = new();
            try
            {
                consultation = await context.Consultations.Where(c => c.Fichisteid == idFichiste).FirstAsync();
            }
            catch (InvalidOperationException)
            {

            }
            return consultation;
        }

        public async Task<Consultation> GetConsultationById(long idConsultation)
        {
            Consultation consultation = new();
            try
            {
                consultation = await context.Consultations.Where(c => c.Consultationid == idConsultation).FirstAsync();
                return consultation;
            }
            catch (InvalidOperationException ex)
            {
                consultation = null;
                return consultation;
            }
        }

        public async Task<List<Consultation>> GetConsultationByMedecin(int idMedecin)
        {
            List<Consultation> cons = await context.Consultations.Where(c => c.Medecinid == idMedecin && c.ListeAttente == "Oui" && c.Statut == null && c.Passage == 1).ToListAsync();
            return cons;
        }

        public async Task<List<Consultation>> GetConsultationByMedecinEnAttente(int idMedecin)
        {
            List<Consultation> cons = await context.Consultations.Where(c => c.Medecinid == idMedecin && c.ListeAttente == "Non" && c.Statut == "En attente" && c.Passage == 0).ToListAsync();
            return cons;
        }

        public async Task<int> GetConsultationCountByMedecin(int idMedecin)
        {
            List<Consultation> cons = await context.Consultations.Where(c => c.Medecinid == idMedecin && c.ListeAttente == "Oui").ToListAsync();
            return cons.Count();
        }

        public async Task<List<Consultation>> GetConsultationFinishOrLoad()
        {
            List<Consultation> cons = await context.Consultations.Where(c => c.Statut != null).ToListAsync();
            return cons;
        }

        public async Task<List<DiagnosticAvoir>> GetDiagnosticAvoirsByFichiste(long idFichiste, long idConsultation)
        {
            List<DiagnosticAvoir> diagAvoirs = await context.DiagnosticAvoirs.Where(da => da.FichisteId == idFichiste && da.ConsultationId == idConsultation).ToListAsync();
            return diagAvoirs;
        }

        public async Task<List<Medecin>> GetMedecin()
        {
            List<Medecin> medecins = await context.Medecins.ToListAsync();
            return medecins;
        }

        public async Task<Medecin> GetMedecinById(int idMedecin)
        {
            Medecin medecin = new();
            medecin = await context.Medecins.Where(m => m.Medecinid == idMedecin).FirstOrDefaultAsync();
            return medecin;
        }

        public async Task<Medecin> GetMedecinByIdUtilisateur(int idUtil)
        {
            Medecin medecin = new();
            medecin = await context.Medecins.Where(m => m.Utilisateurid == idUtil).FirstOrDefaultAsync();
            return medecin;
        }

        public async Task<bool> InsertMedecin(Medecin medecin)
        {
            int i;
            context.Medecins.Add(medecin);
            i = await context.SaveChangesAsync();
            return i > 0;
        }

        public Task<bool> UpdateMedecin(Medecin medecin)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateConsultation(Consultation consultation)
        {
            var entity = context.Consultations.FirstOrDefault(item => item.Consultationid == consultation.Consultationid);
            if (entity != null)
            {
                entity = consultation;
                context.Update(entity);
            }
            int i = await context.SaveChangesAsync();
            return i > 0;
        }

        public async Task<bool> UpdateConsultationByFichiste(long fichisteid, Consultation consultation)
        {
            var entity = context.Consultations.FirstOrDefault(item => item.Fichisteid == fichisteid);
            if (entity != null)
            {
                entity.Passage = consultation.Passage;
                entity.ListeAttente = consultation.ListeAttente;
                context.Update(entity);
            }
            int i = await context.SaveChangesAsync();
            return i > 0;
        }

    }
}
