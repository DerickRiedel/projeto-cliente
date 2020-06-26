using System.Xml;

namespace Aula2.Entidades
{
    public interface IExportarDados
    {
        string ExportarCsv();

        XmlElement ExportarXml(XmlDocument doc);
    }
}