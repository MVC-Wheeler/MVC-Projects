using Ecom.Models;

namespace Ecom.Repo.IRepo
{
    public interface IProductRepo
    {
        //crud product
        void Add(Product product);
        List<Product> GetAll();
        Product GetById(int? id);
        void Update(Product product);
        void Delete(Product product);

        void Save();





    }
}
