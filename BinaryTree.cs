using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab32
{
    // Вузол дерева: значення + лівий і правий нащадок
    public class TreeNode<T> where T : class
    {
        public T Value { get; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T value) { Value = value; }
    }

    // Завдання 3: узагальнене бінарне дерево пошуку.
    // "where T : class" - елементами не можуть бути структури.
    // Завдання 4: порядок задає IComparer<T>; є власний обхід через IEnumerable<T>.
    public class BinaryTree<T> : IEnumerable<T> where T : class
    {
        private readonly IComparer<T> _comparer;

        public TreeNode<T> Root { get; private set; }
        public int Count { get; private set; }

        // Без аргументу береться IComparable<T> самого елемента
        public BinaryTree(IComparer<T> comparer = null)
        {
            _comparer = comparer ?? Comparer<T>.Default;
        }

        // Додавання: менше - ліворуч, інакше - праворуч
        public void Add(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            var node = new TreeNode<T>(value);
            Count++;

            if (Root == null) { Root = node; return; }

            var current = Root;
            while (true)
            {
                if (_comparer.Compare(value, current.Value) < 0)
                {
                    if (current.Left == null) { current.Left = node; return; }
                    current = current.Left;
                }
                else
                {
                    if (current.Right == null) { current.Right = node; return; }
                    current = current.Right;
                }
            }
        }

        // Пошук: чи є елемент, рівний заданому за компаратором
        public bool Contains(T value)
        {
            var current = Root;
            while (current != null)
            {
                int cmp = _comparer.Compare(value, current.Value);
                if (cmp == 0) return true;
                current = cmp < 0 ? current.Left : current.Right;
            }
            return false;
        }

        // Центрований обхід (inorder) - видає елементи відсортованими
        public IEnumerable<T> InOrder() => InOrder(Root);

        private IEnumerable<T> InOrder(TreeNode<T> node)
        {
            if (node == null) yield break;
            foreach (var v in InOrder(node.Left)) yield return v;
            yield return node.Value;
            foreach (var v in InOrder(node.Right)) yield return v;
        }

        // foreach викликає саме цей метод - віддаємо наш власний нумератор (postorder)
        public IEnumerator<T> GetEnumerator() => new PostOrderEnumerator<T>(Root);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
