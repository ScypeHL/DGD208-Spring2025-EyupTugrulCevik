using programming2final;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    internal class Items : Game
    {
        private Dictionary<string, ItemStruct> items = new Dictionary<string, ItemStruct>();
        private List<ItemStruct> _items = new List<ItemStruct>();
        public Items() { }

        public void AddItems()
        {
            BirdFood();
            FishFood();
            DogFood();
            Salmon();
            Carrot();
            Peanut();
            String();
            Laser();
            HamsterWheel();
            RollyTeaser();


            applyItems();
        }

        private void applyItems()
        {
            if (AnimalSelected.TryGetValue(1, out AnimaStruct animal1)) { }
            if (AnimalSelected.TryGetValue(2, out AnimaStruct animal2)) { }
            if (AnimalSelected.TryGetValue(3, out AnimaStruct animal3)) { }

            foreach (var item in _items)
            {
                if (item.CanBeUsedOn == animal1.Type.ToLower())
                {
                    Inventory.Add(item);
                }
            }

            foreach (var item in _items)
            {
                if (item.CanBeUsedOn == animal2.Type.ToLower())
                {
                    Inventory.Add(item);
                }
            }

            foreach (var item in _items)
            {
                if (item.CanBeUsedOn == animal3.Type.ToLower())
                {
                    Inventory.Add(item);
                }
            }
        }

        #region Foods
        private void BirdFood()
        {
            ItemStruct birdFood = new ItemStruct("BirdFood", "A mineral rich meal for your birds", 20, -5, 5,  "parrot", false);
            items["birdfood"] = birdFood;
            _items.Add(birdFood);
        }
        private void FishFood()
        {
            ItemStruct fishFood = new ItemStruct("FishFood", "A mineral rich meal for your fishes", 20, 5, 15, "fish", false);
            items["fishfood"] = fishFood;
            _items.Add(fishFood);
        }

        private void DogFood()
        {
            ItemStruct dogFood = new ItemStruct("DogFood", "High protein food for good dogs", 20, -5, 5, "dog", false);
            items["dogfood"] = dogFood;
            _items.Add(dogFood);
        }
        private void Salmon()
        {
            ItemStruct salmon = new ItemStruct("Salmon", "A delicious salmon for your cat", 20, -5, 5, "cat", false);
            items["salmon"] = salmon;
            _items.Add(salmon);
        }

        private void Carrot()
        {
            ItemStruct carrot = new ItemStruct("Carrot", "It's Carrot... for bunnies..", 20, -5, 5, "rabbit", false);
            items["carrot"] = carrot;
            _items.Add(carrot);
        }
        private void Peanut()
        {
            ItemStruct peanut = new ItemStruct("Peanut", "Hansters love peanuts", 20, -5, 5, "hamster", false);
            items["peanut"] = peanut;
            _items.Add(peanut);
        }
        #endregion

        #region Toys
        private void String()
        {
            ItemStruct String = new ItemStruct("String", "Cats love playing with strings", -5, -5, 20, "cat", true);
            items["string"] = String;
            _items.Add(String);
        }

        private void Laser()
        {
            ItemStruct laser = new ItemStruct("Laser", "A good, enjoy toy for cats", -5, -5, 20, "cat", true);
            items["laser"] = laser;
            _items.Add(laser);
        }

        private void HamsterWheel()
        {
            ItemStruct HamsterWheel = new ItemStruct("HamsterWheel", "Hamsters can buil-d musc-...", -5, -5, 20, "hamster", false);
            items["hamsterwheel"] = HamsterWheel;
            _items.Add(HamsterWheel);
        }
        
        private void RollyTeaser()
        {
            ItemStruct RollyTeaser = new ItemStruct("RollyTeaser", "An enjoyable meal plate for your rabbit", 10, -10, 10, "hamster", false);
            items["rollyteaser"] = RollyTeaser;
            _items.Add(RollyTeaser);
        }

        private void LemmingPlushie()
        {
            ItemStruct LemmingPlushie = new ItemStruct("LemmingPlushie", "Your dog will love to play with it", -5, -5, 5, "hamster", false);
            items["lemmingplushie"] = LemmingPlushie;
            _items.Add(LemmingPlushie);
        }
        #endregion
    }
}
