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
        private Items Items = new Items();

        public Gameplay()
        {
            CurrentAnimal = 1;
            Flow();
        }

        private void Flow()
        {
            Console.Clear();
            Items.AddItems();
            Render.Flow();
        }
    }
}
