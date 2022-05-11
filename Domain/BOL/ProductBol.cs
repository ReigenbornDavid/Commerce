using Common.Entities;
using DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BOL
{
    public class ProductBol
    {
        //Instances
        private ProductDal _productDal = new ProductDal();
        public readonly StringBuilder stringBuilder = new StringBuilder();
        //Properties
        //Methods
        public void Registrate(Product product)
        {
            if (ValidateProduct(product))
            {
                if (_productDal.GetByid(product.IdProduct) == null)
                {
                    _productDal.Insert(product);
                }
                else
                {
                    _productDal.Update(product);
                }
            }
        }

        public List<Product> GetProducts(Category category, Brand brand, Supplier supplier)
        {
            string query = "SELECT p.idProduct, p.description, p.cost, p.price, p.quantity, " +
                "c.name as category, s.name as supplier, b.name as brand, p.usd " +
                "FROM product p, supplier s, category c, brand b " +
                "WHERE p.idBrand = b.idBrand AND p.idCategory = c.idCategory " +
                "AND p.idSupplier = s.idSupplier ";
            if (category != null)
            {
                query = query + "AND p.idCategory = @idCategory ";
            }
            if (brand != null)
            {
                query = query + "AND p.idBrand = @idBrand ";
            }
            if (supplier != null)
            {
                query = query + "AND p.idSupplier = @idSupplier ";
            }
            query = query + "order by p.description;";
            return _productDal.GetByP(query, category, brand, supplier);
        }

        public List<Product> GetProducts()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetByName(string description, string categoryFilter, string supplierFilter, string brandFilter)
        {
            string query =
                "SELECT p.idProduct, p.description, p.cost, p.price, p.quantity, c.name as category, s.name as supplier, b.name as brand, p.usd " +
                "FROM product p, supplier s, category c, brand b " +
                "WHERE description like @Description and p.idBrand = b.idBrand and " +
                "p.idCategory = c.idCategory and p.idSupplier = s.idSupplier";
            if (categoryFilter != "")
            {
                query += " AND c.name = @CategoryFilter ";
            }
            if (supplierFilter != "")
            {
                query += " AND s.name = @SupplierFilter ";
            }
            if (brandFilter != "")
            {
                query += " AND b.name = @BrandFilter ";
            }
            query += " order by p.description";
            return _productDal.GetByName(description, query, categoryFilter, supplierFilter, brandFilter);
        }

        public Product GetById(int idProduct)
        {
            stringBuilder.Clear();

            if (idProduct == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _productDal.GetByid(idProduct);
            }
            return null;
        }

        public void Delete(int idProduct)
        {
            stringBuilder.Clear();

            if (idProduct == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _productDal.Delete(idProduct);
            }
        }

        private bool ValidateProduct(Product product)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(product.Code)) stringBuilder.Append("El campo Codigo es obligatorio");
            if (string.IsNullOrEmpty(product.Description)) stringBuilder.Append(Environment.NewLine + "El campo Descripcion es obligatorio");
            if (string.IsNullOrEmpty(product.Category.Name)) stringBuilder.Append(Environment.NewLine + "El campo Categoria es obligatorio");
            if (product.Cost <= 0) stringBuilder.Append(Environment.NewLine + "El campo Costo es obligatorio");
            if (product.Price <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");
            if (product.Quantity < 0) stringBuilder.Append(Environment.NewLine + "El campo Cantidad es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}
