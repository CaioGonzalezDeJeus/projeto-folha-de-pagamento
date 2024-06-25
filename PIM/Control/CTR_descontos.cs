using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIM.Model;

namespace PIM.Control
{
    public class CTR_descontos
    {
        //metodos
        public descontos calcDesc(descontos desconto)
        {
            contrato contrato = new contrato();
            //Calculo do total de todos os descontos
            if (contrato.salario_bruto > 2299)
            {
               // contrato.salario_bruto 
                desconto.irrf = contrato.salario_bruto / 100 * 8;
                desconto.inss = contrato.salario_bruto / 100 * 10;
                desconto.fgts = contrato.salario_bruto / 100 * 9;
            }
            else
            {
                desconto.inss = contrato.salario_bruto / 100 * 9;
                desconto.irrf = contrato.salario_bruto / 100 * 7;
                desconto.fgts = contrato.salario_bruto / 100 * 8;
            }
            desconto.desc = desconto.inss + desconto.irrf + desconto.refeicao + desconto.fgts + desconto.faltas;
            return desconto;
        }
        public descontos descFaltas(descontos descontos)
        {
            //Descontando as faltas do funcionário
            descontos.faltas = descontos.faltas * 80;
            return descontos;
        }
    }
}
