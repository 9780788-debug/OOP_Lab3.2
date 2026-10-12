using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab32
{
    // Завдання 4: окремий компаратор - порівняння за ПЕРИМЕТРОМ (IComparer)
    public class RectanglePerimeterComparer : IComparer<Rectangle>, IComparer
    {
        // Типізований варіант (для List<T>, Array.Sort, дерева)
        public int Compare(Rectangle x, Rectangle y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.CalculatePerimeter().CompareTo(y.CalculatePerimeter());
        }

        // Нетипізований варіант (для ArrayList.Sort)
        int IComparer.Compare(object x, object y)
        {
            return Compare(x as Rectangle, y as Rectangle);
        }
    }
}
