using System;

namespace Lab32
{
    // Завдання 1: клас "Прямокутник" (варіант 5)
    public class Rectangle : IComparable<Rectangle>, IComparable
    {
        public string FillColor { get; set; }     // колір заповнення
        public string OutlineColor { get; set; }  // колір контуру
        public double SideA { get; set; }         // перша сторона
        public double SideB { get; set; }         // друга сторона

        public Rectangle(string fillColor, string outlineColor, double sideA, double sideB)
        {
            FillColor = fillColor;
            OutlineColor = outlineColor;
            SideA = sideA;
            SideB = sideB;
        }

        public double CalculateArea() => SideA * SideB;              // площа
        public double CalculatePerimeter() => 2 * (SideA + SideB);   // периметр

        public void PrintInfo() => Console.WriteLine(this);         // виведення інформації

        public override string ToString() =>
            $"Прямокутник [{FillColor}, контур {OutlineColor}, {SideA}x{SideB}, " +
            $"площа {CalculateArea()}, периметр {CalculatePerimeter()}]";

        // Завдання 4: порівняння за площею (типізований IComparable<T>)
        public int CompareTo(Rectangle other)
        {
            if (other == null) return 1;
            return CalculateArea().CompareTo(other.CalculateArea());
        }

        // Нетипізований IComparable - потрібен для ArrayList.Sort()
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (!(obj is Rectangle other)) throw new ArgumentException("Очікується Rectangle");
            return CompareTo(other);
        }
    }
}
