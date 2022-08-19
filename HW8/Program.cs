namespace HW8
{
    class Program
    {
//ENTRY POINT FOR COMPILER
        static void Main()
        {
            CallMenu();
        }

//SEMINAR TASKS

    //Task54. Sort all rows of a matrix
        static void Task54()
        {
            Console.WriteLine("Enter dimensions of an array M x N");
            int [] inputLength=InputNNumbers(2);
            int [,] output=RandomArrayGenerator(inputLength, -10, 10);
            Console.WriteLine($"{WriteArrayPretty(output)}");
            ShakerSortRows(output);
            Console.WriteLine($"{WriteArrayPretty(output)}");
            CallMenu();
        }

    //Shaker sorting method for rows in a matrix
        static void ShakerSortRows (int[,] input)
        {
            for (int i=0;i<input.GetLength(0);i++)
            {   
                int left=0,
                    right=input.GetLength(1)-1;
                while (left<right)
                {
                    for (int j=left;j<right;j++)
                    {
                        if(input[i,j]>input[i,j+1])
                        {SwapRowElements(input, i, j, j+1);}
                    }
                    right--;
                    for (int j=right;j>left;j--)
                    {
                        if(input[i,j-1]>input[i,j])
                        {SwapRowElements(input, i, j-1, j);}
                    }
                    left++;
                }    
            }
        }

    //Element swapping method for ShakerSortRows()
        static void SwapRowElements(int[,] input, int i, int j1, int j2)
        {
            int buffer=input[i,j1];
            input[i,j1]=input[i,j2];
            input[i,j2]=buffer;
        }  

    //Task56. Find a row with minimal sum of elements in a matrix
        static void Task56()
        {
            Console.WriteLine("Enter dimensions of an array M x N");
            int [] matrixDimensions=InputNNumbers(2);
            int [,] input=RandomArrayGenerator(matrixDimensions, -10, 10);
            Console.WriteLine($"{WriteArrayPretty(input)}");
            Console.WriteLine($"Row {FindRowWithMinimalSum(input)} is the row with minimal sum of elements");
            CallMenu(); 
        }

    //Method for searching the row in a matrix with minimal sum of elements
        static int FindRowWithMinimalSum(int [,] input)
        {
            int result=0;
            for (int i=0; i<input.GetLength(0)-1;i++)
            {
                if(GetSumOfElementsInARow(input,i+1)<GetSumOfElementsInARow(input,result))
                    result=i+1;
            }
            return result;

        }
    //Method for getting sum of elements in a matrix row
        static int GetSumOfElementsInARow(int [,] matrix, int index)
        {
            int result=0;
            for (int i=0;i<matrix.GetLength(1);i++) 
                result+=matrix[index,i];
            return result;
        }
    
    //Task58. Matrix multiplication
        static void Task58()
        {
            Console.WriteLine("Enter dimensions of an arrays MxN");
            int[] matrixDimensions=InputNNumbers(2);
            int[,] input1=RandomArrayGenerator(matrixDimensions, -10, 10);
            int[,] input2=RandomArrayGenerator(matrixDimensions, -10, 10);
            Console.WriteLine($"\n{WriteArrayPretty(input1)}Multiplied by\n{WriteArrayPretty(input2)}is");
            int[,] output=MatrixMultiplication(input1,input2);
            Console.WriteLine($"{WriteArrayPretty(output)}");
            CallMenu();
        }

    //Method for creating a matrix by multiplying of two input matrices
        static int [,] MatrixMultiplication(int[,] input1, int[,] input2)
        {
            int[,] result=new int[input1.GetLength(0),input1.GetLength(1)];
            for (int i=0; i<result.GetLength(0);i++)
            {
                for (int j=0; j<result.GetLength(1);j++)
                {
                    result[i,j]=input1[i,j]*input2[i,j];
                }
            }
            return result;
        }

    //Task60. Create a 2x2x2 array of two-digit unique numbers.
    //Display each row of this array with indexes of each element
        static void Task60()
        {
            Console.WriteLine($"{WriteCubicMatrixPretty(GenerateRandomCubicMatrix(2))}");
            CallMenu();
        }

    //Generator of cubic matrix with unique elements, 
    //any dimensions could be set
        static int [,,] GenerateRandomCubicMatrix(int dimension)
        {
            List<int> elementsOfCubicMatrix=new List<int>();
            Random rnd=new Random();
            int[,,] result=new int[dimension,dimension,dimension];
            for (int i=0;i<result.GetLength(0);i++)
            {
                for (int j=0;j<result.GetLength(1);j++)
                {
                    for (int k=0;k<result.GetLength(2);k++)
                    {
                        int candidate=rnd.Next(10,100);
                        while(elementsOfCubicMatrix.Contains(candidate))
                        {candidate=rnd.Next(10,100);}
                        result[i,j,k]=candidate;
                        elementsOfCubicMatrix.Add(candidate);
                    }
                }
            }
            return result;
        }

    //Method for creating a string containing info about elements of cubic matrix
        static string WriteCubicMatrixPretty(int[,,] input)
        {
            string result="";
            for (int i=0;i<input.GetLength(0);i++)
            {
                for (int j=0; j<input.GetLength(1); j++)
                {
                    for (int k=0; k<input.GetLength(2);k++)
                    {
                        result+=GetElementOfCubicMatrix(input,i,j,k);
                        if(k!=(input.GetLength(2)-1))result+="\t";
                    } 
                    result+="\r\n";   
                }
                result+="\n";
            }
            return result;
        }

    //Method for getting an element of cubic matrix and its' coordinates as a string
        static string GetElementOfCubicMatrix(int[,,] input, int i, int j, int k)
        {
            return input[i,j,k]+" ("+i+","+j+","+k+")";
        }

    //Fill a 4x4 matrix in a spiral way"
        static void Task62()
        {
            Console.WriteLine("Enter dimension of a matrix");
            int[] matrixDimensions=InputNNumbers(2);
            int[,] matrix=new int[matrixDimensions[0],matrixDimensions[1]];
            SpiralMatrixInfill(matrix);
            Console.WriteLine($"{WriteArrayPretty(matrix)}");
            CallMenu();
        }

    //Works with any matrix dimensions
        static void SpiralMatrixInfill(int [,] input)
        {
            int step = input.GetLength(0);
            int [] point ={0,0};
            //set borders for point to bump in
            int [] border ={input.GetLength(1)-1,input.GetLength(0)-1,0,1}; 
            int value=0;
            int direction=0; //0-right, 1-down, 2-left, 3-up
            int elements = input.GetLength(0)*input.GetLength(1);
            while (value<elements)
            {
                input[point[0],point[1]]=value;
                point=MoveCoordinates(point, direction);  
                if(PointCollidedWithBorder(border,point,direction))
                {
                    if(direction>1) border[direction]++;
                    else border[direction]--;
                    direction++;//turn right
                    if (direction>3)direction=0;//direction overflow handler
                }
                value++;
            }
        }

        //tried new formatting of method initialization
        static bool PointCollidedWithBorder(int[] border, int[] point, int direction) => point[(direction+1)%2]==border[direction];
        /*{
            //Console.WriteLine($"collision with {direction} on {border[direction]}");
            return point[(direction+1)%2]==border[direction];                
        }*/

        //could make it as a void method, dunno why I didn't
        static int[] MoveCoordinates (int[] coordinates, int direction)
        {
            int[] result =coordinates;
            switch (direction)
            {
                case 0:
                    result[1]++; //right, y+1
                    break;
                case 1:
                    result[0]++; //down, x+1
                    break;
                case 2:
                    result[1]--; //left, y-1 
                    break;
                case 3:
                    result[0]--; //up, x-1
                    break;
                default:
                    break;
            }
            return result;
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
            Console.WriteLine("Seminar 8 tasks: 54, 56, 58, 60, 62");
            Console.Write("Enter Task number or q to exit ");
            mode = Console.ReadLine();
            Console.WriteLine("");
            return mode;
        } 
        
    //Method for calling different tasks
        static void ModeSelect(string mode)
        {
            switch (mode){
                case "54":
                    Console.WriteLine("Task54. Sort elements in rows of a matrix");
                    Task54();
                    break;
                case "56":
                    Console.WriteLine("Task56. Find a row with minimal sum of elements in a matrix");
                    Task56();
                    break;
                case "58":
                    Console.WriteLine("Task58. Matrix multiplication");
                    Task58();
                    break;
                case "60":
                    Console.WriteLine("Task60. Create a 2x2x2 array of two-digit unique numbers.\n Display each row of this array with indexes of each element");
                    Task60();
                    break;
                case "62":
                    Console.WriteLine("Task62. Fill a 4x4 matrix in a spiral way");
                    Task62();
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