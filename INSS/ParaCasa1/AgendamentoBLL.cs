using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

/*
 * Todos os campos são de preenchimento obrigatorio
 * Ano de edição deverá ser numérico e positivo
*/

namespace ParaCasa1
{
    class AgendamentoBLL
    {
        public static void conecta()
        {
            AgendamentoDAL.conecta();
            if (!Erro.getErro())
            {

            AgendamentoDAL.populaDR();
            }
        }
        

        public static void desconecta()
        {
            AgendamentoDAL.desconecta();
        }

        public static void validaCodigo(String cpf, char op)
        {
            Erro.setErro(false);
            /*
            if (Agendamento.getCPF().Equals(""))
            {
                Erro.setMsg("O CPF é de preenchimento obrigatório!");
                return;
            }
            */
            if (op == 'c')
                AgendamentoDAL.consultaUmAgendamento(cpf);
            else
                AgendamentoDAL.excluiUmAgendamento();
        }

        public static void validaDados( char op)
        {
            Erro.setErro(false);
            if (Agendamento.getCPF().Equals(""))
            {
                Erro.setMsg("O CPF é de preenchimento obrigatório!");
                return;
            }
            if (Agendamento.getNome().Equals(""))
            {
                Erro.setMsg("O Nome é de preenchimento obrigatório!");
                return;
            }
            if (Agendamento.getHorario().Equals(""))
            {
                Erro.setMsg("O Horário é de preenchimento obrigatório!");
                return;
            }
            if (Agendamento.getData().Date<DateTime.Now)
            {
                Erro.setMsg("Agende para uma data que ainda não chegou!");
                return;
            }
            int numeroCpf9 = 0;
            int numeroCpf10 = 0;
            int i;
            int j = 10;
            int k;
            int l = 11;

            string tempCPF = Agendamento.getCPF();

            char []arrayCPF = tempCPF.Replace(",", "").Replace("-", "").ToCharArray();
            


            for (i = 0; i < 11; i++)
            {
                if (j > 1)
                {
                    numeroCpf9 += int.Parse(arrayCPF[i].ToString()) * j;
                    j--;
                }
            }
            if ((numeroCpf9 % 11) < 2 && int.Parse(arrayCPF[9].ToString()) == 0)
            {
                for (k = 0; k < 11; k++)
                {
                    if (l > 1)
                    {
                        numeroCpf10 += int.Parse(arrayCPF[k].ToString()) * l;
                        l--;
                    }
                }
            }
            else if ((numeroCpf9 % 11) >= 2 && (11 - (numeroCpf9 % 11)) == int.Parse(arrayCPF[9].ToString()))
            {
                for (k = 0; k < 10; k++)
                {
                    if (l > 1)
                    {
                        numeroCpf10 += int.Parse(arrayCPF[k].ToString()) * l;
                        l--;
                    }
                }
            }
            if ((numeroCpf10 % 11) < 2 && int.Parse(arrayCPF[10].ToString()) != 0)
            {
                Erro.setMsg("CPF Inválido");
                return;
            }
            else if ((numeroCpf10 % 11) >= 2 && (11 - (numeroCpf10 % 11)) != int.Parse(arrayCPF[10].ToString()))
            {
                Erro.setMsg("CPF Inválido");
            }
            

            if (op == 'i')
                AgendamentoDAL.inseriUmAgendamento();
            else
                AgendamentoDAL.atualizaUmAgendamento();

        }
        public static void getProximo()
        {
            AgendamentoDAL.getProximo();
        }

     

    }
}

