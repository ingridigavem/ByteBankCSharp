using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employees {
    public class SalaryBonusManager {
        private double _totalSalaryBonus;

        public void Register(Employee employee) {
            _totalSalaryBonus += employee.GetSalaryBonus();
        }

        public double GetTotalSalaryBonus() {
            return _totalSalaryBonus;
        }
    }
}
