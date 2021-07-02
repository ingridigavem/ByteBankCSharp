using ByteBank.Models;
using ByteBank.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank {
    public class CommercialPartner : IAuthenticable {

        private AuthenticationHelper _authenticationHelper = new AuthenticationHelper(); 

        public string Password { get; set; }

        public bool Authenticate(string password) {
            return _authenticationHelper.ComparePasswords(Password, password);
        }

    }
}
