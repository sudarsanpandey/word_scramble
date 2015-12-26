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
    
    public partial class Form1 : Form
    {
        int row = 16;
        int column = 16;

        int w_h = 50;

        string[] words;
        string[] meanings;
        string[] usages;

        Boolean[][] occupied;
        Button[][] boxes = null;
        string[] orientation = null;
        int [][] row_number = null;
        int[][] column_number = null;
        Boolean orient_horizontal = true;
        int counter = 0;
       

        public Form1()
        {
            InitializeComponent();
            get_words_from_database();
             occupied= new Boolean[row][];
            orientation = new string[words.Length];
            row_number= new int[words.Length][];    //how many words are there
            column_number = new int[words.Length][];    //how many words are there
        }
        private void get_words_from_database() {
            //Array.Clear(words,0,words.Length);
          // DBConnect db = new DBConnect();
           //db.Select();

            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=sql5.freesqldatabase.com;uid=sql562297;" +
                "pwd=hC6!zL4!;database=sql562297;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open();
                string statement = "SELECT * from words_scramble";
                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                List<string> word_list = new List<string>();
                List<string> meaning_list = new List<string>();
                List<string> usage_list = new List<string>();
               // int count=0;
                while (rdr.Read())
                {
                    word_list.Add(rdr.GetString(1).ToUpper());
                    meaning_list.Add(rdr.GetString(2));
                    usage_list.Add(rdr.GetString(3));
                    //Console.WriteLine(rdr.GetString(0));
                    //words[count] = rdr.GetString(0);
                   // meanings[count] = rdr.GetString(1);
                   // count++;
                }
                words = new string[word_list.Count];
                meanings = new string[word_list.Count];
                usages = new string[usage_list.Count];

                int count=0;
                for (int i = 0; i < words.Length;i++ )
                {
                    words[count] = word_list.ElementAt(i);
                    meanings[count] = meaning_list.ElementAt(i);
                    usages[count] = usage_list.ElementAt(i);
                    count++;
                }
                conn.Close();
                //MessageBox.Show("connection established");
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //making all the boxes unOccupied for first start
            boxes= new Button[row][];
            for (int i = 0; i < row; i++) {
                boxes[i]= new Button[column];
                occupied[i] = new Boolean[column];
                for (int j = 0; j < column; j++) {
                     boxes[i][j] = new Button();
                     boxes[i][j].Size = new Size(w_h,w_h);
                     boxes[i][j].Location = new Point(j*w_h,i*w_h);
                         boxes[i][j].Enabled = false;
                    //set the boolean value for each
                         occupied[i][j] = false;
                     this.Controls.Add(boxes[i][j]);
                }

            }
            //setting the size of the window
            int win_width = (int)((row+1) * w_h);
            int win_height = (int)(((column+1) * w_h));
            this.Size = new Size(win_height,win_width);

            
           //filling the boxes with characters horizontal
            string word = words[counter];
            int row_num = row/2;
            int col_num = row/2;
            //orient_horizontal = !orient_horizontal;
            fill_table(word, row_num,col_num);
            for (int i = 1; i < words.Length; i++)
            {
                row_num = get_next_row();
            }
        }
        private int get_next_row() {
            try
            {
                string word = words[counter];
                char[] word_char = word.ToCharArray();
                for (int i = 0; i < counter; i++)
                {
                    string temp_word = words[i];
                   // Console.WriteLine("comparing : " + word + " with " + temp_word);
                    char[] temp_word_char = temp_word.ToCharArray();
                    for (int a = 0; a < word_char.Length; a++)
                    {
                        for (int b = 0; b < temp_word_char.Length; b++)
                        {
                            char current_word_char = word_char[a];
                            char comparing_word_char = temp_word_char[b];
                            if (current_word_char == comparing_word_char)
                            {
                                if (orientation[i] == "horizontal") //check to see if the orientation is horizontal
                                {
                                    orient_horizontal = false;      //if yes, change the orientation
                                    Boolean look_another_position = false;
                                    //check if the future occupying spaces are actually available
                                    int word_char_count = 0;
                                    for (int x = (row_number[i][b] - a - 1); x < (row_number[i][b] - a + word.Length - 1); x++)
                                    {
                                      //  Console.WriteLine("x-value : " + x + ",row-value : " + row);
                                        if (x < 0 || x>=row) {
                                            look_another_position = true;
                                            break;
                                        }
                                        int y = column_number[i][b] - 1;
                                        if (occupied[x][y])
                                        {
                                            char occupied_text = ((boxes[x][y].Text).ToCharArray())[0];
                                            char inserting_text = word_char[word_char_count];
                                            if (occupied_text != inserting_text)
                                            {
                                                look_another_position = true;
                                                break;
                                            }
                                        }
                                        word_char_count++;
                                    }
                                    if (look_another_position)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        fill_table(word, (row_number[i][b] - a), (column_number[i][b]));
                                    }
                                }
                                else if (orientation[i] == "vertical")
                                {
                                    //for horizontal orientation
                                    orient_horizontal = true;
                                    Boolean look_another_position = false;
                                    //check if the future occupying spaces are actually available
                                    int word_char_count = 0;
                                    for (int y = (column_number[i][b] - a - 1); y < (column_number[i][b] - a + word.Length - 1); y++)
                                    {
                                      //  Console.WriteLine("y-value : " + y + "column : " + column);
                                        if (y < 0 || y >= column) {
                                            look_another_position = true;
                                            break;
                                        }
                                        int x = row_number[i][b] - 1;
                                        if (occupied[x][y])
                                        {
                                            char occupied_text = ((boxes[x][y].Text).ToCharArray())[0];
                                            char inserting_text = word_char[word_char_count];
                                            if (occupied_text != inserting_text)
                                            {
                                                look_another_position = true;
                                                break;
                                            }
                                        }
                                        word_char_count++;
                                    }
                                    if (look_another_position)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        fill_table(word, (row_number[i][b]), (column_number[i][b] - a));
                                    }

                                }


                                return 1;

                            }

                        }
                    }


                }

                //FOR NON FIT WORDS
                //MessageBox.Show("non fit character:"+Environment.NewLine+""+word);
                int local_counter = 0;
                Random rand = new Random();
                while (local_counter < 100)
                {
                    int orient = rand.Next(0, 2);
                    int random_row = 0;
                    int random_col = 0;
                    if (orient == 0)
                    {
                        orient_horizontal = true;
                        random_row = rand.Next(1, (row - word.Length));
                        random_col = rand.Next(1, column);
                       // Console.WriteLine("random row : " + random_row);
                      //  Console.WriteLine("random col : " + random_col);
                      //  Console.WriteLine("orient : " + orient);
                    }
                    else
                    {
                        orient_horizontal = false;
                        random_row = rand.Next(1, row);
                        random_col = rand.Next(1, (column - word.Length));
                      //  Console.WriteLine("random row : " + random_row);
                      //  Console.WriteLine("random col : " + random_col);
                      //  Console.WriteLine("orient : " + orient);
                    }


                    if (!orient_horizontal)
                    {
                        Boolean fill_ready = true;
                        if ((random_col + word.Length) >= column)
                        {
                            continue;
                        }
                        for (int q = random_col; q < (random_col + word.Length); q++)
                        {
                            if (occupied[q][random_row])
                            {
                                fill_ready = false;
                                break;
                            }
                        }
                        if (fill_ready)
                        {
                            fill_table(word, random_col, random_row);
                            break;
                        }
                    }
                    else
                    {
                        Boolean fill_ready = true;
                        if ((random_row + word.Length) >= row)
                        {
                            continue;
                        }
                        for (int q = random_row; q < (random_row + word.Length); q++)
                        {

                            if (occupied[random_col][q])
                            {
                                fill_ready = false;
                                break;
                            }

                        }
                        if (fill_ready)
                        {
                            fill_table(word, random_col, random_row);
                            break;
                        }

                    }

                    local_counter++;
                }

                for (int i = 0; i < row; i++) {
                    for (int j = 0; j < column; j++) {
                        if (!occupied[i][j]) {
                            boxes[i][j].BackColor = Color.Black;
                        }
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }

                return 1;
        }
        private void fill_table(string word, int row_num, int col_num) {
            if (orient_horizontal)  //horizontal orientation
            {
                char[] temp_char = word.ToCharArray();
                orientation[counter] = "horizontal";
                row_number[counter] = new int[temp_char.Length];
                column_number[counter] = new int[temp_char.Length];
                for (int b = col_num - 1; b < column; b++)
                {
                    
                    if (temp_char != null && (b - (col_num - 1)) < temp_char.Length)
                    {
                        boxes[row_num - 1][b].Text =temp_char[b - (col_num - 1)] + "";// +(row_num) + "," + (b + 1);
                        boxes[row_num - 1][b].BackColor = Color.Teal;
                        boxes[row_num - 1][b].Enabled = true;
                        occupied[row_num - 1][b] = true;
                        row_number[counter][(b - (col_num - 1))] = (row_num);
                        column_number[counter][b - (col_num - 1)] = b+1;

                    }
                }

            }
            else
            {  //vertical orientation

                char[] temp_char = word.ToCharArray();
                orientation[counter] = "vertical";
                row_number[counter] = new int[temp_char.Length];
                column_number[counter] = new int[temp_char.Length];
                for (int a = row_num - 1; a < row; a++)
                {
                    
                    if (temp_char != null && (a - (row_num - 1)) < temp_char.Length)
                    {
                        boxes[a][col_num - 1].Text = temp_char[a - (row_num - 1)] + "";// +(a + 1) + "," + (col_num);
                        boxes[a][col_num - 1].BackColor = Color.Tomato;
                        boxes[a][col_num - 1].Enabled = true;
                        occupied[a][col_num - 1] = true;
                        row_number[counter][a-(row_num-1)] = (a+1);
                        column_number[counter][a - (row_num - 1)] = col_num;
                    }
                }
                
            }
            counter++;
        }
        private Boolean shift(int x, int y) {
            if (x < 0) {
                if (will_shift_backwards(x)) {
                    shift_backwards(x);
                    return true;
                }
            }
            else if (x > 0) {
                if (will_shift_forward(x)) {
                    shift_forward(x);
                    return true;
                }
            }

            if (y < 0) {
                if (will_shift_up(y)) {
                    shift_up(y);
                    return true;
                }
            }
            else if (y > 0) {
                if (will_shift_down(y)) {
                    shift_down(y);
                    return true;
                }
            }

            return false;
        }

        private void shift_forward(int x_units) {
            for (int n = 0; n < x_units; n++)
            {
                for (int i = row - 1; i >= 0; i--)
                {
                    for (int j = column - 1; j >= 0; j--)
                    {
                        if (occupied[i][j] == true)
                        {
                            string text = boxes[i][j].Text;
                            boxes[i][j].Text = "";
                            boxes[i][j+1].Text = text;
                            occupied[i][j] = false;
                            occupied[i][j+1] = true;
                            //have to change the row and column values

                        }
                    }
                }
            }
        }
        private void shift_backwards(int x_units)
        {
            for (int n = 0; n < x_units; n++)
            {
                for (int i = 0; i <row; i++)
                {
                    for (int j = 0; j <column; j++)
                    {
                        if (occupied[i][j] == true)
                        {
                            string text = boxes[i][j].Text;
                            boxes[i][j].Text = "";
                            boxes[i][j-1].Text = text;

                            occupied[i][j] = false;
                            occupied[i][j-1] = true;
                        }
                    }
                }
            }
        }
        private void shift_down(int y_units)
        {
            for (int n = 0; n < y_units; n++)
            {
                for (int i = row - 1; i >= 0; i--)
                {
                    for (int j = column - 1; j >= 0; j--)
                    {
                        if (occupied[i][j] == true)
                        {
                            string text = boxes[i][j].Text;
                            boxes[i][j].Text = "";
                            boxes[i + 1][j].Text = text;

                            occupied[i][j] = false;
                            occupied[i + 1][j] = true;
                        }
                    }
                }
            }
        }
        private void shift_up(int y_units)
        {
            for (int n = 0; n < y_units; n++)
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        if (occupied[i][j] == true)
                        {
                            string text = boxes[i][j].Text;
                            boxes[i][j].Text = "";
                            boxes[i - 1][j].Text = text;

                            occupied[i][j] = false;
                            occupied[i - 1][j] = true;
                        }
                    }
                }
            }
        }

        private Boolean will_shift_forward(int x_units) {           
                int temp_num = column - x_units;
                for (int r = 0; r < row; r++) {
                    for (int c = temp_num; c < column; c++) {
                        if (occupied[r][c] == true) {
                            return false;
                        }
                    }
                }           
                return true;
        }

        private Boolean will_shift_backwards(int x_units)
        {
            int temp_num = x_units;
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < temp_num; c++)
                {
                    if (occupied[r][c] == true)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private Boolean will_shift_down(int y_units)
        {
            int temp_num = row - y_units;
            for (int c = 0; c < column; c++) {
                for (int r = temp_num; r < row; r++) {
                    if (occupied[r][c] == true) {
                        return false;
                    }
                }
            }
                return true;
        }

        private Boolean will_shift_up(int y_units)
        {
            int temp_num =y_units;//1
            for (int c = 0; c < column; c++)//0,1,2,...,12
            {
                for (int r = 0; r < temp_num; r++)
                {
                    if (occupied[r][c] == true)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
