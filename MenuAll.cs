using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado2
{
    class MenuAll
    {

        dao DAO;
        MenuCompras menuCompras;
        Menu menu;
        Menufornecedor menufornecedor;
        ClienteMenu clienteMenu;
        public int opcao;
        public int codigo;
        public MenuAll()
        {
            DAO = new dao();
            menuCompras = new MenuCompras();
            menu = new Menu();
            menufornecedor = new Menufornecedor();
            clienteMenu = new ClienteMenu();


        }//fim do construtor

        public void MostrarOpcoes()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Escolha uma das opções abaixo: \n\n" +
                    "\n1. Ir para as Compras" +
                    "\n2. Ir para Produtos" +
                    "\n3. Ir para o Fornecedor" +
                    "\n4. Ir para o Cliente " +
                    "\n0. Sair" +
                    "\n\n Escolha uma das opções acima: ");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception erro)
            {
                Console.WriteLine("Algo deu errado!\n\n " + erro);
                opcao = 0;
            }
        }//fim do método

        public void Executar()
        {
            do

            {
                MostrarOpcoes();

                switch (opcao)
                {
                    case 0:

                        Console.WriteLine("Obrigado!");
                        break;
                    case 1:
                        //Colentando os dados
                        menuCompras.Executar();
                        break;
                    case 2:

                        menu.Executar();
                        break;
                    case 3:

                        menufornecedor.Executar();
                        break;
                    case 4:

                        clienteMenu.Executar();
                        break;



                }
            } while (opcao != 0);
        }
        



















    }//Fim da Classe
}//Fim do Projeto
