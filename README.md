# Практика по С# в курсе GeekBrains
## Семинар 1. 
* [Лекция 1](https://gb.ru/lessons/249078)
* [Запись семинара 1](https://gb.ru/lessons/249151)
* [Задание 1](https://gb.ru/lessons/249151/homework) 

## 
* [Лекция 1](https://gb.ru/lessons/249078)
[Запись семинара 1](https://gb.ru/lessons/249151)
[Задание 1](https://gb.ru/lessons/249151/homework) 

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