using System.Collections.Generic;
using Aula2.Entidades;
using System.IO;
using System;

namespace Aula2.Aquisicao
{
    public class ImportarCsv : ImportarBase
    {
        string linha = "";
        List<String> linhas = new List<string>();
        string[] linhaSeparada;

        public List<Cliente> AdquirirDados(string nomeArquivo)
        {
            var clientes = new List<Cliente>();

            int index = 0;

            using (var file = new StreamReader(Caminho + nomeArquivo))
            {
                while((linha = file.ReadLine()) != null){
                    linhas.Add(linha);
                    linhaSeparada = linhas[index].Split(';');
                    index++;
                    clientes.Add(new Cliente(
                    linhaSeparada[0],
                    linhaSeparada[1],
                    Convert.ToInt32(linhaSeparada[2]),
                    (linhaSeparada[3] == "Masculino"?EnumSexo.Masculino:EnumSexo.Feminino)){
                        NumeroCarteiraMotorista = Convert.ToInt32(linhaSeparada[4]),
                        CarteiraReservista = Convert.ToInt32(linhaSeparada[5])
                    });
                }
            }
            return clientes;
        }
    }
}


