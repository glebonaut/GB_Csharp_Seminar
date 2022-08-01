// See https://aka.ms/new-console-template for more information

// IDK what namespace + class means yet, found this structure on stackoverflow
// to perfom console application restart 

namespace HW3
{
    class Program
    {
//Enter point for compiler
        static void Main()
        {
            //Task number selection
            //Previously ModeCheck()
            ModeSelect(ModeRead());
        }

//All the stuff is happening there

    //Method for reading user input for task selection
        static string ModeRead()
        {
            string? mode; //Somehow without ? compiler returned warning CS8600
            Console.WriteLine("");
            Console.WriteLine("Seminar 3 tasks: 8 9 10");
            Console.Write("Enter Task number or q to exit ");
            mode = Console.ReadLine();
            Console.WriteLine("");
            return mode;
        } 
        
    //Method for calling different tasks
        static void ModeSelect(string mode)
        {
            switch (mode){
                case "8":
                    Console.WriteLine("Task8. Five-digit palindrome check");
                    Task8();
                    break;
                case "9":
                    Console.WriteLine("Task9. 3D distance between two dots (vector length)");
                    Task9();
                    break;
                case "10":
                    Console.WriteLine("Task10. Row of i^3 in [1..N]");
                    Task10();
                    break;
                case "q":
                    break;
                default: 
                    Console.WriteLine("Invalid input");
                    ModeSelect(ModeRead());
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
            number=Math.Abs(number);
            if (number<Math.Pow(10,rank-1)){return "N/A";};//There's no digit of this rank
            
            while (number>Math.Pow(10,rank)){number/=10;}
            number%=10;
            return Convert.ToString(number);
        }

    //Task8. Five-digit integer palindrome check
        static void Task8()
        {
            string taskID="8";
            string Msg="Enter five digit number";
            int input=IntInputRequest(Msg,taskID);
            int rank = RankCheck(input);

            //Exception handling, yet, method works for integer of any length
            if (rank!=5){
                Console.WriteLine("Input isn't five-digit, yet...");
            }
                int[] inputArray = DigitArray(input, rank);
                bool answer = IntArrayPalindromeCheck(inputArray);
                Console.WriteLine($"Statement 'number {input} is a palindrome' is {answer}");
                ModeSelect(ModeRead());
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
        static int [] DigitArray(int number, int rank)
        {
            int[] digitArray = new int[rank];
            for (int i=rank; i>0; i--){
                digitArray[i-1]=Convert.ToInt32(DigitExtractor(number, i));
                number/=10;
            }
            return digitArray;
        }

    //Method for putting a digit into an array
        static bool IntArrayPalindromeCheck(int [] array)
        {
            bool answer = true;
            for (int i=0; i<array.Length/2; i++)
            {
                if(array[i]!=array[array.Length-1-i])
                {
                    answer=false;
                }
            }
            return answer;
        }

    //Task9. 3D distance between two dots
        static void Task9()
        {
            string taskID="9";
            string Msg="enter coordinates x y z ";
            Console.Write("Point A. "+Msg);
            int [] pointA = InputPoint();
            Console.WriteLine("");
            Console.Write("Point B. "+Msg);
            int [] pointB = InputPoint();
            double lengthAB = Math.Round(VectorLength(pointA, pointB), 1);
            Console.WriteLine($"Length of vector AB is {lengthAB}");
            ModeSelect(ModeRead());
        }
    
        static int [] InputPoint()
        {
            char [] delimiterChars = {' ', ','};
            string input = Console.ReadLine();
            int [] output = {0 , 0 , 0};
            try{output = input.Split(delimiterChars).Select(int.Parse).ToArray();}
            catch(FormatException){Console.WriteLine("Invalid input, returned 0,0,0");}
            return output;            
        }

        static double VectorLength(int[] pointA, int[] pointB)
        {
            double length=0;
            for (int i=0; i<3; i++)
            {
                length+=Math.Pow(pointB[i]-pointA[i], 2);
            }
            length=Math.Pow(length, 0.5);
            return length;
        }

    //Task10. Row of i^3 in [1..N]
        static void Task10()
        {
            string taskID="10";
            string Msg="Enter input: ";
            int number = IntInputRequest(Msg, taskID);
            for (int i=1; i<=number; i++)
            {
                double iCubed = Math.Pow(i, 3);
                Console.Write($"{iCubed} ");
            }
            Console.WriteLine("");
            ModeSelect(ModeRead());
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
            ModeSelect(ModeRead());
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