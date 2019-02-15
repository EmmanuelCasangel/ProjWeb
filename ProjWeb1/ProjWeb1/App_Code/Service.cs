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
    public Service () {

        //Remova os comentários da linha a seguir se usar componentes designados 
        //InitializeComponent(); 
    }
    [WebMethod]
    public double  CalIR(float salB)
    {
        double ir;

        if (salB < 1903.98)
            return 0;
        if(salB < 2826.65)
            return salB * 0.075;
        if(salB < 3751.05) 
            return salB * 0.15;
        if (salB < 4664.68)
            return salB * 0.225;
        return salB * 0.275;
    }


    [WebMethod]
    public bool Valida(string cpf)

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