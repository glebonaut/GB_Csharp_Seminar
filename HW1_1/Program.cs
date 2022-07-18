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
            //Task number check
            ModeCheck();
        }

//All the stuff is happening there
        static void ModeCheck()
        {
            string? mode; //Somehow without ? compiler returned warning CS8600
            Console.Write("Enter Task number (1 2 3 4) or q to exit ");
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

        //Two sections with try-catch Convert.ToInt32 to deal with formating errors

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
    }    
}