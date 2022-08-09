namespace HW5
{
    class Program
    {
//Enter point for compiler
        static void Main()
        {
            CallMenu();
        }

//All the stuff is happening there

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
            Console.WriteLine("Seminar 6 tasks: 41 43");
            Console.Write("Enter Task number or q to exit ");
            mode = Console.ReadLine();
            Console.WriteLine("");
            return mode;
        } 
        
    //Method for calling different tasks
        static void ModeSelect(string mode)
        {
            switch (mode){
                case "41":
                    Console.WriteLine("Task41. Quantity of positive numbers from M input");
                    Task41();
                    break;
                case "43":
                    Console.WriteLine("Task43. Coordinates of two lines intersection");
                    Task43();
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

    //Task41. Quantity of positive numbers from M input
        static void Task41()
        {
            Console.WriteLine("Enter quantity of numbers");
            int [] inputLength=InputNNumbers(1);
            int [] input=InputNNumbers(inputLength[0]);
            int answer=0;
            for (int i=0;i<input.Length;i++)
            {
                if (input[i]>0)
                {
                    answer++;
                }
            }
            Console.WriteLine($"There are {answer} positive elements in {WriteArrayPretty(input)}");
            ModeSelect(ModeRead());
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
            Console.Write("Enter N ");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Array ");
            string input=Console.ReadLine();
            int [] array = ParseIntArray(N, input);
            Console.WriteLine(WriteArrayPretty(array));
            CallMenu();
        }

    //Task43. Coordinates of two lines intersection
        static void Task43()
        {
            Console.WriteLine("For two lines y=k*x+b enter k1, b1, k2, b2");
            int[] input=InputNNumbers(4);
            if(input[0]!=input[2]) 
            {
                double [] answer=TwoLineIntersection(input);
                Console.WriteLine($"Intersection of y={input[0]}*x + {input[1]} and y={input[2]}*x + {input[3]} is ({Math.Round(answer[0],1)}; {Math.Round(answer[1],1)})");
            }
            else
            {
                Console.WriteLine($"Lines y={input[0]}*x + {input[1]} and y={input[2]}*x + {input[3]} are parallel");
            }
            CallMenu(); 
        }

        static double [] TwoLineIntersection(int[] input)
        {
            double [] result = new double[2];
            result[0]=(0.0+input[3]-input[1])/(0.0+input[0]-input[2]);
            result[1]=input[0]*result[0]+input[1];
            return result;
        }

    //Method for formatted output of an array
        static string WriteArrayPretty(int [] array)
        {   
            string result="[";
            for (int i=0; i<array.Length; i++)
            {
                result+=array[i];
                if(i!=array.Length-1){result+=", ";}
            }
            result+="]";
            return result;
        }
 
    }
     
}