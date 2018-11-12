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

            if ((n & 1) == 0)
                evenDisks(n);
            else
                oddDisks(n);

            ClearPillars();
        }

        private void oddDisks(int n)
        {
            int disk = 0;
            double count = 0;
            //for(int i = 0;i < maxMove;i++)
            while(true)
            {
                // Move Between A and C
                if(CompareMove(Pillar_C,Pillar_A))
                {
                    disk = Pillar_A.Pop();
                    Console.WriteLine(MoveMessage, disk, 'A', 'C');
                    Pillar_C.Push(disk);
                    count++;
                }
                else if (CompareMove(Pillar_A,Pillar_C))
                {
                    disk = Pillar_C.Pop();
                    Console.WriteLine(MoveMessage, disk, 'C', 'A');
                    Pillar_A.Push(disk);
                    count++;
                }
                if (count >= maxMove)
                    break;

                // Move Between A and B
                if(CompareMove(Pillar_B,Pillar_A))
                {
                    disk = Pillar_A.Pop();
                    Console.WriteLine(MoveMessage, disk, 'A', 'B');
                    Pillar_B.Push(disk);
                    count++;
                }
                else if (CompareMove(Pillar_A,Pillar_B))
                {
                    disk = Pillar_B.Pop();
                    Console.WriteLine(MoveMessage, disk, 'B', 'A');
                    Pillar_A.Push(disk);
                    count++;
                }
                if (count >= maxMove)
                    break;

                // Move Between B and C
                if(CompareMove(Pillar_C,Pillar_B))
                {
                    disk = Pillar_B.Pop();
                    Console.WriteLine(MoveMessage, disk, 'B', 'C');
                    Pillar_C.Push(disk);
                    count++;
                }
                else if (CompareMove(Pillar_B,Pillar_C))
                {
                    disk = Pillar_C.Pop();
                    Console.WriteLine(MoveMessage,disk, 'C', 'B');
                    Pillar_B.Push(disk);
                    count++;
                }
                if (count >= maxMove)
                    break;
            }
        }

        private void evenDisks(int n)
        {
            int disk = 0;
            double count = 0;
            //for(int i = 0;i < maxMove;i++)
            while(true)
            {
                // Move Between A and B
                if(CompareMove(Pillar_B,Pillar_A))
                {
                    disk = Pillar_A.Pop();
                    Console.WriteLine(MoveMessage, disk, 'A', 'B');
                    Pillar_B.Push(disk);
                    count++;
                }
                else if (CompareMove(Pillar_A,Pillar_B))
                {
                    disk = Pillar_B.Pop();
                    Console.WriteLine(MoveMessage, disk, 'B', 'A');
                    Pillar_A.Push(disk);
                    count++;
                }
                if (count >= maxMove)
                    break;


                // Move Between A and C
                if(CompareMove(Pillar_C,Pillar_A))
                {
                    disk = Pillar_A.Pop();
                    Console.WriteLine(MoveMessage, disk, 'A', 'C');
                    Pillar_C.Push(disk);
                    count++;
                }
                else if (CompareMove(Pillar_A,Pillar_C))
                {
                    disk = Pillar_C.Pop();
                    Console.WriteLine(MoveMessage, disk, 'C', 'A');
                    Pillar_A.Push(disk);
                    count++;
                }
                if (count >= maxMove)
                    break;

                // Move Between B and C
                if(CompareMove(Pillar_C,Pillar_B))
                {
                    disk = Pillar_B.Pop();
                    Console.WriteLine(MoveMessage, disk, 'B', 'C');
                    Pillar_C.Push(disk);
                    count++;
                }
                else if (CompareMove(Pillar_B,Pillar_C))
                {
                    disk = Pillar_C.Pop();
                    Console.WriteLine(MoveMessage, disk, 'C', 'B');
                    Pillar_B.Push(disk);
                    count++;
                }
                if (count >= maxMove)
                    break;
            }
        }

        private void ClearPillars()
        {
            Pillar_A.Clear();
            Pillar_B.Clear();
            Pillar_C.Clear();
        }

        private bool CompareMove(Stack<int> X,Stack<int> Y)
        {
            if (X.Count == 0)
                return true;
            else if (Y.Count > 0 && (X.Peek() > Y.Peek()))
                return true;
            return false;

        }
    }
}
