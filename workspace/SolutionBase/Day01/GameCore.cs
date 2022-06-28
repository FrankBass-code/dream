using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    class GameCore
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("hello world");
            int year = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            PrintCandar(year, month);
            Console.ReadLine();
        }

        private int[,] map;
        private int[,] originMap;
        private int[] removeZeroArray;
        private int[] mergeArray;
        private Random random;
        public bool isChanged;

        public GameCore() {
            map = new int[4, 4];
            originMap = new int[4, 4];
            removeZeroArray = new int[4];
            mergeArray = new int[4];
            emptyLocationList = new List<Location>(16);
            random = new Random();
            isChanged = false;
        }

        public int[,] Map() {
            return this.map;
        }

        static void Main() {
            //int[,] map = new int[4, 4]{
            //{2,2,4,8},
            //{2,4,4,4},
            //{0,8,4,0},
            //{2,4,0,4}
            //};

            //GameCore g = new GameCore();
            //g.map = map;
            //g.MoveUp();

            //PrintArray(g.map);
            //Console.ReadLine();
            GameCore core = new GameCore();
            core.GenerateNumebr();
            core.GenerateNumebr();
            DrawMap(core.Map());
            while (true)
            {
                KeyDown(core);
                if (core.isChanged)
                {
                    core.GenerateNumebr();
                    DrawMap(core.Map());
                }
                
              
            }


            Console.ReadLine();

        }
        private static void DrawMap(int[,] map) {
            Console.Clear();
            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c = 0; c < map.GetLength(1); c++)
                {
                    Console.Write(map.GetValue(r, c) + "\t");
                }
                Console.WriteLine();
            }
        }



        private static void PrintArray(Array array) {

            for (int r = 0; r < array.GetLength(0); r++) {
                for (int c = 0; c < array.GetLength(1); c++) {
                    Console.Write(array.GetValue(r, c) + "\t");
                }
                Console.WriteLine();
            
            }
        
        }

        private static void KeyDown(GameCore core) { 

    
        switch (Console.ReadLine()){
            case "w":
                core.Move(MoveDirection.Up);
                break;
            case "a":
                core.Move(MoveDirection.Left);
                break;
            case "s":
                core.Move(MoveDirection.Down);
                break;
            case "d":
                core.Move(MoveDirection.Right);
                break;
            
        }}


        private void RemoveZero() {
            Array.Clear(removeZeroArray, 0, 4);
            int cnt = 0;
            for (int i = 0; i < mergeArray.Length; i++)
            {
                if (mergeArray[i] != 0)
                {
                    removeZeroArray[cnt] = mergeArray[i];
                    cnt++;
                }
            }
            removeZeroArray.CopyTo(mergeArray, 0);
   
        }



        private void Merge() {
            RemoveZero();
            for (int i = 0; i < mergeArray.Length - 1; i++)
            {
                if (mergeArray[i] != 0 && mergeArray[i] == mergeArray[i + 1])
                {
                    mergeArray[i] += mergeArray[i + 1];
                    mergeArray[i + 1] = 0;
                }
            }

                RemoveZero();
                
        }


        private void MoveUp() {

          
            for (int c = 0; c < map.GetLength(1); c++) { 
                for (int r = 0; r < map.GetLength(0); r++)
                {
                    mergeArray[r] = map[r, c];

                }
            Merge();

            for (int r = 0; r < map.GetLength(0); r++)
            {
                map[r, c] = mergeArray[r];

            }}
        

        }


        private void MoveDown()
        {

      
            for (int c = 0; c < map.GetLength(1); c++)
            {
                for (int r = map.GetLength(0)-1; r >=0 ; r--)
                {
                    mergeArray[3 - r] = map[r, c];

                }
              Merge();

                for (int r = map.GetLength(0) - 1; r >= 0; r--)
                {
                    map[r, c] = mergeArray[3 - r];

                }
            }

        }


        private void MoveLeft()
        {


            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c= 0; c < map.GetLength(1); c++)
                {
                    mergeArray[c] = map[r, c];

                }
               Merge();

                for (int c = 0; c < map.GetLength(1); c++)
                {
                    map[r, c] = mergeArray[c];

                }
            }


        }

        private void MoveRight()
        {


            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c = map.GetLength(1) - 1; c >= 0 ; c--)
                {
                    mergeArray[3 - c] = map[r, c];

                }
              Merge();

                for (int c = map.GetLength(1) - 1; c >= 0; c--)
                {
                    map[r, c] = mergeArray[3 - c];

                }
            }
       

        }


        public  void Move(MoveDirection direction) {
            isChanged = false;
            Array.Copy(map, originMap,map.Length);
            switch (direction) { 
                case MoveDirection.Up:
                    MoveUp();
                    break;
                case MoveDirection.Left:
                    MoveLeft();
                    break;
                case MoveDirection.Down:
                    MoveDown();
                    break;
                case MoveDirection.Right:
                    MoveRight();
                    break;
            }

            for (int i = 0; i < map.GetLength(0); i++) {
                for (int j = 0; j < map.GetLength(1); j++) {
                    if (map[i, j] != originMap[i, j]) {
                        isChanged = true;
                        return;
                    }
                }
            }
        }
        private List<Location> emptyLocationList;
        private void CalculateEmpty() {
            emptyLocationList.Clear();
          
            for (int r = 0; r < map.GetLength(0); r++) {
                for (int c = 0; c < map.GetLength(1); c++) {
                    if (map[r, c] == 0) {
                        emptyLocationList.Add(new Location(r, c));
                    }
                
                }
            
            }



        
        }



        public void GenerateNumebr() {
            CalculateEmpty();
            if (emptyLocationList.Count > 0) { 
            int randomIndex = random.Next(0, emptyLocationList.Count);
            Location loc =  emptyLocationList[randomIndex]  ;
            map[loc.RIndex, loc.CIndex] = random.Next(0,10) == 1 ? 4 : 2;}
        }


        private static int GetWeekDay(int year, int month, int day)
        {
            DateTime dt = new DateTime(year, month, day);
            return (int)dt.DayOfWeek;
        }

        private static int GetDaysByMonth(int month, int year)
        {
            if (month >= 1 && month <= 12)
            {
                switch (month)
                {
                    case 2:
                        return IsLeapYear(year) ? 29 : 28;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        return 30;
                    default:
                        return 31;
                }

            }
            return 0;
        }

        private static bool IsLeapYear(int year)
        {
            return ((year % 4 == 0 && year % 100 != 0) || year % 100 == 0);
        }


        private static void PrintCandar(int year, int month)
        {
            Console.WriteLine("{0}年{1}月", year, month);
            Console.WriteLine("日\t一\t二\t三\t四\t五\t六");

            int weak = GetWeekDay(year, month, 1);
            for (int i = 0; i < weak; i++)
            {
                Console.Write("\t");
            }

            int days = GetDaysByMonth(month, year);
            for (int i = 1; i <= days; i++)
            {
                Console.Write(i); Console.Write("\t");
                if (GetWeekDay(year, month, i) == 6)
                {
                    Console.WriteLine();
                }

            }

        }

    }
}
