using Library.Application.Interfaces;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using Library.Infrastructure.Data;
using Library.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly LibraryContext _libraryContext;
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterRepository(LibraryContext libraryContext, UserManager<IdentityUser> userManager)
        {
            _libraryContext = libraryContext;
            _userManager = userManager;
        }

        public async Task<Client> InsertUserInTheDatabase(string email, string username, string password, Address address)
        {
            var identity = new IdentityUser()
            {
                Email = email,
                UserName = username,
            };
            using var transaction = _libraryContext.Database.BeginTransaction();
            var createdIdentity = await _userManager.CreateAsync(identity, password);
            if (!createdIdentity.Succeeded)
            {
                transaction.RollbackAsync();
                string errorMessage = createdIdentity.Errors.First().Description;
                throw new CreateUserException(errorMessage);
            }
            Client client = new Client(identity.Id, username, password, address, email);
            _libraryContext.Clients.Add(client);
            try
            {
                await _libraryContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return client;
            }
            catch (Exception ex)
            {
                transaction.RollbackAsync();
                throw ex;
            }
        }
    }

}
