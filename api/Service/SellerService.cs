using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface ISellerService
    {

        IEnumerable<Seller> GetAll();
        bool Add(Seller model);
        bool Delete(int id);
        bool Update(Seller model);
        Seller Get(int id);
    }

    public class SellerService : ISellerService
    {
        private readonly ClientDbContext _clientDbContext;

        public SellerService(ClientDbContext clientDbContext)
        {
            _clientDbContext = clientDbContext;
        }

        public IEnumerable<Seller> GetAll()
        {
            var result = new List<Seller>();

            try
            {
                result = _clientDbContext.Seller.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;

        }

        public Seller Get(int id)
        {
            var result = new Seller();

            try
            {
                result = _clientDbContext.Seller.Single(x => x.SellerId == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public bool Add(Seller model)
        {

            try
            {
                _clientDbContext.Add(model);
                _clientDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;

        }

        public bool Update(Seller model)
        {

            try
            {
                var originalModel = _clientDbContext.Seller.Single(x => x.SellerId == model.SellerId);

                originalModel.Name = model.Name;
                originalModel.LastName = model.LastName;
                originalModel.IdNumber = model.IdNumber;
                originalModel.Email = originalModel.Email;

                _clientDbContext.Update(originalModel);
                _clientDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;

        }

        public bool Delete(int id)
        {

            try
            {
                _clientDbContext.Entry(new Seller { SellerId = id }).State = EntityState.Deleted;
                _clientDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;

        }
    }
}
