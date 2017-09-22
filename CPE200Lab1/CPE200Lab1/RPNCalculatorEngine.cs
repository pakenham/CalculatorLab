using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        protected Stack<string> myStack = new Stack<string>();

        public  string calculate(string str)
        {     
            if (str == "0") { return "0"; }
            else if (str == null) { return "E"; }
            List<string> parts = str.Split(' ').ToList<string>();
                string result;
                string firstOperand, secondOperand;
            parts.Remove(" ");
                
            if (parts.Count() == 1) { return "E"; }
            foreach (string token in parts)
            {
                string cc = token;

                if (isNumber(token))
                {
                    myStack.Push(token);
                }
                else if (token == "%")
                {
                    secondOperand = myStack.Pop();
                    firstOperand = myStack.Pop();
                    result = calculate(token, firstOperand, secondOperand);
                    myStack.Push(firstOperand);
                    myStack.Push(result);
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there is only one left in stack?
                    if(myStack.Count() > 1)
                    {
                        secondOperand = myStack.Pop();
                        firstOperand = myStack.Pop();
                        result = calculate(token,firstOperand,secondOperand);
                        if (result is "E")
                        {
                            return result;
                        }
                        myStack.Push(result) ;
                    }
                    else { return "E"; }
                   
                }
                else if (token == "1/X" || token == "√")
                {
                    firstOperand = myStack.Pop();
                    result = calculate(token);
                    myStack.Push(result);
                }
                else if(token != "")
                { return "E"; }

            }
                //FIXME, what if there is more than one, or zero, items in the stack?
            if (myStack.Count() == 0 || myStack.Count() > 1) { return "E"; }
            else
            {
                result = myStack.Pop();
                return result;
            }         
        }
    }
}
