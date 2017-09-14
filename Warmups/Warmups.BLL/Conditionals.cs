using System;

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if ((aSmile == true) && (bSmile == true))
            {
                return true;
            }
            if ((aSmile == false) && (bSmile == false))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if ((isWeekday == false) || (isVacation == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int SumDouble(int a, int b)
        {
            if (a == b)
            {
                return ((a + b) * 2);
            }
            else
            {
                return (a + b);
            }
        }

        public int Diff21(int n)
        {
            if (n >= 21)
            {
                return Math.Abs(n - 21) * 2;
            }
            else if (n < 21)
            {
                return Math.Abs(n - 21);
            }
            else
            {
                return Math.Abs(n - 21);
            }
        }

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if (((hour < 7) || (hour > 20)) && (isTalking == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Makes10(int a, int b)
        {
            if ((a == 10) || (b == 10))
            {
                return true;
            }
            if (a + b == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NearHundred(int n)
        {
            if ((n > 89) && (n < 111))
            {
                return true;
            }
            if ((n > 189) && (n < 211))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PosNeg(int a, int b, bool negative)
        {
            if (((a < 0) && b > 0) && (negative == false))
            {
                return true;
            }
            if (((a > 0) && b < 0) && (negative == false))
            {
                return true;
            }
            if (((a < 0) && b < 0) && (negative == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string NotString(string s)
        {
            if (s.Length <= 2)
            {
                return "not " + s;
            }
            if (s.Substring(0, 2) == "not")
            {
                return s;
            }
            else
            {
                return "not " + s;
            }
        }

        public string MissingChar(string str, int n)
        {
            string firstpart;
            string secondpart;

            firstpart = str.Substring(0, n);
            secondpart = str.Substring(n + 1);
            return firstpart + secondpart;
        }

        public string FrontBack(string str)
        {
            int len = str.Length;
            if (str.Length > 1)
            {
                return str[len - 1] + str.Substring(1, len - 2) + str[0];
            }
            else
            {
                return str;
            }
        }

        public string Front3(string str)
        {
            string converter;
            string first3;
            int len = str.Length;

            if (str.Length >= 3)
            {
                first3 = str.Substring(0, 3);
                converter = first3 + first3 + first3;
                return converter;
            }
            else
            {
                converter = str + str + str;
                return converter;
            }
        }

        public string BackAround(string str)
        {

            char last = str[str.Length - 1];
            return last + str + last;
        }

        public bool Multiple3or5(int number)
        {
            if ((number % 3 == 0) || (number % 5 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool StartHi(string str)
        {
            if(str.Length < 2)
            {
                return false;
            }
            if(str =="hi")
            {
                return true;
            }
           if ((str.Substring(0,3)=="hi ") || (str.Substring(0,3)=="hi,"))
            {
                return true;
            }
           else
            {
                return false;
            }
        }


        public bool IcyHot(int temp1, int temp2)
        {
            if ((temp1 < 0) && temp2 > 100)
            {
                return true;
            }
            if ((temp1 > 100) && temp2 < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Between10and20(int a, int b)
        {
            if ((a > 9) && (a < 21))
            {
                return true;
            }
            if ((b > 9) && (b < 21))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasTeen(int a, int b, int c)
        {
            if ((a > 12) && (a < 20))
            {
                return true;
            }
            if ((b > 12) && (b < 20))
            {
                return true;
            }
            if ((c > 12) && (c < 20))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SoAlone(int a, int b)
        {
            if (((a > 12) && (a < 20)) && ((b < 12) || (b >= 21)))
            {
                return true;
            }
            if (((b > 12) && (b < 20)) && ((a < 12) || (a >= 21)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string RemoveDel(string str)
        {
            if (str.Length <= 3)
            {
                return str;
            }
            if ((str.Substring(1,3)=="del"))
            {
                return str[0] + str.Substring(4);
            }
            else
            {
                return str;
            }
        }

        public bool IxStart(string str)
        {
            if (str.Length < 3)
            {
                return false;
            }
            if ((str.Length > 3) && str.Substring(1, 2) == ("ix"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string StartOz(string str)
        {
            string result = "";

            if (str.Length >= 1 && str[0] == 'o')
            {
                result = result + str[0];
            }

            if (str.Length >= 2 && str[1] == 'z')
            {
                result = result + str[1];
            }

            return result;
        }

        public int Max(int a, int b, int c)
        {

            if ((a > b) && (a > c))
            {
                return a;
            }
            if ((b > a) && (b > c))
            {
                return b;
            }
            if ((c > a) && (c > b))
            {
                return c;
            }
            else
            {
                return a;
            }
        }

        public int Closer(int a, int b)
        {
            if ((Math.Abs(10 - a)) < (Math.Abs(10 - b)))
            {
                return a;
            }
            if ((Math.Abs(10 - a)) > (Math.Abs(10 - b)))
            {
                return b;
            }
            if ((Math.Abs(10 - a)) == (Math.Abs(10 - b)))
            {
                return 0;
            }
            else
            {
                return a;
            }
        }

        public bool GotE(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length ; i++)
            {
                if (str[i] == 'e')
                {
                    count++;
                }

            }
          
            if ((count > 0) && (count < 4))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string EndUp(string str)
        {
            string LastThree;
            if (str.Length <= 3)
            {
                return str.ToUpper();
            }
            if (str.Length > 3)
            {
                LastThree = str.Substring(str.Length - 3);
                return str.Substring(0, str.Length - 3) + LastThree.ToUpper();
            }
            else
            {
                return str.ToUpper();
            }
        }

        public string EveryNth(string str, int n)
        {
            string result = "";

            for(int i=0;i<str.Length;i+=n)
            {
                result += str[i];
            }
            return result;
        }
    }
}
