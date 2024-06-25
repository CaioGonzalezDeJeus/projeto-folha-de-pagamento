using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.Model
{
    public class empresa
    {
        //atributos
        public string nome { get; set; }
        public string cargo { get; set; }
        public double extras { get; set; }
        public contrato contrato;
        public empresa() //construtor
        {
            //inserindo um valor ex em cada atrubuto e conectando classes
            contrato = new contrato();
            nome = "Formandos SA";
            cargo = "Formados"; //se o Ernesto quiser, amém!
        }
    }
}
