using DocumentFormat.OpenXml.Office2010.Excel;
using LYRA.Models;
using LYRA.Models.Examens;
using LYRA.Pages.Fichiste;
using Microsoft.EntityFrameworkCore;

namespace LYRA.Controllers.ControllerDentiste
{
    public class DentisteService : IDentisteService
    {
        readonly EXAMENSContext context;

        public DentisteService(EXAMENSContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreateDentiste(Dentiste dentiste)
        {
            await context.Dentistes.AddAsync(dentiste);
            int i = context.SaveChanges();
            return i > 0;
        }

        public Task<bool> DeleteDentiste(Dentiste dentiste)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Dentiste>> GetAllDentiste()
        {
            List<Dentiste> dentiste = new List<Dentiste>();
            dentiste = await context.Dentistes.ToListAsync();
            return dentiste;
        }

        public async Task<List<Dentiste>> GetAllDentisteByFichiste(long idFichiste)
        {
            List<Dentiste> dentiste = new List<Dentiste>();
            dentiste = await context.Dentistes.ToListAsync();
            return dentiste;
        }

        public async Task<List<Dentiste>> GetDentisteListeByFichiste(long idFichiste)
        {
            List<Dentiste> dentiste = new List<Dentiste>();
            dentiste = await context.Dentistes.Where(d => d.Fichisteid == idFichiste).ToListAsync();
            return dentiste;
        }

        public async Task<List<Dentiste>> GetAllDentisteNonTerminer()
        {
            List<Dentiste> dentiste = new List<Dentiste>();
            dentiste = await context.Dentistes.Where(d => d.Terminer != "Oui").ToListAsync();
            return dentiste;
        }

        public Task<Dentiste> GetDentistByIde(long idDentiste)
        {
            throw new NotImplementedException();
        }

        public Task<Dentiste> GetDentiste(long idDentiste)
        {
            throw new NotImplementedException();
        }

        public Task<Dentiste> GetDentisteByFichiste(long idFichiste)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateDentiste(Dentiste dentiste)
        {
            Dentiste dent = await context.Dentistes.Where(item => item.Dentisteid == dentiste.Dentisteid).FirstOrDefaultAsync();
            dent = dentiste;
            context.Entry(dent).State = EntityState.Modified;
            int i = context.SaveChanges();
            return i > 0;
        }
    }
}
