using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado2
{
    

    class ClienteMenu
    {
        public int opcao;
        ClienteUm clienteUm;
        public int CPF;
        public int cod;
        public void clienteMenu()
        {
            clienteUm = new ClienteUm();
        }//fim do construtor

        public void MostrarOpcoesClientes()
        {
            Console.WriteLine("Escolha uma das opções abaixo: \n\n" +
                "\n1. Cadastar cliente" +
                "\n2. Consultar tudo" +
                "\n3. Consultar Individual" +
                "\n4. Atualizar cliente" +
                "\n5. Excluir cliente" +
                "\n0. Sair");
            opcao = Convert.ToInt32(Console.ReadLine());
        }//fim do método

        public void Executar()
        {
            do

            {
                MostrarOpcoesClientes();

                switch (opcao)
                {
                    case 1:
                        //Colentando os dados

                        Console.WriteLine("Informe seu CPF:");
                       int  CPF = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nInforme o seu Nome: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("\nInfome o Nº do seu Telefone: ");
                        string telefone = Console.ReadLine();
                        Console.WriteLine("\nInforme o Valor Total: ");
                        string valorTotal = Console.ReadLine();
                        clienteUm.Inserir(nome, telefone, CPF, valorTotal);
                        //Executar o metodo inser
                        break;
                    case 2:
                        //consultar os dados
                        clienteUm = new ClienteUm();
                        Console.WriteLine(clienteUm.ConsultarTudouM());

                        break;

                    case 3:
                        //Consultar Individual
                        Console.WriteLine("Informe o código que deseja consultar");
                         cod = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Nome: " + clienteUm.ConsultarNome(cod) +
                                          "\nTelefone: " + clienteUm.ConsultarTelefone(cod) +
                                          "\ncodigo: " + clienteUm.ConsultarCpf(cod) +
                                          "\nvalorTotal: " + clienteUm.ConsultarvalorTotal(cod));
                        break;
                    case 4:
                        //Atualizar
                        Console.WriteLine("Qual campo desejas atualizar?");
                        string campo = Console.ReadLine();
                        Console.WriteLine("Qual o novo dado?");
                        string novoDado = Console.ReadLine();
                        Console.WriteLine("Qual o CPF da pessoa que deseja atualizar?");
                        cod = Convert.ToInt32(Console.ReadLine());
                        clienteUm.Atualizar(campo, novoDado, cod);
                        break;
                    case 5:
                        //Deletar
                        Console.WriteLine("Informe o CPF que deseja deletar");
                        cod = Convert.ToInt32(Console.ReadLine());
                        //Usar o método da classe DAO
                        clienteUm.Deletar(cod);
                        break;
                    case 0:
                        Console.WriteLine("Obrigado!");
                        break;
                    default:
                        Console.WriteLine("Código digitado não é valido!");
                        break;
                }//fim do switch_Case
            } while (opcao != 0);
        }//fim do método



    }//fim da classe
}//fim do projeto

