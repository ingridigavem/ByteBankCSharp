using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Exceptions {
    public class InsufficientBalanceException : FinancialOperationsException {

        public double Balance { get; }
       
        public InsufficientBalanceException() {

        }

        public InsufficientBalanceException(string message) 
            : base(message){
        
        }

        public InsufficientBalanceException(string message, Exception innerException)
            : base(message, innerException) {

        }

        public InsufficientBalanceException(double balance) 
            : this($"Saldo insuficiente para o saque. Saldo atual da conta: {balance}"){
            Balance = balance;
        }
    }
}
