// See https://aka.ms/new-console-template for more information

// IDK what namespace + class means yet, found this structure on stackoverflow
// to perfom console application restart 

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
            Console.WriteLine("Seminar 5 tasks: 34 36 38");
            Console.Write("Enter Task number or q to exit ");
            mode = Console.ReadLine();
            Console.WriteLine("");
            return mode;
        } 
        
    //Method for calling different tasks
        static void ModeSelect(string mode)
        {
            switch (mode){
                case "34":
                    Console.WriteLine("Task34. Quantity of even numbers in an array");
                    Task34();
                    break;
                case "36":
                    Console.WriteLine("Task36. Sum array elements with odd indexes");
                    Task36();
                    break;
                case "38":
                    Console.WriteLine("Task38. Difference between max and min element of array");
                    Task38();
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


    //Task34. Quantity of even numbers in an array
        static void Task34()
        {
            int [] input=RandomArrayGenerator(4,100,1000);
            int answer=0;
            for (int i=0;i<input.Length;i++)
            {
                if(ParityCheck(input[i]))
                {
                    answer++;
                }
            }
            Console.WriteLine($"There are {answer} even elements in {WriteArrayPretty(input)}");
            ModeSelect(ModeRead());
        }

    //Generate array of N random integers    

        static int [] RandomArrayGenerator (int arrayLength, int minValue, int maxValue)
        {
            Random rnd=new Random();
            int [] result=new int[arrayLength];
            for (int i=0;i<arrayLength;i++)
            {
                result[i]=rnd.Next(minValue,maxValue);
            }
            return result;
        }
    
        static bool ParityCheck(int input)
        {
            bool result=false;
            if(input%2==0)
            {
                result=true;
            }
            return result;
        }

    //Input requester for N numbers
        static int [] InputNNumbers(int N)
        {
            char [] delimiterChars = {' ', ','};
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

    //Array of N int parsing method     
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
            while (i<N && input.Length>0)
            {
                char c = input[0];
                if (DetectInteger(c))
                {
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
        static bool DetectInteger(char c)
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

    //Task36. Sum array elements with odd indexes
        static void Task36()
        {
            int [] input = RandomArrayGenerator(4,-1000,1000);
            int answer=SumOfOddElements(input);
            Console.WriteLine($"Sum of elements with odd indexes in {WriteArrayPretty(input)} is {answer}");
            CallMenu(); 
        }

        static int SumOfOddElements(int [] input)
        {   
            int result=0;
            if(input.Length>2)
            {
                for (int i=1; i<input.Length; i+=2)
                {
                    result+=input[i];
                }
            }
            return result;
        }

    //Task38. Difference between max and min element of array
        static void Task38()
        {
            int [] input = InputNNumbers(5);
            Console.WriteLine($"{WriteArrayPretty(input)}");
            int indexMin=SearchIndexOfMin(input);
            int indexMax=SearchIndexOfMax(input);
            int answer = input[indexMax]-input[indexMin];
            Console.WriteLine($"Defference of max and min elements of {WriteArrayPretty(input)} is {answer}");
            CallMenu();
        }

        static int SearchIndexOfMin (int [] input)
        {
            int result=0;
            for (int i=0; i<input.Length; i++)
            {
                if(input[i]<input[result])
                {
                    result=i;
                }
            }
            return result;
        }

        static int SearchIndexOfMax (int [] input)
        {
            int result=0;
            for (int i=0; i<input.Length; i++)
            {
                if(input[i]>input[result])
                {
                    result=i;
                }
            }
            return result;
        }

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