using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2__Controls
{
    public partial class Form1 : Form
    {
        int countOrders = 0;

        public Form1()
        {
            InitializeComponent();
            AddEvent();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {   
            string res = "Total price: ";           

            decimal totalPrice = 0;
            foreach (RadioButton rb in drinksGroupBox.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                    totalPrice += Convert.ToDecimal(rb.Tag);
            }
            foreach (RadioButton rb in mainDishGroupBox.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                    totalPrice += Convert.ToDecimal(rb.Tag);
            }
            foreach (RadioButton rb in dessertsGroupBox.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                    totalPrice += Convert.ToDecimal(rb.Tag);
            }            

            res += totalPrice.ToString() + "₴";
            

            MessageBox.Show($"{res}", $"#{++countOrders} {DateTime.Now.ToShortTimeString()}", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string order = $"#{countOrders} {totalPrice.ToString()}₴ - {DateTime.Now.ToShortTimeString()}{Environment.NewLine}";
            textBox1.Text += order.ToString();

        }

        private bool IsSelect()
        {
            bool isSelectedDrink = false;
            bool isSelectedDish = false;
            bool isSelectedDessert = false;

            foreach (RadioButton rb in drinksGroupBox.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                {
                    isSelectedDrink = true;
                    break;
                }
            }
            foreach (RadioButton rb in mainDishGroupBox.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                {
                    isSelectedDish = true;
                    break;
                }
            }

            foreach (RadioButton rb in dessertsGroupBox.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                {
                    isSelectedDessert = true;
                    break;
                }
            }

            return isSelectedDish && isSelectedDrink && isSelectedDessert;
        }

        private void AddEvent()
        {
            foreach (RadioButton rb in dessertsGroupBox.Controls.OfType<RadioButton>())
            {
                rb.CheckedChanged += RadioButtonCheckedChanged;
            }

            foreach (RadioButton rb in mainDishGroupBox.Controls.OfType<RadioButton>())
            {
                rb.CheckedChanged += RadioButtonCheckedChanged;
            }

            foreach (RadioButton rb in drinksGroupBox.Controls.OfType<RadioButton>())
            {
                rb.CheckedChanged += RadioButtonCheckedChanged;
            }
        }

        private void RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            orderButton.Enabled = IsSelect();
        }
       
    }
}
