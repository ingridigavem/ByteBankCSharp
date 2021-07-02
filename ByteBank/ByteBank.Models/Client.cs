using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank {
    public class Client {
        
        public string Name { get; set; }
        public string Occupation { get; set; }

        private string _cpf;
        public string CPF {
            get {
                return _cpf;
            }
            set {
                // Escrever a lógica de validação de CPF
                _cpf = value;
            }
        }

       
    }
}
