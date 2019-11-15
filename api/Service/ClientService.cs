﻿using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IClientService {

        IEnumerable<Client> GetAll();
        bool Add(Client model);
        bool Delete(int id);
        bool Update(Client model);
        Client Get(int id);
    }
    public class ClientService:IClientService
    {
        private readonly ClientDbContext _clientDbContext;

        public ClientService(ClientDbContext clientDbContext) {
            _clientDbContext = clientDbContext;
        }

        public IEnumerable<Client> GetAll()
        {
            var result = new List<Client>();

            try
            {
                result = _clientDbContext.Client.ToList();
            }
            catch (System.Exception)
            {
                
            }

            return result;

        }

        public Client Get(int id) {
            var result = new Client();

            try
            {
                result = _clientDbContext.Client.Single(x => x.ClientId == id);
            }
            catch(System.Exception) {

            }
            return result;
        }

        public bool Add(Client model) {

            try
            {
                _clientDbContext.Add(model);
                _clientDbContext.SaveChanges();
            }
            catch(System.Exception) {
                return false;
            }

            return true;
            
        }

        public bool Update(Client model)
        {

            try
            {
                var originalModel = _clientDbContext.Client.Single(x => x.ClientId == model.ClientId);

                originalModel.Name = model.Name;
                originalModel.LastName = model.LastName;
                originalModel.IdNumber = model.IdNumber;
                originalModel.Bio = originalModel.Bio;

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
                _clientDbContext.Entry(new Client { ClientId = id }).State = EntityState.Deleted ;
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
