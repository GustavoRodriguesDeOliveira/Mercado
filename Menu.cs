using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado2
{
    class Menu
    {
        dao DAO;
        public int opcao;
        public int codigo;
        public Menu()
        {
            DAO = new dao();
        }//fim do construtor

        public void MostrarOpcoes()
        {
            Console.WriteLine("Escolha uma das opções abaixo: \n\n" +
                "\n1. Cadastar Produto" +
                "\n2. Consultar tudo" +
                "\n3. Consultar o Produto" +
                "\n4. Atualizar Produto" +
                "\n5. Excluir Produto" +
                "\n0. Sair");

            opcao = Convert.ToInt32(Console.ReadLine());
        }//fim do método

        public void Executar()
        {
            do
        
            {
                MostrarOpcoes();

                switch (opcao)
               {

                     case 1:
                    //Colentando os dados
                    
                    Console.WriteLine("Informe seu codigo:");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nInforme o Valor do Produto:");
                    string valorDoProduto = Console.ReadLine();
                    Console.WriteLine("\nInforme a Quantidade de produtos: ");
                    string quantidadeDoProduto = Console.ReadLine();
                    Console.WriteLine("\nInfome a data de validade: ");
                    DateTime dataDeValidade = Convert.ToDateTime(Console.ReadLine());
                    //Executar o metodo inser
                    DAO.Inserir(valorDoProduto, quantidadeDoProduto, dataDeValidade);
                    break;
                     case 2:
                    //consultar os dados
                    Console.WriteLine(DAO.ConsultarTudo());
                    break;
                    //Consultar Individual

                    case 3:
                        //Consultar Individual
                        Console.WriteLine("Informe o código que deseja consultar");
                        codigo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Valor do Produto: " + DAO.ConsultarValorDoProduto(codigo) +
                                          "\nQuantidade Do Produto: " + DAO.ConsultarQuantidadeDeProduto(codigo) +
                                          "\nData de validade: " + DAO.ConsultarDataDeValidade(codigo));
                        break;

                    case 4:
                    Console.WriteLine("Qual campo desejas atualizar?");
                    string campo = Console.ReadLine();
                    Console.WriteLine("Qual o novo dado?");
                    string novoDado = Console.ReadLine();
                    Console.WriteLine("Qual o código da pessoa que deseja atualizar?");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    DAO.Atualizar(campo, novoDado, codigo);
                    break;


                      case 5:
                    Console.WriteLine("Informe o código que deseja deletar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    DAO.Deletar(codigo);
                    break;

                    case 0:
                        Console.WriteLine("Obrigado!");
                        break;
                    default:
                        Console.WriteLine("Código digitado não é valido!");
                        break;
                }
            } while (opcao != 0);
        }

    }//fim do projeto
}//fim do projeto
