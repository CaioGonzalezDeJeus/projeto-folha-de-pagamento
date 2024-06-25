using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.Model
{
    public class descontos
    {
        //atributos
        public double inss { get; set; }
        public double irrf { get; set; }
        public double refeicao { get; set; }
        public double fgts { get; set; }
        public int faltas { get; set; }
        public double desc { get; set; }
        public descontos() //construtor
        {
            //inserindo um valor ex em cada atrubuto
            faltas = 0;
            refeicao = 30;
        }
    }
}
