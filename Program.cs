using System;
using Aula2.Telas;

namespace Aula2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var telaCliente = new TelaCliente();
            var telaAnimal = new TelaAnimal();
            telaAnimal.Executar();
            
        }
    }
}
