using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class my_fuctions
    {


        #region Godel_Number
        public static int[] Godel_Number(int Input)
        {
            if (Input < 2)
                return new int[1] { 0 };
            Stack<int> stack = new Stack<int>();
            for (int i = 2; Input > 1; i++)
            {
                if (IsPrime(i))
                {
                    int factor = Factor(Input, i);
                    stack.Push(factor);
                    for (int j = 0; j < factor; j++)
                        Input /= i;
                }
            }
            int[] Ans = new int[stack.Count]; 
            for (int i = Ans.Length - 1; i >= 0; i--)
                Ans[i] = stack.Pop();
            return Ans;
        }

        public static Double Godel_Number2(Double[] Input)
        {
            Double Ans = 1;
            int k = 0;
            for (int i = 2; k < Input.Length; i++)
                if (IsPrime(i))
                {
                    if (Input[k] == 0)
                    {
                        k++;
                    }
                    else if (Input[k] != 0)
                    {
                        Ans *= Math.Pow(i, Input[k]);
                       // Ans *= Power(i, Input[k]);
                        k++;
                    }

                }
            return Ans;

        }

        private static int Power(int Input1, int Input2)
        {
           int  Ans = 1;
            for (int i = 0; i < Input2; i++)
                Ans *= Input1;
            return Ans;
        }
        private static int Factor(int Input1, int Input2)
        {
            int Ans = 0;
            while (Input1 % Input2 == 0)
            {
                Ans++;
                Input1 /= Input2;
            }
            return Ans;
        }
        private static bool IsPrime(int Input)
        {
            if (Input == 1 || Input == 0)
                return false;
            for (int i = 2; i < Input; i++)
                if (Input % i == 0)
                    return false;
            return true;
        }
        #endregion
        #region Pairing Function
        public static int Pairing2(int Input1, int Input2)
        {
            return Power(2, Input1) * (2 * Input2 + 1) - 1;
        }
        public static int[] Pairing2(int Input)
        {
            int[] Ans = new int[2];
            Input++;
            Ans[0] = Factor(Input, 2);
            if (Ans[0] > 0)
                Input /= Power(2, Ans[0]);
            Input--;
            Ans[1] = Input / 2;
            return Ans;
        }

        public static int Pairing3(int Input1, int Input2, int Input3)
        {
            return Pairing2(Input1, Pairing2(Input2, Input3));
        }

        public static int[] Pairing3(int Input)
        {
            int[] Ans = new int[3];
            int[] temp = Pairing2(Input);
            Ans[0] = temp[0];
            temp = Pairing2(temp[1]);
            Ans[1] = temp[0];
            Ans[2] = temp[1];
            return Ans;
        }
        #endregion


        public static string GetVariable(int Input)
        {
            Input++;
            if (Input < 0) System.Windows.Forms.MessageBox.Show("varialbe Error");
            if (Input ==1)
                return "y";
            //Input++;
            if (Input % 2 == 0)
                return "x" + Input / 2;
            else
                return "z" + Input / 2;
        }


        public static string GetVariable2(int Input)
        {
            if (Input < 0) System.Windows.Forms.MessageBox.Show("varialbe Error");
            if (Input == 1)
                return "y";
            //Input++;
            if (Input % 2 == 0)
                return "x" + Input / 2;
            else
                return "z" + Input / 2;
        }

        public static string GetLable(int Input)
        {
            if (Input < 0) System.Windows.Forms.MessageBox.Show("Lable Error");
            if (Input == 0)
                return "";
            switch (Input % 5)
            {
                case 1:
                    return "A" + ((Input / 5) + 1) + " : ";
                case 2:
                    return "B" + ((Input / 5) + 1) + " : ";
                case 3:
                    return "C" + ((Input / 5) + 1) + " : ";
                case 4:
                    return "D" + ((Input / 5) + 1) + " : ";
                default:
                    return "E" + ((Input / 5) + 1) + " : ";
            }
        }

      
        public static string GetCode2(int Lable, int Instraction, int Variable)
        {
            //Variable++;
            if (Instraction == 0)
                return GetLable(Lable) + GetVariable2(Variable) + "<--" + GetVariable2(Variable);
            else if (Instraction == 1)
                return GetLable(Lable) + GetVariable2(Variable) + "<--" + GetVariable2(Variable) + "+ 1";
            else if (Instraction == 2)
                return GetLable(Lable) + GetVariable2(Variable) + "<--" + GetVariable2(Variable) + "- 1";
            else
                return GetLable(Lable) + "if " + GetVariable2(Variable) + "!= 0 go to " + GetLable(Instraction - 2);
        }

        public static string GetCode(int[] Input)
        {
            return GetCode(Input[0], Input[1], Input[2]);
        }

        public static string GetCode(int Lable, int Instraction, int Variable)
        {
            //Variable++;
            if (Instraction == 0)
                return GetLable(Lable) + GetVariable(Variable) + "<--" + GetVariable(Variable);
            else if (Instraction == 1)
                return GetLable(Lable) + GetVariable(Variable) + "<--" + GetVariable(Variable) + "+ 1";
            else if (Instraction == 2)
                return GetLable(Lable) + GetVariable(Variable) + "<--" + GetVariable(Variable) + "- 1";
            else
                return GetLable(Lable) + GetLable(Variable) + "if " + GetVariable(Variable) + "!= 0 go to " + GetLable(Instraction - 2);
        }
        public static string GetParings(int Input)
        {
            Input++;
            string Ans = "";
            int[] GN = Godel_Number(Input);
            for (int i = 0; i < GN.Length; i++)
            {
                int[] PN = Pairing3(GN[i]);
                Ans += "I" + (i + 1) + ": < " + PN[0] + " , < " + PN[1] + " , " + PN[2] + " >>\n";
            }
            return Ans;
        }
        public static string GetCodes(int Input)
        {
            string Ans = "";
            Input++;
            int[] GN = Godel_Number(Input);
            for (int i = 0; i < GN.Length; i++)
                Ans += GetCode(Pairing3(GN[i])) + "\n";
            return Ans;
        }

   
        public static int get_label_f_form(string s1, int s2)
        {
            int ans = 0;
            string[,] x = new string[100, 5];
            int k = 1;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    x[i, j] = k.ToString();
                    k++;
                }
            }
            int l = 0;

            if (s1 == "None")
            {
                return ans;
            }
            else
            {
                if (s1 == "A")
                {
                    l = 0;
                }
                else if (s1 == "B")
                {
                    l = 1;
                }
                else if (s1 == "C")
                {
                    l = 2;
                }
                else if (s1 == "D")
                {
                    l = 3;

                }
                else if (s1 == "E")
                {
                    l = 4;
                }
                s2 = s2 - 1;
                return ans = Int32.Parse(x[s2, l]);

            }


        }

        public static int get_variable_f_form(string s1, string s2)
        {
            int ans = 0;

            if (s1 == "y")
            {
                ans = 1;
            }
            else if (s1 == "x")
            {
                ans = 2 * Int32.Parse(s2);
            }
            else if (s1 == "z")
            {
                ans = (2 * Int32.Parse(s2)) + 1;
            }

            return ans;
        }
        
    
    
    
    }


}

