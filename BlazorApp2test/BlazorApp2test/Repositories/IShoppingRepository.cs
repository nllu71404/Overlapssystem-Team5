using BlazorApp2test.Models;

namespace BlazorApp2test.Repositories
{
    public interface IShoppingRepository
    {
        List<Shopping> GetAllShopping();
        List<Shopping> GetShoppingByResidentId(int residentId);
        int SaveNewShopping(Shopping shopping);
        void DeleteShopping(int shoppingId);
        void UpdateShopping(Shopping shopping);
    }
}
