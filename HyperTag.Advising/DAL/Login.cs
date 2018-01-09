using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class Login
    {
        public int LoginId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }

        public bool LoginCheck()
        {
            Users usr = new DAL.Users();
            usr.Email = Email;
            usr.Password = Password;
            if(usr.SelectByOthers())
            {
                this.Email = usr.Email;
                this.LoginId = usr.Id;
                this.Name = usr.Name;
                this.Type = usr.Type;
                return true;
            }
            return false;
        }

        public bool Logout ()
        {
            //this = new Login();
            return false;
        }
    }
}
