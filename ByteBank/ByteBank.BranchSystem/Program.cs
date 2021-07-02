using ByteBank.Accounts;
using ByteBank.Employees;
using ByteBank.Exceptions;
using ByteBank.Systems;
using Humanizer;
using System;
using System.Collections.Generic;

namespace ByteBank.BranchSystem {
    class Program {
        static void Main(string[] args) {               

            try {
                CreateAccount();
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                CheckingAccountLists();
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                UseSystem();
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                TotalSalaryBonus();
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                CalculateDate();
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");

            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine("A execução finalizou. Tecle Enter para finalizar...");
            Console.ReadLine();
        }

        public static void CreateAccount() {
            Console.WriteLine();
            Console.WriteLine("####### Resultado do Método CreateAccount #######");

            try {
                var account1 = new CheckingAccount(103, 254689);
                var account2 = new CheckingAccount(103, 986527);

                Console.WriteLine();
                Console.WriteLine("Conta criada: " + account1);
                Console.WriteLine("Conta criada: " + account2);

                Console.WriteLine();
                account1.Deposit(500);
                Console.WriteLine("Saldo conta 1: " + account1.Balance);
                Console.WriteLine("Saldo conta 2: " + account2.Balance);

                Console.WriteLine();
                account1.Transfer(50, account2);
                Console.WriteLine("Saldo conta 1 após trasferencia: " + account1.Balance);
                Console.WriteLine("Saldo conta 2 após transferencia: " + account2.Balance);

                Console.WriteLine();
                Console.WriteLine($"Taxa de operação atual: {CheckingAccount.Fee}");

                Console.WriteLine();
                Console.WriteLine("Contas: ");
                Console.WriteLine(account1);
                Console.WriteLine(account2);

            } catch (ArgumentException e) {

                Console.WriteLine(e.Message);

            } catch (InsufficientBalanceException e) {

                Console.WriteLine(e.Message);

            } catch (FinancialOperationsException e) {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.InnerException.StackTrace);
            }


        }

        public static void CheckingAccountLists() {
            Console.WriteLine();
            Console.WriteLine("####### Resultado do Método CheckingAccontLists #######");
            Console.WriteLine();

            var contas = new List<CheckingAccount>() {
                new CheckingAccount(103, 6),
                new CheckingAccount(153, 5),
                new CheckingAccount(101, 2),
                new CheckingAccount(103, 1)
            };

            contas.Sort();
            Console.WriteLine("Contas ordenadas:");
            foreach (var conta in contas) {
                Console.WriteLine(conta);
            }

        }

        public static void UseSystem() {
            Console.WriteLine();
            Console.WriteLine("####### Resultado do Método UseSystem #######");
            Console.WriteLine();

            InternalSystem internalSystem = new InternalSystem();

            Director roberta = new Director("Roberta", "159.753.398-04");
            AccountManager camila = new AccountManager("Camila", "326.985.628-89");
            CommercialPartner commercialPartner1 = new CommercialPartner();
            roberta.Password = "123";
            camila.Password = "321";
            commercialPartner1.Password = "abc";

            Console.WriteLine("Teste com login correto:");
            internalSystem.LogInto(roberta, "123");
            internalSystem.LogInto(camila, "321");
            internalSystem.LogInto(commercialPartner1, "abc");
            Console.WriteLine();
            Console.WriteLine("Teste com login errado:");
            internalSystem.LogInto(camila, "32154654561");
            internalSystem.LogInto(commercialPartner1, "djfaiofjiao");


        }

        public static void TotalSalaryBonus() {
            Console.WriteLine();
            Console.WriteLine("####### Resultado do Método TotalSalaryBonus #######");
            Console.WriteLine();

            SalaryBonusManager salaryBonusManager = new SalaryBonusManager();

            Designer pedro = new Designer("Pedro", "833.222.048-39");
            Director roberta = new Director("Roberta", "159.753.398-04");
            Assistant igor = new Assistant("Igor", "981.198.778-53");
            AccountManager camila = new AccountManager("Camila", "326.985.628-89");

            
            salaryBonusManager.Register(pedro);
            salaryBonusManager.Register(roberta);
            salaryBonusManager.Register(igor);
            salaryBonusManager.Register(camila);

            Console.WriteLine($"Total de bonificações -> R$: {salaryBonusManager.GetTotalSalaryBonus()}");
        }

        public static void CalculateDate() {
            Console.WriteLine();
            Console.WriteLine("####### Resultado do Método CalculateDate #######");

            DateTime paymentEndDate = new DateTime(2021, 8, 15);
            DateTime currentDate = DateTime.Now;

            TimeSpan differenceBetweenDates = paymentEndDate - currentDate;


            Console.WriteLine($"Data atual: {currentDate}");
            Console.WriteLine($"Data fim de pagamento: {paymentEndDate}");
            Console.WriteLine($"Vencimento em : {TimeSpanHumanizeExtensions.Humanize(differenceBetweenDates)}");
        }


    }
}
