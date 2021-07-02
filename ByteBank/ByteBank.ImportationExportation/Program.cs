using System;
using System.IO;
using System.Text;
using ByteBank.Accounts;
using ByteBank.Models;

namespace ByteBank.ImportationExportation {
     class Program {
        static void Main(string[] args) {
            Console.WriteLine();
            Console.WriteLine("####### Leitura de arquivo de texto #######");
            Console.WriteLine();
            foreach (var linha in File.ReadLines("contas.txt")) {
                Console.WriteLine(linha);
            }

            Console.WriteLine();
            Console.WriteLine("####### Fim da leitura do arquivo de texto #######");
            Console.WriteLine();

            Console.WriteLine("A execução finalizou. Tecle Enter para finalizar...");
            Console.ReadLine();
        }

     }
}
