using LYRA.Models.Administration;

namespace LYRA.Controllers.ControllerRole
{
    public interface IURoleService
    {
        Task<List<Urole>> GetAllRole();
        Task<Urole> UpdateRole(Urole urole);
        Task<Urole> InsertRole(Urole urole);
        Task<Urole> GetUroleById(int id);
        bool DeleteUroleById(Urole urole);
        
    }
}
