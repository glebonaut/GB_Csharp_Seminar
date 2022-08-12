namespace HW7
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
            Console.WriteLine("Seminar 7 tasks: 47, 50, 52");
            Console.Write("Enter Task number or q to exit ");
            mode = Console.ReadLine();
            Console.WriteLine("");
            return mode;
        } 
        
    //Method for calling different tasks
        static void ModeSelect(string mode)
        {
            switch (mode){
                case "47":
                    Console.WriteLine("Task47. Initialize mxn array with random double entries");
                    Task47();
                    break;
                case "50":
                    Console.WriteLine("Task50. Return an element of mxn array or return an error message");
                    Task50();
                    break;
                case "52":
                    Console.WriteLine("Task52. Initialize an array of mxn integer elements. Find average of each collumn");
                    Task52();
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
            Console.Write("Enter N ");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Array ");
            string input=Console.ReadLine();
            int [] array = ParseIntArray(N, input);
            Console.WriteLine(WriteArrayPretty(array));
            CallMenu();
        }

    //Task47. Initialize mxn array with random double entries
        static void Task47()
        {
            Console.WriteLine("Enter dimensions of an array M x N");
            int [] inputLength=InputNNumbers(2);
            double [,] output=DoubleRandomArrayGenerator(inputLength, -10, 10);
            Console.WriteLine($"{WriteArrayPretty(output)}");
            ModeSelect(ModeRead());
        }

    //Generate array of N random integers    
        static int [] RandomArrayGenerator (int arrayLength, int minValue, int maxValue)
        {
            if(arrayLength<0)
            {
                arrayLength*=-1; //negative length filter
            }
            Random rnd=new Random();
            int [] result=new int[arrayLength];
            for (int i=0;i<arrayLength;i++)
            {
                result[i]=rnd.Next(minValue,maxValue);
            }
            return result;
        }

    //Generate array of N x M random integers    
        static int [,] RandomArrayGenerator (int [] arrayLength, int minValue, int maxValue)
        {
            if(arrayLength[0]<0)
            {
                arrayLength[0]*=-1; //negative length filter
            }
            if(arrayLength[1]<0)
            {
                arrayLength[1]*=-1; //negative length filter
            }
            Random rnd=new Random();
            int [,] result=new int[arrayLength[0], arrayLength[1]];
            for (int i=0;i<result.GetLength(0);i++)
            {
                for (int j=0;j<result.GetLength(1);j++)
                {
                result[i,j]=rnd.Next(minValue,maxValue);   
                }
            }
            return result;
        }

    //Generate array of N x M random doubles    
        static double [,] DoubleRandomArrayGenerator (int [] arrayLength, int minValue, int maxValue)
        {
            if(arrayLength[0]<0)
            {
                arrayLength[0]*=-1; //negative length filter
            }
            if(arrayLength[1]<0)
            {
                arrayLength[1]*=-1; //negative length filter
            }
            Random rnd=new Random();
            double [,] result=new double[arrayLength[0], arrayLength[1]];
            for (int i=0;i<result.GetLength(0);i++)
            {
                for (int j=0;j<result.GetLength(1);j++)
                {
                result[i,j]=rnd.Next(minValue,maxValue)+rnd.NextDouble();
                result[i,j]=Math.Round(result[i,j],1);
                }
            }
            return result;
        }

    //Task50. Return an element of mxn array or return an error message
        static void Task50()
        {
            Console.WriteLine("Enter dimensions of an array MxN");
            int[] arrayDimensions=InputNNumbers(2);
            Console.WriteLine("Enter coordinates on an element (i,j)");
            int[] input=InputNNumbers(2);
            int[,] array=RandomArrayGenerator(arrayDimensions, 0, 100);
            Console.WriteLine($"{WriteArrayPretty(array)}");

            if(arrayDimensions[0]>input[0]&&arrayDimensions[1]>input[1]) 
            {
                Console.WriteLine($"Element {input[0]}, {input[1]} is {array[ input[0], input[1] ]}");
            }
            else
            {
                Console.WriteLine($"There's no element with coorditates {input[0]}, {input[1]}");
            }
            CallMenu(); 
        }
    
    //Task52. Initialize an array of mxn integer elements. Find average of each collumn
        static void Task52()
        {
            Console.WriteLine("Enter dimensions of an array MxN");
            int[] arrayDimensions=InputNNumbers(2);
            int[,] input=InputMatrix(arrayDimensions);
            double[] output=MatrixCollumnAverage(input);
            Console.WriteLine($"Average of each collumn is {WriteArrayPretty(output)}");
        }

        static int [,] InputMatrix (int [] arrayDimensions)
        {
            Console.WriteLine($"Initializing array {arrayDimensions[0]}x{arrayDimensions[1]}");
            int [,] result = new int[arrayDimensions[0], arrayDimensions[1]];
            for (int i=0; i<result.GetLength(0);i++)
            {
                int [] buffer=InputNNumbers(result.GetLength(1));
                for (int j=0; j<result.GetLength(1);j++)
                {
                    result[i,j]=buffer[j];
                }
            }
            return result;
        }

        static double [] MatrixCollumnAverage(int [,] input)
        {
            double [] result=new double[input.GetLength(1)];
            for (int i=0;i<result.Length;i++)
            {
                result[i]=0.0;
            }
            for (int j=0;j<input.GetLength(1);j++)
            {   
                double sumOfCollumn = 0.0;
                for (int i=0;i<input.GetLength(0);i++)
                {
                    sumOfCollumn+=input[i,j];
                }
                result[j]=Math.Round(sumOfCollumn/input.GetLength(0),1);
            }
            return result;
        }

    //Method for formatted output of an array
        static string WriteArrayPretty(int [] array)
        {   
            string result="[";
            for (int i=0; i<array.Length; i++)
            {
                result+=array[i];
                if(i!=array.Length-1){result+="\t";}
            }
            result+="]";
            return result;
        }

        static string WriteArrayPretty(double [] array)
            {   
                string result="[";
                for (int i=0; i<array.Length; i++)
                {
                    result+=array[i];
                    if(i!=array.Length-1){result+="\t";}
                }
                result+="]";
                return result;
            }

    //It occurs that you can make methods with same name but different arguments
        static string WriteArrayPretty(double [,] array)
        {   
            string result="";
            for (int i=0;i<array.GetLength(0);i++)
            {
                result+="";
                for (int j=0; j<array.GetLength(1); j++)
                {
                    result+=array[i,j];
                    if(j!=(array.GetLength(1)-1)){result+="\t";}
                }
                result+="\r\n";
            }
            return result;
        }

        static string WriteArrayPretty(int [,] array)
        {   
            string result="";
            for (int i=0;i<array.GetLength(0);i++)
            {
                result+="";
                for (int j=0; j<array.GetLength(1); j++)
                {
                    result+=array[i,j];
                    if(j!=(array.GetLength(1)-1)){result+="\t";}
                }
                result+="\r\n";
            }
            return result;
        }
 
    }
     
}