using LYRA.Models.Administration;
using Microsoft.EntityFrameworkCore;

namespace LYRA.Controllers.ControllerRole
{
    public class AvRolesService : IAvoirRoleService
	{

        readonly AVROLEContext contextRole;

        public AvRolesService(AVROLEContext _context)
        {
            contextRole = _context;
        }

        public List<AvoirRole> GetUtilisateurRole(int id)
        {
            List<AvoirRole> avoirRoles = new List<AvoirRole>();
            List<Urole> roles = new List<Urole>();
            List<int> utilisateurRole = new();
            avoirRoles = contextRole.AvoirRoles.Where(p => p.Utilisateurid == id).ToList();
            return avoirRoles;
        }

        public async Task<AvoirRole> CreateRoleUser(Int32 roleid, Int32 userid)
        {
            AvoirRole avRole = new();
            avRole.Roleid = roleid;
            avRole.Utilisateurid = userid;
            await contextRole.AvoirRoles.AddAsync(avRole);
            contextRole.SaveChanges();
            return avRole;
        }

        public async Task DeleteRoleUser(Int32 avRoleId, Int32 userid)
        {
            List<AvoirRole> avRoles = await contextRole.AvoirRoles.Where(p => p.Roleid == avRoleId
                                                              && p.Utilisateurid == userid).ToListAsync();

            if (avRoles != null)
            {
                foreach (var item in avRoles)
                {
                    contextRole.AvoirRoles.RemoveRange(item);
                    contextRole.SaveChanges();
                }
            }


        }

	}
}
