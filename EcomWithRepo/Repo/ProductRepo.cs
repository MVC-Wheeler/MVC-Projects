using Ecom.Data;
using Ecom.Models;
using Ecom.Repo.IRepo;

namespace Ecom.Repo
{
    public class ProductRepo : IProductRepo
    {
        // controler --> iRepo --> context(db)
        readonly AppDbContext _context;
        public ProductRepo(AppDbContext _context)
        {
            this._context = _context;
            
        }
        public void Add(Product product)
        {
           _context.Products.Add(product);
            //_context.SaveChanges();
        }

        public void Delete(Product product)
        {
           _context.Products.Remove(product);
            //_context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int? id)
        {
            return _context.Products.Find(id);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            //_context.SaveChanges();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
