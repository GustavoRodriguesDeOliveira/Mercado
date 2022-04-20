using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//importes para conexão com o banco de dados
using MySql.Data.MySqlClient;//imports para realizar comandos 

namespace Mercado2
{
    class dao
    {
        MySqlConnection conexao;
        public string dados;
        public string resultado;
        public int []codigo;
        public string []valorDoProduto;
        public string []quantidadeDoProduto;
        public DateTime[] dataDeValidade;
        public int i;
        public string msg;
        public int computador = 0;
        public int contador;
        public dao()
        {
            conexao = new MySqlConnection("Server=localhost;DataBase=Mercado3;Uid=root;Password=;");
            try
            {
                conexao.Open();//Solicitando a entrada ao banco de dados
                Console.WriteLine("Entrei!!!");
            }
            catch(Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
                conexao.Close();//Fechando a conexão com banco de dados
            }//fim da tentativa de conexão com o banco de dados
        }//fim do construtor

        //criar o método INSERIR


        public void Inserir( string valorDoProduto, string quantidadeDoProduto, DateTime dataDeValidade)
        {
            try
            {
                //Guardando na variável dados, todos os dados da parte Value do Insert
                MySqlParameter parameter = new MySqlParameter();
                parameter.ParameterName = "@dataDeValidade";
                parameter.MySqlDbType = MySqlDbType.Date;
                parameter.Value = dataDeValidade.Year + "-" + dataDeValidade.Month + "-" + dataDeValidade.Day;
                dados = "'','" + valorDoProduto + "','" + quantidadeDoProduto + "','" + parameter.Value + "'";
                resultado = "Insert into Produto(codigo, valorDoProduto, quantidadeDoProduto, dataDeValidade) values(" + dados + ")";
                //Executando o insert no BD
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + " Linha(s) Afetada(s)!");
                //Mostrar em tela o resultado da operação

            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
            }
        }//fim do método Inserir


        public void preencherVetor()
        {
            string query = "Select * from produto";//Coletando o dado do BD

            //criar os vetores
            codigo = new int[100];
            valorDoProduto = new string[100];
            quantidadeDoProduto = new string[100];
            dataDeValidade = new DateTime[100];

            //Dar valor iniciais para eles
            for(i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                valorDoProduto[i] = "";
                quantidadeDoProduto[i] = "";
                dataDeValidade[i] = new DateTime();
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
                //dataDeValidade[i] = Convert.ToDateTime(leitura["dataDeValidade"]);
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
                    + ", quantidadeDoProduto: " + quantidadeDoProduto[i]
                    + ", dataDeValidade: " + dataDeValidade[i];
                }//fim do for
            return msg; 
        }//fim do consultartudo

        public string ConsultarValorDoProduto(int cod)
        {
            preencherVetor();
            for(int i=0; i < contador; i++)
            {
                if(cod == codigo[i])
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
        public DateTime ConsultarDataDeValidade(int cod)
        {
            preencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return dataDeValidade[i];
                }
            }//fim do for 
            return new DateTime();
        }
        public void Atualizar(string campo, string novoDado, int codigo)
        {
            try
            {
                resultado = "update produto set " + campo + " = '" + novoDado + "' where codigo = '" + codigo + "'";
                
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
            resultado = "delete from produto where codigo = '" + codigo + "'";
            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();
            Console.WriteLine("Dados Excluidos com sucesso!");
        }//fim do deletar




    }//fim da classe
}//fim do projeto
