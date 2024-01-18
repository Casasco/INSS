using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParaCasa1
{
    public partial class CadAgendamentoUIL : Form
    {
        public Agendamento Agendamento = new Agendamento();
        RadioButton botao= new RadioButton();
        public CadAgendamentoUIL()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Value=DateTime.Now;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Agendamento.setNome(textBox2.Text);
            Agendamento.setCPF(maskedTextBox1.Text);
            Agendamento.setData(dateTimePicker1.Value);
            if (radioButton1.Checked)
            {
                Agendamento.setHorario("13:00");
            } else if (radioButton2.Checked)
            {
               Agendamento.setHorario("14:00");
            }
            else if (radioButton3.Checked)
            {
               Agendamento.setHorario("15:00");
            }
            else if (radioButton4.Checked)
            {
               Agendamento.setHorario("16:00");
            }
            else if (radioButton5.Checked)
            {
                Agendamento.setHorario("17:00");
            }
            else if (radioButton6.Checked)
            {
               Agendamento.setHorario("18:00");
            }
            AgendamentoBLL.validaDados('i');
           
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("Dados inseridos com sucesso!");
        }

        private void CadLivrosUIL_Load(object sender, EventArgs e)
        {
            this.ActiveControl = maskedTextBox1;
            AgendamentoBLL.conecta();
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
        }
        /*
        private void button3_Click(object sender, EventArgs e)
        {
            Agendamento.setCPF(textBox2.Text);

            AgendamentoBLL.validaCodigo( 'c');
            
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
            {
                maskedTextBox1.Text = Agendamento.getCPF();
                textBox2.Text = Agendamento.getNome();
                //textBox3.Text = umAgendamento.getHorario();
                dateTimePicker1.Value =Agendamento.getData();
                
            }
        }
        */
        

        private void CadLivrosUIL_FormClosing(object sender, FormClosingEventArgs e)
        {
            AgendamentoBLL.desconecta();
        }

       
        
        private void button5_Click(object sender, EventArgs e)
        {
            Agendamento.setCPF(maskedTextBox1.Text);
           Agendamento.setData(dateTimePicker1.Value);
            // colocar horario
            Agendamento.setNome(textBox2.Text);
            

            AgendamentoBLL.validaDados('a');

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("Dados alterados com sucesso!");
        }
        

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Senha senha = new Senha();
            senha.Show();
        }
    }
}
