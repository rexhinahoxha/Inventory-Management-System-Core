using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InventoryManegementSystemCore.View;
using InventoryManegementSystemCore.Model;
using InventoryManegementSystemCore.BusinessLogic;

namespace InventoryManegementSystemCore.Controllers
{
    
    public class UsersController : Controller
    {
        private readonly UsersRepository repository;
        public UsersController(UsersRepository category)
        {
            this.repository = category;
        }

        public  Boolean AuthenticateUser(string userName, string password)
        {
            bool istrue = false;
            Users user = new Users();
            user.UserName = userName;
            user.Password = password;
            try
            {
                istrue = repository.AuthenticateUser(user);                
            }

            catch (Exception exc)
            {
                throw exc;
            }
            return (istrue);
        }

        public  ErrorMessage UserExists(string userName, string password)
        {
            ErrorMessage response = new ErrorMessage();
            response.isOk = false;
            response.errorMessage = "Password incorrect!";

            Users user = new Users();
            user.UserName = userName;
            user.Password = password;
            try
            {
                response.isOk = repository.AuthenticateUser(user);
                if (response.isOk) response.errorMessage = "200";
            }

            catch (Exception exc)
            {
                response.isOk = false;
                response.errorMessage = exc.ToString();
            }
            return response;
        }

        public async Task<ActionResult<ErrorMessage>> GetUser(string userName, string password)
        {
            ErrorMessage response = new ErrorMessage();
            response.isOk = false;
            response.errorMessage = "Password incorrect!";

            Users user = new Users();
            user.UserName = userName;
            user.Password = password;
            try
            {
                response.isOk = await repository.User(user);
                if (response.isOk) response.errorMessage = "200";
            }

            catch (Exception exc)
            {
                response.isOk = false;
                response.errorMessage = exc.ToString();
            }
            return response;
        }

        public async Task<ActionResult<IEnumerable<Users>>> GetAllUsers()
        {
            return await repository.GetAllUsers();
        }

    }
}