using System.Collections.Generic;
using Aula2.Entidades;
using System.IO;
using System;

namespace Aula2.Output
{
    public class ExportarCsv : IExportar
    {
        public string NomeArquivo {get; set; }
        public string Tipo = ".csv";
        public ExportarCsv(string nomeArquivo, string tipo)
        {
            NomeArquivo = nomeArquivo;
        }
        public void Exportar(List<IExportarDados> dados)
        {
            using(var file = new StreamWriter("Dados/"+NomeArquivo+Tipo))
            {
                foreach (var dado in dados)
                {
                    file.WriteLine($"{dado.ExportarCsv()}");
                }
            }
        }
    }
}