using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LocalizaCS.Data;
using LocalizaCS.Models;
using Microsoft.Data.SqlClient;

namespace LocalizaCS.Data
{
    public class ValidacoesController
	{

		public class ValidaCPF
		{

			public static bool IsCpf(string cpf)
			{
				int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
				int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
				string tempCpf;
				string digito;
				int soma;
				int resto;
				cpf = cpf.Trim();
				cpf = cpf.Replace(".", "").Replace("-", "");
				switch (cpf)
				{
					case "11111111111":
						return false;
					case "00000000000":
						return false;
					case "2222222222":
						return false;
					case "33333333333":
						return false;
					case "44444444444":
						return false;
					case "55555555555":
						return false;
					case "66666666666":
						return false;
					case "77777777777":
						return false;
					case "88888888888":
						return false;
					case "99999999999":
						return false;
				}
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
	}
}
