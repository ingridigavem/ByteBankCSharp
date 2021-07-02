using ByteBank.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ByteBank.Systems {
    public class InternalSystem {
        public bool LogInto(IAuthenticable employee, string password) {

            bool authenticatedUser = employee.Authenticate(password);

            if (authenticatedUser) {
                Console.WriteLine("Welcome!");
                return true;
            } else {
                Console.WriteLine("Incorrect password!");
                return false;
            }
        }
    }
}
