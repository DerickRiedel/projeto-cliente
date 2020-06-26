using Aula2.Output;
using Aula2.Entidades;
using System.Collections.Generic;
namespace Aula2.Aquisicao
{
    public class FactoryImportar
    {
        public List<Cliente> Importar(EnumTipoExportacao tipo, string nomeArquivo){

            switch(tipo){
                case EnumTipoExportacao.csv :
                    var importarCsv = new ImportarCsv();
                    return importarCsv.AdquirirDados(nomeArquivo);
                    break;
                default :
                    var importarXml = new ImportarXml();
                    return importarXml.AdquirirDados(nomeArquivo);
                    break;
            }
        }
    }
}