using PIM.Control;
using PIM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace PIM.View
{
    public partial class Form2 : Form
    {
        funcionario funcionario;
        administrador administrador;
        CTR_administrador CTR_administrador;
        CTR_funcionario CTR_funcionario;
        public Form2()
        {
            InitializeComponent();
            funcionario = new funcionario();
            administrador = new administrador();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //funcionario funcionario = new funcionario();
            //funcionario.idade = DateTime.Now;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            comboBox1.Enabled = true;
            CTR_empresa cTR_Empresa = new CTR_empresa();
            comboBox1.Items.Add(1);
            comboBox1.Items.Add(2);
            comboBox1.Items.Add(3);
            comboBox1.Items.Add(4);
            comboBox1.Items.Add(5);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*MessageBox.Show("Cargo inserido!");
            CTR_empresa cTR_Empresa = new CTR_empresa();
            empresa empresa = new empresa();
            cTR_Empresa.definCargo(empresa, Convert.ToInt16(comboBox1.SelectedItem));
            //form4.ShowDialog()*/
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }
        public void habilitar(administrador administrador)
        {
            label11.Visible = true;
            textBox16.Visible = true;
            textBox16.Enabled = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
        }
        public void habilitar(funcionario funcionario)
        {
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            funcionario.carteira_trabalho = Convert.ToInt16(textBox6.Text);
            //funcionario.idade = Convert.ToDateTime(dateTimePicker1);
            funcionario.ra = Convert.ToInt16(textBox4.Text);
            funcionario.numUser = Convert.ToInt16(textBox1.Text);
            funcionario.nome = textBox3.Text;
            funcionario.senha = textBox5.Text;
            funcionario.cpf = Convert.ToInt32(textBox2.Text);
            funcionario.rua = textBox7.Text;
            funcionario.bairro = textBox8.Text;
            funcionario.cidade = textBox9.Text;
            funcionario.estado = textBox10.Text;
            funcionario.numero = Convert.ToInt16(textBox11.Text);
            funcionario.cep = Convert.ToInt16(textBox12.Text);
            funcionario.contatos.tel1 = Convert.ToInt32(textBox13.Text);
            funcionario.contatos.tel2 = Convert.ToInt32(textBox14.Text);
            funcionario.contatos.email = textBox15.Text;
            empresa empresa = new empresa();
            CTR_usuario cTR_Usuario = new CTR_usuario();
            cTR_Usuario.selTipoConta(empresa);

            CTR_funcionario.C_novoFun(funcionario);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog abre_arq = new OpenFileDialog();
            //abre_arq.Filter = "*.xls|Microsoft Excel";

            abre_arq.Title = "Selecione o Arquivo";
            if (abre_arq.ShowDialog() == DialogResult.OK)
            {
                button9.Enabled = false;
                button6.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                label12.Visible = false;
                textBox17.Enabled = false;
                textBox17.Text = abre_arq.FileName;

                funcionario = new funcionario();
                CTR_funcionario = new CTR_funcionario(abre_arq.FileName);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            funcionario.numUser = Convert.ToInt16(textBox1.Text);
            funcionario = CTR_funcionario.R_buscarFun(funcionario);
            atualiza_textbox(funcionario);
        }

        private void atualiza_textbox(funcionario funcionario)
        {
            textBox2.Text = Convert.ToString(funcionario.cpf);
            textBox4.Text = Convert.ToString(funcionario.ra);
            textBox3.Text = funcionario.nome;
            textBox6.Text = Convert.ToString(funcionario.carteira_trabalho);
            //dateTimePicker1.Value = Convert.ToDateTime(funcionario.idade);
            textBox12.Text = Convert.ToString(funcionario.cep);
            textBox7.Text = funcionario.rua;
            textBox8.Text = funcionario.bairro;
            textBox9.Text = funcionario.cidade;
            textBox10.Text = funcionario.estado;
            textBox11.Text = Convert.ToString(funcionario.numero);
            textBox13.Text = Convert.ToString(funcionario.contatos.tel1);
            textBox14.Text = Convert.ToString(funcionario.contatos.tel2);
            textBox15.Text = funcionario.contatos.email;
        }
        private void atualiza_textbox(administrador administrador)
        {
            textBox1.Text = Convert.ToString(funcionario.numUser);
            textBox2.Text = Convert.ToString(funcionario.cpf);
            textBox3.Text = funcionario.nome;
            textBox12.Text = Convert.ToString(funcionario.cep);
            textBox7.Text = funcionario.rua;
            textBox8.Text = funcionario.bairro;
            textBox9.Text = funcionario.cidade;
            textBox10.Text = funcionario.estado;
            textBox11.Text = Convert.ToString(funcionario.numero);
            textBox13.Text = Convert.ToString(funcionario.contatos.tel1);
            textBox14.Text = Convert.ToString(funcionario.contatos.tel2);
            textBox15.Text = funcionario.contatos.email;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            funcionario.carteira_trabalho = Convert.ToInt16(textBox6.Text);
            //funcionario.idade = Convert.ToDateTime(dateTimePicker1);
            funcionario.ra = Convert.ToInt16(textBox4.Text);
            funcionario.numUser = Convert.ToInt16(textBox1.Text);
            funcionario.nome = textBox3.Text;
            funcionario.senha = textBox5.Text;
            funcionario.cpf = Convert.ToInt32(textBox2.Text);
            funcionario.rua = textBox7.Text;
            funcionario.bairro = textBox8.Text;
            funcionario.cidade = textBox9.Text;
            funcionario.estado = textBox10.Text;
            //funcionario.numero = Convert.ToInt16(textBox11.Text);
            //funcionario.cep = Convert.ToInt16(textBox12.Text);
            funcionario.contatos.tel1 = Convert.ToInt32(textBox13.Text);
            funcionario.contatos.tel2 = Convert.ToInt32(textBox14.Text);
            funcionario.contatos.email = textBox15.Text;
            empresa empresa = new empresa();
            CTR_usuario cTR_Usuario = new CTR_usuario();
            cTR_Usuario.selTipoConta(empresa);

            CTR_funcionario.U_alteraFun(funcionario);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            funcionario.numUser = Convert.ToInt16(textBox1.Text);

            CTR_funcionario.D_excluiFun(funcionario);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            administrador.idAdm = Convert.ToInt16(textBox16.Text);
            administrador.numUser = Convert.ToInt16(textBox1.Text);
            administrador.nome = textBox3.Text;
            administrador.senha = textBox5.Text;
            administrador.cpf = Convert.ToInt32(textBox2.Text);
            administrador.rua = textBox7.Text;
            administrador.bairro = textBox8.Text;
            administrador.cidade = textBox9.Text;
            administrador.estado = textBox10.Text;
            //administrador.numero = Convert.ToInt16(textBox11.Text);
            //administrador.cep = Convert.ToInt16(textBox12.Text);
            administrador.contatos.tel1 = Convert.ToInt32(textBox13.Text);
            administrador.contatos.tel2 = Convert.ToInt32(textBox14.Text);
            administrador.contatos.email = textBox15.Text;

            CTR_administrador.C_novoAdm(administrador);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string banco = textBox17.Text;
            CTR_administrador cTR_Administrador = new CTR_administrador(banco);
            administrador.numUser = Convert.ToInt16(textBox1.Text);
            administrador = cTR_Administrador.R_buscarAdm(administrador);
            atualiza_textbox(administrador);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            administrador.numUser = Convert.ToInt16(textBox1.Text);
            administrador.nome = textBox3.Text;
            administrador.senha = textBox5.Text;
            administrador.cpf = Convert.ToInt32(textBox2.Text);
            administrador.rua = textBox7.Text;
            administrador.bairro = textBox8.Text;
            administrador.cidade = textBox9.Text;
            administrador.estado = textBox10.Text;
            //administrador.numero = Convert.ToInt16(textBox11.Text);
            //administrador.cep = Convert.ToInt16(textBox12.Text);
            administrador.contatos.tel1 = Convert.ToInt32(textBox13.Text);
            administrador.contatos.tel2 = Convert.ToInt32(textBox14.Text);
            administrador.contatos.email = textBox15.Text;

            CTR_administrador.U_alteraAdm(administrador);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            administrador.numUser = Convert.ToInt16(textBox1.Text);

            CTR_administrador.D_excluiAdm(administrador);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
        }
    }
}
