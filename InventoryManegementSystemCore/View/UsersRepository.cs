using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManegementSystemCore.Data;
using InventoryManegementSystemCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManegementSystemCore.View
{
    public class UsersRepository : EfCoreRepository<Users, Data.Furniture_InventoryContext>
    {
        private readonly Data.Furniture_InventoryContext context;
        public UsersRepository(Data.Furniture_InventoryContext context) : base(context)
        {
            this.context = context;
        }

        public bool AuthenticateUser(Users user)
        {
            bool isUser = false;

            Users existUser = context.Users.ToList().Find(x => x.UserName == user.UserName && x.Password==user.Password);
            if (existUser!= null && existUser.IsActive==true) isUser = true;
            return isUser;
        }

        public int returnIduser(Users user)
        {
            int idUser = 0;

            Users existUser = context.Users.ToList().Find(x => x.UserName == user.UserName && x.Password == user.Password);
            if (existUser != null && existUser.IsActive == true) idUser = existUser.Iduser;
            return idUser;
        }

        public async Task<bool> User(Users user)
        {

            int idUser = returnIduser(user);
            var existUser = await context.Set<Users>().FindAsync(idUser);
            if (existUser != null && existUser.IsActive == true)
                return true;

            else return false;
        }

        public Task<List<Users>> GetAllUsers()
        {
            return context.Users.ToListAsync();

        }

    }
}
