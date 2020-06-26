using System.Collections.Generic;
using Aula2.Entidades;

namespace Aula2.Output
{
    public class FactoryExportar
    {
        public static IExportar RetornarExportador(EnumTipoExportacao tipo, string nomeArquivo)
        {
            IExportar exporta;
            switch (tipo)
            {
                case EnumTipoExportacao.csv:
                    exporta = new ExportarCsv(nomeArquivo,"."+tipo);
                    break;
                default:
                    exporta = new ExportarXml(nomeArquivo,"."+tipo);
                    break;
            }

            return exporta;
        }
    }
}