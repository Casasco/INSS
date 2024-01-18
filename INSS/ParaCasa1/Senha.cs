using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParaCasa1
{
    public partial class Senha : Form
    {
      
        public Senha()
        {
            
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            listBox1.Items.Clear();
            AgendamentoBLL.getProximo();

            String texto = maskedTextBox1.Text.Replace(",",".");
           
            while (!Erro.getErro())
            {
                String cpf = Agendamento.getCPF();
                if (cpf== texto)
                {
              
                    button2.Enabled = true;
                    listBox1.Items.Add("CPF = " + Agendamento.getCPF());
                    listBox1.Items.Add(" Nome: " + Agendamento.getNome());
                    listBox1.Items.Add("Horário: " + Agendamento.getHorario());
                    listBox1.Items.Add("Data: " + Agendamento.getData());
                    SenhaClasse.setNome(Agendamento.getNome());
                    SenhaClasse.setCPF(Agendamento.getCPF());
                    
                    
                }
                
                AgendamentoBLL.getProximo();

                
                   



            }
            
        }

        private void Senha_Load(object sender, EventArgs e)
        {
            AgendamentoDAL.populaDR2();
            button2.Enabled = false;
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AgendamentoDAL.inseriUmaSenha();
            button2.Enabled=false;
            
        }

        private void Senha_FormClosed(object sender, FormClosedEventArgs e)
        {
            AgendamentoDAL.excluiUmAgendamento();
        }
    }
}
