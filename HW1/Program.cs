// See https://aka.ms/new-console-template for more information
namespace HW1
{
    class Program
    {

        static void Main()
        {
            Run();
        }

        static void Run()
        {
            string input = String.Empty;
            int max;
            int a=0;
            int b=0;

            Console.Write("Enter a: ");
            try {
            a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("a = " + a); }
            catch (FormatException){
                Console.WriteLine("Input isn't Int, Try again"); 
                Run();};


            Console.Write("Enter b: ");
            try {
            b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("b = " + b);}
            catch (FormatException){
                Console.WriteLine("Input isn't Int, Try again"); 
                Run();}



            if (a>b) {
            max=a;
            }
            else {
                max=b;
                }
            Console.WriteLine("max = " + max +" Press anykey to continue");
            Console.ReadLine();
        }
    }    
}