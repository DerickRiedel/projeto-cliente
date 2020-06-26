using System;

namespace Aula2.Telas
{
    /// <summary>
    /// Classe base para a construção de novas telas 
    /// </summary>
    public class TelaBase
    {
        /// <summary>
        /// Método que escreve em tela as informações
        /// </summary>
        /// <param name="mensagem"></param>
        protected void Escrever(string mensagem)
        {
            Console.WriteLine((mensagem));
        }

        /// <summary>
        /// Método que retorna dado em formato string
        /// </summary>
        /// <returns></returns>
        protected string LerString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Metodo que retorna dados
        /// </summary>
        /// <returns></returns>
        protected int LerInt()
        {
            var retorno = 0;
            var executando = true;
            do{
                try
                {
                    retorno = int.Parse(Console.ReadLine());
                    executando = false;
                }
                catch
                {
                    Escrever("Opção inválida. Digite novamente.");
                }
            }while(executando == true);
            return retorno;
        }

        /// <summary>
        /// Limpa a tela
        /// </summary>
        protected void LimparTela()
        {
            Console.Clear();
        }

        /// <summary>
        /// Aguarda qualquer tela ser pressionada 
        /// </summary>
        protected void AguardarTecla()
        {
            Console.ReadKey();
        }

        protected void AguardarTecla(string mensagem)
        {
            Escrever(mensagem);

            AguardarTecla();
        }

        protected string EscreverLerString(string mensagem)
        {
            Escrever(mensagem);

            return LerString();
        }

        protected void EscreverTitulo(string mensagem){
            LimparTela();
            Escrever($"▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
            Escrever($"▐▐    {mensagem}  ■           ");
            Escrever($"▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            Escrever("");
        }

        protected int EscreverLerInt(string mensagem)
        {
            Escrever(mensagem);

            return LerInt();
        }
    }
}