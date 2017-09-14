using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
          
            Stack<string> rpnStack = new Stack<string>();
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            string firstOperand, secondOperand;

           // if(parts.Count() == 1) { return "E"; }

            foreach (string token in parts)
            {
                if (isNumber(token))
                {
                    rpnStack.Push(token);
                }
                else if (token == "%")
                {
                    secondOperand = rpnStack.Pop();
                    firstOperand = rpnStack.Pop();
                    result = calculate(token, firstOperand, secondOperand, 4);
                    rpnStack.Push(firstOperand);
                    rpnStack.Push(result);
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there is only one left in stack?
                    try
                    {
                        secondOperand = rpnStack.Pop();
                        firstOperand = rpnStack.Pop();
                        result = calculate(token, firstOperand, secondOperand, 4);
                        if (result is "E")
                        {
                            return result;
                        }
                        rpnStack.Push(result);
                    }
                    catch
                    {
                        return "E";
                    }                 
                }
                else if (token == "1/X" || token == "√")
                {
                    firstOperand = rpnStack.Pop();
                    result = unaryCalculate(token, firstOperand, 8);
                    rpnStack.Push(result);
                   
                }
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            if(rpnStack.Count() == 0 ||rpnStack.Count() > 1 ) { return "E"; }
            else
            {
                result = rpnStack.Pop();
                return result;
            }
            
        }
    }
}
