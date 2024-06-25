using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.Model
{
    public class funcionario : usuario
    {
        //atributos
        public int carteira_trabalho { get; set; }
        public DateTime idade { get; set; }
        public int horas { get; set; }
        public int ra { get; set; }
        public contrato contrato;
        public funcionario() //construtor
        {
            //inserindo um valor ex em cada atrubuto e conectando classes
            contrato = new contrato();
        }
        public funcionario incluirFunc(int carteira_trabalho, string nome, int cpf, DateTime idade, int ra)
        {
            funcionario funcionario = new funcionario();
            this.carteira_trabalho = carteira_trabalho;
            this.nome = nome;
            this.cpf = cpf;
            this.idade = idade;
            this.ra = ra;
            return funcionario;
        }
    }
}
