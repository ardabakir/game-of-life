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

        Cell[,] myArr = new Cell[col+2,row+2];

        Random rnd = new Random();

        for (int i = 0; i < myArr.GetLength(0); i++)
        {
            for(int j=0; j < myArr.GetLength(1); j++)
            {
                myArr[i, j] = new Cell(i,j);
                int r = rnd.Next(10);
                if (i==0 || i==myArr.GetLength(0)-1 || j==0 || j == myArr.GetLength(1)-1)
                {
                    myArr[i, j].IsAlive = false;
                }
                else if (r <= 5)
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
        string exitGame = "";
        for (int i = 1; i < myArr.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < myArr.GetLength(1) - 1; j++)
            {
                CheckNeighbors(ref myArr, i, j);
            }
        }
        Console.ReadKey();
        while (exitGame != "exit")
        {
            for (int i = 1; i < myArr.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < myArr.GetLength(1) - 1; j++)
                {
                    myArr[i, j].NextGeneration();
                    if (myArr[i, j].IsAlive)
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write("O ");
                    }
                }
                Console.WriteLine();
            }
            for (int i = 1; i < myArr.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < myArr.GetLength(1) - 1; j++)
                {
                    CheckNeighbors(ref myArr, i, j);
                }
            }
            exitGame = Console.ReadLine();
        }

    }

    private static void CheckNeighbors(ref Cell[,] arr, int x, int y)
    {
        int aliveCount = 0;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i != 0 || j != 0)
                {
                    if (arr[x + i, y + j].IsAlive)
                    {
                        aliveCount = aliveCount + 1;
                    }
                }
            }
        }
        arr[x,y].AliveNeighborCount = aliveCount;
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

        public void CheckNeighbors(Cell[,] myArr)
        {
            int aliveCount = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i != 0 && j != 0)
                    {
                        if (myArr[this.XPos + i, this.YPos + j].IsAlive)
                        {
                            aliveCount++;
                        }
                    }
                }
            }
            this.AliveNeighborCount = aliveCount;
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