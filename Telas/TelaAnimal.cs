using System.Collections.Generic;
using Aula2.Entidades;
using Aula2.Aquisicao;
using Aula2.Output;
using System.Linq;
using System;

namespace Aula2.Telas
{
    public class TelaAnimal : TelaBase
    {
        private List<Animal> Animais;
        public TelaAnimal()
        {
            Animais = new List<Animal>();
        }
        public void Executar()
        {
            var executando = true;
            do
            {
                LimparTela();
                EscreverTitulo("Menu de Opções ");
                Escrever("");
                Escrever("   ▐ 1 ■ Listar    ");
                Escrever("   ▐ 2 ■ Inserir   ");
                Escrever("   ▐ 3 ■ Remover   ");
                Escrever("   ▐ 4 ■ Editar    ");
                Escrever("   ▐ 5 ■ Sair    \n");
                Escrever("Escolha uma opcao: ");
                int opcao = LerInt();
                switch (opcao)
                {
                    case 1: // Listar Animal
                        Listar();
                        break;
                    case 2: // Inserir Animal
                        Adicionar();
                        break;
                    case 3: // Remover Animal
                        Remover();
                        break;
                    case 4: // Editar Animal
                        Editar();
                        break;
                    case 5: // Sair
                        executando = false;
                        break;
                    default:
                        OpcaoInvalida();
                        break;
                }

            } while (executando);
        }

        private Animal Inserir()
        {
            var nome = EscreverLerString("Digite o nome do animal:");
            var idade = EscreverLerInt("Digite a idade do animal:");
            var sexoStr = EscreverLerString("Digite o sexo do animal: (m/f)");
            var sexo = (sexoStr == "m" ? EnumSexo.Masculino : EnumSexo.Feminino);
            var obj = new Animal(nome,idade,sexo);
            return obj;
        }

        private void Adicionar()
        {
            LimparTela();
            EscreverTitulo("Adicionar Animais");
            Escrever("");
            var executando = true;
            do{
                Animais.Add(Inserir());
                var opt = EscreverLerString("Continuar adicionando animais? s/n");
                executando = (opt == "s" ? true : false);
            }while(executando == true);
        }

        private void Remover()
        {
            var executando = true;
            do{
                LimparTela();
                EscreverTitulo("Remover Animais");
                Listar();
                var opt = EscreverLerString("Digite o nome do animal que quer Remover\n(Deixe em branco para voltar)");
                if(String.IsNullOrWhiteSpace(opt)){
                    executando = false;
                    break;
                }
                var result = Animais.Where(x => x.Nome == opt).FirstOrDefault();
                if(result != null){
                    Animais.Remove(result);
                    AguardarTecla("Animal removido com sucesso");
                }else{
                    AguardarTecla("Animal não encontrado");
                }
            }while(executando == true);
        }

        private void Listar()
        {
            LimparTela();
            EscreverTitulo("Lista de animais");
            Escrever("");
            foreach(var animal in Animais){
                Escrever($"{animal.RetornarDados()}");
            }
            AguardarTecla();
        }

        private void Editar()
        {
            var executando = true;
            do{
                LimparTela();
                EscreverTitulo("Editar animais");
                Listar();
                var opt = EscreverLerString("Digite o nome do animal que quer editar\n(Deixe em branco para voltar)");
                if(String.IsNullOrWhiteSpace(opt)){
                    executando = false;
                    break;
                }
                var result = Animais.Where(x=> x.Nome == opt).FirstOrDefault();
                if(result != null){
                    Animais.Remove(result);
                    Animais.Add(Inserir());
                    AguardarTecla("Animal editado com sucesso");
                }else{
                    AguardarTecla("Animal não encontrado");
                }
            }while(executando == true);
        }

        private void OpcaoInvalida()
        {
            AguardarTecla("Opção Inválida");
        }
    }
}