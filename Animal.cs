

using TextFile;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Reflection.Metadata.Ecma335;

namespace OOP2
{
    public abstract class Animal
    {
        public string Name { get; }
    protected int exhLevel;
    public int getExhLevel()
        {
            return exhLevel;
        }
    public void ModifyLevel(int e) { exhLevel += e;
        }
    public bool Alive() { return exhLevel > 0; }

    protected Animal(string str, int exh = 0) { Name = str; exhLevel = exh; }
        
        public abstract void Traverse(IDay day);



    }

public class Fish : Animal
{
    public Fish(string str, int exh = 0) : base(str, exh) { }
        
        public override void Traverse(IDay day)
        {
            day.ChangeF(this);
            if(exhLevel > 100) { exhLevel = 100; }

        }
    }
public class Bird : Animal
{
    public Bird(string str, int e = 0) : base(str, e) { }
        public override void Traverse(IDay day)
        {
            day.ChangeB(this);
            if (exhLevel > 100) { exhLevel = 100; }

        }
    }

public class Dog : Animal
{
    public Dog(string str, int exh = 0) : base(str, exh) { }
       
        public override void Traverse(IDay day)
        {
            day.ChangeD(this);
            if (exhLevel > 100) { exhLevel = 100; }

        }
    }
}
