using TextFile;
using System;
using System.Collections.Generic;

namespace OOP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextFileReader reader = new("animals.txt");

            // populating creatures
            reader.ReadLine(out string line); int n = int.Parse(line);
            Keeper keeper = new Keeper("Cathy");
            for (int i = 0; i < n; ++i)
            {
                char[] separators = new char[] { ' ', '\t' };
 

                if (reader.ReadLine(out line))
                {
                    string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    char ch = char.Parse(tokens[0]);
                    string name = tokens[1];
                    int p = int.Parse(tokens[2]);

                    switch (ch)
                    {
                        case 'F': 
                            Animal fish = new Fish(name, p);
                            keeper.TakeAnimal(fish);
                            break;
                            Console.WriteLine(fish.Name);

                        case 'D': 
                            Animal dog = new Dog(name, p);
                            keeper.TakeAnimal(dog);
                            break;
                            Console.WriteLine(dog.Name);

                        case 'B': 
                            Animal bird = new Bird(name, p);
                            keeper.TakeAnimal(bird);
                            break;
                            Console.WriteLine(bird.Name);

                    }
                }
               
            }


            // populating the days
            List<IDay> days = new();
            while(reader.ReadChar(out char c))
            {
                switch (c)
                {
                    case 'o': days.Add(Ordinary.Instance()); break;
                    case 'g': days.Add(Good.Instance()); break;
                    case 'b': days.Add(Bad.Instance()); break;
                }
            }



            // caring
            try
            {
                List<Animal> output = new List<Animal>();
                bool l = false;
                keeper.CareRoutine(ref days);
                l = keeper.SaddestAnimal(ref output);
                if (l)
                {
                    foreach (Animal animal in output)
                    {
                        Console.WriteLine(animal.Name,animal.getExhLevel());
                        
                    }
                  
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.ToString());
            }
        }

    }
}
