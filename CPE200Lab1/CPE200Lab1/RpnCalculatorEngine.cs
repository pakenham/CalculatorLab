using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    class RpnCalculatorEngine : CalculatorEngine
    {
        /*public void testStack()
        {
            // creat and initializes a new stack
            Stack myStack = new Stack();
            myStack.Push("Hello");
            myStack.Push("World");
            System.Console.Out.WriteLine("Pop 1" + myStack.Pop());
            System.Console.Out.WriteLine("Pop 2" + myStack.Pop());
            System.Console.Out.WriteLine("Pop 3" + myStack.Pop());
        }*/

        public string RpnProcess(string stringInput)
        {
            string[] parts = stringInput.Split(' ');
            string result="";
            Stack rpnStack = new Stack();

            foreach(string input in parts) // แต่ละ element ของ parts ให้เอามาเป็น input
            //for(int i = 0; i < parts.Length; i++)
            {
                //string input = parts[i]; // = each part one by one
                if (isNumber(input))
                {
                    rpnStack.Push(input);
                }
                else if(isOperator(input))
                {
                    if(input == "+" || input == "-" || input == "X" || input == "÷")
                    {
                        string rpnOperate = input;
                        string secondRpnOperand = rpnStack.Pop().ToString();
                        string firstRpnOperand = rpnStack.Pop().ToString();
                        result = calculate(rpnOperate, firstRpnOperand, secondRpnOperand, 4);
                        rpnStack.Push(result);
                    }
                    if(input == "%")
                    {
                        string rpnOperate = input;
                        string secondRpnOperand = rpnStack.Pop().ToString();
                        string firstRpnOperand = rpnStack.Pop().ToString();
                        result = calculate(rpnOperate, firstRpnOperand, secondRpnOperand, 4);
                        rpnStack.Push(firstRpnOperand);
                        rpnStack.Push(result);
                    }
                    else if(input == "1/x" || input == "√" )
                    {
                        string rpnOperate = input;
                        string rpnOperand = rpnStack.Pop().ToString();                    
                        result = unaryCalculate(rpnOperate, rpnOperand);
                        if (result is "E" || result.Length > 8)
                        {
                            result = "Error";
                        }
                        else
                        {
                            rpnStack.Push(result);
                        }
                    }
                                  
                }             
            }
            return result;
    
          

        }

      
      

        /*public override string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            return base.calculate(operate, firstOperand, secondOperand,maxOutputSize);
        }*/
    }
}
