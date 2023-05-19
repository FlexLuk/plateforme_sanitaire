using LYRA.Models;
using Microsoft.EntityFrameworkCore;

namespace LYRA.Controllers.ControllerFichiste
{
    public class FichisteService : IFichisteService
    {
        readonly FICHISTEContext contextFichiste;

        public FichisteService(FICHISTEContext _context)
        {
            contextFichiste = _context;
        }

        public async Task<List<Fichiste>> getAllFichiste()
        {
            return await contextFichiste.Fichistes.ToListAsync();
        }

        public async Task<List<Fichiste>> getAllFichisteJournalier(DateTime date)
        {
            List<Fichiste> fichistes = await contextFichiste.Fichistes.Where(f => f.Date.ToShortDateString() == date.ToShortDateString()).ToListAsync();
            return fichistes;
        }

        public async Task<List<Fichiste>> getAllFichisteJournalierFam()
        {
            List<Fichiste> fichistes = await contextFichiste.Fichistes.Where(f => f.Date.ToShortDateString() == DateTime.Now.ToShortDateString() && f.Categorie == "Famille").ToListAsync();
            return fichistes;
        }

        public async Task<List<Fichiste>> getAllFichisteJournalierTrav()
        {
            List<Fichiste> fichistes = await contextFichiste.Fichistes.Where(f => f.Date.ToShortDateString() == DateTime.Now.ToShortDateString() && f.Categorie == "Travailleur").ToListAsync();
            return fichistes;
        }

        public async Task<List<Fichiste>> getFichistesEntreDates(DateTime d1, DateTime d2)
        {
            List<Fichiste> fichistes = await contextFichiste.Fichistes.Where(f => DateOnly.FromDateTime(f.Date) >= DateOnly.FromDateTime(d1) && DateOnly.FromDateTime(f.Date) <= DateOnly.FromDateTime(d2)).ToListAsync();
            return fichistes;
        }

        public async Task<int> GetFrequenceMounth(string categorie, string affiliation, DateOnly date)
        {
            DateTime androany = DateTime.Now;
            List<Fichiste> fichistes = await contextFichiste.Fichistes.Where(f => f.Date.Year == date.Year && f.Date.Month == date.Month && f.Categorie == categorie && f.Affiliationid == affiliation).ToListAsync();
            return fichistes.Count;
        }

        public async Task<int> GetFrequenceYear(string categorie, string affiliation)
        {
            DateTime androany = DateTime.Now;
            List<Fichiste> fichistes = await contextFichiste.Fichistes.Where(f => f.Date.Year == androany.Year && f.Categorie == categorie && f.Affiliationid == affiliation).ToListAsync();
            return fichistes.Count;
        }
        public async Task<int> GetFrequenceMonth(string categorie, string affiliation)
        {
            DateTime androany = DateTime.Now;
            List<Fichiste> fichistes = await contextFichiste.Fichistes.Where(f => f.Date.Year == androany.Year && f.Date.Month == androany.Month && f.Categorie == categorie && f.Affiliationid == affiliation).ToListAsync();
            return fichistes.Count;
        }

        public async Task<int> GetNumJour()
        {
            //DateTime t = DateTime.Now;
            List<Fichiste> fichistes = await contextFichiste.Fichistes.Where(f => f.Date.Date == DateTime.Now.Date).ToListAsync();
            return fichistes.Count + 1;
        }

        public async Task<long> InsertFichiste(Fichiste fichiste)
        {
            Fichiste _fichiste = new();
            _fichiste = fichiste;
            await contextFichiste.SaveChangesAsync();
            await contextFichiste.Fichistes.AddAsync(_fichiste);
            int i = contextFichiste.SaveChanges();
            return _fichiste.Fichisteid;
        }

        public async Task<Fichiste> getFichisteById(long id)
        {
            Fichiste fichiste = new();
            fichiste = await contextFichiste.Fichistes.Where(f => f.Fichisteid == id).FirstOrDefaultAsync();
            return fichiste;
        }

    }
}
