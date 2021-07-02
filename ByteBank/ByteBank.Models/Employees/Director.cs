using ByteBank.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employees {
    public class Director : AuthenticableEmployee {

        public Director(string name, string cpf) : base(name, cpf, 10000.00) {

        }
               
        public override void IncreaseSalary() {
            Salary *= 1.15;
        }

        internal protected override double GetSalaryBonus() {
            return Salary * 0.5;
        }

    
    }
}
