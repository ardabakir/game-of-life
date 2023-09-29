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

        Cell[,] myArr = new Cell[col,row];

        Random rnd = new Random();

        for (int i = 0; i < myArr.GetLength(0); i++)
        {
            for(int j=0; j < myArr.GetLength(1); j++)
            {
                myArr[i, j] = new Cell(i,j);
                int r = rnd.Next(10);
                if (r <= 3)
                {
                    myArr[i, j].IsAlive = true;
                    Console.Write("X ");
                }
                else
                {
                    Console.Write("O ");
                }
            }
            Console.WriteLine();
        }

        Console.ReadKey();
        Console.ReadLine();
    }

    private class Cell
    {
        public int AliveNeighborCount { get; set; }
        public bool IsAlive { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }


        public bool IsOverpopulated()
        {
            return this.AliveNeighborCount > 3;
        }

        public bool IsUnderpopulated()
        {
            return this.AliveNeighborCount < 2;
        }

        public void NextGeneration()
        {
            if (this.IsAlive)
            {
                if(this.IsUnderpopulated() || this.IsOverpopulated())
                {
                    this.IsAlive = false;
                }
                else
                {
                    this.IsAlive = true;
                }
            }
            else
            {
                if(this.AliveNeighborCount == 3)
                {
                    this.IsAlive = true;
                }
                else
                {
                    this.IsAlive = false;
                }
            }
        }
        public Cell(int posX, int posY)
        {
            this.AliveNeighborCount = 0;
            this.IsAlive = false;
            this.XPos = posX;
            this.YPos = posY;
            
        }
        
    }
}