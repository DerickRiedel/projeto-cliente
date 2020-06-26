namespace Aula2.Entidades
{
    public class Endereco
    {
        public string Rua { get; set; }

        public string Numero { get; set; }

        public string Cep { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public Endereco() { }

        public Endereco(string cep)
        {
            Cep = cep;
        }

        public string RetornarDados()
        {
            return $"▐ Endereço: {Rua}, {Numero} - {Cidade}/{Estado} ({Cep})";
        }
    }
}
