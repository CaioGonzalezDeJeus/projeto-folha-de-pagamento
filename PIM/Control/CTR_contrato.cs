using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using PIM.Model;

namespace PIM.Control
{
    public class CTR_contrato
    {
        //metodos
        public contrato addSaida(contrato contrato)
        {
            //Adicionando saida do funcionário da empresa
            contrato.saida = DateTime.Today;
            return contrato;
        }

        public contrato cancelBeneficios(contrato contrato, int cancelar)
        {
            //Cancelando beneficios do funcionário
            Console.WriteLine("Deseja cancelar o convenio médico deste funcioário? \nDigite 1 para sim e 0 para não:");
            cancelar = Convert.ToInt16(Console.ReadLine());
            if (cancelar == 1)
            {
                contrato.beneficios.convenioMedico = false;
            }
            else
            {

            }

            Console.WriteLine("Deseja cancelar o convenio odontológico deste funcioário? \nDigite 1 para sim e 0 para não:");
            cancelar = Convert.ToInt16(Console.ReadLine());
            if (cancelar == 1)
            {
                contrato.beneficios.convenioOdonto = false;
            }
            else
            {

            }

            Console.WriteLine("Deseja cancelar o transporte deste funcioário? \nDigite 1 para sim e 0 para não:");
            cancelar = Convert.ToInt16(Console.ReadLine());
            if (cancelar == 1)
            {
                contrato.beneficios.transporte = false;
            }
            else
            {

            }
            return contrato;
        }
        public contrato calculosalarioL(contrato contrato)
        {
            
            empresa empresa = new empresa();
            CTR_empresa cTR_Empresa = new CTR_empresa();
            //Fazendo o calculo do salario liquido
            contrato.salario_liquido =  contrato.salario_bruto - contrato.descontos.desc;

            if (contrato.beneficios.convenioMedico == true)
            {
                contrato.salario_liquido = contrato.salario_liquido - 50;
            }
            if (contrato.beneficios.convenioOdonto == true)
            {
                contrato.salario_liquido = contrato.salario_liquido - 30;
            }
            if (contrato.beneficios.transporte == true)
            {
                contrato.salario_liquido = contrato.salario_liquido - 20;
            }
           //Inserir aqui quantidade de extras ex:
            contrato.salario_liquido = contrato.salario_liquido + Convert.ToDouble(cTR_Empresa.addExtras(empresa));

            return contrato;
        }
    }
}
