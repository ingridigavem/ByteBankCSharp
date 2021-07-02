using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Models {
    class AuthenticationHelper {

        public bool ComparePasswords(string password, string passwordAttempt) {

            return password == passwordAttempt;

        }

    }
}
