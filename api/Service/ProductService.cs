﻿using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
        public interface IProductService
        {

            IEnumerable<Product> GetAll();
            bool Add(Product model);
            bool Delete(int id);
            bool Update(Product model);
            Product Get(int id);
        }

        public class ProductService : IProductService
        {
            private readonly ClientDbContext _clientDbContext;

            public ProductService(ClientDbContext clientDbContext)
            {
                _clientDbContext = clientDbContext;
            }

            public IEnumerable<Product> GetAll()
            {
                var result = new List<Product>();

                try
                {
                    result = _clientDbContext.Product.ToList();
                }
                catch (System.Exception)
                {

                }

                return result;

            }

            public Product Get(int id)
            {
                var result = new Product();

                try
                {
                    result = _clientDbContext.Product.Single(x => x.ProductId == id);
                }
                catch (System.Exception)
                {

                }
                return result;
            }

            public bool Add(Product model)
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

            public bool Update(Product model)
            {

                try
                {
                    var originalModel = _clientDbContext.Product.Single(x => x.ProductId == model.ProductId);

                    originalModel.Name = model.Name;
                    originalModel.Price = model.Price;
                    originalModel.Type = model.Type;
                    originalModel.Amount = originalModel.Amount;
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
                    _clientDbContext.Entry(new Product { ProductId = id }).State = EntityState.Deleted;
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
