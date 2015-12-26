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
    public partial class Typing_Tutor : Form
    {
        int global_count = 0;
        char[] char_texts = null;
        string current_word = "";

        bool matching = true;

        public Typing_Tutor()
        {
            InitializeComponent();
        }

        private void Typing_Tutor_Load(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=sql5.freesqldatabase.com;uid=sql562297;" +
                "pwd=hC6!zL4!;database=sql562297;";
            Boolean exception_bool = true;
            while (exception_bool)
            {
                try
                {
                    conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                    conn.Open();
                    string statement = "SELECT `word`,`usage` FROM `words_scramble` WHERE id = (ROUND(RAND()*(SELECT max(id) FROM words_scramble)))";
                    MySqlCommand cmd = new MySqlCommand(statement, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    string type_text = "";
                    string word = "";
                    while (rdr.Read())
                    {
                        word = rdr.GetString(0) + "";
                        type_text = rdr.GetString(1) + "";

                    }
                    content_tb.Text = get_rid_of_word(type_text, word);
                    conn.Close();
                    exception_bool = false;
                    //MessageBox.Show("connection established");
                }
                catch (MySql.Data.MySqlClient.MySqlException)
                {
                    exception_bool = true;
                }
                catch (Exception) {
                    exception_bool = true;
                }
            }

            color_first_word();
            user_tb.Focus();
        }

        public string get_rid_of_word(string type_text, string word) {
            word = word.ToLower();
            string replace_string = "";
            for (int i = 0; i < word.Length; i++) {
                replace_string += "*";
            }
                type_text = type_text.Replace(word,replace_string);
                char_texts = type_text.ToCharArray();
            Console.WriteLine("WORD : "+word);
            return type_text;
        }

        private void color_first_word() {
            String[] token = (content_tb.Text).Split(' ');
            content_tb.Text = "";
            content_tb.SelectionColor = Color.Green;
            content_tb.SelectionFont = new Font("Verdana", 14, FontStyle.Bold | FontStyle.Underline);
            content_tb.AppendText(token[0]);
            current_word = token[0];
            for (int i = 1; i < token.Length; i++)
            {      
                content_tb.SelectionColor = Color.Black;
                content_tb.SelectionFont = new Font("Verdana", 14, FontStyle.Bold);
                content_tb.AppendText(" ");              
                content_tb.AppendText((token[i] + " "));
            }
        }

        private void text_changed(object sender, EventArgs e)
        {
            string text = user_tb.Text;
            matching = is_it_matching(current_word, text);
            Console.WriteLine(matching);

            if (text.Contains(" ") && text.Trim().Length >=1) {
                color_the_current_word();
            }

        }
        private void color_the_current_word() {
            user_tb.Text = "";
            global_count++;
            String[] token = (content_tb.Text).Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            content_tb.Text = "";
            for (int i = 0; i < token.Length; i++)
            {
                if (i == global_count)
                {
                    content_tb.SelectionColor = Color.Green;
                    content_tb.SelectionFont = new Font("Verdana", 14, FontStyle.Bold | FontStyle.Underline);
                    content_tb.AppendText(token[i]);
                    current_word = token[i];
                    content_tb.SelectionColor = Color.Black;
                    content_tb.SelectionFont = new Font("Verdana", 14, FontStyle.Bold);
                    content_tb.AppendText(" ");
                    continue;
                }
                content_tb.AppendText((token[i] + " "));
            }
        }
        private Boolean is_it_matching(string current_word, string typing_word) {
            Console.WriteLine("current word : " + current_word + ", typing word :" + typing_word+".");
            if (current_word.Trim().StartsWith(typing_word.Trim()) && typing_word.Trim().Length>=1) {
                return true;
            }
            return false;
        }
    }
}
