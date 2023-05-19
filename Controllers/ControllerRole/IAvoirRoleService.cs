using LYRA.Models.Administration;

namespace LYRA.Controllers.ControllerRole
{
    public interface IAvoirRoleService
	{
		List<AvoirRole> GetUtilisateurRole(int id);
		Task<AvoirRole> CreateRoleUser(Int32 roleid, Int32 iserid);
		Task DeleteRoleUser(Int32 avroleid, Int32 userid);
	}
}
