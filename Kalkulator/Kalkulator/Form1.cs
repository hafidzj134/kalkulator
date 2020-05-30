﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double hasil=0;
        string operasi = "";
        bool angkaBaru = true;
        bool operasiBerjalan = false;

        Hitung ht = new Hitung();

        private void buttonAngka_click(object sender, EventArgs e)
        {
            if (txtMain.Text == "0" || operasiBerjalan==true && angkaBaru==true)
                txtMain.Clear();
            angkaBaru = false;
            Button btn = (Button)sender;
            txtMain.Text = txtMain.Text + btn.Text;
        }

        private void buttonOperator_click(object sender, EventArgs e)
        {
            if(operasiBerjalan == false)
            {
                Button btn = (Button)sender;
                operasi = btn.Text;
                hasil = Double.Parse(txtMain.Text);
                txtSub.Text = hasil.ToString() + " " + operasi;
                txtMain.Text = "0";
            }
            else
            {
                switch (operasi)
                {
                    case "+":
                        txtMain.Text = Convert.ToString(ht.tambah(hasil, Double.Parse(txtMain.Text)));
                        break;
                    case "−":
                        txtMain.Text = Convert.ToString(ht.kurang(hasil, Double.Parse(txtMain.Text)));
                        break;
                    case "*":
                        txtMain.Text = Convert.ToString(ht.kali(hasil, Double.Parse(txtMain.Text)));
                        break;
                    case "/":
                        txtMain.Text = Convert.ToString(ht.bagi(hasil, Double.Parse(txtMain.Text)));
                        break;
                }
                hasil = Double.Parse(txtMain.Text);
                txtSub.Text = txtMain.Text + " " + operasi;
                txtMain.Text = "0";
                Button btn = (Button)sender;
                operasi = btn.Text;
            }
            operasiBerjalan = true; angkaBaru = true;
        }

        private void buttonHasil_click(object sender, EventArgs e)
        {
            txtSub.Text = txtSub.Text + " " + txtMain.Text + " =";
            switch (operasi)
            {
                case "+":
                    txtMain.Text = Convert.ToString(ht.tambah(hasil, Double.Parse(txtMain.Text)));
                    break;
                case "−":
                    txtMain.Text = Convert.ToString(ht.kurang(hasil, Double.Parse(txtMain.Text)));
                    break;
                case "*":
                    txtMain.Text = Convert.ToString(ht.kali(hasil, Double.Parse(txtMain.Text)));
                    break;
                case "/":
                    txtMain.Text = Convert.ToString(ht.bagi(hasil, Double.Parse(txtMain.Text)));
                    break;
            }
            operasiBerjalan = false; angkaBaru = true;
        }

        private void buttonKoma_click(object sender, EventArgs e)
        {
            if (txtMain.Text.Contains("."))
            {
                txtMain.Text = txtMain.Text;
            }
            else
            {
                txtMain.Text = txtMain.Text + ".";
            }
        }

        private void buttonNegatif_click(object sender, EventArgs e)
        {
            if (txtMain.Text == "0")
            {
                txtMain.Text = "-";
            }
            else if (txtMain.Text == "-")
            {
                txtMain.Text = "0";
            }
            else
            {
                txtMain.Text = Convert.ToString(Double.Parse(txtMain.Text) * (-1));
            }
        }

        private void buttonClear_click(object sender, EventArgs e)
        {
            txtMain.Text = "0"; txtSub.Clear();
            hasil = 0;
            operasiBerjalan = false; angkaBaru = true;
        }

        private void buttonDel_click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMain.Text))
            {
                int i = txtMain.TextLength;
                txtMain.Text = txtMain.Text.Remove(i - 1, 1);
                if (String.IsNullOrEmpty(txtMain.Text))
                {
                    txtMain.Text = "0";
                }
            }
        }

    }
}
