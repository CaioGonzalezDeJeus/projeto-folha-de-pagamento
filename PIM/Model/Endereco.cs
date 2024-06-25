using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.Model
{
    public class endereco
    {
        //atributos
        public string rua { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public int numero { get; set; }
        public int cep { get; set; }
        public endereco() //construtor
        {
            //inserindo um valor ex em cada atrubuto
        }
        //metodos
        public endereco altRua(string rua)
        {
            //alterando valor
            endereco endereco = new endereco();
            this.rua = rua;
            return endereco;
        }
        public endereco altBairro(string bairro)
        {
            //alterando valor
            endereco endereco = new endereco();
            this.bairro = bairro;
            return endereco;
        }
        public endereco altCidade(string cidade)
        {
            //alterando valor
            endereco endereco = new endereco();
            this.cidade = cidade;
            return endereco;
        }
        public endereco altEstado(string estado)
        {
            //alterando valor
            endereco endereco = new endereco();
            this.estado = estado;
            return endereco;
        }
        public endereco altNum(int numero)
        {
            //alterando valor
            endereco endereco = new endereco();
            this.numero = numero;
            return endereco;
        }
        public endereco altCep(int cep)
        {
            //alterando valor
            endereco endereco = new endereco();
            this.cep = cep;
            return endereco;
        }
    }
}
