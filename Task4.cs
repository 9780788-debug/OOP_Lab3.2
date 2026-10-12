using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab32
{
    // Завдання 4: порівняння (IComparable, IComparer), сортування, власний ітератор
    internal static class Task4
    {
        public static void Run()
        {
            Helpers.Title("ЗАВДАННЯ 4. Порівняння та власний ітератор");
            SortingDemo();
            TreeDemo();
        }

        // Один і той самий набір, різні правила порівняння
        private static void SortingDemo()
        {
            Helpers.Sub("Сортування");

            var list = new List<Rectangle>(Helpers.Sample());

            list.Sort();                                      // IComparable<T> -> за площею
            Helpers.Print("List.Sort() - за площею", list);

            list.Sort(new RectanglePerimeterComparer());      // IComparer<T> -> за периметром
            Helpers.Print("List.Sort(comparer) - за периметром", list);

            // Компаратор лямбдою - за кольором заповнення
            list.Sort(Comparer<Rectangle>.Create((a, b) => string.Compare(a.FillColor, b.FillColor)));
            Helpers.Print("List.Sort(лямбда) - за кольором", list);

            // Масив
            var array = Helpers.Sample();
            Array.Sort(array);
            Helpers.Print("Array.Sort() - за площею", array);

            // ArrayList використовує нетипізовані IComparable / IComparer
            var arrayList = new ArrayList(Helpers.Sample());
            arrayList.Sort(new RectanglePerimeterComparer());
            Helpers.Print("ArrayList.Sort(comparer) - за периметром", arrayList);
        }

        private static void TreeDemo()
        {
            Helpers.Sub("Дерево з різними компараторами");

            var byArea = new BinaryTree<Rectangle>();                                      // за площею
            var byPerimeter = new BinaryTree<Rectangle>(new RectanglePerimeterComparer()); // за периметром

            foreach (var r in Helpers.Sample())
            {
                byArea.Add(r);
                byPerimeter.Add(r);
            }

            // Центрований обхід дає відсортований результат
            Helpers.Print("InOrder, дерево за площею", byArea.InOrder());
            Helpers.Print("InOrder, дерево за периметром", byPerimeter.InOrder());

            // Власний ітератор: foreach ходить у зворотному порядку (postorder)
            Helpers.Sub("Власний ітератор: postorder (площі 14, 12, 10, 16, 15)");
            foreach (var r in byArea)
                Console.WriteLine($"   площа {r.CalculateArea()}: {r.FillColor}");

            // Те саме вручну: саме так foreach працює під капотом
            Helpers.Sub("Ручний виклик MoveNext / Current");
            using (IEnumerator<Rectangle> e = byArea.GetEnumerator())
            {
                while (e.MoveNext())
                    Console.WriteLine("   " + e.Current.FillColor);
            }
        }
    }
}
