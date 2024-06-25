using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIM.Dao;
using PIM.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace PIM.Control
{
    public class CTR_administrador : CTR_usuario
    {
        //metodos
        DaoAdm dao;

        public CTR_administrador(string banco)
        {
            dao = new DaoAdm(banco);
        }

        public void C_novoAdm(administrador administrador)
        {
            if (administrador.numUser != 0) // && carta.nome != "" )
            {
                dao.createAdm(administrador); // slq no BD
            }
        }

        public administrador R_buscarAdm(administrador administrador)
        {
            return dao.readAdm(administrador);
        }

        public void U_alteraAdm(administrador administrador)
        {
            administrador temp = new administrador();

            temp.numUser = administrador.numUser;
            temp = R_buscarAdm(temp);

            //  if (temp.numUser != "")
            // {
            dao.updateAdm(administrador);
            // }
        }

        public void D_excluiAdm(administrador administrador)
        {
            administrador temp = new administrador();

            temp.numUser = administrador.numUser;
            temp = R_buscarAdm(temp);

            if (temp.numUser != 0)
            {
                dao.deleteAdm(administrador);
            }
        }
    }
}
