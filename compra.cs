using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//importes para conexão com o banco de dados
using MySql.Data.MySqlClient;//imports para realizar comandos 

namespace Mercado2
{
    class compra
    {
        MySqlConnection conexao;
        public string dados;
        public string resultado;
        public int[] codigo;
        public string[] quantidadeDoProduto;
        public string[] valorDoProduto;
        public int i;
        public string msg;
        public int computador = 0;
        public int contador;

        public compra()
        {
            conexao = new MySqlConnection("Server=localhost;DataBase=Mercado3;Uid=root;Password=;");
            try
            {
                conexao.Open();//Solicitando a entrada ao banco de dados
                Console.WriteLine("Entrada efetuada em compras");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
                conexao.Close();//Fechando a conexão com banco de dados
            }//fim da tentativa de conexão com o banco de dados
        }//fim do construtor
        public void Inserir(string valorDoProduto, string quantidadeDoProduto)
        {
            try
            {
                dados = "('" + codigo + "','" + valorDoProduto + "','" + quantidadeDoProduto + "')";
                resultado = "Insert into compras(codigo, valorDoProduto, quantidadeDoProduto) values" + dados;
                //Executar o comando resultado no banco de dados
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + " Linha(s) Afetada(s)!");

            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);

            }//fim do catch
        }//fim do mpetodo inserir
        public void preencherVetor()
        {
            string query = "Select * from compra";//Coletando o dado do BD

            //criar os vetores
            codigo = new int[100];
            valorDoProduto = new string[100];
            quantidadeDoProduto = new string[100];

            //Dar valor iniciais para eles
            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                valorDoProduto[i] = "";
                quantidadeDoProduto[i] = "";
            }//fim da repetição

            //Criar o comando para coleta de dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Usar o comando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                valorDoProduto[i] = leitura["valordoProduto"] + "";
                quantidadeDoProduto[i] = leitura["quantidadeDoProduto"] + "";
                i++;
                contador++;
            }//fim do while
            leitura.Close();
            //fim do preencher vetor

        }//fim do preencher vetor

        public string ConsultarTudo()
        {
            //preencher vetor
            preencherVetor();
            msg = "";
            for (int i = 0; i < contador; i++)
            {
                msg += "\n\ncodigo: " + codigo[i]
                    + ",valorDoProduto: " + valorDoProduto[i]
                    + ", quantidadeDoProduto: " + quantidadeDoProduto[i];
            }//fim do for
            return msg;
        }//fim do consultartudo

        public string ConsultarValorDoProduto(int cod)
        {
            preencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return valorDoProduto[i];
                }
            }//fim do for 
            return "Código não encontrado1!";
        }//fim do consultorCompra
        public string ConsultarQuantidadeDeProduto(int cod)
        {
            preencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return quantidadeDoProduto[i];
                }
            }//fim do for 
            return "Código não encontrado1!";
        }

        public void Atualizar(string campo, string novoDado, int codigo)
        {
            try
            {
                resultado = "update compra set " + campo + " = '" + novoDado + "' where codigo = '" + codigo + "'";

                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Dado Atualizada com Sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!" + e);
            }
        }
        public void Deletar(int codigo)
        {
            resultado = "delete from compra where codigo = '" + codigo + "'";
            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();
            Console.WriteLine("Dados Excluidos com sucesso!");
        }//fim do deletar
    }//fim da classe
}//fim do projeto