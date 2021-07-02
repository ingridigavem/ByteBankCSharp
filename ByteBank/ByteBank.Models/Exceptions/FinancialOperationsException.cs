using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Exceptions {
    public class FinancialOperationsException : Exception {

        public FinancialOperationsException() {

        }
        public FinancialOperationsException(string message)
            : base(message){

        }

        public FinancialOperationsException(string message, Exception innerException) 
            : base (message, innerException){

        }
    }
}
