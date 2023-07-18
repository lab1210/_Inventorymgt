using Inventory_App.Models;


namespace Inventory_App.IServices
{
    public interface ILoginService
    {
        Login CheckUser(Login login);
        void StoreLoginName(string name);
       


        void clearLoginName();
    }
}
