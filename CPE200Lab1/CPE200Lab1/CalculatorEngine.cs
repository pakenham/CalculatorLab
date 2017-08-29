using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    {
        public CalculatorEngine() { } // construction
       

        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength);
                    }
                    break;
           
            }
            return "E";
        }

        public string percentage(bool hasOperate,string firstOperand,string textbox)
        {
            if (hasOperate == true)
            {
                double percentage = Convert.ToDouble(firstOperand) * (Convert.ToDouble(textbox) / 100);
                return textbox = Convert.ToString(percentage);
            }
            else {return textbox = Convert.ToString(Convert.ToDouble(textbox) / 100); }
        }

        public string sqrt(string textbox)
        {
             return Convert.ToString(Math.Sqrt(Convert.ToDouble(textbox)));
            
        }

        public string oneOx(string textbox)
        {
            return Convert.ToString(1 / Convert.ToDouble(textbox));
        }

        public double mPlus(string textbox,double memo)
        {
            return memo + Convert.ToDouble(textbox);
        }

        public double mMinus(string textbox, double memo)
        {
            return  memo - Convert.ToDouble(textbox);
        }

        public double MS(string textbox)
        {
            return Convert.ToDouble(textbox);
        }


    }
}
