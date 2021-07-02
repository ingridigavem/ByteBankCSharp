using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employees {
    public abstract class Employee {
        public static int TotalEmployees { get; private set; }
        
        public string Name { get; set; }
        public string Cpf { get; private set; }
        public double Salary { get; protected set; }

        public Employee(string name, string cpf, double salary) {
            Name = name;
            Cpf = cpf;
            Salary = salary;
            TotalEmployees++;
        }
               

        public abstract void IncreaseSalary();
        internal protected abstract double GetSalaryBonus();

    }
}
