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
        private AnimaStruct firstAnimal;
        private AnimaStruct secondAnimal;
        private AnimaStruct thirdAnimal;

        private Action animalController;
        private PlayerCommand playerCommand = new PlayerCommand();

        public Gameplay()
        {
            CurrentAnimal = 1;

            if (animalSelected.TryGetValue(1, out AnimaStruct _firstAnimal)) { firstAnimal = _firstAnimal; }
            if (animalSelected.TryGetValue(2, out AnimaStruct _secondAnimal)) { secondAnimal = _secondAnimal; }
            if (animalSelected.TryGetValue(3, out AnimaStruct _thirdAnimal)) { thirdAnimal = _thirdAnimal; }

            flow();
            repeat();
        }

        private void flow()
        {
            render.print();
            Console.WriteLine("Type command");
            playerCommand.read();
        }

        void repeat()
        {
            while (true)
            {
                flow();
            }
        }
    }
}
