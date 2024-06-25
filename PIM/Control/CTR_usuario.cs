using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIM.Dao;
using PIM.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace PIM.Control
{
    public class CTR_usuario : CTR_endereco
    {
        //metodos
        public usuario validarCpf(usuario usuario) //n pode retornar string, ta errado, mas veremos depois.
        {
            if (usuario.cpf > 0 && usuario.cpf < 100)
            {
                MessageBox.Show("O CPF é valido");
                return usuario;
            }
            else
            {
                MessageBox.Show("O CPF é invalido");
                return usuario;
            }
        }
        public usuario validarCep(usuario usuario) //n pode retornar string, ta errado, mas veremos depois.
        {
            if (usuario.cep > 0 && usuario.cep < 100)
            {
                MessageBox.Show("O CEP é valido");
                return usuario;
            }
            else
            {
                MessageBox.Show("O CEP é invalido");
                return usuario;
            }
        }
        public bool verifLogin(usuario usuario) // Provisório
        {                                       //Sem banco
            if (usuario.nome != "Admin" || usuario.senha != "admin")
            {
                return false;
            } else
            {
                return true;
            }
        }

        public void selTipoConta(empresa empresa)
        {
            //Sera puxado o cargo ralacionado ao funcionário
            CTR_empresa cTR_Empresa = new CTR_empresa();
            cTR_Empresa.definCargo(empresa, 0);
        }
    }
}
