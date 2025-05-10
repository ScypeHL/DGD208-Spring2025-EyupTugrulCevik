using programming2final;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    internal class ListSortBy
    {
        private AnimalPick animalpick;
        private List<AnimaStruct> animals_;
        private List<AnimaStruct> sortedAnimals = new List<AnimaStruct>();
        public ListSortBy(List<AnimaStruct> Animals, AnimalPick animalpick_)
        {
            animalpick = animalpick_;
            animals_ = Animals;
        }
        
        public void chooseSortby(string sortbyOpionSelect)
        {
            switch (sortbyOpionSelect) 
            {
                case "Fun":
                    animalpick.sortOption += () => { sortbyFun(animals_); };
                    break;
                case "Sleep":
                    animalpick.sortOption += () => { sortbySleep(animals_); };
                    break;
                case "Hunger":
                    animalpick.sortOption += () => { sortbyHunger(animals_); };
                    break;
            }
            
        }
        
        void sortbyFun(List<AnimaStruct> animals)
        {
            IEnumerable<AnimaStruct> doneSorted =
                from animal in animals
                orderby animal.FunScaling descending
                select animal;
            printList(doneSorted.ToList());
        }

        List<AnimaStruct> sortbyHunger(List<AnimaStruct> animals)
        {
            IEnumerable<AnimaStruct> doneSorted =
                from animal in animals
                orderby animal.HungerScaling descending
                select animal;
            return doneSorted.ToList();
        }

        void sortbySleep(List<AnimaStruct> animals)
        {
            IEnumerable<AnimaStruct> doneSorted =
                from animal in animals
                orderby animal.SleepScaling descending
                select animal;
            printList(doneSorted.ToList());
        }

        private void printList(List<AnimaStruct> animals)
        {
            for (int i = 0; i < animals.Count; i = i + 1)
            {
                Console.WriteLine(animals[i].Type);
            }
        }
    }
}
