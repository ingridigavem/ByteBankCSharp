using ByteBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ByteBank.Accounts {

    /// <summary>
    /// Define uma Conta Corrente do banco ByteBank.
    /// </summary>

    public class CheckingAccount : IComparable {
        
        public static double Fee { get; private set; } // taxa de operacao
        public static int TotalAccountsCreated { get; private set; }
        public Client Holder { get; set; } // titular    
        public int Branch { get; } // agencia
        public int Number { get; }

        private double _balance = 0;
        public double Balance {
            get {
                return _balance;
            }
            set {
                if (value < 0) {
                    return;
                }
                _balance = value;
            }
        }

        /// <summary>
        /// Cria uma instância de ContaCorrente com os argumentos utilizados.
        /// </summary>
        /// <param name="branch">Representa o valor da propriedade <see cref="Branch"/> e deve possuir um valor maior do que zero.</param>
        /// <param name="number">Representa o valor da propriedade <see cref="Number"/> e deve possuir um valor maior do que zero.</param>

        public CheckingAccount(int branch, int number) {

            if(branch <= 0) {
                throw new ArgumentException("O número da agência deve ser maior que 0.", nameof(branch));
            }
            
            if (number <= 0) {
                throw new ArgumentException("O número da conta deve ser maior que 0.", nameof(number));
            }

            Branch = branch;
            Number = number;

            TotalAccountsCreated++;
            Fee = 30 / TotalAccountsCreated; // qto mais contas existentes no banco menor a taxa

        }

        /// <summary>
        /// Realiza o saque e atualiza o valor da propriedade <see cref="Balance"/>.
        /// </summary>
        /// <exception cref="ArgumentException">Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="amount"/>.</exception>
        /// <exception cref="InsufficientBalanceException">Execção lançada quando o valor de <paramref name="amount"/> é maior que o valor da propriedade <see cref="Balance"/>.</exception>
        /// <param name="amount">Representa a quantia de saque e deve ser maior que zero e menor que <see cref="Balance"/>.</param>

        public void Withdraw(double amount) {
            if(amount < 0) {
                throw new ArgumentException("Valor inválido para o saque.", nameof(amount));
            }

            if (_balance < amount) {
                throw new InsufficientBalanceException(Balance);
            }
            _balance -= amount;
           
        }

        public void Deposit(double amount) {
            _balance += amount;
        }
        
        public void Transfer(double amount, CheckingAccount destinationAccount) {
            if (amount < 0) {
                throw new ArgumentException("Valor inválido para a transferencia.", nameof(amount));
            }

            try {
                Withdraw(amount);
            } catch (InsufficientBalanceException e) {
                throw new FinancialOperationsException("Saldo insuficiente. Operação de transferência não realizada", e);
            }

            destinationAccount.Deposit(amount);
           
        }

        public override string ToString() {
            return $"Number: {Number}, Branch: {Branch}, Balance: {Balance}";
        }

        public override bool Equals(object obj) {
            CheckingAccount otherAccount = obj as CheckingAccount;

            if(otherAccount == null)  return false;

            return (Number == otherAccount.Number && Branch == otherAccount.Branch);
                
        }

        public int CompareTo(object obj) {
            CheckingAccount otherAccount = obj as CheckingAccount;

            if (otherAccount.Number == null) {
                return -1;
            }
            if (Number < otherAccount.Number) {
                return -1;
            }
            if (Number == otherAccount.Number) {
                return 0;
            }

            return 1;
        }
    }
}
