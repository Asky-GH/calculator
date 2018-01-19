using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private Stack<double> numbers;
        private Stack<string> operators;

        public Calculator()
        {
            InitializeComponent();

            this.ActiveControl = label_History;

            numbers = new Stack<double>();
            operators = new Stack<string>();
        }

        #region Кнопки
        #region Функции
        private void button_Percent_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if ((textBox_Screen.Text != "" && "-+*/(^".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1])) || textBox_Screen.Text == "")
            {
                return;
            }

            textBox_Screen.Text += "%";
        }

        private void button_Sin_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            textBox_Screen.Text += "Sin(";
        }

        private void button_Cos_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            textBox_Screen.Text += "Cos(";
        }

        private void button_Tan_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            textBox_Screen.Text += "Tan(";
        }

        private void button_E_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if (textBox_Screen.Text != "" && "0123456789,".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1]))
            {
                return;
            }

            textBox_Screen.Text += Math.E.ToString();
        }

        private void button_Factorial_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if ((textBox_Screen.Text != "" && "-+*/(^".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1])) || textBox_Screen.Text == "")
            {
                return;
            }

            textBox_Screen.Text += "!";
        }

        private void button_Ln_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            textBox_Screen.Text += "Ln(";
        }

        private void button_Log_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            textBox_Screen.Text += "Log(";
        }

        private void button_Sqrt_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            textBox_Screen.Text += "Sqrt(";
        }

        private void button_Sqr_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if (textBox_Screen.Text == "")
            {
                textBox_Screen.Text = "0^";
            }
            textBox_Screen.Text += "0123456789)!%,".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1]) ? "^" : "";
        }
        #endregion
        #region Дополнительные символы
        private void button_LeftBracket_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            textBox_Screen.Text += "(";
        }

        private void button_RightBracket_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if (textBox_Screen.Text == "")
            {
                return;
            }
            else if (textBox_Screen.Text[textBox_Screen.Text.Length - 1] == '(' || "+-*/".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1]))
            {
                return;
            }

            if ("()".Contains(textBox_Screen.Text))
            {
                int leftParan = 0, rightParan = 0;
                foreach (char ch in textBox_Screen.Text)
                {
                    switch (ch)
                    {
                        case '(':
                            leftParan++;
                            break;

                        case ')':
                            rightParan++;
                            break;
                    }
                }
                if (leftParan == rightParan)
                {
                    return;
                }
            }

            textBox_Screen.Text += ")";
        }

        private void button_Dot_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if (textBox_Screen.Text != "")
            {
                int length = textBox_Screen.Text.Length;
                if (textBox_Screen.Text[length - 1] == ',' || textBox_Screen.Text[0] == ',')
                {
                    return;
                }
                else
                {
                    string dotCheck = "";
                    for (int i = length - 1; i >= 0; i--)
                    {
                        if ("+-*/^(".Contains(textBox_Screen.Text[i]))
                        {
                            break;
                        }
                        else
                        {
                            dotCheck += textBox_Screen.Text[i].ToString();
                        }
                    }
                    textBox_Screen.Text += dotCheck.Contains(',') ? "" : ",";
                    return;
                }
            }

            textBox_Screen.Text += ",";
        }
        #endregion
        #region Цифры
        private void button0_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if (textBox_Screen.Text != "" && "!%".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1]))
            {
                return;
            }

            textBox_Screen.Text += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if (textBox_Screen.Text != "" && "!%".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1]))
            {
                return;
            }

            textBox_Screen.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if (textBox_Screen.Text != "" && "!%".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1]))
            {
                return;
            }

            textBox_Screen.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if (textBox_Screen.Text != "" && "!%".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1]))
            {
                return;
            }

            textBox_Screen.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if (textBox_Screen.Text != "" && "!%".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1]))
            {
                return;
            }

            textBox_Screen.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if (textBox_Screen.Text != "" && "!%".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1]))
            {
                return;
            }

            textBox_Screen.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if (textBox_Screen.Text != "" && "!%".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1]))
            {
                return;
            }

            textBox_Screen.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if (textBox_Screen.Text != "" && "!%".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1]))
            {
                return;
            }

            textBox_Screen.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if (textBox_Screen.Text != "" && "!%".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1]))
            {
                return;
            }

            textBox_Screen.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if (textBox_Screen.Text != "" && "!%".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1]))
            {
                return;
            }

            textBox_Screen.Text += "9";
        }
        #endregion
        #region Операторы
        private void button_Div_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if (textBox_Screen.Text == "")
            {
                return;
            }
            else
            {
                textBox_Screen.Text += "0123456789),!%".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1]) ? "/" : "";
                if (textBox_Screen.Text.Length > 1)
                {
                    switch (textBox_Screen.Text[textBox_Screen.Text.Length - 1])
                    {
                        case '+':
                        case '*':
                            button_Del.PerformClick();
                            textBox_Screen.Text += "/";
                            break;
                    }
                }
            }
        }

        private void button_Mult_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if (textBox_Screen.Text == "")
            {
                return;
            }
            else
            {
                textBox_Screen.Text += "0123456789),!%".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1]) ? "*" : "";
                if (textBox_Screen.Text.Length > 1)
                {
                    switch (textBox_Screen.Text[textBox_Screen.Text.Length - 1])
                    {
                        case '+':
                        case '/':
                            button_Del.PerformClick();
                            textBox_Screen.Text += "*";
                            break;
                    }
                }
            }
        }

        private void button_Minus_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if (textBox_Screen.Text == "")
            {
                textBox_Screen.Text += "-";
            }
            else
            {
                textBox_Screen.Text += "(0123456789)*/!%,^".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1]) ? "-" : "";
                if (textBox_Screen.Text.Length > 1 && textBox_Screen.Text[textBox_Screen.Text.Length - 1] == '+')
                {
                    button_Del.PerformClick();
                    textBox_Screen.Text += "-";
                }
            }
        }

        private void button_Plus_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }

            if (textBox_Screen.Text == "")
            {
                return;
            }
            else
            {
                textBox_Screen.Text += "0123456789)!%,".Contains(textBox_Screen.Text[textBox_Screen.Text.Length - 1]) ? "+" : "";
                if (textBox_Screen.Text.Length > 1)
                {
                    switch (textBox_Screen.Text[textBox_Screen.Text.Length - 1])
                    {
                        case '/':
                        case '*':
                            button_Del.PerformClick();
                            textBox_Screen.Text += "+";
                            break;
                    }
                }

            }
        }
        #endregion
        #region Прочие
        private void button_Equal_Click(object sender, EventArgs e)
        {
            if ("()".Contains(textBox_Screen.Text))
            {
                int leftParan = 0, rightParan = 0;
                foreach (char ch in textBox_Screen.Text)
                {
                    switch (ch)
                    {
                        case '(':
                            leftParan++;
                            break;

                        case ')':
                            rightParan++;
                            break;
                    }
                }
                if (leftParan != rightParan)
                {
                    return;
                }
            }

            string input = Format();
            label_History.Text = input + '=';
            string[] inputArray = input.Split(' ');
            inputArray[inputArray.Length - 1] = ")";
            double output = 0;
            try
            {
                output = Calculate(inputArray);
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233079 || ex.HResult == -2146233033)
                {
                    textBox_Screen.Text = "Invalid input";
                    return;
                }
            }            
            textBox_Screen.Text = output.ToString();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            label_History.Text = "";
            textBox_Screen.Text = "";
        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            if (label_History.Text != "")
            {
                button_Clear.PerformClick();
            }
            else
            {
                int length = textBox_Screen.Text.Length;
                string newText = "";
                for (int i = 0; i < length - 1; i++)
                {
                    newText += textBox_Screen.Text[i];
                }
                textBox_Screen.Text = newText;
            }
        }
        #endregion
        #endregion

        #region Алгоритм вычисления
        private int Precedence(string input)
        {
            switch (input)
            {
                case "+":
                case "-":
                    return 1;

                case "*":
                case "/":
                    return 2;

                case "Sin":
                case "Cos":
                case "Tan":
                case "Ln":
                case "Log":
                case "Sqrt":
                    return 3;

                case "^":
                    return 4;

                case "(":
                    return 5;

                case ")":
                    return 0;
            }
            return -1;
        }

        private double Calculate(string[] inputArray)
        {
            foreach (string input in inputArray)
            {
                if (input == "")
                {
                    continue;
                }
                if ("+-*/()SinCosTanLnLogSqrt^".Contains(input))
                {
                    while (operators.Count > 0)
                    {
                        if (Precedence(operators.Peek()) >= Precedence(input) && operators.Peek() != "(")
                        {
                            Evaluate();
                        }
                        else if (input == ")")
                        {
                            operators.Pop();
                            if (operators.Count > 0 && "SinCosTanLnLogSqrt".Contains(operators.Peek()))
                            {
                                Evaluate();
                            }
                            break;
                        }
                        else
                        {
                            operators.Push(input);
                            break;
                        }
                    }
                    if (operators.Count == 0 && input != ")")
                    {
                        operators.Push(input);
                    }
                }
                else if ("!%".Contains(input))
                {
                    operators.Push(input);
                    Evaluate();
                }
                else
                {
                    numbers.Push(double.Parse(input));
                }
            }
            return numbers.Pop();
        }

        private void Evaluate()
        {
            string operation = operators.Pop();
            double operand = 0, leftOperand = 0, rightOperand = 0;
            if ("+-*/^".Contains(operation))
            {
                rightOperand = numbers.Pop();
                leftOperand = numbers.Pop();
            }
            else
            {
                operand = numbers.Pop();
            }
            switch (operation)
            {
                case "+":
                    numbers.Push(leftOperand + rightOperand);
                    break;

                case "-":
                    numbers.Push(leftOperand - rightOperand);
                    break;

                case "*":
                    numbers.Push(leftOperand * rightOperand);
                    break;

                case "/":
                    numbers.Push(leftOperand / rightOperand);
                    break;

                case "Sin":
                    numbers.Push(Math.Sin(operand));
                    break;

                case "Cos":
                    numbers.Push(Math.Cos(operand));
                    break;

                case "Tan":
                    numbers.Push(Math.Tan(operand));
                    break;

                case "Ln":
                    numbers.Push(Math.Log(operand));
                    break;

                case "Log":
                    numbers.Push(Math.Log10(operand));
                    break;

                case "%":
                    numbers.Push(operand / 100);
                    break;

                case "!":
                    numbers.Push(Factorial(operand));
                    break;

                case "Sqrt":
                    numbers.Push(Math.Sqrt(operand));
                    break;

                case "^":
                    numbers.Push(Math.Pow(leftOperand, rightOperand));
                    break;
            }
        }
        #endregion

        private double Factorial(double operand)
        {
            int sign = operand < 0 ? -1 : 1;
            if (sign < 0)
            {
                operand *= -1;
            }
            double factorial = 1;
            for (int i = 1; i <= operand; i++)
            {
                factorial *= i;
            }
            factorial *= sign;
            return factorial;
        }

        private string Format()
        {
            string input = "";
            int length = textBox_Screen.Text.Length;
            for (int i = 0; i < length; i++)
            {
                if ("+*/nsgt!w%(^)".Contains(textBox_Screen.Text[i]))
                {
                    if (textBox_Screen.Text[i] == ')' && (i + 1 < textBox_Screen.Text.Length) && "0123456789,SCTL(".Contains(textBox_Screen.Text[i + 1]))
                    {
                        input += textBox_Screen.Text[i] + " * ";
                        continue;
                    }
                    else if (textBox_Screen.Text[i] == '(' && i - 1 >= 0 && "%!)0123456789,".Contains(textBox_Screen.Text[i - 1])) 
                    {
                        input += " * " + textBox_Screen.Text[i] + " ";
                        continue;
                    }
                    input += textBox_Screen.Text[i] + " ";
                }
                else if ("SCTLioqrac".Contains(textBox_Screen.Text[i]))
                {
                    input += textBox_Screen.Text[i];
                }
                else if (textBox_Screen.Text[i] == ',')
                {
                    if ((i + 1 < textBox_Screen.Text.Length) && "SCTL()%!+-*/^".Contains(textBox_Screen.Text[i + 1]) && i == 0)
                    {
                        input = "Invalid input ";
                        break;
                    }
                    else if ((i + 1 < textBox_Screen.Text.Length) && "%!^+-/*".Contains(textBox_Screen.Text[i + 1]))
                    {
                        input += textBox_Screen.Text[i] + " ";
                        continue;
                    }
                    else if ((i + 1 < textBox_Screen.Text.Length) && "SCTL".Contains(textBox_Screen.Text[i + 1]))
                    {
                        input += textBox_Screen.Text[i] + " * ";
                        continue;
                    }
                    input += textBox_Screen.Text[i];
                }
                else if (textBox_Screen.Text[i] == '-')
                {
                    if ((i - 1 >= 0) && "*/(^".Contains(textBox_Screen.Text[i - 1]) || i == 0 && ((i + 1 < textBox_Screen.Text.Length) && !"SCTL".Contains(textBox_Screen.Text[i + 1])))
                    {
                        input += textBox_Screen.Text[i];
                    }
                    else if ((i + 1 < textBox_Screen.Text.Length) && "SCTL".Contains(textBox_Screen.Text[i + 1]))
                    {
                        input += "-1 * ";
                    }
                    else
                    {
                        input += textBox_Screen.Text[i] + " ";
                    }
                }
                else
                {
                    if ((i + 1 < textBox_Screen.Text.Length) && "0123456789,".Contains(textBox_Screen.Text[i + 1]))
                    {
                        input += textBox_Screen.Text[i];
                    }
                    else if ((i + 1 < textBox_Screen.Text.Length) && "SCTL".Contains(textBox_Screen.Text[i + 1]))
                    {
                        input += textBox_Screen.Text[i] + " * ";
                    }
                    else
                    {
                        input += textBox_Screen.Text[i] + " ";
                    }
                }
            }
            return input;
        }

        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.D5)
            {
                button_Percent.PerformClick();
            }
            else if(e.Shift && e.KeyCode == Keys.D6)
            {
                button_Sqr.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.D1)
            {
                button_Factorial.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.D9)
            {
                button_LeftBracket.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.D0)
            {
                button_RightBracket.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.D8)
            {
                button_Mult.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.Oemplus)
            {
                button_Plus.PerformClick();
            }

            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        this.Close();
                        break;

                    case Keys.Back:
                    case Keys.Delete:
                        button_Del.PerformClick();
                        break;
                    case Keys.Space:
                        button_Clear.PerformClick();
                        break;

                    case Keys.D0:
                    case Keys.NumPad0:
                        button0.PerformClick();
                        break;
                    case Keys.D1:
                    case Keys.NumPad1:
                        button1.PerformClick();
                        break;
                    case Keys.D2:
                    case Keys.NumPad2:
                        button2.PerformClick();
                        break;
                    case Keys.D3:
                    case Keys.NumPad3:
                        button3.PerformClick();
                        break;
                    case Keys.D4:
                    case Keys.NumPad4:
                        button4.PerformClick();
                        break;
                    case Keys.D5:
                    case Keys.NumPad5:
                        button5.PerformClick();
                        break;
                    case Keys.D6:
                    case Keys.NumPad6:
                        button6.PerformClick();
                        break;
                    case Keys.D7:
                    case Keys.NumPad7:
                        button7.PerformClick();
                        break;
                    case Keys.D8:
                    case Keys.NumPad8:
                        button8.PerformClick();
                        break;
                    case Keys.D9:
                    case Keys.NumPad9:
                        button9.PerformClick();
                        break;

                    case Keys.C:
                        button_Cos.PerformClick();
                        break;
                    case Keys.E:
                        button_E.PerformClick();
                        break;
                    case Keys.G:
                        button_Log.PerformClick();
                        break;
                    case Keys.L:
                        button_Ln.PerformClick();
                        break;
                    case Keys.Q:
                        button_Sqrt.PerformClick();
                        break;
                    case Keys.S:
                        button_Sin.PerformClick();
                        break;
                    case Keys.T:
                        button_Tan.PerformClick();
                        break;

                    case Keys.Multiply:
                        button_Mult.PerformClick();
                        break;
                    case Keys.Add:
                        button_Plus.PerformClick();
                        break;
                    case Keys.Subtract:
                    case Keys.OemMinus:
                        button_Minus.PerformClick();
                        break;
                    case Keys.Divide:
                    case Keys.OemQuestion:
                        button_Div.PerformClick();
                        break;

                    case Keys.Decimal:
                    case Keys.OemPeriod:
                        button_Dot.PerformClick();
                        break;

                    case Keys.Enter:
                    case Keys.Oemplus:
                        button_Equal.PerformClick();
                        break;
                }
            }
        }

    }
}
