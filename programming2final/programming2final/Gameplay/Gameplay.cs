using programming2final;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    internal class Gameplay : Game
    {
        private Items items = new Items();

        public Gameplay()
        {
            CurrentAnimal = 1;
            Flow();
        }

        private void Flow()
        {
            Console.Clear();
            items.AddItems();
            Render.Flow();
        }
    }
}
