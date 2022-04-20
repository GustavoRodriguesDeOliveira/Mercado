using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado2
{
    class Menufornecedor
    {
        public int opcao;
        fornecedor fornecedorum;
        public int codigo;
        public void clienteMenu()
        {
            fornecedorum = new fornecedor();
        }//fim do construtor

        public void MostrarOpcoesFornecedor()
        {
            Console.WriteLine("Escolha uma das opções abaixo: \n\n" +
                "\n1. Cadastar Fornecedor" +
                "\n2. Consultar Tudo" +
                "\n3. Consultar Individual" +
                "\n4. Atualizar Fornecedor" +
                "\n5. Excluir Fornecedor" +
                "\n0. Sair");
            opcao = Convert.ToInt32(Console.ReadLine());
        }//fim do método



        public void Executar()
        {
            do

            {
                MostrarOpcoesFornecedor();

                switch (opcao)
                {
                    case 1:
                        //Colentando os dados

                        
                        Console.WriteLine("\nInforme o seu endereco:");
                        string endereco = Console.ReadLine();
                        Console.WriteLine("\nInforme o N° do seu telefone: ");
                        string telefone = Console.ReadLine();
                        Console.WriteLine("\nInfome a quantidade: ");
                        int quantidade  = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nInforme a sua razaoSocial: ");
                        string razaoSocial = Console.ReadLine();
                        fornecedorum.Inserir(endereco, telefone, quantidade,  razaoSocial);
                        //Executar o metodo inser
                        break;
                    case 2:
                        //consultar os dados
                        fornecedorum = new fornecedor();
                        Console.WriteLine(fornecedorum.ConsultarTudoFornecedor());

                        break;

                    case 3:
                        //Consultar Individual
                        Console.WriteLine("Informe o código que deseja consultar");
                        codigo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("endereco: " + fornecedorum.ConsultarEndereco(codigo) +
                                          "\nTelefone: " + fornecedorum.ConsultarTelefone(codigo) +
                                          "\nquantidade: " + fornecedorum.ConsultarQuantidade(codigo) +
                                          "\nrazaoSocial: " + fornecedorum.ConsultarrazaoSocial(codigo));
                        break;
                    case 4:
                        //Atualizar
                        Console.WriteLine("Qual campo desejas atualizar?");
                        string campo = Console.ReadLine();
                        Console.WriteLine("Qual o novo dado?");
                        string novoDado = Console.ReadLine();
                        Console.WriteLine("Qual o codigo da pessoa que deseja atualizar?");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        fornecedorum.Atualizar(campo, novoDado, codigo);
                        break;
                    case 5:
                        //Deletar
                        Console.WriteLine("Informe o codigo que deseja deletar");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        //Usar o método da classe DAO
                        fornecedorum.Deletar(codigo);
                        break;
                    case 0:
                        Console.WriteLine("Obrigado!");
                        break;
                    default:
                        Console.WriteLine("codigo digitado não é valido!");
                        break;
                }//fim do switch_Case
            } while (opcao != 0);
        }//fim do método



    }//fim da classe
}//fim do projeto
