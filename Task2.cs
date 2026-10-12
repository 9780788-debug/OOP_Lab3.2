using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab32
{
    // Завдання 2: ArrayList, List<T> і масив - додавання, видалення, оновлення, пошук, обхід
    internal static class Task2
    {
        public static void Run()
        {
            Helpers.Title("ЗАВДАННЯ 2. Колекції та масиви");
            ArrayListDemo();
            ListDemo();
            ArrayDemo();
            Summary();
        }

        // ArrayList - звичайна колекція, зберігає object
        private static void ArrayListDemo()
        {
            Helpers.Sub("ArrayList (non-generic)");
            var list = new ArrayList(Helpers.Sample());

            // Додавання
            list.Add(new Rectangle("Помаранчевий", "Чорний", 8, 3));

            // Упаковка/розпаковка: число пакується в object
            int number = 42;
            object boxed = number;
            int unboxed = (int)boxed;
            Console.WriteLine($"Boxing: {boxed}, unboxing: {unboxed}");

            // ArrayList приймає і число - помилка типу буде лише під час виконання
            list.Add(number);
            try { foreach (Rectangle r in list) { } }
            catch (InvalidCastException) { Console.WriteLine("Помилка під час виконання: у списку є не Rectangle"); }
            list.RemoveAt(list.Count - 1);

            // Видалення та оновлення
            list.RemoveAt(0);
            list[0] = new Rectangle("Рожевий", "Синій", 3, 3);
            ((Rectangle)list[1]).FillColor = "Бірюзовий";
            Helpers.Print("Після Add, RemoveAt і оновлення", list);

            // Пошук - вручну циклом, з приведенням типу
            foreach (object item in list)
            {
                var found = item as Rectangle;
                if (found != null && found.CalculateArea() > 15)
                {
                    Console.WriteLine("Знайдено (площа > 15): " + found);
                    break;
                }
            }
        }

        // List<T> - узагальнена колекція, типобезпечна
        private static void ListDemo()
        {
            Helpers.Sub("List<Rectangle> (generic)");
            var list = new List<Rectangle>(Helpers.Sample());

            // Додавання
            list.Add(new Rectangle("Помаранчевий", "Чорний", 8, 3));
            // list.Add(42);   // не скомпілюється - перевірка типу під час компіляції

            // Видалення: за індексом і за умовою
            list.RemoveAt(0);
            list.RemoveAll(r => r.FillColor == "Зелений");

            // Оновлення: зміна властивості і заміна елемента
            list[0].FillColor = "Бірюзовий";
            list[1] = new Rectangle("Рожевий", "Синій", 3, 3);
            Helpers.Print("Після Add, видалення та оновлення", list);

            // Пошук - готові методи
            Console.WriteLine("Find (площа > 12): " + list.Find(r => r.CalculateArea() > 12));
            Console.WriteLine("FindIndex (рожевий): " + list.FindIndex(r => r.FillColor == "Рожевий"));

            // Прохід
            foreach (var item in list) item.PrintInfo();
        }

        // Масив - фіксований розмір
        private static void ArrayDemo()
        {
            Helpers.Sub("Масив Rectangle[]");
            var array = Helpers.Sample();

            // Додавання: розмір змінити не можна - створюється новий масив
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = new Rectangle("Помаранчевий", "Чорний", 8, 3);

            // Видалення елемента 0: зсуваємо елементи і зменшуємо масив
            Array.Copy(array, 1, array, 0, array.Length - 1);
            Array.Resize(ref array, array.Length - 1);

            // Оновлення за індексом
            array[1] = new Rectangle("Рожевий", "Синій", 3, 3);

            // Пошук
            Console.WriteLine("Array.Find (площа > 15): " + Array.Find(array, r => r.CalculateArea() > 15));
            Console.WriteLine("Array.IndexOf (array[2]): " + Array.IndexOf(array, array[2]));

            // Прохід
            for (int i = 0; i < array.Length; i++)
                Console.WriteLine($"   [{i}] {array[i]}");
        }

        private static void Summary()
        {
            Helpers.Sub("Порівняння");
            Console.WriteLine("Масив: фіксований розмір, найшвидший доступ за індексом.");
            Console.WriteLine("ArrayList: розмір змінюється, але зберігає object (boxing, приведення типів, помилки під час виконання).");
            Console.WriteLine("List<T>: розмір змінюється, типобезпечний, без boxing, є Find/RemoveAll з лямбдами.");
        }
    }
}
