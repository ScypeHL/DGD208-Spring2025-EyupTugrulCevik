using programming2final;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    internal class AnimalPick
    {
        private List<AnimaStruct> animals;
        private List<AnimaStruct> empty;
        private ListSortBy sortby;
        public event Action sortOption;
        
        public AnimalPick()
        {
        }

        public void start()
        {
            createList();
            sortby = new ListSortBy(animals, this);
            sortby.chooseSortby("Hunger");
            sortOption?.Invoke();
        }

        void createList()
        {
            animals = new List<AnimaStruct>()
            {
                new AnimaStruct("Parrot", "Red", 100, 100, 100),
                new AnimaStruct("Dog", "Golden", 80, 100, 120),
                new AnimaStruct("Cat", "Black", 150, 70, 100)
            };            
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
