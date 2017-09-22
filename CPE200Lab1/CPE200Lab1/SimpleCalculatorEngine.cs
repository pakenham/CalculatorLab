using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class SimpleCalculatorEngine : CalculatorEngine
    {
        protected double firstOperand;
        protected double secondOperand;

        public void setFirstOperand(string num)
        {
            firstOperand = Convert.ToDouble(num);
        }

        public void setSecondOperand(string num)
        {
            secondOperand = Convert.ToDouble(num);
        }

        public string calculate(string oper)
        {
            switch (oper)
            {
                case "+":
                    return (firstOperand + secondOperand).ToString();
                case "-":
                    return (firstOperand - secondOperand).ToString();
                case "X":
                    return (firstOperand * secondOperand).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != 0)
                    {
                        double result;
                        result = (firstOperand / secondOperand);
                        if ((firstOperand / secondOperand) == 0)
                        {
                            return result.ToString();
                        }
                        result = Math.Round(result, 4);
                        return Convert.ToString(result);
                    }
                    else { return "E"; }
                default:
                    return "E";
            }
        }
    }
}
