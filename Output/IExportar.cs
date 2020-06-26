using System.Collections.Generic;
using Aula2.Entidades;

namespace Aula2.Output
{
    public interface IExportar
    {
        string NomeArquivo { get; set; }

        void Exportar(List<IExportarDados> dados);
    }
}