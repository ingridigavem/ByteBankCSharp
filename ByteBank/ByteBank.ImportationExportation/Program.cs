using System;
using System.IO;
using System.Text;
using ByteBank.Accounts;
using ByteBank.Models;

namespace ByteBank.ImportationExportation {
    partial class Program {
        static void Main(string[] args) {

            //var linhasLidas = File.ReadAllLines("contas.txt");
            //foreach (var linha in linhasLidas) {
            //    Console.WriteLine(linha);

            //}
            foreach (var linha in File.ReadLines("contas.txt")) {

            Console.WriteLine(linha);
            
            }

            Console.ReadLine();
        }

    }
}
