using learnApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace learnApp.services
{
    public interface IAdminService
    {
        bool login(string Email, string Password);
        bool ChangePassword(string Email, string Password);
        bool ForgotPassword(string Email);
    }
    public class AdminService : IAdminService
    {
        public enjoy_learn_DBEntities context { get; set; }
        public AdminService()
        {
            context = new enjoy_learn_DBEntities();
        }


        public bool ChangePassword(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public bool ForgotPassword(string Email)
        {
            throw new NotImplementedException();
        }

        public bool login(string Email, string Password)
        {
            return context.admins.Where(a => a.email == Email && a.password == Password).Any();
        }
    }
}