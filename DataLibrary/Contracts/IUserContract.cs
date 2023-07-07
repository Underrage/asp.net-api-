using DataLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Contracts
{
    public interface IUserContract
    {
        void Register(User user);

        User Validate(string email, string password);
    }
}
