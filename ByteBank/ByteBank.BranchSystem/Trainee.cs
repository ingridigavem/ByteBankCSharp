using ByteBank.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.BranchSystem {
    public class Trainee : Employee{

        public Trainee(string name, string cpf) : base(name, cpf, 5000.00) {

        }

        public override void IncreaseSalary() {
          
        }

        protected override double GetSalaryBonus() {
            throw new NotImplementedException();
        }
    }
}
