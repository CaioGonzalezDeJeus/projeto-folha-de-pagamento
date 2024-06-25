using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.Model
{
    public class contrato
    {
        //atributos
        public DateTime entrada { get; set; }
        public DateTime saida { get; set; }
        public double salario_bruto { get; set; }
        public double salario_liquido { get; set; }
        public descontos descontos;
        public beneficios beneficios;
        public contrato() //construtor
        {
            //inserindo um valor ex em cada atrubuto e conectando classes
            descontos = new descontos();
            beneficios = new beneficios();
        }
    }
}

