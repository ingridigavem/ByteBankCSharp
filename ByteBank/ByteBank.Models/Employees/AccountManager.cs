using ByteBank.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employees {
    public class AccountManager : AuthenticableEmployee {

        public AccountManager(string name, string cpf) : base(name, cpf, 6000.00) {

        }

        public override void IncreaseSalary() {
            Salary *= 1.05;
        }

        internal protected override double GetSalaryBonus() {
            return Salary * 0.25;
        }

    }
}
