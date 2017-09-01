using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            if ((numbers[0] == 6 || numbers[numbers.Length - 1] == 6))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SameFirstLast(int[] numbers)
        {
            if ((numbers.Length > 0) && (numbers[0] == numbers[numbers.Length - 1]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int[] MakePi(int n)
        {
            {
                double pi = Math.PI;
                var str = pi.ToString().Remove(1, 1);
                var chararray = str.ToCharArray();
                var numbers = new int[n];

                for (int i = 0; i < n; i++)
                {

                    numbers[i] = int.Parse(chararray[i].ToString());
                }
                return numbers;

            }
        }

        public bool CommonEnd(int[] a, int[] b)
        {
            if ((a[0] == b[0] || a[a.Length - 1] == b[b.Length - 1]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Sum(int[] numbers)
        {

            if (numbers.Length > 0)
            {
                { return (numbers[0] + numbers[1] + numbers[2]); }
            }
            else
            {
                return 0;
            }
        }

        public int[] RotateLeft(int[] numbers)
        {
            int[] rotated = { numbers[1], numbers[2], numbers[0] };
            return rotated;
        }

        public int[] Reverse(int[] numbers)
        {
            int[] reversed = { numbers[2], numbers[1], numbers[0] };
            return reversed;
        }

        public int[] HigherWins(int[] numbers)
        {
            int[] maxVal = new int[3];
            maxVal[0] = numbers[0];
            if (numbers[2] >= maxVal[0])
                maxVal[0] = numbers[2];
            maxVal[1] = maxVal[0];
            maxVal[2] = maxVal[0];
            return maxVal;
        }

        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] GetMiddle = { a[1], b[1] };
            return GetMiddle;
        }

        public bool HasEven(int[] numbers)
        {
            if (numbers[0] % 2 == 0)
            {
                return true;
            }
            if (numbers[1] % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int[] KeepLast(int[] numbers)
        {
            int len = numbers.Length * 2;
            int[] dubsArr = new int[len];
            dubsArr[len - 1] = numbers[numbers.Length - 1];
            return dubsArr;
        }

        public bool Double23(int[] numbers)
        {
            {
                if (numbers.Length == 2)
                {
                    if (numbers[0] == 2 && numbers[1] == 2)
                        return true;
                    return (numbers[0] == 3 && numbers[1] == 3);
                }
                if (numbers.Length > 2)
                {
                    if (numbers[1] == 2 && numbers[2] == 2)
                        return true;
                    return (numbers[1] == 3 && numbers[2] == 3);
                }
                else
                {
                    return false;
                }
            }
        }
            
        


        public int[] Fix23(int[] numbers)
        {
            int[] fxArr = { numbers[0], numbers[1], numbers[2] };
            if (numbers[0] == 2 && numbers[1] == 3)
                fxArr[1] = 0;
            if (numbers[1] == 2 && numbers[2] == 3)
                fxArr[2] = 0;
            return fxArr;
        }
        
        public bool Unlucky1(int[] numbers)
        {
            if((numbers[0]== 1) && (numbers[1]==3))
            {
                return true;
            }
            if ((numbers[1] == 1) && (numbers[2] == 3))
            {
                return true;
            }
            if ((numbers[numbers.Length-2] == 1) && (numbers[numbers.Length-1] == 3))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            int[] result = new int[2];

            for (int i = 0, ai = 0, bi = 0; i < result.Length; i++)
            {
                if (ai < a.Length)
                {
                    result[i] = a[ai];
                    ai++;
                }
                else if (bi < b.Length)
                {
                    result[i] = b[bi];
                    bi++;
                }
                else
                {
                    break;
                }

                Console.Write(result[i]);
            }

            Console.WriteLine();

            return result;
        }

    }
}
