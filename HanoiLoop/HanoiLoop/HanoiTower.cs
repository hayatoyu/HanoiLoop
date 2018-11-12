using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiLoop
{
    class HanoiTower
    {
        Stack<int> Pillar_A, Pillar_B, Pillar_C;
        double maxMove = 0,count = 0;
        string MoveMessage = "Move disk {0} from {1} to {2}";

        public HanoiTower()
        {
            Pillar_A = new Stack<int>();
            Pillar_B = new Stack<int>();
            Pillar_C = new Stack<int>();
        }
        public void run(int n)
        {
            maxMove = Math.Pow(2, n) - 1;

            // Add to Pillar_A for initialize
            for (int i = n; i > 0; i--)
                Pillar_A.Push(i);

            Move(n);

            ClearPillars();
        }

        private void ClearPillars()
        {
            Pillar_A.Clear();
            Pillar_B.Clear();
            Pillar_C.Clear();
            count = 0;
            maxMove = 0;
        }

        private void CompareMove(Stack<int> X,Stack<int> Y,string XName,string YName)
        {
            int disk = 0;
            if(X.Count == 0)
            {
                disk = Y.Pop();
                Console.WriteLine(MoveMessage, disk, YName, XName);
                X.Push(disk);
                count++;
            }
            else if (Y.Count == 0)
            {
                disk = X.Pop();
                Console.WriteLine(MoveMessage, disk, XName, YName);
                Y.Push(disk);
                count++;
            }
            else if (X.Peek() < Y.Peek())
            {
                disk = X.Pop();
                Console.WriteLine(MoveMessage, disk, XName, YName);
                Y.Push(disk);
                count++;
            }
            else if (Y.Peek() < X.Peek())
            {
                disk = Y.Pop();
                Console.WriteLine(MoveMessage, disk, YName, XName);
                X.Push(disk);
                count++;
            }
        }

        private void Move(int n)
        {            
            if((n & 1) == 0)
            {
                while (true)
                {
                    CompareMove(Pillar_A, Pillar_B,nameof(Pillar_A),nameof(Pillar_B));
                    if (count >= maxMove)
                        break;
                    CompareMove(Pillar_A, Pillar_C,nameof(Pillar_A),nameof(Pillar_C));
                    if (count >= maxMove)
                        break;
                    CompareMove(Pillar_B, Pillar_C,nameof(Pillar_B),nameof(Pillar_C));
                    if (count >= maxMove)
                        break;
                }
            }
            else
            {
                while(true)
                {
                    CompareMove(Pillar_A, Pillar_C,nameof(Pillar_A),nameof(Pillar_C));
                    if (count >= maxMove)
                        break;
                    CompareMove(Pillar_A, Pillar_B,nameof(Pillar_A),nameof(Pillar_B));
                    if (count >= maxMove)
                        break;
                    CompareMove(Pillar_B, Pillar_C,nameof(Pillar_B),nameof(Pillar_C));
                    if (count >= maxMove)
                        break;
                }
            }
        }

        
    }
}
