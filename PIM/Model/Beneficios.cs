using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.Model
{
    public class beneficios
    {
        //atributos
        public bool convenioMedico { get; set; }
        public bool convenioOdonto { get; set; }
        public bool transporte { get; set; }
        public beneficios() //construtor
        {
            //inserindo um valor ex em cada atrubuto
            convenioMedico = true;
            convenioOdonto = true;
            transporte = true;
        }
    }
}
