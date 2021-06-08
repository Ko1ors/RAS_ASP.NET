using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Services
{
    public class SupplyService : IService<SupplyEntity>
    {
        private ModelStateDictionary _modelState;
        private ISupplyDAO _DAO;

        public SupplyService(ModelStateDictionary modelState, ISupplyDAO DAO)
        {
            _modelState = modelState;
            _DAO = DAO;
        }

        public bool Validate(SupplyEntity supply)
        {
            if (supply.ProdQuantity < 0)
                _modelState.AddModelError("ProdQuantity", "Product quantity cannot be less than zero.");
            return _modelState.IsValid;
        }

        public IEnumerable<SupplyEntity> List()
        {
            return _DAO.GetAll();
        }

        public bool Exists(int id)
        {
            if (_DAO.GetById(id) is null)
                return false;
            return true;
        }

        public SupplyEntity Get(int id)
        {
            return _DAO.GetById(id);
        }

        public bool Create(SupplyEntity supply)
        {
            if (!Validate(supply))
                return false;

            try
            {
                _DAO.SaveOrUpdate(supply);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Edit(int id, SupplyEntity supplyEdited)
        {
            try
            {
                var supply = _DAO.GetById(id);

                supply.Date = supplyEdited.Date;
                supply.ProdQuantity = supplyEdited.ProdQuantity;
                supply.Product = supplyEdited.Product;

                if (!Validate(supply))
                    return false;

                _DAO.SaveOrUpdate(supply);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Delete(SupplyEntity supply)
        {
            try
            {
                _DAO.Delete(supply);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
