namespace DrawShape
{
    public abstract class Shape
    {
        public abstract void Draw();
    }

    public class Rectangle : Shape
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public override void Draw()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }

    public class Circle : Shape
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            int diameter = radius * 2;

            for (int i = 0; i < diameter; i++)
            {
                for (int j = 0; j < diameter; j++)
                {
                    if ((i - radius) * (i - radius) + (j - radius) * (j - radius) <= radius * radius)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }

    public class Triangle : Shape
    {
        private int basis;
        private int height;

        public Triangle(int basis, int height)
        {
            this.basis = basis;
            this.height = height;
        }

        public override void Draw()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Создать список фигур
            List<Shape> shapes = new List<Shape>();

            // Запрашивать ввод пользователя до тех пор, пока он не решит выйти
            while (true)
            {
                // Отобразить меню и запросить ввод пользователя
                Console.WriteLine("Выберите фигуру:");
                Console.WriteLine("1. Прямоугольник");
                Console.WriteLine("2. Круг");
                Console.WriteLine("3. Равнобедренный треугольник");
                Console.WriteLine("4. Выход");
                int choice = int.Parse(Console.ReadLine());

                // Создать фигуру в зависимости от выбора пользователя
                Shape shape = null;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите ширину прямоугольника:");
                        int width = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите высоту прямоугольника:");
                        int height = int.Parse(Console.ReadLine());
                        shape = new Rectangle(width, height);
                        break;
                    case 2:
                        Console.WriteLine("Введите радиус круга:");
                        int radius = int.Parse(Console.ReadLine());
                        shape = new Circle(radius);
                        break;
                    case 3:
                        Console.WriteLine("Введите основание равнобедренного треугольника:");
                        int @base = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите высоту равнобедренного треугольника:");
                        int triangleHeight = int.Parse(Console.ReadLine());
                        shape = new Triangle(@base, triangleHeight);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Повторите попытку.");
                        continue;
                }

                
                shapes.Add(shape);

                
                Console.Clear();

                
                foreach (var s in shapes)
                {
                    s.Draw();
                    Console.WriteLine();
                }
            }
        }
    }
}
