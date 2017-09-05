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
        public void testStack()
        {
            // creat and initializes a new stack
            Stack myStack = new Stack();
            myStack.Push("Hello");
            myStack.Push("World");
            System.Console.Out.WriteLine("Pop 1" + myStack.Pop());
            System.Console.Out.WriteLine("Pop 2" + myStack.Pop());
            System.Console.Out.WriteLine("Pop 3" + myStack.Pop());
        }

        /*public override string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            return base.calculate(operate, firstOperand, secondOperand,maxOutputSize);
        }*/
    }
}
