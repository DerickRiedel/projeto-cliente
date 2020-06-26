using System.Collections.Generic;
using Aula2.Output;
using Aula2.Entidades;
using System.IO;
using System.Linq;
using System;

namespace Aula2.Aquisicao
{
    public class ImportarBase
    {
        public string Caminho = @"C:\Users\Derek Riedel\Documents\CsProjects\Aula2\Dados\";
        
        public List<String> PesquisarArquivos()
        {
            string[] caminhos = Directory.GetFiles(Caminho);
            List<String> arquivos = new List<string>();
            foreach (string fileName in caminhos)
            {
                arquivos.Add(Path.GetFileName(fileName));
            }

            return arquivos;
        }
    }

}