using SpeechLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace YapayZekaTemelleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void ProductList()
        {
            var products = db.TBLPRODUCT.ToList();
            dataGridView1.DataSource = products;
        }

        void enabled()
        {
            TxtBuyPrice.Enabled = false;
            TxtSellPrice.Enabled = false;
            TxtName.Enabled = false;
            TxtMark.Enabled = false;
            TxtStock.Enabled = false;
            TxtCategory.Enabled = false;
            maskedTextBox1.Enabled = false;
            comboBox1.Enabled = false;
        }

        void colormethod()
        {
            TxtBuyPrice.BackColor = Color.White;
            TxtSellPrice.BackColor = Color.White;
            TxtName.BackColor = Color.White;
            TxtMark.BackColor = Color.White;
            TxtStock.BackColor = Color.White;
            TxtCategory.BackColor = Color.White;
            maskedTextBox1.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
        }

        DbProductAIEntities db = new DbProductAIEntities();
        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_BackColorChanged(object sender, EventArgs e)
        {
            if (comboBox1.BackColor == Color.Yellow)
            {
                comboBox1.Text = "Active";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            enabled();
            colormethod();
            timer1.Start();
            

        }
        private void maskedTextBox1_BackColorChanged(object sender, EventArgs e)
        {
            if(maskedTextBox1.BackColor == Color.Yellow)
            {
                maskedTextBox1.Text = DateTime.Now.ToString("dd.MM.yyyy");
            }
        }
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void BtnSpeak_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            Grammar g = new DictationGrammar();
            sr.LoadGrammar(g);
            try
            {
                BtnSpeak.Text = "Please Speak";
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult res = sr.Recognize();
                richTextBox1.Text = res.Text;
            }
            catch(Exception)
            {
                BtnSpeak.Text = "Error Try Again";
            }
        }

        private void BtnListen_Click(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(richTextBox1.Text);
        }

        private void BtnProductAdd_Click(object sender, EventArgs e)
        {
            ProductList();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TxtName.BackColor == Color.Yellow && TxtName.Enabled==true)
            {
                TxtName.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }

            if (TxtMark.BackColor == Color.Yellow && TxtMark.Enabled == true)
            {
                TxtMark.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }

            if (TxtStock.BackColor == Color.Yellow && TxtStock.Enabled == true)
            {
                TxtStock.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }

            if (TxtBuyPrice.BackColor == Color.Yellow && TxtBuyPrice.Enabled == true)
            {
                TxtBuyPrice.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }

            if (TxtSellPrice.BackColor == Color.Yellow && TxtSellPrice.Enabled == true)
            {
                TxtSellPrice.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }

            if (TxtCategory.BackColor == Color.Yellow && TxtCategory.Enabled == true)
            {
                TxtCategory.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }

            if (maskedTextBox1.BackColor == Color.Yellow && maskedTextBox1.Enabled == true)
            {
                enabled();
                colormethod();
            }

            if (comboBox1.BackColor == Color.Yellow && comboBox1.Enabled == true)
            {
                comboBox1.Text = "Active";
                enabled();
                colormethod();
            }

            if (richTextBox1.Text == "List of products" || richTextBox1.Text == "Products List"
                || richTextBox1.Text == "56")
            {
                ProductList();
            }

            if(richTextBox1.Text == "Add" || richTextBox1.Text == "Add to" || richTextBox1.Text == "Add the")
            {
                TBLPRODUCT t = new TBLPRODUCT();
                t.NAME = TxtName.Text;
                t.BRAND = TxtMark.Text;
                t.SELLPRICE = decimal.Parse(TxtSellPrice.Text);
                t.BUYPRICE = decimal.Parse(TxtBuyPrice.Text);
                t.STOCK = short.Parse(TxtStock.Text);
                t.PRODUCTCASE = true;
                t.DATEADDPRO = DateTime.Parse(comboBox1.Text);
                t.CATEGORY = TxtCategory.Text;
                db.TBLPRODUCT.Add(t);
                db.SaveChanges();
                label10.Text = "Products saved in Database";


            }

            if(richTextBox1.Text == "Products name" || richTextBox1.Text == "Products List"
                || richTextBox1.Text == "55" || richTextBox1.Text == "Product"
                || richTextBox1.Text == "Products" || richTextBox1.Text == "Name"
                || richTextBox1.Text == "Main")
            {
                TxtName.Focus();
                TxtName.BackColor = Color.Yellow;
                TxtName.Enabled = true;
            }

            if (richTextBox1.Text == "Mark" || richTextBox1.Text == "Brand")
            {
                TxtMark.Focus();
                TxtMark.BackColor = Color.Yellow;
                TxtMark.Enabled = true;
            }

            if (richTextBox1.Text == "Stock" || richTextBox1.Text == "Stocks"
                || richTextBox1.Text == "Store")
            {
                TxtStock.Focus();
                TxtStock.BackColor = Color.Yellow;
                TxtStock.Enabled = true;
            }

            if (richTextBox1.Text == "Sell price"|| richTextBox1.Text == "52" 
                || richTextBox1.Text == "Sales" || richTextBox1.Text == "Sale")
            {
                TxtSellPrice.Focus();
                TxtSellPrice.BackColor = Color.Yellow;
                TxtSellPrice.Enabled = true;
            }

            if (richTextBox1.Text == "Buy price" || richTextBox1.Text == "Buying price"
                || richTextBox1.Text == "By" || richTextBox1.Text == "Buy")
            {
                TxtBuyPrice.Focus();
                TxtBuyPrice.BackColor = Color.Yellow;
                TxtBuyPrice.Enabled = true;
            }

            if (richTextBox1.Text == "Category"|| richTextBox1.Text == "Set"
                || richTextBox1.Text == "Group" || richTextBox1.Text == "Cluster")
            {
                TxtCategory.Focus();
                TxtCategory.BackColor = Color.Yellow;
                TxtCategory.Enabled = true;
            }

            if (richTextBox1.Text == "Date" )
            {
                maskedTextBox1.Focus();
                maskedTextBox1.BackColor = Color.Yellow;
                maskedTextBox1.Enabled = true;
            }

            if (richTextBox1.Text == "State" || richTextBox1.Text == "Case")
            {
                comboBox1.Enabled = true;
                comboBox1.Focus();
                comboBox1.BackColor = Color.Yellow;
            }

            if (richTextBox1.Text == "Exit application" || richTextBox1.Text == "Exits application" ||
                richTextBox1.Text == "Exit app" || richTextBox1.Text == "Exit")
            {
                timer1.Stop();
                Application.Exit();
            }
            if(richTextBox1.Text == "Paint")
            {
                System.Diagnostics.Process.Start("MsPaint");
            }

            

        }

        private void label10_TextChanged(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(label10.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            Grammar g = new DictationGrammar();
            sr.LoadGrammar(g);
            try
            {
                BtnSpeak.Text = "Please Speak";
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult res = sr.Recognize();
                richTextBox1.Text = res.Text;
            }
            catch (Exception)
            {
                BtnSpeak.Text = "Error Try Again";
            }
        }
    }
}
