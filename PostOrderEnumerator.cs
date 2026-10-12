using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab32
{
    // Завдання 4: власний ітератор. Обхід за варіантом 5 - зворотний (postorder):
    // лівий нащадок -> правий нащадок -> сам вузол.
    internal class PostOrderEnumerator<T> : IEnumerator<T> where T : class
    {
        private readonly TreeNode<T> _root;
        private readonly Stack<TreeNode<T>> _stack = new Stack<TreeNode<T>>(); // шлях від кореня
        private TreeNode<T> _node;         // куди ще треба спуститися ліворуч
        private TreeNode<T> _lastVisited;  // останній повернений вузол
        private T _current;

        public PostOrderEnumerator(TreeNode<T> root)
        {
            _root = root;
            Reset();
        }

        public T Current
        {
            get
            {
                if (_current == null) throw new InvalidOperationException("Спочатку викличте MoveNext()");
                return _current;
            }
        }

        object IEnumerator.Current => Current;

        // Перехід до наступного елемента; false, коли елементи закінчились
        public bool MoveNext()
        {
            while (_node != null || _stack.Count > 0)
            {
                if (_node != null)
                {
                    // 1) йдемо ліворуч до кінця, запам'ятовуючи шлях
                    _stack.Push(_node);
                    _node = _node.Left;
                }
                else
                {
                    var top = _stack.Peek();

                    // 2) є необроблене праве піддерево - йдемо в нього
                    if (top.Right != null && _lastVisited != top.Right)
                    {
                        _node = top.Right;
                    }
                    else
                    {
                        // 3) обидва піддерева готові - повертаємо сам вузол
                        _current = top.Value;
                        _lastVisited = _stack.Pop();
                        return true;
                    }
                }
            }

            _current = null;
            return false;
        }

        // Повернення на початок обходу
        public void Reset()
        {
            _stack.Clear();
            _node = _root;
            _lastVisited = null;
            _current = null;
        }

        public void Dispose() { }
    }
}
