using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIM.Dao;
using PIM.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace PIM.Control
{
    public class CTR_funcionario : CTR_usuario
    {
        //metodos
        DaoFun dao;

        public CTR_funcionario()
        {

        }
        public CTR_funcionario(string banco)
        {
            dao = new DaoFun(banco);
        }
        public funcionario enderecoCompleto(funcionario funcionario, string completo)
        {
            //Concatenando endereço 
            completo = "Cidade: " + funcionario.cidade + "\nEstado: " + funcionario.estado + "\nBaiorro: " + funcionario.bairro + "\nRua: " + funcionario.rua + "\nNumero: " + funcionario.numero + "\nCEP: " + funcionario.cep;
            return funcionario;
        }

        public contrato afastamento(int tempoAfastado)
        {
            contrato contrato = new contrato();
            if (tempoAfastado > 15)
            {
                contrato.salario_liquido = 0;
                Console.WriteLine("Funcionario afastado pelo INSS!");
            }
            return contrato;
        }
        public void C_novoFun(funcionario funcionario)
        {
            if (funcionario.numUser != 0)
            {
                dao.createFun(funcionario); // slq no BD
            }
        }

        public funcionario R_buscarFun(funcionario funcionario)
        {
            return dao.readFun(funcionario);
        }

        public void U_alteraFun(funcionario funcionario)
        {
            funcionario temp = new funcionario();

            temp.numUser = funcionario.numUser;
            temp = R_buscarFun(temp);

            //  if (temp.nome != "")
            // {
            dao.updateFun(funcionario);
            // }
        }

        public void D_excluiFun(funcionario funcionario)
        {
            funcionario temp = new funcionario();

            temp.numUser = funcionario.numUser;
            temp = R_buscarFun(temp);

            if (temp.nome != "")
            {
                dao.deleteFun(funcionario);
            }
        }
        /*public funcionario verifLoginFun(funcionario funcionario, string banco) //não esta funcionando
        {
            DaoFun dao = new DaoFun(banco);

            if (dao.verifLogin(funcionario))
            {
                return funcionario;
            }
            else
            {
                return null;
            }
        }*/
    }
}
