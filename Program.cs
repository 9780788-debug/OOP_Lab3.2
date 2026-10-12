using System;
using System.Text;

namespace Lab32
{
    // Лабораторна 3.2, варіант 5: Прямокутник, 5 об'єктів, обхід дерева - postorder
    internal class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;  // щоб відображалась українська

            Task2.Run();   // колекції та масиви
            Task3.Run();   // бінарне дерево
            Task4.Run();   // порівняння, сортування, ітератор

            Console.WriteLine();
            Console.WriteLine("Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}
