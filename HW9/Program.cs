namespace HW9
{
    class Program
    {
//ENTRY POINT FOR COMPILER
        static void Main()
        {
            CallMenu();
        }

//SEMINAR TASKS

    //Task64. Print all integers from M to N
        static void Task64()
        {
            Console.WriteLine("Enter borders of interval M and N");
            int [] interval=InputNNumbers(2);
            IntervalPrintRecursion(interval[0],interval[1]);
            CallMenu();
        }

        static void IntervalPrintRecursion(int M, int N)
        {
            if(M<N)IntervalPrintRecursion(M,N-1);
            if(M>N)IntervalPrintRecursion(M,N+1);
            Console.Write($"{N} ");
        }

    //Task66. Find sum of all integers from M to N
        static void Task66()
        {
            Console.WriteLine("Enter borders of interval M and N");
            int [] interval=InputNNumbers(2);
            Console.Write($"Sum of numbers between {interval[0]} and {interval[1]} is {IntervalSumRecursion(interval[0],interval[1])}");
            CallMenu(); 
        }

        static int IntervalSumRecursion(int M, int N)
        {
            if(M<N) return N + IntervalSumRecursion(M,N-1);
            if(M>N) return N + IntervalSumRecursion(M,N+1);
            return N;            
        }
    
    //Task68. Ackermann function
        static void Task68()
        {
            Console.WriteLine("Enter arguments of Ackermann function M, N");
            int[] input=InputNNumbers(2);
            Console.WriteLine(Ackermann(input[0],input[1]));
            CallMenu();
        }

        static int Ackermann(int m, int n)
        {
            if (m==0) return n+1;
            else if(n==0) return Ackermann(m-1,1);
            else return Ackermann(m-1,Ackermann(m,n-1));    
        }

//SUPPORT METHODS FOR UI, INPUT REQUEST, PARSING, ETC.

    //Call menu
        static void CallMenu()
        {
            ModeSelect(ModeRead());
        }

    //Method for reading user input for task selection
        static string ModeRead()
        {
            string? mode; //Somehow without ? compiler returned warning CS8600
            Console.WriteLine("");
            Console.WriteLine("Seminar 8 tasks: 64, 66, 68");
            Console.Write("Enter Task number or q to exit ");
            mode = Console.ReadLine();
            Console.WriteLine("");
            return mode;
        } 
        
    //Method for calling different tasks
        static void ModeSelect(string mode)
        {
            switch (mode){
                case "64":
                    Console.WriteLine("Task64. Print all integers from M to N");
                    Task64();
                    break;
                case "66":
                    Console.WriteLine("Task66. Find sum of all integers from M to N");
                    Task66();
                    break;
                case "68":
                    Console.WriteLine("Task68. Ackermann function");
                    Task68();
                    break;
                case "f":
                    Console.WriteLine("New Feature");
                    Feature();
                    break;    
                case "q":
                    break;
                default: 
                    Console.WriteLine("Invalid input");
                    CallMenu();
                    break;            
            }
        }

    //Input requester for N numbers
        static int [] InputNNumbers(int N)
        {
            //char [] delimiterChars = {' ', ','};
            Console.Write($"Enter {N} numbers ");
            string input = Console.ReadLine();
            int [] output = new int [N];
            for (int i=0; i<N; i++)
                {output[i]=0;}
            try
                {output=ParseIntArray(N, input);}
            catch(FormatException)
                {Console.WriteLine("Invalid input, returned nulls");}
            catch(IndexOutOfRangeException)    
                {Console.WriteLine("Invalid input, returned nulls");}
            return output;            
        }

    //Array of N int custom parsing method 
    //Example: input "-1-2  d67- 9,35" output [-1, -2, 67, 9, 35]    
        static int [] ParseIntArray(int N, string input)
        {
            int [] result  = new int [N];
            string[] buffer = new string[N];
            int i=0;
            for (i=0; i<N; i++)
            {
                result[i]=0;
                buffer[i]="0";
            }
            i=0;
            bool numberDetected=false;
            bool minusDetected=false;
            while (i<N && input.Length>0)
            {
                char c = input[0];
                if (c=='-')
                {
                   minusDetected=true;
                   if(numberDetected)
                   {
                        i++; 
                        numberDetected=false;
                   } 
                }
                else
                {   if (DetectNumber(c))
                    {
                        if(minusDetected)
                        {
                            buffer[i]=Convert.ToString('-');
                            numberDetected=true;
                            minusDetected=false;
                        }
                        if (numberDetected)
                        {
                            buffer[i]+=Convert.ToString(c);
                        }
                        else
                        {
                            buffer[i]=Convert.ToString(c);
                            numberDetected=true;
                        }
                    }
                    else
                    {
                        if (numberDetected)
                        {
                            i++;
                        }
                        numberDetected=false;
                        minusDetected=false;
                    }
                }
                input=input.Remove(0,1);
            }
            for (i=0; i<N; i++)
            {
                result[i]=Convert.ToInt32(buffer[i]);
            }
            return result;
        }

    //Comparing char to set of digits
        static bool DetectNumber(char c)
        {
            char [] numbers = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            for (int i=0; i<10; i++)
            {
                if (c==numbers[i]){return true;}
            }
            return false;
        }

    //Method for testing a new feature
        static void Feature()
        {
            CallMenu();
        }
 
    }
     
}