using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employees {
    public class Designer : Employee{

        public Designer(string name, string cpf) : base(name, cpf, 5000.00) {

        }

        public override void IncreaseSalary() {
            Salary *= 1.11;
        }

        internal protected override double GetSalaryBonus() {
            return Salary * 0.17;
        }
    }
}
