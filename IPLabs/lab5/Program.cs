using System;
using IPLabs.lab5.Gifts;

namespace IPLabs.lab5;

public class Program
{
    static void Main(string[] args)
    {
        GiftBuilder builder = new GiftBuilder();
        Gift gift = builder.Build();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Новогодний подарок ===");
            Console.WriteLine("1. Добавить шоколадную конфету");
            Console.WriteLine("2. Добавить карамельную конфету");
            Console.WriteLine("3. Добавить печенье");
            Console.WriteLine("4. Показать содержимое подарка");
            Console.WriteLine("5. Отсортировать сладости по весу");
            Console.WriteLine("6. Найти сладость по диапазону сахара");
            Console.WriteLine("7. Удалить сладость по индексу");
            Console.WriteLine("0. Выход");
            Console.Write("Ваш выбор: ");
        }
    }
}