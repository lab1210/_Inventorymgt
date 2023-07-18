using Inventory_App.Models;

namespace Inventory_App.IServices
{
    public interface IRegisterService
    {
        Register AddUser(Register register);
    }
}
