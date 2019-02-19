using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service() {

        //Remova os comentários da linha a seguir se usar componentes designados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public double[] gerar(double salB, int numDep, string cpf)
    {
        double[] hollerit = null;

        if (ValidaCPF(cpf))
        {
            hollerit = new double[4];

            hollerit[0] = CalINSS(salB);//INSS

            hollerit[1] = CalIR(salB, numDep, hollerit[1]);//Imposto de Renda

            hollerit[2] = CalFGTS(salB); //FGTS

            hollerit[3] = CalSalLiq(salB, hollerit[0], hollerit[1]);//Salario Liquido

        }

        return hollerit;

    }

    [WebMethod]
    private double  CalIR(double salB, int numDep, double inss)
    {
        double salIR = salB - ( (189.59 * numDep) + inss );


        if (salIR < 1903.98)
            return 0;
        if(salIR < 2826.65)
            return salIR * 0.075;
        if(salIR < 3751.05) 
            return salIR * 0.15;
        if (salIR < 4664.68)
            return salIR * 0.225;
        //>4664.68
        return salIR * 0.275;
    }

    [WebMethod]
    private double CalINSS(double salB)
    {

        if (salB < 1659.38)
            return salB * 0.08;
        if (salB < 2765.66)
            return salB * 0.09;
        if (salB < 5531.31)
            return salB * 0.11;
        //>5531.31
            return 5531.31 * 0.11;        
    }

    [WebMethod]
    private double CalFGTS(double salB)
    {
        return salB * 0.08;
    }

    [WebMethod]
    private double CalSalLiq(double salB, double inss, double ir)
    {
        return salB - (inss + ir);
    }


    [WebMethod]
    private bool ValidaCPF(string cpf)

    {

        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf;

        string digito;

        int soma;

        int resto;

        cpf = cpf.Trim();

        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)

            return false;

        tempCpf = cpf.Substring(0, 9);

        soma = 0;

        for (int i = 0; i < 9; i++)

            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        resto = soma % 11;

        if (resto < 2)

            resto = 0;

        else

            resto = 11 - resto;

        digito = resto.ToString();

        tempCpf = tempCpf + digito;

        soma = 0;

        for (int i = 0; i < 10; i++)

            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;

        if (resto < 2)

            resto = 0;

        else

            resto = 11 - resto;

        digito = digito + resto.ToString();

        return cpf.EndsWith(digito);

    }

}