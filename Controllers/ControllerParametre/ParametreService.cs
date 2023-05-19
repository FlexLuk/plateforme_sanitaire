using DocumentFormat.OpenXml.InkML;
using LYRA.Models;
using Microsoft.EntityFrameworkCore;

namespace LYRA.Controllers.ControllerParametre
{
    public class ParametreService : IParametreService
    {
        readonly PARAMETREContext contextParam;

        public ParametreService(PARAMETREContext _context)
        {
            contextParam = _context;
        }

        public async Task<bool> ActiverListeParametre(int id)
        {
            ListeParametre entity = await contextParam.ListeParametres.Where(item => item.Listeparametreid == id).FirstOrDefaultAsync();
            entity.Statut = "Activer";
            contextParam.Entry(entity).State = EntityState.Modified;
            int i = contextParam.SaveChanges();
            return i > 0;
        }

        public async Task<bool> AddListParametre(ListeParametre listParametre)
        {
            await contextParam.ListeParametres.AddAsync(listParametre);
            int i = contextParam.SaveChanges();
            return i > 0;
        }

        public async Task<bool> AddParametre(Parametre parametre)
        {
            await contextParam.Parametres.AddAsync(parametre);
            int i = contextParam.SaveChanges();
            return i > 0;
        }

        public async Task<bool> AddPatiant(Patiant patiant)
        {
            await contextParam.Patiants.AddAsync(patiant);
            int i = contextParam.SaveChanges();
            return i > 0;
        }

        public Task DeleteParametre(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DesactiverListeParametre(int id)
        {

            ListeParametre entity = await contextParam.ListeParametres.Where(item => item.Listeparametreid == id).FirstOrDefaultAsync();
            entity.Statut = "Desactiver";
            contextParam.Entry(entity).State = EntityState.Modified;
            int i = contextParam.SaveChanges();
            return i > 0;

        }

        public async Task<List<ListeParametre>> GetAllListParametre()
        {
            List<ListeParametre> listParam = await contextParam.ListeParametres.ToListAsync();
            return listParam;
        }

        public async Task<List<Parametre>> GetAllParametre()
        {
            List<Parametre> parametres = await contextParam.Parametres.ToListAsync();
            return parametres;
        }

        public async Task<List<Patiant>> getListPatiantInParam(int numParam)
        {
            return await contextParam.Patiants.Where(p => p.Datepassage.Date == DateTime.Now.Date && p.Numeroparametre == numParam && p.Statut == null).ToListAsync();
        }

        public Task<Parametre> GetParametre(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ListeParametre> GetListeParametre(int id)
        {
            return await contextParam.ListeParametres.Where(p => p.Numero == id).FirstAsync();
        }

        public async Task<List<ListeParametre>> getParametreActif()
        {
            return await contextParam.ListeParametres.Where(p => p.Statut == "Activer").ToListAsync();
        }

        public Task<bool> ModifierListePArametre(int id, ListeParametre listeParametre)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateParametre(Parametre parametre)
        {
            var entity = contextParam.Parametres.FirstOrDefault(item => item.Parametreid == parametre.Parametreid);
            if (entity != null)
            {
                entity = parametre;
                contextParam.Update(entity);
            }
            int i = await contextParam.SaveChangesAsync();
            return i > 0;
        }

        public async Task<ListeParametre> GetListParamByUser(int id)
        {
            return await contextParam.ListeParametres.Where(p => p.Utilisateurid == id).FirstAsync();
        }

        public async Task<List<ListeParametre>> GetListAllParamByUser(int id)
        {
            return await contextParam.ListeParametres.Where(p => p.Utilisateurid == id).ToListAsync<ListeParametre>();
        }

        public async Task<Parametre> GetParametreByFichiste(long idFichiste)
        {
            Parametre param = new();
            param = await contextParam.Parametres.Where(p => p.Fichisteid == idFichiste).FirstAsync();
            return param;
        }

        public async Task<List<Patiant>> getListPatiantInParamNonTerminer(int numParam)
        {
            return await contextParam.Patiants.Where(p => p.Numeroparametre == numParam && p.Statut == null && p.Datepassage.Date < DateTime.Now.Date).ToListAsync();
        }
    }
}
