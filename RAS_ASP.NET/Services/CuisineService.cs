using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Services
{
    public class CuisineService : IService<CuisineEntity>
    {
        private ModelStateDictionary _modelState;
        private ICuisineDAO _DAO;

        public CuisineService(ModelStateDictionary modelState, ICuisineDAO DAO)
        {
            _modelState = modelState;
            _DAO = DAO;
        }

        public bool Validate(CuisineEntity cuisine)
        {
            if (cuisine.Name.Trim().Length == 0)
                _modelState.AddModelError("Name", "Name is required.");
            if (cuisine.CooksNumber < 0)
                _modelState.AddModelError("CooksNumber", "Cook number cannot be less than zero.");
            if (cuisine.AverageDish < 0)
                _modelState.AddModelError("AverageDish", "Average dish cannot be less than zero.");
            return _modelState.IsValid;
        }

        public IEnumerable<CuisineEntity> List()
        {
            return _DAO.GetAll();
        }

        public bool Exists(int id)
        {
            if (_DAO.GetById(id) is null)
                return false;
            return true;
        }

        public CuisineEntity Get(int id)
        {
            return _DAO.GetById(id);
        }

        public bool Create(CuisineEntity cuisine)
        {
            if (!Validate(cuisine))
                return false;

            try
            {
                _DAO.SaveOrUpdate(cuisine);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Edit(int id, CuisineEntity cuisineEdited)
        {
            try
            {
                var cuisine = _DAO.GetById(id);

                cuisine.AverageDish = cuisineEdited.AverageDish;
                cuisine.CooksNumber = cuisineEdited.CooksNumber;
                cuisine.DishesSummary = cuisineEdited.DishesSummary;
                cuisine.Restaurant = cuisineEdited.Restaurant;
                cuisine.Name = cuisineEdited.Name;

                if (!Validate(cuisine))
                    return false;

                _DAO.SaveOrUpdate(cuisine);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Delete(CuisineEntity cuisine)
        {
            try
            {
                _DAO.Delete(cuisine);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
