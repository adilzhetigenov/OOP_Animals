using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class Keeper
    {
        private string name;
        private List<Animal> animals;

        public Keeper(string name)
        {

            this.name = name;
            animals = new();
        }
        public void TakeAnimal(Animal animal)
        {
            animals.Add(animal);
        }
        public List<Animal> GetAnimals() { return animals; }

        public void CareAbout(Animal animal, IDay day)
        {
            animal.Traverse(day);
        }

        public void CareRoutine(ref List<IDay> days)
        {
            try{
                foreach (Animal animal in animals)
                {
                   
                    for (int j = 0; animal.Alive() && j < days.Count; ++j)
                    {
                        CareAbout(animal, days[j]);
                    }

                } 
            }catch(Exception e)
            {
                Console.WriteLine("{0}",e.ToString());
            }
        }

        public bool SaddestAnimal(ref List<Animal> result)
        {
            bool l = false;
            Animal saddest = null;
            int min = 0;
            foreach (Animal animal in animals)
            {
                if (!l && animal.Alive())
                {
                    l = true;
                    saddest = animal;
                    min = animal.getExhLevel();
                }
                else if (l && animal.Alive() && animal.getExhLevel() < min)
                {
                    saddest = animal;
                    min = animal.getExhLevel();
                }
            }
            if (l)
            {
                foreach (Animal animal in animals)
                {
                    if (min == animal.getExhLevel())
                    {
                        result.Add(animal);
                    }
                }
            }
            return l;
        }
    }
    }
