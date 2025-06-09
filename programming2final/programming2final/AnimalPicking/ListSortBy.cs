using programming2final;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    internal class ListSortBy:Game
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
            Printer.Get("(Descending) You may sort by:");
            Printer.GetHighlighted("[Hunger]");
            Printer.GetHighlighted("[Sleep]");
            Printer.GetHighlighted("[Fun]");
            Printer.MainFlow();

            string sortbyOpionSelect = Printer.Execute();
            switch (sortbyOpionSelect) 
            {
                case "[Fun]":
                    animalpick.sortOption += () => sortbyFun(animals_);
                    break;
                case "[Sleep]":
                    animalpick.sortOption += () => sortbySleep(animals_);
                    break;
                case "[Hunger]":
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
