using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Services
{
    public class RestaurantService : IService<RestaurantEntity>
    {
        private ModelStateDictionary _modelState;
        private IRestaurantDAO _DAO;

        public RestaurantService(ModelStateDictionary modelState, IRestaurantDAO DAO)
        {
            _modelState = modelState;
            _DAO = DAO;
        }

        public bool Validate(RestaurantEntity restaurant)
        {
            if(restaurant.Name.Trim().Length == 0)
                _modelState.AddModelError("Name", "Name is required.");
            if(restaurant.Address.Trim().Length == 0)
                _modelState.AddModelError("Address", "Address is required.");
            if(restaurant.SeatCapacity < 0)
                _modelState.AddModelError("SeatCapacity", "Seat capacity cannot be less than zero.");
            return _modelState.IsValid;
        }

        public IEnumerable<RestaurantEntity> List()
        {
            return _DAO.GetAll();
        }

        public bool Exists(int id)
        {
            if (_DAO.GetRestaurantByID(id) is null)
                return false;
            return true;
        }

        public RestaurantEntity Get(int id)
        {
            return _DAO.GetRestaurantByID(id);
        }

        public bool Create(RestaurantEntity restaurant)
        {
            if (!Validate(restaurant))
                return false;

            try
            {
                _DAO.SaveOrUpdate(restaurant);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Edit(int id, RestaurantEntity restaurantEdited)
        {
            try
            {
                var restaurant = _DAO.GetRestaurantByID(id);

                restaurant.Address = restaurantEdited.Address;
                restaurant.CloseTime = restaurantEdited.CloseTime;
                restaurant.CooksSummary = restaurantEdited.CooksSummary;
                restaurant.Cuisines = restaurantEdited.Cuisines;
                restaurant.Name = restaurantEdited.Name;
                restaurant.OpenTime = restaurantEdited.OpenTime;
                restaurant.SeatCapacity = restaurantEdited.SeatCapacity;

                if (!Validate(restaurant))
                    return false;

                _DAO.SaveOrUpdate(restaurant);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Delete(RestaurantEntity restaurant)
        {
            try
            {
                _DAO.Delete(restaurant);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
