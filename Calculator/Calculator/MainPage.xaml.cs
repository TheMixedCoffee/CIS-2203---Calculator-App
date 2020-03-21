using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
//Output of Magsipoc, Orbiso, Quinicot
namespace Calculator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        struct Equation
        {
            public float num1;
            public float num2;
            public int operatorSymbol;
        }

        Equation equation = new Equation();
        public bool isSecond; //Checks if it's the second operand
        public MainPage()
        {
            InitializeComponent();
            result.Text = 0.ToString();
            isSecond = false;
        }

        private void displayNum(float num)
        {
            if (isSecond == true)
            {
                result.Text = 0.ToString();
                isSecond = false;
            }
            if (char.IsNumber(result.Text.Last()))
            {
                if (result.Text.Length == 1 && result.Text == "0") //Default value when no input
                {
                    result.Text = string.Empty;
                }
                result.Text += num; //Change value of text to inputted number
            }
            else
            {
                if (num != 0 || result.Text == "0.")
                {
                    result.Text += num; //
                }
            }
        }

        private void checkUndefined()
        {
            if (result.Text == "undefined" || result.Text == "NaN") //Resets num1 as 0 so the user can proceed normally
            {
                equation.num1 = 0;
            }
            else
            {
                equation.num1 = float.Parse(result.Text);
            }
        }

        private void performOperation(Equation equation)
        {
            equation.num2 = float.Parse(result.Text);
            switch (equation.operatorSymbol)
            {
                case 1:
                    result.Text = (equation.num1 + equation.num2).ToString();
                    break;
                case 2:
                    result.Text = (equation.num1 - equation.num2).ToString();
                    break;
                case 3:
                    result.Text = (equation.num1 * equation.num2).ToString();
                    break;
                case 4:
                    if (equation.num1 == 0 && equation.num2 == 0) //Checks for 0/0
                    {
                        result.Text = "undefined";
                    }
                    else
                    {
                        result.Text = (equation.num1 / equation.num2).ToString();
                    }
                    break;
                case 5:
                    result.Text = (equation.num1 / 100).ToString();
                    break;
            }
        }

        private void clearBtn_Clicked(object sender, EventArgs e)
        {
            result.Text = "0";
            isSecond = false;
        }

        private void delBtn_Clicked(object sender, EventArgs e)
        {
            if(result.Text.Length == 1 || result.Text == "undefined" || result.Text == "NaN")
            {
                result.Text = 0.ToString();
            }
            else
            {
                result.Text = result.Text.Substring(0, result.Text.Length - 1);
            }
        }

        private void perBtn_Clicked(object sender, EventArgs e)
        {
            checkUndefined();
            equation.operatorSymbol = 5; 
            performOperation(equation); //Automatically performs the function when pressed
        }

        private void divBtn_Clicked(object sender, EventArgs e)
        {
            checkUndefined();
            equation.operatorSymbol = 4;
            isSecond = true;
        }

        private void sevenBtn_Clicked(object sender, EventArgs e)
        {
            displayNum(7);
        }

        private void eightBtn_Clicked(object sender, EventArgs e)
        {
            displayNum(8);
        }

        private void nineBtn_Clicked(object sender, EventArgs e)
        {
            displayNum(9);
        }

        private void multBtn_Clicked(object sender, EventArgs e)
        {
            checkUndefined();
            equation.operatorSymbol = 3;
            isSecond = true;
        }

        private void fourBtn_Clicked(object sender, EventArgs e)
        {
            displayNum(4);
        }

        private void fiveBtn_Clicked(object sender, EventArgs e)
        {
            displayNum(5);
        }

        private void sixBtn_Clicked(object sender, EventArgs e)
        {
            displayNum(6);
        }

        private void subBtn_Clicked(object sender, EventArgs e)
        {
            checkUndefined();
            equation.operatorSymbol = 2;
            isSecond = true;
        }

        private void oneBtn_Clicked(object sender, EventArgs e)
        {
            displayNum(1);
        }

        private void twoBtn_Clicked(object sender, EventArgs e)
        {
            displayNum(2);
        }

        private void threeBtn_Clicked(object sender, EventArgs e)
        {
            displayNum(3);
        }

        private void addBtn_Clicked(object sender, EventArgs e)
        {
            checkUndefined();
            equation.operatorSymbol = 1;
            isSecond = true;
        }

        private void zeroBtn_Clicked(object sender, EventArgs e)
        {
            displayNum(0);
        }

        private void decBtn_Clicked(object sender, EventArgs e)
        {
            if(!result.Text.Contains('.')) //Checks if the number is a float
            {
                result.Text += ".";
            }
        }

        private void equalBtn_Clicked(object sender, EventArgs e)
        {
            performOperation(equation);
            isSecond = false;
        }
    }
}
