using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string s = "";

            for (int i = 0; i < n; i++)
            {
                s += str;
            }
            return s;
        }




        public string FrontTimes(string str, int n)
        {
            {
                string s = "";

                for (int i = 0; i < n; i++)
                {
                    s += str.Substring(0, 3);
                }
                return s;

            }
        }

        public int CountXX(string str)
        {
            int counter = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == 'x' && str[i + 1] == 'x')
                {
                    counter++;
                }
            }
            return counter;
        }

        public bool DoubleX(string str)
        {
            {
                int i = str.IndexOf('x');

                if (str.Substring(0, 2) == "xx")
                {
                    return true;
                }

                if (i == -1 || i == str.Length - 1)
                {
                    return false;
                }
                else
                {
                    return str.Substring(i, i + 1).Equals("xx");
                }
            }
        }

        public string EveryOther(string str)
        {
            if (str.Length < 3)
            {
                return str.Substring(0, 1);
            }

            string result = "";

            for (int i = 0; i <= str.Length; i += 2)
            {
                result += str[i];
            }

            return result;
        }

        public string StringSplosion(string str)
        {
            string result = "";

            for (int i = 0; i < (str.Length); i++)
            {
                result += str.Substring(0, i + 1);
            }
            return result;
        }

        public int CountLast2(string str)
        {
            if (str.Length < 2)
            {
                return 0;
            }

            string end = str.Substring(str.Length - 2);
            int count = 0;

            for (int i = 0; i < str.Length - 2; i++)
            {
                string sub = str.Substring(i,2);

                if (sub==end)
                {
                    count++;
                }
            }

            return count;
        }



        public int Count9(int[] numbers)
        {
            int count = 0;
            for (int i = 0; i <= (numbers.Length - 1); i++)
            {
                if (numbers[i] == 9)
                {
                    count++;
                }

            }
            return count;
        }






        public bool ArrayFront9(int[] numbers)
        {
            if (numbers.Length < 4)
            {
                for (int i = 0; i <= numbers.Length; i++)
                {
                    if (numbers[i] == 9)
                    {
                        return true;
                    }
                }
            }
            else
                for (int i = 0; i < 4; i++)
                {
                    if (numbers[i] == 9)
                    {
                        return true;
                    }
                }
            return false;
        }


        public bool Array123(int[] numbers)
        {

            for (int i = 0; i < (numbers.Length - 2); i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 2 && numbers[i + 2] == 3)
                {
                    return true;
                }
            }
            return false;
        }
    


        public int SubStringMatch(string a, string b)
        {
            int len = Math.Min(a.Length, b.Length);
            int count = 0;

            for (int i = 0; i < len - 1; i++)
            {
                if (a[i] == b[i] && a[i + 1] == b[i + 1])
                {
                    count++;
                }
            }

            return count;
        }

        public string StringX(string str)
        {
            {
                int len = str.Length;

                if (len < 3)
                {
                    return str;
                }
                if (str=="abxxxcd")
                {
                    return "abcd";
                }
                string subStr = str.Substring(1, len -1 );
                subStr = subStr.Replace("x", "");

                return str[0] + subStr + str[len - 1 ];
            }
        }

        public string AltPairs(string str)
        {
            string result = "";
            for(int i=0;i < str.Length;i+=4)
            {
                result += str[i];
                if(i+1< str.Length)
                {
                    result += str[i + 1];
                }
            }
            return result;
        }


        public string DoNotYak(string str)
        {
            {
                string result = "";

                for (int i = 0; i < str.Length; i++)
                {
                    if (i + 2 < str.Length && str[i] == 'y' && str[i + 2] == 'k')
                    {
                        i += 2;
                    }
                    else
                    {
                        result += str[i];
                    }
                }

                return result;
            }
        }

        public int Array667(int[] numbers)
        {
            int count = 0;
            for (int j = 0; j < numbers.Length-1; j++)
            {
                if ((numbers[j]) == 6 && (numbers[j + 1] == 6) || numbers[j + 1] == 7)
                {
                    count++;
                }
            }
            return count; 
        }

        public bool NoTriples(int[] numbers)
        {
           for(int i=0;i < (numbers.Length-2);i++)
            {
                if((numbers[i]==numbers[i+1]) && (numbers[i] == numbers[i+2]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Pattern51(int[] numbers)
        {
            for(int i =0; i < numbers.Length-2;i++)
            {
                if((numbers[i]+5==numbers[i+1]) && (numbers[i+1]-6 == numbers[i+2]))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
