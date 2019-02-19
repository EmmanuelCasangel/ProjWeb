using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        localhost.Service service = new localhost.Service();

        private void btnGerar_Click(object sender, EventArgs e)
        {
            if (txtCPF.Text == "" || txtNumDep.Text == "" || txtSalB.Text == "")
                ltbHoll.Text = "Favor Preencha todos os campos";
            else
            {
                double[] holl = service.gerar(Convert.ToDouble(txtSalB.Text), Convert.ToInt16(txtNumDep.Text), txtCPF.Text);

                if (holl != null)
                {
                   
                    ltbHoll.Items.Add("Salario Bruto = R$ " + Convert.ToDouble(txtSalB.Text));

                    ltbHoll.Items.Add("INSS = R$ " + holl[0]);

                    ltbHoll.Items.Add("IR = R$ "+ holl[1]);

                    ltbHoll.Items.Add("FGTS = R$ " + holl[2]);

                    ltbHoll.Items.Add("Salario Liquido = R$ " + holl[3]);
                }

                else
                    ltbHoll.Text = "CPF Invalido";



            }

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
