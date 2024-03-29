# Практика по С# в курсе GeekBrains
## Семинар 1. 
* [Лекция 1](https://gb.ru/lessons/249078)
* [Запись семинара 1](https://gb.ru/lessons/249151)
* [Задание 1](https://gb.ru/lessons/249151/homework) 

## Семинар 2.
* [Лекция 2](https://gb.ru/lessons/249079)
* [Запись семинара 2](https://gb.ru/lessons/249152)
* [Задание 2](https://gb.ru/lessons/249152/homework) 

## Семинар 3.
* [Лекция 3](https://gb.ru/lessons/249080)
* [Запись семинара 3](https://gb.ru/lessons/249153)
* [Задание 3](https://gb.ru/lessons/249153/homework) 

## Семинар 4.
* [Лекция 4](https://gb.ru/lessons/249081)
* [Запись семинара 4](https://gb.ru/lessons/249154)
* [Задание 4](https://gb.ru/lessons/249154/homework) 

## Семинар 5.
* [Лекция 5](https://gb.ru/lessons/249082)
* [Запись семинара 5](https://gb.ru/lessons/249155)
* [Задание 5](https://gb.ru/lessons/249155/homework) 

## Семинар 6.
* [Лекция 6](https://gb.ru/lessons/249083)
* [Запись семинара 6](https://gb.ru/lessons/249156)
* [Задание 6](https://gb.ru/lessons/249156/homework) 

## Семинар 7.
* [Лекция 7](https://gb.ru/lessons/249084)
* [Запись семинара 7](https://gb.ru/lessons/249157)
* [Задание 7](https://gb.ru/lessons/249157/homework) 

## Семинар 8.
* [Лекция 8](https://gb.ru/lessons/249085)
* [Запись семинара 8](https://gb.ru/lessons/249158)
* [Задание 8](https://gb.ru/lessons/249158/homework) 

## Семинар 9.
* [Лекция 9](https://gb.ru/lessons/249086)
* [Запись семинара 9](https://gb.ru/lessons/249159)
* [Задание 9](https://gb.ru/lessons/249159/homework)

## Новые материалы
* `dotnet new console` -- команда запуска новой консоли в выбранной папке, создаёт файлы Filename.cs, Foldername.csproj и временные файлы, которые можно отфильтровать при помощи файла .gitignore 
[Инструкция по .gitignore](https://gbcdn.mrgcdn.ru/uploads/asset/3850834/attachment/f05a318ae735374e643d15e71d42214f.mp4)
[githug .gitignore templates](https://github.com/iksergey/gitignore)
* `dotnet run` -- команда выполнения программы в текущей консоли
* `git checkout -b NewBranchName` -- Создание новой ветки NewBranchName и переключение сразу на неё
* Перевод строки в целочисленное 
```C#
int num =Convert.ToInt32(string)
```
* Чтение и запись в консоль
```C#
// Без перевода строки
Console.Read();
Console.Write("text " + variable);

// С переводом строки
Console.ReadLine();
Console.WriteLine("text " + variable);
```
* Блок для обработки кода, в котором могут быть ошибки
```C#
// На примере из домашнего задания, проверка конвертируемости данных из терминала в целочисленное
  try { 
     a = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("a = " + a); 
     }
  catch (FormatException){
     Console.WriteLine("Input isn't integer, Try again"); 
    Run();
    };
```                
* Создание пространства имён `HW1_1`, объявление класса `Program`, создание входной точки кода `Main()` и процедуры `Run()`, которая вызывается внутри `Main()`
```C#
// На примере из домашнего задания, проверка конвертируемости данных из терминала в целочисленное
namespace HW1_1
{
    class Program
    {
        // Точка входа кода    
        static void Main()
        {
            Run(); 
        }
        // Процедура, вызываемая из Main()
        static void Run()
        {
            //stuff here
        }
    }
}
```   
* Объявление массива в С#
```C#
int[] input = new int[3];
```
* Пропись вывода в терминал с переменными внутри текста
```C#
// Перед "" должен стоять $, переменная указывается в {}
ConsoleWrtieLine($"Text {Variable} text");
```
* Инициализация рандомного числа
```C#
int number = new Random().Next(min,max);
```
* **Метод должен быть однозадачным и работать без выводов (если цель != "сделать вывод")**
```C#
// Инициализация метода
type MethodName (type input, type input2)
{
    //stuff here
    return value; //Если тип не void
}
```
*  Действие для каждого элемента
```C#
foreach (int digit in inputArray){
                    Console.Write(" " + digit + " ");
                }
```
* Преобразование строки в массив чисел
```C#
char [] delimiterChars = {' ', ','};
string input = Console.ReadLine();
int [] output = input.Split(delimiterChars).Select(int.Parse).ToArray();
```

* Метод можно вызывать прямо в выводе данных, в {}

* Случайный int в формате double
```C#
Random rnd = new Random();
double number=new rnd.Next(1,10) + new rnd.NextDouble();
```

* Спецсимволы для форматирования строки
```C#
"\t" // collumn or tab
"\r\n" // row
"\n" // new paragraph 
````