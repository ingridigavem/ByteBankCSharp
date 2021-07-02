using System;
using System.IO;
using System.Text;
using ByteBank.Models;

namespace ByteBank.ImportationExportation { 

    partial class Program {
        static void LidandoComFileStreamDiretamente() {
            //Lendo arquivo

            var fileAddress = "contas.txt";

            using (var fluxoDoArquivo = new FileStream(fileAddress, FileMode.Open)) { // garante o fechamento sempre

                var buffer = new byte[1024]; // array de 1kb

                var numeroDeBytesLidos = -1;

                while (numeroDeBytesLidos != 0) {
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    EscreverBuffer(buffer, numeroDeBytesLidos);
                }
            }
        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos) {

            var utf8 = new UTF8Encoding();

            var texto = utf8.GetString(buffer, 0, bytesLidos);
            Console.Write(texto);

            //foreach (var meuByte in buffer) {
            //    Console.Write(meuByte);
            //    Console.Write(" ");
            //}
        }
    }



}