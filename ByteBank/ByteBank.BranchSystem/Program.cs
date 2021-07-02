using ByteBank.Accounts;
using ByteBank.BranchSystem.Comparators;
using ByteBank.BranchSystem.Extensions;
using ByteBank.Employees;
using ByteBank.Exceptions;
using ByteBank.Systems;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteBank.BranchSystem {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            var contas = new List<CheckingAccount>() {
                new CheckingAccount(103, 6),
                new CheckingAccount(153, 5),
                new CheckingAccount(101, 2),
                new CheckingAccount(103, 1)
            };

            //listaContas.Sort();
            //foreach (var conta in listaContas) {
            //    Console.WriteLine(conta);
            //}

            //listaContas.Sort(new CheckingAccountComparatorByBranch());
            //foreach (var conta in listaContas) {
            //    Console.WriteLine(conta);
            //}


            //var listaOrdenada = listaContas.OrderBy(listaContas => listaContas.Number);
            var listaOrdenada = contas.Where(conta => conta != null).OrderBy(conta => conta.Number);

            foreach (var conta in listaOrdenada) {
                Console.WriteLine(conta);
            }

            //TestaArrayComTipoGenerico();
            //TesteArray();

            try {
                
                //CalculateDate();
                //TotalSalaryBonus();
                //UseSystem();
                // CreateAccount();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        public static void TestaArrayComTipoGenerico() {
            Lists<int> idades = new Lists<int>();

            idades.AddSeveral(63, 15, 21, 50);
            idades.Remove(15);

            for(int i = 0; i < idades.Size; i++) {
                Console.WriteLine(idades[i]);
            }
            

            Lists<string> cursos = new Lists<string>();
            cursos.AddSeveral("C# Parte 1", "C# Parte 2", "C# Parte 3");
            for (int i = 0; i < cursos.Size; i++) {
                Console.WriteLine(cursos[i]);
            }

            Lists<CheckingAccount> contas = new Lists<CheckingAccount>();
            contas.AddSeveral(new CheckingAccount(124, 54354), new CheckingAccount(201, 44354));
            for (int i = 0; i < contas.Size; i++) {
                Console.WriteLine(contas[i]);
            }
        }
       
        public static void TesteArray() {

            CheckingAccountsList list = new CheckingAccountsList();
            list.AddAccount(new CheckingAccount(103, 654984));
            list.AddAccount(new CheckingAccount(103, 555566));
            list.AddAccount(new CheckingAccount(103, 265698));
            list.AddAccount(new CheckingAccount(103, 265698));

            list.AddSeveral(
                new CheckingAccount(100, 40010),
                new CheckingAccount(101, 40011),
                new CheckingAccount(103, 222565),
                new CheckingAccount(103, 222565),
                new CheckingAccount(103, 222565),
                new CheckingAccount(103, 222565),
                new CheckingAccount(103, 222565)
            );
            
            CheckingAccount contaTeste = new CheckingAccount(111, 111111);
            list.AddAccount(contaTeste);
            Console.WriteLine($"Conta {contaTeste.Number} adicionada");

            Console.WriteLine("Removendo a conta adicionada...");
            list.RemoveAccount(contaTeste);
            

            for (int i = 0; i < list.Size; i++) {
                CheckingAccount itemAtual = list.GetItemInIndex(i);
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Number}/{itemAtual.Branch}");
            }

        }

        
        public static void CreateAccount() {
            try {
                var account1 = new CheckingAccount(103, 254689);
                var account2 = new CheckingAccount(103, 986527);
               

                Console.WriteLine(account1);
                Console.WriteLine(account2);

                account1.Deposit(500);
                Console.WriteLine(account1.Balance);
                Console.WriteLine(account2.Balance);
                account1.Transfer(50, account2);
                Console.WriteLine(account1.Balance);
                Console.WriteLine(account2.Balance);

                Console.WriteLine($"Taxa de operação atual: {CheckingAccount.Fee}");

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

        public static void UseSystem() {

            InternalSystem internalSystem = new InternalSystem();

            Director roberta = new Director("Roberta", "159.753.398-04");
            AccountManager camila = new AccountManager("Camila", "326.985.628-89");
            CommercialPartner commercialPartner1 = new CommercialPartner();
            roberta.Password = "123";
            camila.Password = "321";
            commercialPartner1.Password = "abc";

            internalSystem.LogInto(roberta, "123");
            internalSystem.LogInto(camila, "321");
            internalSystem.LogInto(commercialPartner1, "abc");

        }

        public static void TotalSalaryBonus() {
            SalaryBonusManager salaryBonusManager = new SalaryBonusManager();

            Designer pedro = new Designer("Pedro", "833.222.048-39");
            Director roberta = new Director("Roberta", "159.753.398-04");
            Assistant igor = new Assistant("Igor", "981.198.778-53");
            AccountManager camila = new AccountManager("Camila", "326.985.628-89");

            salaryBonusManager.Register(pedro);
            salaryBonusManager.Register(roberta);
            salaryBonusManager.Register(igor);
            salaryBonusManager.Register(camila);

            Console.WriteLine($"Total de bonificacoes -> R$: {salaryBonusManager.GetTotalSalaryBonus()}");
        }

        public static void CalculateDate() {

            DateTime paymentEndDate = new DateTime(2021, 8, 15);
            DateTime currentDate = DateTime.Now;

            TimeSpan differenceBetweenDates = paymentEndDate - currentDate;


            Console.WriteLine($"Data atual: {currentDate}");
            Console.WriteLine($"Data fim de pagamento: {paymentEndDate}");
            Console.WriteLine($"Vencimento em : {TimeSpanHumanizeExtensions.Humanize(differenceBetweenDates)}");
        }


    }
}
