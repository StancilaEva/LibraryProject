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
    public class UserRegistrator : IUserRegistrator
    {
        private readonly LibraryContext _libraryContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRegistrator(LibraryContext libraryContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _libraryContext = libraryContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Client> InsertUserInTheDatabase(string email, string username, string password, Address address)
        {
            var identity = new IdentityUser()
            {
                Email = "admin@example.com",
                UserName = "admin",
            };
            using var transaction = _libraryContext.Database.BeginTransaction();
            var createdIdentity = await _userManager.CreateAsync(identity, password);
            if (!createdIdentity.Succeeded)
            {
                transaction.RollbackAsync();
                string errorMessage = createdIdentity.Errors.First().Description;
                throw new CreateUserException(errorMessage);
            }
             _userManager.AddToRoleAsync(identity, "Client").Wait();
           
            Client client = new Client(identity.Id, username, address, email);
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
