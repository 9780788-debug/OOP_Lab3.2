using System;
using System.Collections;

namespace Lab32
{
    // Допоміжні методи: тестові дані та виведення
    internal static class Helpers
    {
        // 5 прямокутників. Щоразу нові об'єкти.
        public static Rectangle[] Sample() => new[]
        {
            new Rectangle("Червоний",   "Чорний",    5, 3),   // площа 15, периметр 16
            new Rectangle("Синій",      "Білий",     4, 4),   // площа 16, периметр 16
            new Rectangle("Зелений",    "Чорний",    10, 1),  // площа 10, периметр 22
            new Rectangle("Жовтий",     "Червоний",  2, 6),   // площа 12, периметр 16
            new Rectangle("Фіолетовий", "Сірий",     7, 2)    // площа 14, периметр 18
        };

        public static void Title(string text)
        {
            Console.WriteLine();
            Console.WriteLine("==== " + text + " ====");
        }

        public static void Sub(string text)
        {
            Console.WriteLine();
            Console.WriteLine("--- " + text + " ---");
        }

        // Виводить будь-яку колекцію (ArrayList, List<T>, масив, дерево)
        public static void Print(string title, IEnumerable items)
        {
            Console.WriteLine(title + ":");
            foreach (var item in items)
                Console.WriteLine("   " + item);
        }

        // Малює дерево з відступами: (L) - лівий нащадок, (R) - правий
        public static void PrintTree<T>(TreeNode<T> node, string indent, string label, Func<T, string> describe)
            where T : class
        {
            if (node == null) return;
            Console.WriteLine(indent + label + " " + describe(node.Value));
            PrintTree(node.Left, indent + "    ", "(L)", describe);
            PrintTree(node.Right, indent + "    ", "(R)", describe);
        }
    }
}
