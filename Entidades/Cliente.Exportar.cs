using System;
using System.Xml;

namespace Aula2.Entidades
{
    public partial class Cliente
    {
        public string ExportarCsv()
        {
            return $"{Cpf};{Nome};{Idade};{Sexo};{NumeroCarteiraMotorista};{CarteiraReservista}";
        }

        public XmlElement ExportarXml(XmlDocument doc)
        {
            var xmlCliente = doc.CreateElement("cliente");

            var xmlCpf = doc.CreateElement("cpf");
            xmlCpf.InnerText = Cpf;
            xmlCliente.AppendChild(xmlCpf);

            var xmlNome = doc.CreateElement("nome");
            xmlNome.InnerText = Nome;
            xmlCliente.AppendChild(xmlNome);

            var xmlIdade = doc.CreateElement("idade");
            xmlIdade.InnerText = Convert.ToString(Idade);
            xmlCliente.AppendChild(xmlIdade);

            var xmlSexo = doc.CreateElement("sexo");
            xmlSexo.InnerText = Convert.ToString(Sexo);
            xmlCliente.AppendChild(xmlSexo);

            return xmlCliente;
        }
    }
}
