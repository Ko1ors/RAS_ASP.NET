using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Services
{
    public class ProductService : IService<ProductEntity>
    {
        private ModelStateDictionary _modelState;
        private IProductDAO _DAO;

        public ProductService(ModelStateDictionary modelState, IProductDAO DAO)
        {
            _modelState = modelState;
            _DAO = DAO;
        }

        public bool Validate(ProductEntity product)
        {
            if (product.Name.Trim().Length == 0)
                _modelState.AddModelError("Name", "Name is required.");
            if (product.AvailCount < 0)
                _modelState.AddModelError("AvailCount", "Available count cannot be less than zero.");
            return _modelState.IsValid;
        }

        public IEnumerable<ProductEntity> List()
        {
            return _DAO.GetAll();
        }

        public bool Exists(int id)
        {
            if (_DAO.GetById(id) is null)
                return false;
            return true;
        }

        public ProductEntity Get(int id)
        {
            return _DAO.GetById(id);
        }

        public bool Create(ProductEntity product)
        {
            if (!Validate(product))
                return false;

            try
            {
                _DAO.SaveOrUpdate(product);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Edit(int id, ProductEntity productEdited)
        {
            try
            {
                var product = _DAO.GetById(id);

                product.AvailCount = productEdited.AvailCount;
                product.Component = productEdited.Component;
                product.Name = productEdited.Name;
                product.Supply = productEdited.Supply;

                if (!Validate(product))
                    return false;

                _DAO.SaveOrUpdate(product);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Delete(ProductEntity product)
        {
            try
            {
                _DAO.Delete(product);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
