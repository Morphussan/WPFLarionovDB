using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Interface;

namespace WpfApp2.Model
{
    public class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
