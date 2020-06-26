using System;

namespace Aula2.Entidades
{
    public partial class Cliente : IExportarDados
    {
        public string Cpf{ get; set; }
        public string Nome{ get; set; }
        public int Idade{ get; set; }
        public EnumSexo Sexo{ get; set; }
        public int NumeroCarteiraMotorista{ get; set; }
        public int CarteiraReservista{ get; set; }
        public Endereco Endereco{ get; set; }
        
        public Cliente(string cpf, string nome, int idade, EnumSexo sexo)
        {            
            Cpf = cpf;
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
        }

        public Cliente(string cpf, string nome, int idade, EnumSexo sexo, Endereco endereco) 
        : this(cpf, nome, idade, sexo)
        {
            Endereco = endereco;            
        }

        public void InformarEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }

        public bool PossuiMaioridade()
        {
            return (Idade >= 18);
        }

        public bool InformarCarteiraReservista(int carteiraReservista)
        {
            if(!PossuiMaioridade())
                return false;

            if(Sexo == EnumSexo.Feminino)
                return false;

            CarteiraReservista = carteiraReservista;

            return true;
        }

        public bool InformarNumeroCarteiraMotorista(int numeroCarteiraMotorista)
        {
            if(!PossuiMaioridade())
                return false;

            NumeroCarteiraMotorista = numeroCarteiraMotorista;

            return true;                
        }

        public string RetornarDados()
        {
            var enderecoCliente = Endereco != null 
                ? Endereco.RetornarDados()
                : "";

            var info = ($"▐ Nome: {Nome}   ▌ Cpf: {Cpf}\n"+
                        $"▐ Sexo: {Sexo}   ▌ Idade: {Idade}({RetornarAnoNascimento()})\n"+
                        $"{enderecoCliente}");

            return info;
        }

        public int RetornarAnoNascimento()
        {
            var anoNascimento = DateTime.Now.Year - Idade;

            return anoNascimento;
        }

        public string RetornarCpfNome()
        {
            return $"Cpf - {Cpf}     Nome - {Nome}";
        }

        public string RetornarNome()
        {
            return Nome;
        }

        public string RetornarCpf()
        {
            return Cpf;
        }
    }
}
