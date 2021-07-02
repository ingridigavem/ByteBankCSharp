using System;
using System.IO;
using System.Text;
using ByteBank.Accounts;
using ByteBank.Models;

namespace ByteBank.ImportationExportation {
    partial class Program {
        static void UsandoStreamReader() {
            //Lendo arquivo

            var fileAddress = "contas.txt";
            using (var fluxoDoArquivo = new FileStream(fileAddress, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDoArquivo)) {
                //Console.WriteLine(leitor.ReadToEnd());
                //  ou
                while (!leitor.EndOfStream) {
                    var linha = leitor.ReadLine();
                    var contaCorrente = ConverterStringParaContaCorrente(linha);

                    var msg = $"Conta número: {contaCorrente.Number} | ag.: {contaCorrente.Branch} | saldo: {contaCorrente.Balance} | titular: {contaCorrente.Holder.Name}";
                    Console.WriteLine(msg);
                }
            }
        }

        static CheckingAccount ConverterStringParaContaCorrente(string linha) {
            string[] campos = linha.Split('|');

            var agencia = campos[0];
            var numero = campos[1];
            var saldo = campos[2].Replace('.', ',');
            var nomeTitular = campos[3];

            var saldoConvertido = double.Parse(saldo);

            var titular = new Client();
            titular.Name = nomeTitular;


            var resultado = new CheckingAccount(int.Parse(agencia), int.Parse(numero));
            resultado.Deposit(saldoConvertido);
            resultado.Holder = titular;

            return resultado;
        }
    }
}
