using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Nosso objeto de transposição

namespace ParaCasa1
{
    public class Agendamento
    {

        private static string nome;
        private static string horario;
        private static string cpf;
        private static DateTime data;

        public static string getNome()
        {
            return nome;
        }

        public static void setNome(string _nome)
        {
            nome = _nome;
        }

        public static string getHorario()
        {
            return horario;
        }

        public static void setHorario(string _horario)
        {
            horario = _horario;
        }

        public static string getCPF()
        {
            return cpf;
        }

        public static void setCPF(string _cpf)
        {
            cpf = _cpf;
        }

        public  static DateTime getData()
        {
            return data;
        }

        public  static void setData(DateTime _data)
        {
            data = _data;
        }

    }
}
