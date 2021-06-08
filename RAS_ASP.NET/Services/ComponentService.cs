using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Services
{
    public class ComponentService : IService<ComponentEntity>
    {
        private ModelStateDictionary _modelState;
        private IComponentDAO _DAO;

        public ComponentService(ModelStateDictionary modelState, IComponentDAO DAO)
        {
            _modelState = modelState;
            _DAO = DAO;
        }

        public bool Validate(ComponentEntity component)
        {
            if (component.NeedCount < 0)
                _modelState.AddModelError("NeedCount", "Need product count cannot be less than zero.");
            return _modelState.IsValid;
        }

        public IEnumerable<ComponentEntity> List()
        {
            return _DAO.GetAll();
        }

        public bool Exists(int id)
        {
            if (_DAO.GetById(id) is null)
                return false;
            return true;
        }

        public ComponentEntity Get(int id)
        {
            return _DAO.GetById(id);
        }

        public bool Create(ComponentEntity component)
        {
            if (!Validate(component))
                return false;

            try
            {
                _DAO.SaveOrUpdate(component);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Edit(int id, ComponentEntity componentEdited)
        {
            try
            {
                var component = _DAO.GetById(id);

                component.Dish = componentEdited.Dish;
                component.NeedCount = componentEdited.NeedCount;
                component.Product = componentEdited.Product;

                if (!Validate(component))
                    return false;

                _DAO.SaveOrUpdate(component);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Delete(ComponentEntity component)
        {
            try
            {
                _DAO.Delete(component);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
