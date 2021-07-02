using ByteBank.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Systems {
    public interface IAuthenticable {
        bool Authenticate(string password);
    }
}
