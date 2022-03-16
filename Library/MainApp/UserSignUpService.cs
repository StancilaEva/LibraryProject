using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
     public class UserSignUpService
    {

        public Client LogIn(String email,String password, List<Client> clients)
        {
            Client client = checkiIfEmailIsAlreadyUsed(email, clients);
            if (client == null)
            {
                throw new NonExistentUserException("this email is not in the database");
            }
            else

            if (!client.Password.Equals(password))
            {
                throw new WrongPasswordException("wrong password");
            }
            else
            return client;
            
        }
        public Client SignUp(Client client, List<Client> clients)
        { 
            if(isValid(client,clients))
            {
                throw new EmailAlreadyInUseException("this email is already being used by another user");
            }
            return client;
        }

        private bool isValid(Client client,List<Client> clients)
        {
            if (checkiIfEmailIsAlreadyUsed(client.Email, clients)==null){
                return false;
            }
            return true;
        }

        private Client checkiIfEmailIsAlreadyUsed(string email , List<Client> clients)
        {
            
            return  clients.Where((client) => client.Email.Equals(email)).FirstOrDefault();
            
        }
        
    }

   

}
