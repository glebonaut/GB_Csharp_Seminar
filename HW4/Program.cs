// See https://aka.ms/new-console-template for more information

// IDK what namespace + class means yet, found this structure on stackoverflow
// to perfom console application restart 

namespace HW4
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
            Console.WriteLine("Seminar 4 tasks: 25 27 29");
            Console.Write("Enter Task number, f to test a new feature or q to exit ");
            mode = Console.ReadLine();
            Console.WriteLine("");
            return mode;
        } 
        
    //Method for calling different tasks
        static void ModeSelect(string mode)
        {
            switch (mode){
                case "25":
                    Console.WriteLine("Task25. Cycle A^B");
                    Task25();
                    break;
                case "27":
                    Console.WriteLine("Task27. Sum of digits in a number");
                    Task27();
                    break;
                case "29":
                    Console.WriteLine("Task29. Initialize and output 8-element array");
                    Task29();
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
        
    // Method to request integer input
        static int IntInputRequest (string Msg, string taskID)
        {
            Console.Write($"{Msg} ");
            int result = 0;
            result = IntInputValidation(taskID);
            return result;

        }

    // Method to get integer input and validate it
        static int IntInputValidation (string taskID)
       {
            int result = 0;
            try {
                result=Convert.ToInt32(Console.ReadLine());
                return result;   
            }
            catch(FormatException){
                Console.WriteLine("Input isn't integer, try again");
                ModeSelect(taskID);
                return result; 
                //If value is invalid, method returns 0 several times before finally ending
            }
       }
    
    //Method for extraction a digit from integer
        static string DigitExtractor (int number, int rank)
        {
            //Exceptions handling
            if (rank<1){return "N/A";};//Number contains at least one digit
            if (number==0 && rank==1){return "0";};//First digit of 0
            if (number<0){number*=-1;}; //instead of Math.Abs()
            if (number<PowerAB(10,rank-1)){return "N/A";};//There's no digit of this rank
            
            while (number>PowerAB(10,rank)){number/=10;}
            number%=10;
            return Convert.ToString(number);
        }

    //Task25. Cycle A^B
        static void Task25()
        {
            string taskID="25";
            int [] input=InputNNumbers(2);
            int A=input[0];
            int B=input[1];
            int answer=PowerAB(A,B);
            Console.WriteLine($"{A} to the power of {B} is {answer}");
            ModeSelect(ModeRead());
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

    //Powering method
        static int PowerAB(int A, int B)
        {
            int result=A;
            for (int i=1; i<B; i++)
                {
                    result*=A;
                }
            return result;
        }
    
    //Method for integer rank checking 
        static int RankCheck(int number)
        {
            int rank=1;
            int tenPowered=10;
            while (number>=tenPowered){
                rank++;
                tenPowered*=10;
            }
            return rank;
        }

    //Method for putting a digit into an array
        static int [] DigitArray(int number)
        {
            int rank = RankCheck(number);
            int[] digitArray = new int[rank];
            for (int i=rank; i>0; i--){
                digitArray[i-1]=Convert.ToInt32(DigitExtractor(number, i));
                number/=10;
            }
            return digitArray;
        }

    //Task27. Sum of digits in a number
        static void Task27()
        {
            string taskID="27";
            string Msg="Enter a number";
            int input = IntInputRequest(Msg, "27");
            int rank = RankCheck(input);
            int [] inputToArray = DigitArray(input);
            int answer=0;
            for (int i=0; i<inputToArray.Length; i++)
                {
                    answer+=inputToArray[i];
                }
            Console.WriteLine($"Sum of digits in {input} is {answer}");
            CallMenu(); 
        }

    //Task29. Initialize and output 8-element array
        static void Task29()
        {
            string taskID="29";
            string Msg="Enter input: ";
            int [] input = InputNNumbers(8);
            Console.WriteLine($"{WriteArrayPretty(input)}");
            CallMenu();
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

    //TaskTemplate. Template for task method
        static void TaskTemplate()
        {
            string Msg="Enter input: ";
            string taskID="Placeholder";
            Placeholder(taskID);
        }

    // Method for displaying a placeholder for uncompleted tasks 
        static void Placeholder(string taskID)
        {
            Console.WriteLine($"Task {taskID} is not ready yet");
            CallMenu();
        }

    /*
    // Method for checking validity of an integer
        static bool IntegerCheck (string input)
        {
            int test=0;
            try {
                test=Convert.ToInt32(input);
                return true;
            }
            catch(FormatException){
                return false;
            }
        }
    */     
    }
     
}