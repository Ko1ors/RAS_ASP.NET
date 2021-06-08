using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Services
{
    public class DishService : IService<DishEntity>
    {
        private ModelStateDictionary _modelState;
        private IDishDAO _DAO;

        public DishService(ModelStateDictionary modelState, IDishDAO DAO)
        {
            _modelState = modelState;
            _DAO = DAO;
        }

        public bool Validate(DishEntity dish)
        {
            if (dish.DishName.Trim().Length == 0)
                _modelState.AddModelError("Name", "Name is required.");
            if (dish.Price < 0)
                _modelState.AddModelError("Price", "Price cannot be less than zero.");
            if (dish.Weight < 0)
                _modelState.AddModelError("Weight", "Weight cannot be less than zero.");
            return _modelState.IsValid;
        }

        public IEnumerable<DishEntity> List()
        {
            return _DAO.GetAll();
        }

        public bool Exists(int id)
        {
            if (_DAO.GetById(id) is null)
                return false;
            return true;
        }

        public DishEntity Get(int id)
        {
            return _DAO.GetById(id);
        }

        public bool Create(DishEntity dish)
        {
            if (!Validate(dish))
                return false;

            try
            {
                _DAO.SaveOrUpdate(dish);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Edit(int id, DishEntity dishEdited)
        {
            try
            {
                var dish = _DAO.GetById(id);

                dish.Component = dishEdited.Component;
                dish.Cuisine = dishEdited.Cuisine;
                dish.DishName = dishEdited.DishName;
                dish.Order = dishEdited.Order;
                dish.Price = dishEdited.Price;
                dish.Weight = dishEdited.Weight;

                if (!Validate(dish))
                    return false;

                _DAO.SaveOrUpdate(dish);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Delete(DishEntity dish)
        {
            try
            {
                _DAO.Delete(dish);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
