using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace ParaCasa1
{
    class AgendamentoDAL
    {
        private static String strConexao = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=BDLivros.mdb";
        private static OleDbConnection conn = new OleDbConnection(strConexao);
        private static OleDbCommand strSQL;
        private static OleDbDataAdapter adaptador;
        private static DataTable dt = new DataTable();
        private static OleDbDataAdapter adaptador2;
        private static DataTable dt2 = new DataTable();
        private static OleDbDataReader result;
        private static int i = -1;
        private static int senha = 0;
        public static void conecta()
        {
            try
            {
                conn.Open();
            }
            catch(Exception)
            {
                Erro.setMsg("Problemas ao se conectar ao Banco de Dados");
            }
            
        }

        public static void desconecta()
        {
            conn.Close();
        }
        public static void inseriUmaSenha()
        {

            
            senha++;
            String aux = "insert into Tabela1(Senha,CPF,NOME) values (@Senha,@CPF,@NOME)";
            strSQL = new OleDbCommand(aux, conn);
            strSQL.Parameters.Add("@Senha", OleDbType.VarChar).Value = senha.ToString();
            strSQL.Parameters.Add("@CPF", OleDbType.VarChar).Value = SenhaClasse.getCPF();
            strSQL.Parameters.Add("@NOME", OleDbType.VarChar).Value = SenhaClasse.getNome();

            Erro.setErro(false);
            try
            {
                strSQL.ExecuteNonQuery();
                MessageBox.Show("Senha gerada com sucesso!!\n" + "Senha: " + senha.ToString());
            }
            catch (Exception t)
            {
                MessageBox.Show(t+"");
            }
        }
        

        public static void inseriUmAgendamento()
        {
            String aux = "insert into TabLivro(CPF,NOME,HORARIO,Data) values (@CPF,@NOME,@HORARIO,@Data)";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.Parameters.Add("@CPF", OleDbType.VarChar).Value = Agendamento.getCPF().Replace(",",".");
            strSQL.Parameters.Add("@NOME", OleDbType.VarChar).Value = Agendamento.getNome();
            strSQL.Parameters.Add("@HORARIO", OleDbType.VarChar).Value = Agendamento.getHorario();
            strSQL.Parameters.Add("@Data", OleDbType.DBTimeStamp).Value = Agendamento.getData();
            Erro.setErro(false);
            try
            {
                strSQL.ExecuteNonQuery();
            }
            catch(Exception t)
            {
                Erro.setMsg(""+t);
            }
        }
        public static void populaDR()
        {
            String aux = "select * from TabLivro";
            
            adaptador = new OleDbDataAdapter(aux, conn);
            adaptador.Fill(dt);
            adaptador.Dispose();
        }
        public static void populaDR2()
        {
            String aux = "select * from TabLivro";

            adaptador2 = new OleDbDataAdapter(aux, conn);
            adaptador2.Fill(dt2);
            adaptador2.Dispose();
        }


        public static void excluiUmAgendamento()
        {
            String aux = "delete from Tabela1";

            strSQL = new OleDbCommand(aux, conn);
            
            strSQL.ExecuteNonQuery();
        }
        
        public static void atualizaUmAgendamento()
        {
            String aux = "update TabLivro set titulo=@titulo, autor=@autor, editora=@editora, ano=@ano where codigo =@codigo";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.Parameters.Add("@titulo", OleDbType.VarChar).Value = Agendamento.getNome();
            strSQL.Parameters.Add("@autor", OleDbType.VarChar).Value = Agendamento.getCPF();
           
            strSQL.Parameters.Add("@codigo", OleDbType.VarChar).Value = Agendamento.getHorario();
            strSQL.ExecuteNonQuery();
        }
        
        
        public static void consultaUmAgendamento(String cpf)
        {
            String aux = "select * from TabLivro where NOME = @NOME";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.Parameters.Add("@NOME", OleDbType.VarChar).Value = cpf;
            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                Agendamento.setCPF(result.GetString(0));
                Agendamento.setNome(result.GetString(1));
                Agendamento.setHorario(result.GetString(2));
                
                
            }
            else
                Erro.setMsg("Sem Agendamentos neste CPF.");
        }
        public static void getProximo()
        {
           
            Erro.setErro(false);
            
            ++i;
            if (i >= dt.Rows.Count)
            {
                i = -1;
                Erro.setErro(true);
            }
            else
            {
                Agendamento.setCPF("" + dt.Rows[i].ItemArray[0]);
                Agendamento.setNome("" + dt.Rows[i].ItemArray[1]);
                Agendamento.setHorario("" + dt.Rows[i].ItemArray[2]);
                Agendamento.setData(DateTime.Parse(dt.Rows[i].ItemArray[3].ToString()));
               
                
            }
            

            
        }
            


    }
}
