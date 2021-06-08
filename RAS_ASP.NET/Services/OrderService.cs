using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Services
{
    public class OrderService : IService<OrderEntity>
    {
        private ModelStateDictionary _modelState;
        private IOrderDAO _DAO;

        public OrderService(ModelStateDictionary modelState, IOrderDAO DAO)
        {
            _modelState = modelState;
            _DAO = DAO;
        }

        public bool Validate(OrderEntity order)
        {
            if (order.Date is null)
                _modelState.AddModelError("Date", "Date is required.");
            return _modelState.IsValid;
        }

        public IEnumerable<OrderEntity> List()
        {
            return _DAO.GetAll();
        }

        public bool Exists(int id)
        {
            if (_DAO.GetById(id) is null)
                return false;
            return true;
        }

        public OrderEntity Get(int id)
        {
            return _DAO.GetById(id);
        }

        public bool Create(OrderEntity order)
        {
            if (!Validate(order))
                return false;

            try
            {
                _DAO.SaveOrUpdate(order);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Edit(int id, OrderEntity orderEdited)
        {
            try
            {
                var order = _DAO.GetById(id);

                order.Date = orderEdited.Date;
                order.Dish = orderEdited.Dish;
                order.PayType = orderEdited.PayType;

                if (!Validate(order))
                    return false;

                _DAO.SaveOrUpdate(order);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Delete(OrderEntity order)
        {
            try
            {
                _DAO.Delete(order);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
