using Abp.Domain.Repositories;
using RentalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalSystem.Extensions
{
    public static class ClientExtension
    {
        public static bool ClientExists(this IRepository<Client, long> clientRepository, string email)
        {
            bool _clientExists = false;

            _clientExists = clientRepository.GetAll()
                .Any(c => c.Email.ToLower() == email);

            return _clientExists;
        }
    }
}
