using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//importes para conexão com o banco de dados
using MySql.Data.MySqlClient;//imports para realizar comandos 

namespace Mercado2
{
    class ClienteUm
    {
        MySqlConnection conexao;


        public int opcao;
        public int[] codigo;
        public int[] CPF;
        public string[] nome;
        public string[] telefone;
        public string[] valorTotal;
        public int i;
        public string dados;
        public string resultado;
        public int contador = 0;
        public string msg;
        public string[] endereco;
        public ClienteUm()
        {
            conexao = new MySqlConnection("Server=localhost;DataBase=Mercado3;Uid=root;Password=;");
            try
            {
                conexao.Open();//Solicitando a entrada ao banco de dados
                Console.WriteLine("Entrei Mercado!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado Mercado!\n\n" + e);
                conexao.Close();//Fechando a conexão com banco de dados
            }//fim da tentativa de conexão com o banco de dados
        }//fim do construtor

        //Criar o método INSERIR
        public void Inserir(string nome, string telefone, int cpf, string valorTotal)
        {
            try
            {
                dados = "('','" + nome + "','" + telefone + "','" + cpf + "', '" + valorTotal + "')";
                resultado = "Insert into cliente(CPF, nome, telefone, codigo, ValorTotal) values" + dados;
                //Executar o comando resultado no banco de dados
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + " Linha(s) Afetada(s)!");

            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
            }//fim do catch
        }//fim do método inserir

        public void PreencherVetor()
        {
            string query = "select * from cliente";//Coletando o dado do BD

            //Instanciando os vetores
            CPF = new int[100];
            nome = new string[100];
            telefone = new string[100];
            codigo = new int[100];
            valorTotal = new string[100];
            //Dar valores iniciais para ele
            for (i = 0; i < 100; i++)
            {
                CPF[i] = 0;
                nome[i] = "";
                telefone[i] = "";
                codigo[i] = 0;
                valorTotal[i] = "";
            }//fim da repetição

            //Criar o comando para coleta de dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Usar o comando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                CPF[i] = Convert.ToInt32(leitura["CPF"]);
                nome[i] = leitura["nome"] + "";
                telefone[i] = leitura["telefone"] + "";
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                valorTotal[i] = leitura["valortotal"] + "";
                i++;
                contador++;
            }//fim do while

            //Fechar o dataReader
            leitura.Close();
        }//fim do preencher Vetor

        public string ConsultarTudouM()
        {
            //Preencher o vetor
            PreencherVetor();
            msg = "";
            for (int i = 0; i < contador; i++)
            {
                msg += "\n\nCPF: " + CPF[i]
                    + ", Nome: " + nome[i]
                    + ", Telefone: " + telefone[i]
                    + ", codigo: " + codigo[i]
                    + ", valorTotal: " + valorTotal[i];
            }//fim do for
            return msg;
        }//fim do consultarTudo

        public string ConsultarNome(int cod)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return nome[i];
                }
            }//fim do for
            return "Código não encontrado!";
        }//fim do consultarNome

        public string ConsultarTelefone(int cod)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return telefone[i];
                }
            }//fim do for
            return "Código não encontrado!";
        }//fim do consultarTelefone

        public string ConsultarCpf(int cod)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return endereco[i];
                }
            }//fim do for
            return "Código não encontrado!";
        }//fim do consultarEndereço

        public string ConsultarvalorTotal(int cod)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return valorTotal[i];
                }
            }//fim do for
            return "Código não encontrado!";
        }//fim do consultarEndereço


        public void Atualizar(string campo, string novoDado, int codigo)
        {
            try
            {
                resultado = "update cliente set " + campo + " = '" +
                            novoDado + "' where cpf = '" + codigo + "'";
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
            resultado = "delete from cliente where cpf = '" + codigo + "'";
            //Executar o comando
            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();
            //Mensagem...
            Console.WriteLine("Dados Excluídos com sucesso!");
        }//fim do deletar
    }
}
