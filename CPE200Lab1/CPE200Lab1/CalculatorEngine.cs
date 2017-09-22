using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        protected bool isNumber(string str) // protected = คลาสที่สืบทดก็ใช้ได้
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        protected bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return true;
                default: return false;
                    break;
            }
            
        }

        public string Process(string str)
        {

            if (str == "0") { return "0"; }
            else if (str == null) { return "E"; }
            //Split input string to multiple parts by space
            List<string> parts = str.Split(' ').ToList<string>(); 
            
            string result;
            //As long as we have more than one part
            while(parts.Count > 1)
            {
                //Check if the first three is ready for calcuation
                if (!(isNumber(parts[0]) && isOperator(parts[2]) && isNumber(parts[1]))) 
                {
                    return "E";
                } 
                else
                {
                    //Calculate the first three
                    result = calculate(parts[1], parts[0], parts[2]);
                    //Remove the first three
                    parts.RemoveRange(0, 3);
                    // Put back the result
                    parts.Insert(0, result);
                }

                
            }
            return parts[0];
        }
        public string calculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;
                        try
                        {
                            result = Math.Sqrt(Convert.ToDouble(operand));
                        }
                        catch
                        {
                            return "E";
                        }
                        
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
                case "1/X":
                    if(operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(operand));
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

        public string calculate(string operate, string firstOperand, string secondOperand)
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
                        //string[] parts;
                        //int remainLength;
                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        if(Convert.ToDouble(firstOperand) % Convert.ToDouble(secondOperand) == 0)
                        {
                            return result.ToString();
                            //return Convert.ToString(Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        }
                        //else
                        //{

                        // split between integer part and fractional part
                        /*parts = result.ToString().Split('.');
                          // if integer part length is already break max output, return error
                          if (parts[0].Length > maxOutputSize)
                          {
                              return "E";
                          }*/
                        // calculate remaining space for fractional part.
                        //remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        result = Math.Round(result, 4);
                        return Convert.ToString(result);//N" + remainLength);
                        //}
                        
                    }
                    break;
                case "%":
                    //your code here
                    double r = Convert.ToDouble(firstOperand) * (Convert.ToDouble(secondOperand) / 100);
                    return r.ToString();
                    break;
            }
            return "E";
        }
    }
}
