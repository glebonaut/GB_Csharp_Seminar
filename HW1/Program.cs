// See https://aka.ms/new-console-template for more information

// IDK what namespace + class means yet, found this structure on stackoverflow
// to perfom console application restart 

namespace HW1
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
    //Previous method for task selection
        static void ModeCheck()
        {
            string? mode; //Somehow without ? compiler returned warning CS8600
            Console.WriteLine("Seminar 1 tasks: 1 2 3 4");
            Console.WriteLine("Seminar 2 tasks: 5 6 7");
            Console.Write("Enter Task number or q to exit ");
            mode = Console.ReadLine();
            switch (mode){
                case "1": 
                    Console.WriteLine("Task1. Maximum of two integers");
                    Task1();
                    break;
                case "2":
                    Console.WriteLine("Task2. Maximum of three integers");
                    Task2();
                    break;
                case "3":
                    Console.WriteLine("Task3. Integer parity check");
                    Task3();
                    break;
                case "4":
                    Console.WriteLine("Task4. Row of even numbers 2..N");
                    Task4();
                    break;
                case "5":
                    Console.WriteLine("Task5. Second digit of three-digit number");
                    Task5();
                    break;
                case "6":
                    Console.WriteLine("Task6. Third digit of an integer");
                    Task6();
                    break;
                case "7":
                    Console.WriteLine("Task7. Name of a weekday based on its' number");
                    Task7();
                    break;
                case "q":
                    break;
                default: 
                    Console.WriteLine("Invalid input");
                    ModeCheck();
                    break;            
            }
        }

    //Method for reading user input for task selection
        static string ModeRead()
        {
            string? mode; //Somehow without ? compiler returned warning CS8600
            Console.WriteLine("");
            Console.WriteLine("Seminar 1 tasks: 1 2 3 4");
            Console.WriteLine("Seminar 2 tasks: 5 6 7");
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
                case "1": 
                    Console.WriteLine("Task1. Maximum of two integers");
                    Task1();
                    break;
                case "2":
                    Console.WriteLine("Task2. Maximum of three integers");
                    Task2();
                    break;
                case "3":
                    Console.WriteLine("Task3. Integer parity check");
                    Task3();
                    break;
                case "4":
                    Console.WriteLine("Task4. Row of even numbers 2..N");
                    Task4();
                    break;
                case "5":
                    Console.WriteLine("Task5. Second digit of three-digit number");
                    Task5();
                    break;
                case "6":
                    Console.WriteLine("Task6. Third digit of an integer");
                    Task6();
                    break;
                case "7":
                    Console.WriteLine("Task7. Name of a weekday based on its' number");
                    Task7();
                    break;
                case "8":
                    Console.WriteLine("Task8. Five-digit palindrome check");
                    Task8();
                    break;
                case "9":
                    Console.WriteLine("Task9. 3D distance between two dots");
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
                    ModeCheck();
                    break;            
            }
        }
    //Task1. input int a, int b; output larger number
        static void Task1()
        {
            int max;
            int a=0;
            int b=0;

        //Two sections with try-catch convertion to deal with formating errors

            Console.Write("Enter integer a: ");
            try { 
                a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("a = " + a); 
                }
            catch (FormatException){
                Console.WriteLine("Input isn't integer. Try again"); 
                Task1();
                }


            Console.Write("Enter integer b: ");
            try {
            b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("b = " + b);
                }
            catch (FormatException){
                Console.WriteLine("Input isn't integer. Try again"); 
                Task1();
                }

        //Comparasion and output 

            if (a>b) {
            max=a;
            }
            else {
                max=b;
                }
            Console.WriteLine("max = " + max);
            ModeCheck();

        }

    //Task2. input 3xint; output max number
        static void Task2()
        {
            int[] input = new int[3];
            for (int i=0; i<3; i++){
                Console.Write("Enter integer " + i + ": ");
                try{
                    input[i]=Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Number " + i + " = " + input[i]);
                }
                catch(FormatException){
                    Console.WriteLine("Input isn't integer. Try again");
                    Task2();
                }
            }
            int max = input[0];
            for (int i=0; i<2; i++){
                if (input[i+1]>max){
                    max = input[i+1];
                }
            }
            Console.WriteLine(max + " is the largest number of three inputs");
            ModeCheck();
        }

    //Task3. Integer parity check    
        static void Task3()
        {
            Console.Write("Enter integer: ");
            int number=0;
            try { 
            number = Convert.ToInt32(Console.ReadLine()); 
                }
            catch (FormatException){
                Console.WriteLine("Input isn't integer. Try again"); 
                Task3();
                }
            string numberType;
            if ((number % 2) == 0){
                    numberType="Even";
                }
            else{
                    numberType="Odd";
                }
            Console.WriteLine("Integer " + number + " is " + numberType);
            ModeCheck();
        }

    //Task4. Row of even numbers 2..N    
        static void Task4()
        {
            Console.Write("Enter integer N: ");
            int number=0;
            try { 
            number = Convert.ToInt32(Console.ReadLine()); 
                }
            catch (FormatException){
                Console.WriteLine("Input isn't integer, Try again"); 
                Task4();
                }
            if (number>=2){
            for (int i=2; i<=number; i=i+2){
                Console.Write(i + " ");
            }
            }
            else{
                Console.Write("Error! " + number + "<2");
                Console.WriteLine();
                Task4();
            }
            Console.WriteLine();
            ModeCheck();
        }

    //Task5. Second digit of-three digit number    
        static void Task5()
        {
            string Msg = "Enter three-digit integer";
            string taskID="5"; //Probably should add taskID as an attribute of struct or smth
            int number = IntInputRequest(Msg, taskID); //Call a method to request integer input
            if (number>1000||number<100) //Input exception handler
            {
                Console.WriteLine($"{number} isn't a three-digit number, try again");
                ModeSelect(taskID);
            }
            string result=DigitExtractor(number, 2); //Call a method to extract second digit from number 
            Console.WriteLine($"Answer: second digit of {number} is {result}"); //result output
            ModeSelect(ModeRead()); //back to menu
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

    //Task6. Third digit of an integer. Slightly changed Task5    
        static void Task6()
        {
            string Msg = "Enter an integer";
            string taskID="6";
            int number = IntInputRequest(Msg, taskID); 
            string result=DigitExtractor(number, 3); 
            Console.WriteLine($"Answer: third digit of {number} is {result}"); 
            ModeSelect(ModeRead());
        }

    //Task7. Name of a weekday based on its' number    
        static void Task7()
        {
            string Msg="Enter day number";
            string taskID="7";
            string[] DayNames = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
            int id = IntInputRequest(Msg, taskID);
            if (id>0 && id<8)
            {
            Console.WriteLine($"Day number {id} is {DayNames[id-1]}");
            }
            else {Console.WriteLine($"There's no such thing as day {id}");};
            ModeSelect(ModeRead());
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
            string Msg="Enter input: ";
            Placeholder(taskID);
        }

    //Task10. Row of i^3 in [1..N]
        static void Task10()
        {
            string taskID="10";
            string Msg="Enter input: ";
            Placeholder(taskID);
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
            ModeCheck();
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