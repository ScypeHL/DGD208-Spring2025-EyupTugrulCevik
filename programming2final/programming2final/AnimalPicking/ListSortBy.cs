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
        public ListSortBy(List<AnimaStruct> Animals, AnimalPick animalpick_)
        {
            animalpick = animalpick_;
            animals_ = Animals;
        }
        
        public void chooseSortby()
        {
            Console.WriteLine("You may sort by: [Fun, Hunger, Sleep]");
            string sortbyOpionSelect = Console.ReadLine().ToLower();
            switch (sortbyOpionSelect) 
            {
                case "fun":
                    animalpick.sortOption += () => sortbyFun(animals_);
                    break;
                case "sleep":
                    animalpick.sortOption += () => sortbySleep(animals_);
                    break;
                case "hunger":
                    animalpick.sortOption += () => sortbyHunger(animals_);
                    break;
                default:
                    Console.WriteLine("This is not an option");
                    chooseSortby();
                    break;
            }
            
        }

        List<AnimaStruct> sortbyFun(List<AnimaStruct> animals)
        {
            IEnumerable<AnimaStruct> doneSorted =
                from animal in animals
                orderby animal.FunScaling descending
                select animal;
            return doneSorted.ToList();
        }

        List<AnimaStruct> sortbyHunger(List<AnimaStruct> animals)
        {
            IEnumerable<AnimaStruct> doneSorted =
                from animal in animals
                orderby animal.HungerScaling descending
                select animal;
            return doneSorted.ToList();
        }

        List<AnimaStruct> sortbySleep(List<AnimaStruct> animals)
        {
            IEnumerable<AnimaStruct> doneSorted =
                from animal in animals
                orderby animal.SleepScaling descending
                select animal;
            return doneSorted.ToList();
        }
    }
}
