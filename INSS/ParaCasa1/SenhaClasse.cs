using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaCasa1
{
    internal class SenhaClasse
    {
        public static string id,nome,cpf;
        public static string getNome()
        {
            return nome;
        }

        public static void setNome(string _nome)
        {
            nome = _nome;
        }
        public static string getCPF()
        {
            return cpf;
        }

        public static void setCPF(string _cpf)
        {
            cpf = _cpf;
        }
        public static string getId()
        {
            return id;
        }
        public static void setId(String _id)
        {
            id=_id;
        }
    }
}
