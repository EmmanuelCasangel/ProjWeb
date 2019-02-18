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
                if (service.ValidaCPF(txtCPF.Text))
                {
                    double salB = Convert.ToDouble(txtSalB.Text);

                    ltbHoll.Items.Add("Salario Bruto = R$ " + salB);

                    double inss = service.CalINSS(salB);
                    ltbHoll.Items.Add( "INSS = R$ " + inss);

                    double ir = service.CalIR(salB, Convert.ToInt16(txtNumDep.Text));
                    ltbHoll.Items.Add("IR = R$ "+ ir);

                    ltbHoll.Items.Add("FGTS = R$ " + service.CalFGTS(salB));

                    ltbHoll.Items.Add("Salario Liquido = R$ " + service.CalSalLiq(salB, inss, ir);
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
