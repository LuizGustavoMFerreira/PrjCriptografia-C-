using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Security.Cryptography;

namespace Criptografia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox2.Text = getHash(richTextBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public string getHash(string entrada)
        {
            string txtResultado = "";
            byte[] txtMensagem = System.Text.Encoding.Default.GetBytes(entrada);
            System.Security.Cryptography.MD5CryptoServiceProvider txtmd5 = new MD5CryptoServiceProvider();
            byte[] txthashcode = txtmd5.ComputeHash(txtMensagem);
            for  (int i = 0; i < txthashcode.Length; i++)
            {
                txtResultado += (char)(txthashcode[i]);
            }
            return (txtResultado);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                richTextBox2.Text = getMd5(richTextBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public string getMd5(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
        }
    }
}
