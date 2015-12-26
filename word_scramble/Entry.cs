using MySql.Data.MySqlClient;
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
    public partial class Entry : Form
    {
        public Entry()
        {
            InitializeComponent();
        }

        private void Entry_Load(object sender, EventArgs e)
        {
            last_word_label.Text = "Last Word : ";

            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=ubuntu-db.madelia.org;uid=wscramble;" +
                "pwd=456123;database=word_scramble;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open();
                string statement = "SELECT word FROM words_scramble WHERE id=(SELECT max(id) FROM words_scramble)";
                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                 {
                     last_word_label.Text = "Last Word : " +rdr.GetString(0);
                 }
                conn.Close();
                //MessageBox.Show("connection established");
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string word = word_tf.Text;
            string meaning = meaning_tf.Text;
            string usage = usage_tf.Text;

            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=ubuntu-db.madelia.org;uid=wscramble;" +
                "pwd=456123;database=word_scramble;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);

                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO `words_scramble`(`word`, `meaning`, `usage`) VALUES (@word, @meaning, @usage)";
                
                command.Parameters.AddWithValue("@word", word);
                command.Parameters.AddWithValue("@meaning", meaning);
                command.Parameters.AddWithValue("@usage", usage);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Entry Successful!!");
                last_word_label.Text = "Last Word : " + word;
                word_tf.Text = "";
                meaning_tf.Text = "";
                usage_tf.Text = "";
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
