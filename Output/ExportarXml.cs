using System.Collections.Generic;
using Aula2.Entidades;
using System.Xml;
using System;

namespace Aula2.Output
{
    public class ExportarXml : IExportar
    {
        public string NomeArquivo {get; set; }
        public string Tipo = ".xml";
        public ExportarXml(string nomeArquivo, string tipo){
            NomeArquivo = nomeArquivo;
        }
        public void Exportar(List<IExportarDados> dados)
        {
            var doc = new XmlDocument();
            
            var xmlDado = doc.CreateElement("dados");
            doc.AppendChild(xmlDado);

            foreach (var item in dados)
            {
                xmlDado.AppendChild(item.ExportarXml(doc));
            }

            doc.Save("Dados\\"+NomeArquivo+Tipo);
        }
    }
}