using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employees {
    public class Assistant : Employee{

        public Assistant(string name, string cpf) : base(name, cpf, 4000.00) {
            
        }

        public override void IncreaseSalary() {
            Salary *= 1.1;
        }

        internal protected override double GetSalaryBonus() {
            return Salary * 0.2;
        }
    }
}
