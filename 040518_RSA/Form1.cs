using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _040518_RSA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private RSASifreleme nesne;

        Boolean dBirimTesti(int e,int d,int num1)
        {
            if ((d * e)%num1 ==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setNesne(new RSASifreleme(this));
        }
        RSASifreleme getNesne()
        {
            return nesne;
        }
        void setNesne(RSASifreleme nesne)
        {
            this.nesne = nesne;
        }

        private void btn_sifrele_Click(object sender, EventArgs e)
        {
                txt_ascii.Clear();
                txt_ascii0.Clear();
                txt_cozulmusMetin.Clear();
                txt_sifrelemeSonuc.Clear();
                txt_a_sifreliMetin.Clear();
                txt_a_cozulmus_ascii.Clear();
                txt_a_sifreliMetin.Text = nesne.Sifreleme(txt_acikMetin.Text);
        }
        
        private void btn_sifrecoz_Click(object sender, EventArgs e)
        {
            txt_cozulmusMetin.Text=nesne.Desifreleme(txt_a_sifreliMetin.Text);
        }
    }
}
