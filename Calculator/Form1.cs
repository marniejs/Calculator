using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        string currentCalculation = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            currentCalculation += (sender as Button).Text;
            outputBox.Text = currentCalculation;
        }

        private void button_equals_Click(object sender, EventArgs e)
        {
            string formattedCalculation = currentCalculation.ToString().Replace("X", "*");

            try
            {
                outputBox.Text = new DataTable().Compute(formattedCalculation, null).ToString();
                currentCalculation = outputBox.Text;
            }

            catch (Exception ex)
            {
                outputBox.Text = "0";
                currentCalculation = "";
            }
        }
        private void button_clear_Click(object sender, EventArgs e)
        {
            outputBox.Text = "0";
            currentCalculation = "";
        }

        private void button_clearEntry_Click(object sender, EventArgs e)
        {
            if (currentCalculation.Length > 0)
            {
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
            }

            outputBox.Text = currentCalculation;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
