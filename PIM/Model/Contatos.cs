using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PIM.Model
{
    public class contatos
    {
        //atributos
        public int tel1 { get; set; }
        public int tel2 { get; set; }
        public string email { get; set; }
        public contatos() //construtor
        {
            //inserindo um valor ex em cada atrubuto
        }
        //metodos
        public contatos altTel1(int tel1)
        {
            //alterando valor
            contatos contatos = new contatos();
            this.tel1 = tel1;
            return contatos;
        }
        public contatos altTel2(int tel2)
        {
            //alterando valor
            contatos contatos = new contatos();
            this.tel2 = tel2;
            return contatos;
        }
        public contatos altEmail(string email)
        {
            //alterando valor
            contatos contatos = new contatos();
            this.email = email;
            return contatos;
        }
    }
}
