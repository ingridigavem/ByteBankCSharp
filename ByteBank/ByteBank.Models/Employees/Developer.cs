using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employees {
    public class Developer : Employee {

        public Developer(string name, string cpf) : base(name, cpf, 7000.00) {

        }

        public override void IncreaseSalary() {
            Salary *= 0.1;
        }

        internal protected override double GetSalaryBonus() {
            return Salary * 0.1;
        }

    
    }
}
