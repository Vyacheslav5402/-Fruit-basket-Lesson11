using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    public class Game
    {
        public void StartGame()
        {
            GeneratorBaskets baskets = new GeneratorBaskets();
            int basketWeight;
            baskets.Baskets(out basketWeight);

            NotebucPlayer notebucPlayer = new NotebucPlayer();
            notebucPlayer.Name = "Ron";
            UberPlayer uberPlayer = new UberPlayer();
            uberPlayer.Name = "Tod";
            ChiterPlayer chiterPlayer = new ChiterPlayer();
            chiterPlayer.Name = "Alisa";
            UberChiterPlayer uberChiterPlayer = new UberChiterPlayer();
            uberChiterPlayer.Name = "Sam";

            Console.WriteLine($"Basket weight {basketWeight} kg");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"{notebucPlayer.TypePlaye} {notebucPlayer.Name} : ");
            Console.SetCursorPosition(0, 5);
            Console.WriteLine($"{uberPlayer.TypePlaye} {uberPlayer.Name} : ");
            Console.SetCursorPosition(0, 8);
            Console.WriteLine($"{chiterPlayer.TypePlaye} {chiterPlayer.Name} : ");
            Console.SetCursorPosition(0, 11);
            Console.WriteLine($"{uberChiterPlayer.TypePlaye} {uberChiterPlayer.Name} : ");

            int[] commonList = new int[105];
            int[] notepagList = new int[105];
            int[] cheaterList = new int[105];
            int[] uberList = new int[105];
            int[] uberChiterList = new int[105];
            Player[] players = new Player[4] { notebucPlayer, uberPlayer, chiterPlayer, uberChiterPlayer };


            

            Random random = new Random();
            int rnd = random.Next(40, 139);

            if (rnd == null)
            {

            }
            int num = 0;
            int step = 0;
            int x = 0;
            int i = 0;

            while (true)
            {
                
                if (step < 100)
                {
                    rnd = random.Next(40, 139);
                    notebucPlayer.Tactic(rnd, notepagList, out num);
                    notepagList[i + x] = num;
                    commonList[i + x] = num;
                    Console.SetCursorPosition(0 + step, 3);
                    Console.Write(num);
                    if (num == basketWeight)
                    {
                        Winner(notebucPlayer.Name, basketWeight);
                        break;
                    }

                    Console.SetCursorPosition(0 + step, 6);
                    Console.Write(uberPlayer.number);
                    commonList[i + x + 1] = uberPlayer.number;
                    uberList[i] = uberPlayer.number;
                    if (uberPlayer.number == basketWeight)
                    {
                        Winner(uberPlayer.Name, basketWeight);
                    }
                    if (uberPlayer.number != basketWeight)
                    {
                        uberPlayer.Tactic();
                    }

                    rnd = random.Next(40, 139);
                    chiterPlayer.Tactic(rnd, commonList, out num);
                    commonList[i + x + 2] = num;
                    cheaterList[i] = num;
                    Console.SetCursorPosition(0 + step, 9);
                    Console.Write(num);
                    if (num == basketWeight)
                    {
                        Winner(chiterPlayer.Name, basketWeight);
                        break;
                    }

                    uberChiterPlayer.Tactic(commonList, out num);
                    commonList[i + x + 3] = num;
                    uberChiterList[i + 1] = num;
                    Console.SetCursorPosition(0 + step, 12);
                    Console.Write(num);
                    if (num == basketWeight)
                    {
                        Winner(uberChiterPlayer.Name, basketWeight);
                        break;
                    }
                    step = step + 4;
                    x = x + 3;
                    i++;
                }
                else
                {
                    int difference;
                    int numberWin;
                    int number1;
                    int number2;
                    int number3;
                    int number4;
                    DidntGuess(notepagList, basketWeight, out number1);
                    DidntGuess(uberList , basketWeight, out number2);
                    DidntGuess(cheaterList, basketWeight, out number3);
                    DidntGuess(uberChiterList, basketWeight, out number4);
                    bool sing;
                    DidntGuess2(basketWeight, number1, number2, number3, number4, out numberWin, out difference, out sing);
                    Winner(numberWin, players, basketWeight, difference, sing);
                    break;

                }
            }
            

        }
        public  void Winner(string name, int basketWeight)
        {
            Console.SetCursorPosition(0, 13);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"Player {name} winner");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"{basketWeight} kg");
            Console.ResetColor();

        }
        public void Winner(int number, Player[] players , int basketWeight, int difference, bool sing)
        {
            Console.SetCursorPosition(0, 13);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"Was closest player {players[number].Name}");
            Console.BackgroundColor = ConsoleColor.Green;
            if (sing == true)
            {
                Console.WriteLine($"{basketWeight + difference} kg");
            }
            else
            {
                Console.WriteLine($"{basketWeight - difference} kg");
            }
            
            Console.ResetColor();
        }

        public static void DidntGuess(int[] list, int basketWeight, out int number)
        {
            number = 0;
            int cons;
            int a = 0;
            int b = 0;
            for (int g = 0; g < list.Length; g++)
            {
                for (int j = list.Length - 1; j >= 1; j--)
                {
                    if (list[j] == 0)
                    {
                        continue;
                    }
                    if (list[j] >= list[j - 1])
                    {
                        cons = list[j - 1];
                        list[j - 1] = list[j];
                        list[j] = cons;
                    }
                }
            }
            for (int j = 0; j < list.Length; j++)
            {
                if (list[j] < basketWeight)
                {
                    a = list[j];

                    break;
                }
            }
            for (int j = list.Length - 1; j > 0 ; j--)
            {
                if (list[0]< basketWeight)
                {
                    b = list[0];
                    break;
                }
                if (list[j] == 0)
                {
                    continue;
                }
                if (list[j] > basketWeight)
                {
                    b = list[j];
                    if (b <= 0)
                    {
                        b = list[0];
                    }
                    break;
                }
            }
            
            if ((basketWeight - a) < (b - basketWeight))
            {
                number = a;
            }
            else
            {
                number = b;
            }
            if ((b - basketWeight) < 0)
            {
                number = a;

            }
        }
        public void DidntGuess2(int basketWeight, int number1, int number2, int number3, int number4, out int number, out int difference, out bool sing)
        {
            sing = false;
            int[] arr = new int[] { number1, number2, number3, number4 };
            bool[] sings = new bool[4] {true, true, true, true};
            for (int g = 0; g < arr.Length; g++)
            {
                if (arr[g] > basketWeight)
                {
                    arr[g] = arr[g] - basketWeight;
                    sings[g]= true;
                }
                else
                {
                    arr[g] = basketWeight - arr[g];
                    sings[g] = false;
                }

            }
            
            //number1 = basketWeight - number1;
            //number2 = basketWeight - number2;
            //number3 = basketWeight - number3;
            //number4 = basketWeight - number4;
            number = 0;
            difference = 0;
            bool x = true;
            int i = 1;
            
            
            while(x)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] == i)
                    {
                        number = j;
                        x = false;
                        break;
                    }
                    
                }
                i++;
            }
            if (number == 0)
            {
                difference = arr[0];
                sing = sings[0];
            }
            if (number == 1)
            {
                difference = arr[1];
                sing = sings[1];
            }
            if (number == 2)
            {
                difference = arr[2];
                sing = sings[2];
            }
            if (number == 3)
            {
                difference = arr[3];
                sing = sings[3];
            }

        }
    }
}
