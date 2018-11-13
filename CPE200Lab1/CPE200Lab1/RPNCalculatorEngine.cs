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
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            // your code here
            Stack<string> number = new Stack<string>();
            string[] part = str.Split(' ');
            string firstOp;
            string seccondOp;
            
            foreach(string text in part)
            {
                if (isNumber(text))
                {
                    number.Push(text);
                }
                else if(isOperator(text) && number.Count >= 2) // chack have a number
                {
                    seccondOp = number.Pop(); //if have number than give seccond number = seccondOp
                    firstOp = number.Pop(); //than give first number = firstOp
                    if(text == "%")
                    {
                        number.Push(firstOp);
                    }
                    number.Push(calculate(text, firstOp, seccondOp));
                }
                else try // chack Exception
                {
                    string num = number.Pop();
                    number.Push(unaryCalculate(text, num));
                }
                catch (Exception)
                {
                    return "E";
                }
            }
            if(number.Count == 1)
            {
                try // check Exception
                {
                    return number.Peek();
                }
                catch(Exception)
                {
                    return "E";
                }
            }
            return "E";
        }
    }
}
