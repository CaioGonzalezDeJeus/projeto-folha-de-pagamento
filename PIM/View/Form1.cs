using PIM.Control;
using PIM.Model;
using PIM.View;

namespace PIM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usuario usuario = new usuario();
            CTR_usuario cTR_Usuario = new CTR_usuario();
            usuario.nome = textBox1.Text;
            usuario.senha = textBox2.Text;

            if (cTR_Usuario.verifLogin(usuario) == true)
            {
                administrador administrador = new administrador();
                Form2 form2 = new Form2();
                form2.habilitar(administrador);
                form2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Erro ao entrar");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usuario usuario = new usuario();
            CTR_usuario cTR_Usuario = new CTR_usuario();
            usuario.nome = textBox1.Text;
            usuario.senha = textBox2.Text;

            if (cTR_Usuario.verifLogin(usuario) == true)
            {
                funcionario funcionario = new funcionario();
                Form2 form2 = new Form2();
                form2.habilitar(funcionario);
                form2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Erro ao entrar");
            }
            /*funcionario funcionario = new funcionario();           
            funcionario.nome = textBox1.Text;
            funcionario.senha = textBox2.Text;
            string abre_arq = @"C:\Users\Caio\Downloads\PIM\PIM\BD\Folha_Pagamento.xlsx";
            if (File.Exists(abre_arq))
            {
                CTR_funcionario cTR_Funcionario = new CTR_funcionario(abre_arq);
                if(cTR_Funcionario.verifLoginFun(funcionario, abre_arq) != null)
                {
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Erro ao entrar");
                }
            }*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}