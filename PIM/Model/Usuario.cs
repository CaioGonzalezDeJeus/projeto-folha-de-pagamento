using PIM.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.Model
{
    public class usuario : endereco
    {
        //atributos
        public int numUser { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public int cpf { get; set; }
        public contatos contatos;
        public usuario() //construtor
        {
            //inserindo um valor ex em cada atrubuto e conectando classes
            contatos = new contatos();
            nome = "Juriscleiton";
        }
    }
}
