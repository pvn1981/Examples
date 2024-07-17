namespace SimpleFuncInterface
{
    internal class Program
    {
        public interface IEventHandler<T>
        {
            void Handle(T e);
        }

        class Event
        { }

        class Work
        { }


        class Worker : IEventHandler<Event>, IEventHandler<Work>
        {
            public void Handle(Event e)
            {
                Console.WriteLine("Worker handle Event");
            }

            public void Handle(Work e)
            {
                Console.WriteLine("Worker handle Work");
            }
        }

        static void Main(string[] args)
        {
            Worker worker = new Worker();

            worker.Handle(new Event());
            worker.Handle(new Work());
        }
    }
}
