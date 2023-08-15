namespace c_study_week3_3_2_3
{
    internal class Program
    {
        abstract class Shape
        {
            public abstract void Draw();
        }

        class Circle :  Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Drawing Circle");
            }
        }

        class Square : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Drawing Square");
            }
        }

        class Triangle : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Drawing Triangle");
            }
        }

        static void Main(string[] args)
        {
            // Shape shape = new Shape(); -> 객체화 불가능
            List<Shape> list = new List<Shape>();
            list.Add(new Circle());
            list.Add(new Square());
            list.Add(new Triangle());
            
            foreach (Shape shape in list)
            {
                shape.Draw();
            }
        }
    }
}