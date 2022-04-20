using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//importes para conexão com o banco de dados
using MySql.Data.MySqlClient;//imports para realizar comandos 

namespace Mercado2
{
    class fornecedor
    {
        MySqlConnection conexao;
        public int[] codigo;
        public int i;
        public string[] endereco;
        public string[] telefone;
        public int[] quantidade;
        public string[] razaoSocial;
        public string msg;
        public int computador = 0;
        public int contador;
        public string dados;
        public string resultado;


        public fornecedor()
        {
            conexao = new MySqlConnection("Server=localhost;DataBase=Mercado3;Uid=root;Password=;");
            try
            {
                conexao.Open();//Solicitando a entrada ao banco de dados
                Console.WriteLine("Entrada efetuada em Fornecedor");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
                conexao.Close();//Fechando a conexão com banco de dados
            }//fim da tentativa de conexão com o banco de dados
        }//fim do construtor

        public void Inserir(string endereco, string telefone, int quantidade, string razaoSocial)
        {
            try
            {
                dados = "('" + endereco + "','" + telefone + "','" + quantidade + "','" + razaoSocial + "')";
                resultado = "Insert into fornecedor(codigo, endereco, telefone, quantidade, razaoSocial) values" + dados;
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
            string query = "Select * from fornecedor";//Coletando o dado do BD

            //criar os vetores
            codigo = new int[100];
            endereco = new string[100];
            telefone = new string[100];
            quantidade = new int[100];
            razaoSocial = new string[100];

            //Dar valor iniciais para eles
            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                endereco[i] = "";
                telefone[i] = "";
                quantidade[i] = 0;
                razaoSocial[i] = "";
            }//fim da repetição

            //Criar o comando para coleta de dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Usar o comando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                endereco[i] = leitura["endereco"] + "";
                telefone[i] = leitura["telefone"] + "";
                quantidade[i] = Convert.ToInt32(leitura["quantidade"]);
                razaoSocial[i] = leitura["razaoSocial"] + "";
                i++;
                contador++;
            }//fim do while
            leitura.Close();
            //fim do preencher vetor

        }//fim do preencher vetor

        public string ConsultarTudoFornecedor()
        {
            //preencher vetor
            preencherVetor();
            msg = "";
            for (int i = 0; i < contador; i++)
            {
                msg += "\n\ncodigo: " + codigo[i]
                    + ",endereco: " + endereco[i]
                    + ", telefone: " + telefone[i]
                    + ", quantidade: " + quantidade[i]
                    + ", razaoSocial: " + razaoSocial[i];
            }//fim do for
            return msg;
        }//fim do consultartudo

        public string ConsultarEndereco(int cod)
        {
            preencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return endereco[i];
                }
            }//fim do for 
            return "Código não encontrado1!";
        }//fim do consultorEndereco
        public string ConsultarTelefone(int cod)
        {
            preencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return telefone[i];
                }
            }//fim do for 
            return "Código não encontrado1!";
        }

        public int ConsultarQuantidade(int cod)
        {
            preencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return quantidade[i];
                }
            }//fim do for
            return 0;
        }

        public string ConsultarrazaoSocial(int cod)
        {
            preencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return razaoSocial[i];
                }
            }//fim do for
            return "Código não emcontrado2!";
        }

        public void Atualizar(string campo, string novoDado, int codigo)
        {
            try
            {
                resultado = "update fornecedor set " + campo + " = '" +
                            novoDado + "' where codigo = '" + codigo + "'";
                //Executar o script
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Dado Atualizado com Sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!" + e);
            }
        }//fim do atualizar

        public void Deletar(int codigo)
        {
            resultado = "delete from fornecedor where cpf = '" + codigo + "'";
            //Executar o comando
            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();
            //Mensagem...
            Console.WriteLine("Dados Excluídos com sucesso!");
        }//fim do deletar
    }//fim da classe
}//fim do projeto
