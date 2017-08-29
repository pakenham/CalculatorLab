using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class MainForm : Form
    {
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string operate;
        private string operate2;
        private double memo;


        // calculating
        private CalculatorEngine calculatorE = new CalculatorEngine();
        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            memo = 0;
        }
        public MainForm()
        {
            InitializeComponent();

            resetAll();
        }

        // ui
        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                lblDisplay.Text = "0";
            }
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            isAllowBack = true;
            string digit = ((Button)sender).Text;
            if (lblDisplay.Text is "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text += digit;
            isAfterOperater = false;
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }

            operate = ((Button)sender).Text;
            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;

            }
            isAllowBack = false;

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string secondOperand = lblDisplay.Text;
            string result = calculatorE.calculate(operate, firstOperand, secondOperand);
            if (result is "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }
            isAfterEqual = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if (!hasDot)
            {
                lblDisplay.Text += ".";
                hasDot = true;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            // already contain negative sign
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if (lblDisplay.Text[0] is '-')
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
            }
            else
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if (lblDisplay.Text != "0")
            {
                string current = lblDisplay.Text;
                char rightMost = current[current.Length - 1];
                if (rightMost is '.')
                {
                    hasDot = false;
                }
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if (lblDisplay.Text is "" || lblDisplay.Text is "-")
                {
                    lblDisplay.Text = "0";
                }
            }
        }

        private void btnPercent_Click_1(object sender, EventArgs e)
        {
            double percentage = Convert.ToDouble(firstOperand) * (Convert.ToDouble(lblDisplay.Text) / 100);
            lblDisplay.Text = Convert.ToString(percentage);

        }

        private void btnSq_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(lblDisplay.Text);
            double xhi = x;
            double xlo = 0;
            double guess = x / 2;

            while (guess * guess != x)
            {
                if (guess * guess > x) { xhi = guess; }
                else { xlo = guess; }
                double new_guess = (xhi + xlo) / 2;
                if (new_guess == guess)
                {
                    break; // not getting closer }  
                    guess = new_guess;
                }
                lblDisplay.Text = Convert.ToString(guess);
            }
        }

        private void btn1Ox_Click(object sender, EventArgs e)
        {
            double fraction = 1 / Convert.ToDouble(lblDisplay.Text);
            lblDisplay.Text = Convert.ToString(fraction);
        }

        private void mPlus_Click(object sender, EventArgs e)
        {
            double value = Convert.ToDouble(lblDisplay.Text);
            memo += value;
        }

        private void mMinus_Click(object sender, EventArgs e)
        {
            double value = Convert.ToDouble(lblDisplay.Text);
            memo -= value;
        }

        private void MR_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = Convert.ToString(memo);
        }

        private void CE_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = " ";
        }

        private void MC_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = Convert.ToString(memo);
            memo = 0;
        }

        private void MS_Click(object sender, EventArgs e)
        {
            memo = Convert.ToDouble(lblDisplay.Text);
        }
    }
}
