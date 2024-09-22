

using TextFile;

namespace OOP2
{
    public interface IDay
    {
        void ChangeB(Bird p);
        void ChangeF(Fish p);
        void ChangeD(Dog p);
    }

   
    public class Ordinary : IDay
    {

        public void ChangeB(Bird p)
        {
            p.ModifyLevel(-1);

        }
        public void ChangeF(Fish p)
        {
            p.ModifyLevel(-3);
        }
        public void ChangeD(Dog p)
        {

        }
        private Ordinary() { }

        private static Ordinary instance = null;
        public static Ordinary Instance()
        {
            if (instance == null)
            {
                instance = new Ordinary();
            }
            return instance;
        }
    }

    public class Good : IDay
    {
        public void ChangeB(Bird p)
        {
            p.ModifyLevel(2);
            
        }
        public void ChangeF(Fish p)
        {
            p.ModifyLevel(1);
        }
        public void ChangeD(Dog p)
        {
            p.ModifyLevel(3);
        }

        private Good() { }

        private static Good instance = null;
        public static Good Instance()
        {
            if (instance == null)
            {
                instance = new Good();
            }
            return instance;
        }
    }


    public class Bad : IDay
    {
        public void ChangeB(Bird p)
        {
            p.ModifyLevel(-3);

        }
        public void ChangeF(Fish p)
        {
            p.ModifyLevel(-5);
        }
        public void ChangeD(Dog p)
        {
            p.ModifyLevel(-10);
        }

        private Bad() { }

        private static Bad instance = null;
        public static Bad Instance()
        {
            if (instance == null)
            {
                instance = new Bad();
            }
            return instance;
        }
    }
}
