using ByteBank.Models;
using ByteBank.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employees {
    public abstract class AuthenticableEmployee : Employee, IAuthenticable{

        private AuthenticationHelper _authenticationHelper = new AuthenticationHelper();
        public string Password { get; set; }

        public AuthenticableEmployee(string name, string cpf, double salary) : base(name, cpf, salary) {

        }

        public bool Authenticate(string password) {
            return _authenticationHelper.ComparePasswords(Password, password);
        }
    }
}
