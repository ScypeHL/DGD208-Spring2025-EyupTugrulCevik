using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programming2final
{
    internal class Render
    {
        private float hunger = 50;
        private float sleep = 50;
        private float fun = 50;

        private int flowDelay = 1000;

        public Render()
        {

        }

        public void logicFlow(bool SWITCH)
        {
            while (SWITCH)
            {
                print();

                Thread.Sleep(flowDelay);
                Console.Clear();
            }
        }

        void print()
        {
            Console.Write($"Hunger:{hunger}| Sleep:{sleep}| Fun:{fun}\n");
        }
    }
}
