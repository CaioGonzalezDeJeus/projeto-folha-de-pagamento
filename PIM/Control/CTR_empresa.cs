using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIM.Model;

namespace PIM.Control
{
    public class CTR_empresa
    {
        //metodos
        public empresa definCargo(empresa empresa, int tipo)
        {
            contrato contrato = new contrato();
            //Definindo um cargo para cada numero
            //Console.WriteLine("Digite 1 para AnalistaI \nDigite 2 para AnalistaII \nDigite3 para analistaIII \nDigite 4 para estagiário \nDigite 5 para funcionário temporário \nDigite o numero do cargo que esse funcionário exerce");
            //tipo = Convert.ToInt16(Console.ReadLine());
            if (tipo == 1) { empresa.cargo = "AnalistaI"; contrato.salario_bruto = 2100; }
            else
            {
                if (tipo == 2) { empresa.cargo = "AnalistaII"; contrato.salario_bruto = 2300; }
                else
                {
                    if (tipo == 3) { empresa.cargo = "AnalistaIII"; contrato.salario_bruto = 2500; }
                    else
                    {
                        if (tipo == 4) { empresa.cargo = "Estagiário"; contrato.salario_bruto = 1100; }
                        else
                        {
                            if (tipo == 5) { empresa.cargo = "Temporário"; contrato.salario_bruto = 2100; }
                            else
                            {
                                empresa.cargo = "Este funcionário não tem cargo";
                            }
                        }
                    }
                }
            }
            return empresa;
        }
        public empresa addExtras(empresa empresa)
        {
            //Adicionando horas extras
            empresa.extras = empresa.extras * 100.75;
            return empresa;
        }
    }
}
