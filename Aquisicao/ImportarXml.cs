using System;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using Aula2.Entidades;
namespace Aula2.Aquisicao
{
    public class ImportarXml : ImportarBase
    {
        public List<Cliente> AdquirirDados(string nomeArquivo){
            XmlTextReader xtr = new XmlTextReader(Caminho+nomeArquivo);

            int index = 0;

            List<String> nomes = new List<string>();
            List<String> cpfs = new List<string>();
            List<String> idades = new List<string>();
            List<String> sexos = new List<string>();

            var lista = new List<Cliente>();
            
            while (xtr.Read()){
                if(xtr.NodeType == XmlNodeType.Element && xtr.Name == "nome" ){
                    nomes.Add(xtr.ReadElementString());
                }
                if(xtr.NodeType == XmlNodeType.Element && xtr.Name == "cpf" ){
                    cpfs.Add(xtr.ReadElementString());
                }
                if(xtr.NodeType == XmlNodeType.Element && xtr.Name == "idade" ){
                    idades.Add(xtr.ReadElementString());
                }
                if(xtr.NodeType == XmlNodeType.Element && xtr.Name == "sexo" ){
                    sexos.Add(xtr.ReadElementString());
                }
            }
            while(index < nomes.Count){
                lista.Add(new Cliente(cpfs[index],nomes[index],Convert.ToInt32(idades[index]),(sexos[index] == "Masculino"?EnumSexo.Masculino:EnumSexo.Feminino)));
                index++;
            }
            return lista;
        }
    }
}