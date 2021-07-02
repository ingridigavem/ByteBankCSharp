using System;
using System.IO;
using System.Text;
using ByteBank.Accounts;
using ByteBank.Models;

namespace ByteBank.ImportationExportation {
    partial class Program {

        static void CriarArquivo() {

            var caminhoDoArquivo = "contasExportadas.csv";

            using (var fluxoDoArquivo = new FileStream(caminhoDoArquivo, FileMode.Create)) {

                var contaCorrenteDeTeste = "456,7895,4785.40,Gustavo Santos";

                var bytes = Encoding.UTF8.GetBytes(contaCorrenteDeTeste);

                fluxoDoArquivo.Write(bytes, 0, bytes.Length);
            }

        }

        static void CriarArquivoComWriter() {

            var caminhoDoArquivo = "contasExportadas.csv";

            using (var fluxoDoArquivo = new FileStream(caminhoDoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDoArquivo, Encoding.UTF8)) {
                var contaCorrenteDeTeste = "456,65456,478.32,Pedro Silva";

                escritor.Write(contaCorrenteDeTeste);
            }


        }
    }
}
