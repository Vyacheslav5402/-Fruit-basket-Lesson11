using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    public abstract class Player
    {
        public string Name { get; set; }
        public string TypePlaye { get; set; }

        public void Tactic() 
        {
            Random random = new Random();
            int rnd = random.Next(40, 139);
        }
    }
    class NotebucPlayer : Player
    {
        public string TypePlaye = "Notebuc Player";
        public void Tactic(int rnd, int[] notepadList , out int num)
        {
            Random random = new Random();
            num = rnd;
            for (int i = 0; i < notepadList.Length; i++)
            {
                for (int j = 0; j < notepadList.Length; j++)
                {
                    if (notepadList[j] == 0)
                    {
                        continue;
                    }
                    if (num == notepadList[j])
                    {
                        num = random.Next(40, 139);
                    }
                }
            }
        }
    }
        class UberPlayer : Player
        {
            public string TypePlaye = "Uber Player";
            public byte number = 40;
            public void Tactic()
            {
                number++;
            }
        }

        class ChiterPlayer : Player
        {
            public string TypePlaye = "Chiter Player";
            public void Tactic(int rnd, int[] CeaterList, out int num)
            {
                Random random = new Random();
                num = rnd;
            for (int i = 0; i < CeaterList.Length; i++)
            {
                for (int j = 0; j < CeaterList.Length; j++)
                {
                    if (num == CeaterList[j])
                    {
                        num = random.Next(40, 139);
                    }
                }
            }
            }
        }

        class UberChiterPlayer : Player
        {
            public string TypePlaye = "Uber-Chiter Player";

        public void Tactic(int[] CeaterList, out int number)
        {
            number = 40;
            for (int j = 0; j < CeaterList.Length; j++)
            {
                for (int i = 0; i < CeaterList.Length; i++)
                {
                    if (number == CeaterList[i])
                    {
                        number++;
                    }
                    if (CeaterList[i] == 0)
                    {
                        break;
                    }
                }

            }
        }
        }
    
   
}
