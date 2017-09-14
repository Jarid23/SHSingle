using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            bool isGreatParty = cigars >= 40;
            if (!isWeekend && isGreatParty)
            {
                isGreatParty = cigars <= 60;
                return isGreatParty;
            }

            return isGreatParty;
        }


        public int CanHazTable(int yourStyle, int dateStyle)
        {


            if (yourStyle > 8 || dateStyle > 8)
            {
                return 2;
            }
            else if (yourStyle < 3 || dateStyle < 3)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            if ((temp > 59) && (temp < 91))
            {
                return true;
            }
            if ((isSummer == true && temp > 59) && (101 > temp))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            if (speed < 60)
            {
                return 0;
            }
            if ((speed < 60) && (isBirthday == false))
            {
                return 0;
            }
            else if (((60 < speed) && (81 > speed)) && (isBirthday == false))
            {
                return 1;
            }
            else if ((speed > 80) && (isBirthday == false))
            {
                return 2;
            }
            else if ((speed < 65) && (isBirthday == true))
            {
                return 0;
            }
            else if (((65 < speed) && (86 > speed)) && (isBirthday == true))
            {
                return 1;
            }
            else if ((speed > 85) && (isBirthday == true))
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        public int SkipSum(int a, int b)
        {
            if ((a + b) > 20)
            {
                return (a + b);
            }
            else if ((a+b) <11)
                {
                return (a + b);
            }
            else 
            {
                return 20;
            }
        }
       
        public string AlarmClock(int day, bool vacation)
        {
            if ((day == 0))
            {
                return "10:00";
            }
           
            
            if ((day > 6) && (vacation = false))
            {
                return "10:00";
            }
            else
            {
                return "7:00";
            }
        }
        
        public bool LoveSix(int a, int b)
        {
           if  (a == 6)
            {
                return true;
            }
           if (b == 6)
            {
                return true;
            }
           if ((a + b) == 6)
            {
                return true; 
            }
           if ((a - b) == 6)
            {
                return true;
            }
           else
            {
                return false;
            }
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            if ((n < 10) && (outsideMode == false))
            {
                return true;
            }
            if ((n > 10) && (outsideMode == true))
            {
                return true;
            }
            if ((n > 10) && (outsideMode == false))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        public bool SpecialEleven(int n)
        {
            if ((n % 11 ==0) || (n % 11 == 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool Mod20(int n)
        {
            if ((n % 20 == 1)|| (n % 20 == 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool Mod35(int n)
        {
            if (n % 15 == 0)
            {
                return false;
            }
                if (n % 3 ==0)
            {
                return true;
            }
            if (n % 5 == 0)
            {
                return true;
            }
            
            
            else{
                return false;
            }
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isAsleep == true)
            {
                return false;
            }
            if ((isMorning == true) && (isMom == false))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            if ((a + b) == c)
            {
                return true;
            }
            if ((a + c) == b) 
            {
                return true;
            }
            if ((c+b)==a)
                {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if((a < b) && (b < c))
            {
                return true;
            }
            if ((c > b) && (bOk == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if((a < b) && (b < c))
            {
                return true;
            }
            if((equalOk == true) && (a <= b) && (b <= c))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            int modA = a % 10;
            int modB = b % 10;
            int modC = c % 10;

            if (modA == modB || modA == modC || modB == modC)
                return true;
            else
                return false;
        }

        public int RollDice(int die1, int die2, bool noDoubles)
        {
            if(!noDoubles)
            {
                return (die1 + die2);
            }
            if((noDoubles == true) && (die1 == die2))
            {
                return ((die1 + die2) + 1);
            }
            else
            {
                return (die1 + die2);
            }
        }

    }
}
