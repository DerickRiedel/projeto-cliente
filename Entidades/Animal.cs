using System;
namespace Aula2.Entidades
{
    public class Animal
    {
        public string Nome {get; private set;}
        public int Idade {get; private set;}
        public EnumSexo Sexo {get; private set;}

        public Animal(string nome, int idade, EnumSexo sexo){
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
        }
        public string RetornarDados(){
            string sexo = Convert.ToString(Sexo);
            return $"▐ {Nome}   ▐ {Convert.ToString(Idade)}   ▐ {sexo}";
        }


    }
}