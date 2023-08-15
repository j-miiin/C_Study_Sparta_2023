namespace c_study_week3_3_3
{
    internal class Program
    {
        class Stack<T>
        {
            private T[] elements;
            private int top;

            public Stack()
            {
                elements = new T[100];
                top = 0;
            }

            public void Push(T item)
            {
                elements[top++] = item;
            }

            public T Pop()
            {
                return elements[--top];
            }
        }
        
        class Pair<T1, T2>
        {
            public T1 First { get; set; }
            public T2 Second { get; set; }

            public Pair(T1 first, T2 second)
            {
                First = first;
                Second = second;
            }

            public void Display()
            {
                Console.WriteLine($"First: {First}, Second: {Second}");
            }
        }

        static void Main(string[] args)
        {
            Stack<int> intStack = new Stack<int>();
            intStack.Push(1);
            intStack.Push(2);
            intStack.Push(3);
            Console.WriteLine(intStack.Pop());

            Pair<int, string> pair1 = new Pair<int, string>(1, "One");
            pair1.Display();

            Pair<double, bool> pair2 = new Pair<double, bool>(3.14, true);
            pair2.Display();
        }
    }
}