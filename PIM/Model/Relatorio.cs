using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.Model
{
    public class relatorio
    {
        //atributos
        public int numRelatorio { get; }
        public string mes { get; set; }
        public relatorio() //construtor
        {
            //inserindo um valor ex em cada atrubuto e conectando classes
            numRelatorio = 1;
            mes = "Janeiro";
        }
    }
}
