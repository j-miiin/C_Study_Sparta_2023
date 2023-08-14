namespace c_study_week1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Console.WriteLine(10);
            //Console.WriteLine(3.141592);
            //Console.WriteLine(3 + 3);

            //Console.WriteLine("Hello\rWorld");

            //Console.Write("Enter your name: ");
            //string name = Console.ReadLine();
            //Console.WriteLine("Hello, {0}!", name);

            //Console.Write("Enter two numbers: ");
            //string input = Console.ReadLine();

            //string[] numbers = input.Split(' ');
            //int num1 = int.Parse(numbers[0]);
            //int num2 = int.Parse(numbers[1]);

            //int sum = num1 + num2;

            //Console.WriteLine("The sum of {0} and {1} is {2}.", num1, num2, sum);

            //int n1 = 30, n2 = 20;

            //Console.WriteLine(n1 + n2);
            //Console.WriteLine(n1 - n2);
            //Console.WriteLine(n1 * n2);
            //Console.WriteLine(n1 / n2);
            //Console.WriteLine(n1 % n2);

            //Console.WriteLine(n1 == n2);
            //Console.WriteLine(n1 != n2);
            //Console.WriteLine(n1 > n2);
            //Console.WriteLine(n1 < n2);
            //Console.WriteLine(n1 >= n2);
            //Console.WriteLine(n1 <= n2);

            //int n3 = 15;

            //Console.WriteLine(0 < n3 && n3 <= 20);
            //Console.WriteLine(0 > n3 || n3 > 20);
            //Console.WriteLine(!(0 < n3 && n3 <= 20));

            string str1 = "Hello, World!";
            string str2 = new string('h', 5);

            string str3 = str1 + " " + str2;
            Console.WriteLine(str3);

            string[] str4 = str1.Split(',');
            Console.WriteLine(str4[0]);
            Console.WriteLine(str4[1]);

            int index = str1.IndexOf("World");
            Console.WriteLine(index);

            string newStr = str1.Replace("World", "Universe");
            Console.WriteLine(newStr);
            Console.WriteLine(str1);

            string str5 = "123";
            int num = int.Parse(str5);
            Console.WriteLine(num);

            num += 10;

            Console.WriteLine(num.ToString());

            Console.WriteLine(str1 == str2);
            Console.WriteLine(string.Compare(str1, str2));

            string name = "potato";
            int age = 100;
            string message = string.Format("My name is {0} and I'm a {1} years old.", name, age);
            Console.WriteLine(message);

            string message2 = $"My name is {name} and I'm a {age} years old.";
            Console.WriteLine(message2);
        }
    }
}