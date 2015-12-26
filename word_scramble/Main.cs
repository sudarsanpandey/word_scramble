using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace word_scramble
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        //Puzzle btn
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 play_form = new Form1();
            play_form.Show();
        }
        //Enter word in database
        private void button2_Click(object sender, EventArgs e)
        {
            Entry entry_form = new Entry();
            entry_form.Show();
        }
        //Typing Tutor Button
        private void button3_Click(object sender, EventArgs e)
        {
            Typing_Tutor typtut = new Typing_Tutor();
            typtut.Show();
        }
    }
}
