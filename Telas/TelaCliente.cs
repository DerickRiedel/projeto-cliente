using System.Collections.Generic;
using Aula2.Entidades;
using Aula2.Aquisicao;
using Aula2.Output;
using System.Linq;
using System;

namespace Aula2.Telas
{
    public class TelaCliente : TelaBase
    {
        private List<Cliente> Clientes;

        /// <summary>
        /// Efetua a listagem do cliente
        /// </summary>
        public TelaCliente()
        {
            Clientes = new List<Cliente>();

        }

        /// <summary>
        /// Executa a tela inicial
        /// </summary>
        public void Executar()
        {
            CarregarDados();

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
                Escrever("   ▐ 5 ■ Exportar Dados");
                Escrever("   ▐ 6 ■ Carregar dados");
                Escrever("   ▐ 7 ■ Enviar arquivos por email");
                Escrever("   ▐ 8 ■ Sair");

                int opcao = LerInt();
                switch (opcao)
                {
                    case 1: // Listar Clientes
                        Listar();
                        break;
                    case 2: // Inserir Clientes
                        Adicionar();
                        break;
                    case 3: // Remover Clientes
                        Remover();
                        break;
                    case 4: // Editar Clientes
                        Editar();
                        break;
                    case 5: // Exportar Dados
                        ExportarDados();
                        break;
                    case 6: // Carregar Dados
                        CarregarDados();
                        break;
                    case 7: // Mandar Email
                        ExportarPorEmail();
                        break;
                    case 8: // Sair
                        executando = false;
                        break;

                    default:
                        OpcaoInvalida();
                        break;
                }

            } while (executando);
        }

        /// <summary>
        /// Remove os clientes
        /// </summary>
        private void Remover()
        {
            var executando = true;
            do
            {
                EscreverTitulo("Remover Clientes");
                ListarClientes();

                var opcao = EscreverLerString("Informe o Cpf para remover o cliente? (deixe em branco caso queira voltar)");
                if (string.IsNullOrWhiteSpace(opcao))
                {
                    executando = false;
                }
                else
                {
                    var result = Clientes
                        .Where(x => x.RetornarCpf() == opcao)
                        .FirstOrDefault();
                    if (result != null)
                    {
                        Clientes.Remove(result);
                        AguardarTecla("Cliente removido com sucesso.");
                    }
                    else
                    {
                        AguardarTecla("Cliente não encontrado.");
                    }
                }

            } while (executando);
        }

        /// <summary>
        /// Efetua a listagem dos clientes
        /// </summary>
        private void ListarClientes()
        {
            foreach (var cliente in Clientes)
            {
                Escrever("▌ " + cliente.RetornarCpfNome());
            }
        }

        /// <summary>
        /// Lista os clientes
        /// </summary>

        private void ExportarPorEmail()
        {   
            var executando = true;
            do
            {
                LimparTela();
                EscreverTitulo("Enviar por email");
                Escrever("▐▐ Lista de arquivos");
                Escrever("");
                ListarArquivos();
                Escrever("");
                var arquivo = EscreverLerString("▌ Digite o nome do arquivo que deseja exportar\n(Deixe em branco caso queira voltar)");
                if(String.IsNullOrWhiteSpace(arquivo)){
                    executando = false;
                    break;
                }
                var remetente = EscreverLerString("▌ Remetente: (e-mail)");
                var senha = EscreverLerString("▌ Senha: ");
                var destinatario = EscreverLerString("▌ Destinatário: (e-mail)");
                var assunto = EscreverLerString("▌ Assunto: ");
                var mensagem = EscreverLerString("▌ Mensagem: ");
                var obj = new ExportarEmail(arquivo);
                obj.EnviarEmail(remetente, destinatario, assunto, mensagem, senha);
            }while(executando == true);
        }

        private void ExportarDados()
        {
            var executando = true;
            do
            {
                LimparTela();
                EscreverTitulo("Exportação de dados");
                Escrever("▐▐ Lista de arquivos");
                Escrever("");
                ListarArquivos();
                Escrever("");
                Escrever("Escolha o formato do arquivo desejado.");
                Escrever("");
                var opt = EscreverLerInt("▐ 1 - .CSV  ▐ 2 - .Xml  ▐ 3 - Voltar");
                if (opt == 3)
                {
                    executando = false;
                    break;
                }
                var nomeArquivo = EscreverLerString("Qual o nome do arquivo?");
                var importar = new ImportarBase();

                var result = importar.PesquisarArquivos()
                        .Where(x => x == nomeArquivo)
                        .FirstOrDefault();

                if(result != null){
                    AguardarTecla("Arquivo já existe.");
                    break;
                }
                var data = $".{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}-{DateTime.Now.Hour}-{DateTime.Now.Minute}";

                IExportar exportador = FactoryExportar.RetornarExportador((EnumTipoExportacao)opt, nomeArquivo);

                exportador.Exportar(Clientes.Cast<IExportarDados>().ToList());
            } while (executando == true);

        }

        private void CarregarDados()
        {
            LimparTela();
            EscreverTitulo("Carregar Dados");
            Escrever("▐▐ Lista de arquivos ▐▐");
            Escrever("");
            ListarArquivos();
            Escrever("");
            Escrever("▐▐ Digite o nome do arquivo que deseja carregar");
            Escrever("");
            var arquivo = EscreverLerString("Deixe em branco se quiser voltar");
            
            string[] tipos = arquivo.Split('.');

            var obj = new FactoryImportar();

            var importar = new ImportarBase();

            var result = importar.PesquisarArquivos()
                        .Where(x => x == arquivo)
                        .FirstOrDefault();
            if (result != null)
            {
                Clientes = obj.Importar((tipos[1] == "csv" ? EnumTipoExportacao.csv : EnumTipoExportacao.xml),arquivo);
            }

        }

        private void ListarArquivos()
        {
            var obj = new ImportarBase();
            foreach (string arquivo in obj.PesquisarArquivos())
            {
                Escrever("▐ " + arquivo);
            }
        }

        private void Editar()
        {
            LimparTela();
            EscreverTitulo("Editar Clientes");
            ListarClientes();

            var cpfEscolhido = EscreverLerString("Digite o cpf desejado para editá-lo");

            var result = Clientes
                    .Where(x => x.RetornarCpf() == cpfEscolhido)
                    .FirstOrDefault();
            if (result != null)
            {
                Clientes.Remove(result);
                Clientes.Add(Inserir());
                AguardarTecla("Pressione qualquer tecla para voltar");
            }
            else
            {
                AguardarTecla("Cliente não encontrado.");
            }
        }

        private void Listar()
        {
            EscreverTitulo("Lista de Clientes");
            ListarClientes();
            Escrever("");

            var cpfEscolhido = EscreverLerString("Digite um cpf se quiser abrangir os dados \n(Deixe em branco se quiser voltar)");
            var result = Clientes
                    .Where(x => x.RetornarCpf() == cpfEscolhido)
                    .FirstOrDefault();
            if (result != null)
            {
                Escrever(" ");
                Escrever(result.RetornarDados());
                Escrever(" ");
                AguardarTecla();
            }
            else
            {
                AguardarTecla("Cpf não encontrado ");
            }
        }

        /// <summary>
        /// Insere os dados do cliente
        /// </summary>
        /// 
        private Cliente Inserir()
        {
            EscreverTitulo("Inserir Cliente");

            var cpf = InserirCpf();
            var nome = EscreverLerString("▌ Informe o nome:");
            var idade = EscreverLerInt("▌ Informe a idade:");
            var sexoStr = EscreverLerString("▌ Informe o sexo (m/f):");
            var sexo = (sexoStr == "m")
                ? EnumSexo.Masculino
                : EnumSexo.Feminino;

            var carteiraMotorista = InserirCarteira(idade);
            var certidaoReservista = InserirReservista(idade, sexo);
            var optEndereco = EscreverLerString("Informar Endereço? s/n");

            var obj = new Cliente(cpf, nome, idade, sexo, (optEndereco == "s")
                                                            ? InserirEndereco()
                                                            : null);

            if (carteiraMotorista != 0)
            {
                obj.InformarNumeroCarteiraMotorista(carteiraMotorista);
            }
            if (certidaoReservista != 0)
            {
                obj.InformarCarteiraReservista(certidaoReservista);
            }

            return obj;
        }

        /// <summary>
        /// Insere um cliente à lista
        /// </summary>
        /// 
        private void Adicionar()
        {
            bool executando = true;
            do
            {
                Clientes.Add(Inserir());
                Escrever("");
                Escrever("▐ Cliente inserido com sucesso ▐\n\n");

                var opt = EscreverLerString("Adicionar mais clientes? s/n");
                executando = (opt == "s" ? true : false);
            } while (executando == true);
        }

        private Endereco InserirEndereco()
        {
            EscreverTitulo("Inserir Endereco");
            var rua = EscreverLerString("▌ Informe a rua:");
            var numeroRua = EscreverLerString("▌ Informe a numero da rua:");
            var cidade = EscreverLerString("▌ Informe a cidade:");
            var estado = EscreverLerString("▌ Informe o estado:");
            var cep = EscreverLerString("▌ Informe o cep:");

            var endereco = new Endereco
            {
                Rua = rua,
                Cidade = cidade,
                Cep = cep,
                Estado = estado,
                Numero = numeroRua
            };

            return endereco;
        }


        private int InserirCarteira(int idade)
        {
            int carteiraMot;
            string opt;
            if (idade >= 18)
            {
                opt = EscreverLerString("Cadastrar carteira de motorista? s/n");
                if (opt == "s")
                {
                    carteiraMot = EscreverLerInt("▌ Digite o numero da sua carteira de motorista: ");
                    return carteiraMot;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        private int InserirReservista(int idade, EnumSexo sexo)
        {
            int carteiraRes;
            string opt;
            if (idade >= 18 && sexo == EnumSexo.Masculino)
            {
                opt = EscreverLerString("Cadastrar certidão de Reservista? s/n");
                if (opt == "s")
                {
                    carteiraRes = EscreverLerInt("▌ Digite sua certidão de Reservista: ");
                    return carteiraRes;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        private string InserirCpf()
        {
            bool Executando = true;
            string cpf;
            do
            {
                cpf = EscreverLerString("Informe o cpf:");
                var result = Clientes.Where(x => x.RetornarCpf() == cpf).FirstOrDefault();
                if (result != null)
                {
                    Executando = true;
                    Escrever("Cpf já cadastrado");
                    Escrever(" ");
                }
                else
                {
                    Executando = false;
                }
                if (cpf == "")
                {
                    Executando = true;
                    Escrever("Cpf Obrigatório");
                    Escrever("");
                }
            } while (Executando == true);

            return cpf;
        }

        private void OpcaoInvalida()
        {
            AguardarTecla("Opção inválida");
        }
    }
}