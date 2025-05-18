using programming2final;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    internal class Gameplay
    {
        private int funScale;
        private int sleepScale;
        private int hungerScale;
        private string type;
        private string colour;
        public Gameplay(AnimaStruct pickedAnimal)
        {
            funScale = pickedAnimal.FunScaling;
            sleepScale = pickedAnimal.SleepScaling;
            hungerScale = pickedAnimal.HungerScaling;
            type = pickedAnimal.Type;
            colour = pickedAnimal.Colour;
            start();
        }

        private void start()
        {
        }
    }
}
