using System;

namespace Lab32
{
    // Завдання 3: узагальнене бінарне дерево
    internal static class Task3
    {
        public static void Run()
        {
            Helpers.Title("ЗАВДАННЯ 3. Бінарне дерево BinaryTree<T>");

            // Дерево прямокутників (порядок за замовчуванням - за площею)
            var tree = new BinaryTree<Rectangle>();
            foreach (var r in Helpers.Sample())
                tree.Add(r);

            Console.WriteLine("Елементів у дереві: " + tree.Count);
            Helpers.PrintTree(tree.Root, "", "(корінь)", r => $"{r.FillColor}, площа {r.CalculateArea()}");

            // Пошук за площею (3 x 4 = 12, як у жовтого)
            var probe = new Rectangle("-", "-", 3, 4);
            Console.WriteLine("Чи є в дереві площа 12? " + tree.Contains(probe));

            // Те саме дерево для іншого типу (string)
            var words = new BinaryTree<string>();
            foreach (var w in new[] { "кіт", "яблуко", "авокадо", "дім", "ліс" })
                words.Add(w);

            Helpers.Sub("Те саме дерево для string");
            Helpers.PrintTree(words.Root, "", "(корінь)", s => s);

            // BinaryTree<int> не скомпілюється: where T : class забороняє структури
        }
    }
}
