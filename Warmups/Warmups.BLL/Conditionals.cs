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
            if(n >= 21)
            {
                return Math.Abs(n - 21)*2;
            }
            else if(n < 21)
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
            if(((hour < 7) || (hour > 20)) && (isTalking== true))
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
            if((a ==10) || (b ==10))
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
            if((n > 89) && (n < 111))
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
            if (((a > 0) && b <0) && (negative == false))
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
            if (s
        }
        
        public string MissingChar(string str, int n)
        {
            throw new NotImplementedException();
        }
        
        public string FrontBack(string str)
        {
            throw new NotImplementedException();
        }
        
        public string Front3(string str)
        {
            throw new NotImplementedException();
        }
        
        public string BackAround(string str)
        {
            throw new NotImplementedException();
        }
        
        public bool Multiple3or5(int number)
        {
            throw new NotImplementedException();
        }
        
        public bool StartHi(string str)
        {
            throw new NotImplementedException();
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            throw new NotImplementedException();
        }
        
        public bool Between10and20(int a, int b)
        {
            throw new NotImplementedException();
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            throw new NotImplementedException();
        }
        
        public bool SoAlone(int a, int b)
        {
            throw new NotImplementedException();
        }
        
        public string RemoveDel(string str)
        {
            throw new NotImplementedException();
        }
        
        public bool IxStart(string str)
        {
            throw new NotImplementedException();
        }
        
        public string StartOz(string str)
        {
            throw new NotImplementedException();
        }
        
        public int Max(int a, int b, int c)
        {
            throw new NotImplementedException();
        }
        
        public int Closer(int a, int b)
        {
            throw new NotImplementedException();
        }
        
        public bool GotE(string str)
        {
            throw new NotImplementedException();
        }
        
        public string EndUp(string str)
        {
            throw new NotImplementedException();
        }
        
        public string EveryNth(string str, int n)
        {
            throw new NotImplementedException();
        }
    }
}
