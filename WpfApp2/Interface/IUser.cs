using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Interface
{
    public interface IUser
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}
