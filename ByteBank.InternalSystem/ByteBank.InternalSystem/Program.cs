using ByteBank.Accounts;
using System;

namespace ByteBank.InternalSystem {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            CheckingAccount conta = new CheckingAccount(123, 985623);

            conta.Withdraw(-50);

            Console.WriteLine(conta.Branch);
        }
    }
}
