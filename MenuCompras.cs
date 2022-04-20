using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado2
{
    class MenuCompras
    {
        compra comp;
        MenuCompras menuCompras;
        public int opcao;
        public int codigo;
        public MenuCompras()
        {
            comp = new compra();
        }
        public void MostrarOpcoes()
        {
            Console.WriteLine("Escolha uma das opções abaixo: \n\n" +
                "\n1. Cadastar Compra" +
                "\n2. Consultar todas as Compras" +
                "\n3. Consultar uma Compra" +
                "\n4. Atualizar Compra" +
                "\n5. Excluir compra" +
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


                        Console.WriteLine("\nInforme o Valor do Produto:");
                        string valorDoProduto = Console.ReadLine();
                        Console.WriteLine("\nInforme a Quantidade de produtos: ");
                        string quantidadeDoProduto = Console.ReadLine();
                        //Executar o metodo inser
                        comp.Inserir(valorDoProduto, quantidadeDoProduto);
                        break;
                    case 2:
                        //consultar os dados
                        Console.WriteLine(comp.ConsultarTudo());
                        break;
                    //Consultar Individual

                    case 3:
                        //Consultar Individual
                        Console.WriteLine("Informe o código que deseja consultar");
                        codigo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Valor do Produto: " + comp.ConsultarValorDoProduto(codigo) +
                                          "\nQuantidade Do Produto: " + comp.ConsultarQuantidadeDeProduto(codigo));

                        break;
                    case 4:
                        Console.WriteLine("Qual campo desejas atualizar?");
                        string campo = Console.ReadLine();
                        Console.WriteLine("Qual o novo dado?");
                        string novoDado = Console.ReadLine();
                        Console.WriteLine("Qual o código da pessoa que deseja atualizar?");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        comp.Atualizar(campo, novoDado, codigo);
                        break;


                    case 5:
                        Console.WriteLine("Informe o código que deseja deletar");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        comp.Deletar(codigo);
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
