using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBCmode
{
    public partial class Form1 : Form
    {
        string iv = "";
        string plain = "";
        List<string> plainbinary = new List<string>();
        List<string> encryption = new List<string>();
        List<string> decryption = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetEncryptListView();
            ResetDecryptListView();
        }

        private void button1_Click(object sender, EventArgs e) //encreypt button
        {
            ResetEncryptListView();
            ResetDecryptListView();
            Encoding();
            GetKey();
            Encryption();
            UpdateEncryptListView();

        }

        private void button2_Click(object sender, EventArgs e) //decrypt btn
        {
            ResetDecryptListView();
            Decryption();
            Decoding();
            UpdateDecryptListView();
        }


        #region Encrypt
        private void Encoding()
        {
            plainbinary = Encoder.Encoding(textBox1.Text);
            foreach (string a in plainbinary)
                textBox2.Text += a;
        }
        private void GetKey()
        {
            iv = Rand.GetRandomBinary();
            textBox3.Text = iv;
            textBox8.Text = iv;
        }
        private void Encryption()
        {
            encryption = Encrypt.Encryption(plainbinary, iv);
            foreach (string a in encryption)
            {
                textBox4.Text += a;
                textBox7.Text += a;
            }

        }
        private void ResetEncryptListView()
        {
            listView1.View = View.Details;

            plainbinary.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox7.Clear();

            listView1.Clear();
            //ResetDecryptListView();
            listView1.Width = 360;

            listView1.Columns.Add("키", 120, HorizontalAlignment.Center);
            listView1.Columns.Add("평문 블록", 120, HorizontalAlignment.Center);
            listView1.Columns.Add("암호문(xor결과)", 120, HorizontalAlignment.Center);

        }
        private void UpdateEncryptListView()
        {
            listView1.Items.Add(textBox3.Text); //iv

            for(int i = 0; i<encryption.Count-1;i++)
            {
                listView1.Items.Add(encryption[i]);
            }
            for (int i = 0; i < plainbinary.Count; i++)
            {
                listView1.Items[i].SubItems.Add(plainbinary[i]);
            }
            for (int i = 0; i < encryption.Count; i++)
            {
                listView1.Items[i].SubItems.Add(encryption[i]);
            }
        }
        #endregion

        #region Decrypt

        private void Decryption()
        {
            decryption = Decrypt.Decryption(encryption, iv);
            foreach (string s in decryption)
                textBox6.Text += s;
        }

        private void Decoding()
        {
            plain = Decoder.Decoding(decryption);
            textBox5.Text = plain;
        }

        private void ResetDecryptListView()
        {
            listView2.View = View.Details;

            plainbinary.Clear();
            textBox5.Clear();
            textBox6.Clear();

            listView2.Clear();
            //ResetDecryptListView();
            listView2.Width = 360;

            listView2.Columns.Add("키", 120, HorizontalAlignment.Center);
            listView2.Columns.Add("암호문", 120, HorizontalAlignment.Center);
            listView2.Columns.Add("평문 블록(xor결과)", 120, HorizontalAlignment.Center);

        }

        private void UpdateDecryptListView()
        {
            listView2.Items.Add(textBox8.Text); //iv

            for (int i = 0; i < encryption.Count - 1; i++)
            {
                listView2.Items.Add(encryption[i]);
            }
            for (int i = 0; i < encryption.Count; i++)
            {
                listView2.Items[i].SubItems.Add(encryption[i]);
            }
            for (int i = 0; i < decryption.Count; i++)
            {
                listView2.Items[i].SubItems.Add(decryption[i]);
            }
        }

        #endregion

    }
}

