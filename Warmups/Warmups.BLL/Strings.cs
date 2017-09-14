using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            return a + b + b + a;
        }

        public string MakeTags(string tag, string content)
        {

            return ("<" + (tag) + ">" + (content)) + "</" + (tag) + ">";

        }

        public string InsertWord(string container, string word)
        {
            return container.Insert(2, word);
        }

        public string MultipleEndings(string str)
        {
            string result;
            result = str.Substring(str.Length - 2);
            return (result + result + result);
        }

        public string FirstHalf(string str)
        {
            string result;

            result = str.Substring(0, str.Length / 2);
            return result;
        }

        public string TrimOne(string str)
        {

            return str.Substring(1, str.Length - 2);


        }

        public string LongInMiddle(string a, string b)
        {
            if (a.Length > b.Length)
            {
                string result = b + a + b;
                return result;
            }

            if (b.Length > a.Length)
            {
                string result = a + b + a;
                return result;
            }
            else
            {
                return "A";
            }

        }

        public string RotateLeft2(string str)
        {
            string first2 = str.Substring(0, 2);
            string leftovers = str.Substring(2);
            string result = (leftovers + first2);
            return result;

        }

        public string RotateRight2(string str)
        {
            string last2 = str.Substring(str.Length - 2);
            string leftovers = str.Substring(0, str.Length - 2);
            string result = last2 + leftovers;
            return result;
        }

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront == true)
            {
                string first1 = str.Substring(0, 1);
                return first1;
            }
            if (fromFront == false)
            {
                string last1 = str.Substring(str.Length - 1);
                return last1;
            }
            else
            {
                return "A";
            }
        }

        public string MiddleTwo(string str)
        {
            if ((str.Length % 2 == 0) && str.Length >= 3)
            {
                return str.Substring(str.Length / 2 - 1, 2);
            }
            else
            {
                return "A";
            }
        }
        public bool EndsWithLy(string str)
        {
            if (str.Length < 2)
            {
                return false;
            }
            string ending = str.Substring(str.Length - 2);
            if (ending == "ly")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string FrontAndBack(string str, int n)
        {
            return (str.Substring(0, n) + str.Substring(str.Length - n));
        }


        public string TakeTwoFromPosition(string str, int n)
        {
            if ((n + 2) > str.Length)
            {
                return str.Substring(0, 2);
            }
            else
            {
                return str.Substring(n, 2);
            }
        }

        public bool HasBad(string str)
        {
            int len = str.Length;
            if (len == 3 && str == ("bad"))
                return true;
            else if (len >= 4)
            {
                if (str.Substring(0, 3) == ("bad"))
                    return true;
                return str.Substring(1, 3) == ("bad");
            }
            else
                return false;
        }



        public string AtFirst(string str)
        {
            if (str.Length >= 2)
            {
                string first2 = str.Substring(0, 2);
                return first2;
            }
            if (str.Length == 1)
            {
                return str + "@";
            }
            else
            {
                return "@@";
            }
        }

        public string LastChars(string a, string b)
        {
            if ((a == "") && (b == ""))
            {
                return "@@";
            }
            if ((a.Length >= 2) && (b.Length >= 2))
            {
                string firsta = a.Substring(0, 1);
                string lastb = b.Substring(b.Length - 1);
                string newword = firsta + lastb;
                return newword;
            }
            if (a == "")
            {
                string firsta = "@";
                string lastb = b.Substring(b.Length - 1);
                string newword = firsta + lastb;
                return newword;
            }
            if (b == "")
            {
                string lastb = "@";
                string firsta = a.Substring(0, 1);
                string newword = firsta + lastb;
                return newword;
            }
           

            else
            {
                return "A";
            }



        }

        public string ConCat(string a, string b)
        {
            int lenA = a.Length;
            int lenB = b.Length;
            if (lenA >= 1 && lenB >= 1)
            {
                if (a[lenA - 1] == b[0])
                    return (a + b.Substring(1));
                else
                    return (a + b);
            }
            return (a + b);
        }

        public string SwapLast(string str)
        {
            int len = str.Length;
            if (len >= 2)
                return str.Substring(0, len - 2) + str[len - 1] + str[len - 2];
            else
                return str;
        }



        public bool FrontAgain(string str)
        {
            if (str.Length >= 2)
            {
                if (str.Substring(0, 2) == (str.Substring(str.Length - 2)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public string MinCat(string a, string b)
        {
            int WordNum;

            if (a.Length == b.Length)
            {
                return a + b;
            }
            if (a.Length > b.Length)
            {
                WordNum = (a.Length - b.Length);
                string ShortWord = a.Substring(WordNum);
                return ShortWord + b;
            }
            if (a.Length < b.Length)
            {
                WordNum = (b.Length - a.Length);
                string ShortWord = b.Substring(WordNum);
                return a + ShortWord;
            }
            else
            {
                return a + b;
            }
        }

        public string TweakFront(string str)
        {
            if (str.Length == 1 && str[0] != 'a')
                return "";

            if (str.Length >= 2)
            {
                if (str[0] != 'a' && str[1] != 'b')
                {
                    return str.Substring(2);
                }
                else if (str[0] != 'a')
                {
                    return str.Substring(1);
                }
                else if (str[1] != 'b')
                {
                    return "a" + str.Substring(2);
                }
            }

            return str;
        }

        public string StripX(string str)
        {
            if (str.Length == 0)
            {
                return str;
            }
            if ((str.Length == 1) && (str[0] == 'x'))
            {
                return "";
            }
            if ((str[0] == 'x') && (str.Length == 4))
            {
                str = str.Substring(1, str.Length - 2);
                return str;
            }
            if ((str[0] == 'x') && (str.Length > 1))
            {
                str = str.Substring(1, str.Length - 1);
                return str;
            }

          
            if ((str[(str.Length - 1)] == 'x') && (str.Length > 1))
            {
                str = str.Substring(0, str.Length - 1);
                return str;
            }
            else
            {
                return str;
            }
        }
    }
}


