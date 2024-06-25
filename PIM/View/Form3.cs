using PIM.Control;
using PIM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PIM.View
{
    public partial class Form3 : Form
    {
        relatorio relatorio;
        contrato contrato;
        empresa empresa;
        beneficios beneficios;
        funcionario funcionario;
        CTR_funcionario CTR;
        public Form3()
        {
            relatorio = new relatorio();
            contrato = new contrato();
            empresa = new empresa();
            beneficios = new beneficios();
            funcionario = new funcionario();
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            funcionario fun = new funcionario();
            funcionario.ra = Convert.ToInt16(textBox1.Text);
            atualizaL(fun);
        }
        private void atualizaL(funcionario funcionario)
        {
            CTR_contrato cTR_Contrato = new CTR_contrato();
            descontos descontos = new descontos();
            beneficios beneficios = new beneficios();

            label12.Text = Convert.ToString(relatorio.numRelatorio);
            label13.Text = relatorio.mes;
            label14.Text = funcionario.nome;
            label15.Text = Convert.ToString(contrato.entrada);
            label16.Text = Convert.ToString(contrato.salario_bruto);
            //label17.Text = Convert.ToString(cTR_Contrato.calculosalarioL(contrato));
            label17.Text = Convert.ToString(contrato.salario_liquido);
            label18.Text = empresa.nome;
            label19.Text = empresa.cargo;
            label20.Text = "inss: -R$" + descontos.inss + "\nirrf: -R$" + descontos.irrf + "\nrefeição: -R$" + descontos.refeicao + "\nfgts: -R$" + descontos.fgts + "\nfaltas: -R$" + descontos.faltas + "\nTotal: -R$" + descontos.desc;
            label21.Text = "Transporte: -R$20,00 " + beneficios.transporte + "\nPlano Odontologico: -R$30,00 " + beneficios.convenioOdonto + "\nConvenio Medico: -R$50,00 " + beneficios.convenioMedico;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            //cliquei sem querer
        }

        private void label17_Click(object sender, EventArgs e)
        {
            //cliquei sem querer
        }

        private void label19_Click(object sender, EventArgs e)
        {
            //cliquei sem querer
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog abre_arq = new OpenFileDialog();
            //abre_arq.Filter = "*.xls|Microsoft Excel";

            abre_arq.Title = "Selecione o Arquivo";
            if (abre_arq.ShowDialog() == DialogResult.OK)
            {
                button1.Enabled = true;
                button4.Enabled = false;
                textBox2.Enabled = false;
                label22.ForeColor = Color.Gray;
                textBox2.Text = abre_arq.FileName;

                funcionario = new funcionario();
                CTR = new CTR_funcionario(abre_arq.FileName);

            }
        }
    }
}
