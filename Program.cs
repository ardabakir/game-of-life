internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Hi");
        
        int col;
        int row;
        string columns = Console.ReadLine();
        string rows = Console.ReadLine();

        Int32.TryParse(columns, out col);
        Int32.TryParse(rows, out row);

        Console.WriteLine(col + " " + row);

        int[,] myArr = new int[col,row];


        Random rnd = new Random();
        int numOfLiveCells = rnd.Next((int)Math.Ceiling(row * col * 0.75));
        for (int i = 0; i < numOfLiveCells; i++)
        {
            int posX = rnd.Next(col);
            int posY = rnd.Next(row);
            while (myArr[posX,posY] != 0)
            {
                posX = rnd.Next(col);
                posY = rnd.Next(row);
            }
            myArr[posX, posY]++;
        }

        for (int i = 0; i < myArr.GetLength(0); i++)
        {
            for (int j = 0; j < myArr.GetLength(1); j++)
            {
                Console.Write(myArr[i, j] + " ");
            }
            Console.WriteLine();
        }
    
        Console.ReadKey();
        Console.ReadLine();
    }
}