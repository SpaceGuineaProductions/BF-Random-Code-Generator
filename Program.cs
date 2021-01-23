using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF_Code_Maker
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            string code = "";
            string[] possibChars = { ".", "+", "-", ">", "<"};

            List<string> possibchars = new List<string>();

            bool canhaveB = true;
            bool canhaveArrows = true;

            int curB = 0;
            int lenofCode;
            int lenofB = 0;

            bool isB = false;
            bool beginB = false;
            //start of code

            //checking for canhaveB and canhaveArrows
            Console.WriteLine("Include brackets? (y, n)");
            Console.WriteLine("");
            string ans = Console.ReadLine();
            canhaveB = (ans == "y");
            Console.WriteLine("Include arrows? (y, n)");
            Console.WriteLine("");
            ans = Console.ReadLine();
            canhaveArrows = (ans == "y");

            //setting list based off of bools
            possibchars.Add("+");
            possibchars.Add("-");
            possibchars.Add(".");
            if (canhaveArrows)
            {
                possibchars.Add("<");
                possibchars.Add(">");
            }

            Console.WriteLine("Please type the length of the code (int only)");
            Console.WriteLine("WARNING! When the code is shown, the window will close when you press any button. Be careful copy and pasting");
            Console.WriteLine("");
            lenofCode = int.Parse(Console.ReadLine());

            for(int i = 0; i < lenofCode; i++)
            {
                int num = r.Next(0, possibchars.Count + 1);

                if (num == possibchars.Count && (lenofCode - i) > 2 && !isB && canhaveB)
                {
                    beginB = false;
                    isB = true;
                    Random r2 = new Random();
                    lenofB = r2.Next(2, (lenofCode - i));
                }

                if (!isB && num < possibchars.Count) code += possibchars[num];
                if (isB)
                {
                    if (!beginB)
                    {
                        beginB = true;
                        code += "[";
                    }

                    if (curB != lenofB)
                    {
                        curB++;
                        num = r.Next(0, possibchars.Count);
                        code += possibchars[num];
                    }
                    else if (curB == lenofB)
                    {
                        curB = 0;
                        isB = false;
                        code += "]";
                    }
                    

                }
            }

            Console.WriteLine("Here's your code: " + code);
            Console.ReadKey(true);
            
        }
    }
}
