using System;
using Castle.Windsor;
using System.Linq;
using Castle.MicroKernel.Registration;


namespace CharacterCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            container.Register(Component.For<ILoadDirectory>().ImplementedBy<LoadDirectory>().LifestyleSingleton());
            container.Register(Component.For<ICharacterCounter>().ImplementedBy<CharacterCounter>());
            container.Register(Component.For<ICharacterCount>().ImplementedBy<CharacterCount>());


            var loadedDirectory = container.Resolve<ILoadDirectory>();
            var characterCounter = container.Resolve<ICharacterCounter>();

            var csFilesFromDirectory = loadedDirectory.LoadingDirectory("/Users/hongle/Projects/CharacterCounter");

            var characterCounted = characterCounter.CountingChar(csFilesFromDirectory);

            var sortedList = characterCounted.OrderBy(x => x.Count);


            foreach(var n in sortedList)
            {
                Console.WriteLine($"Character = {n.Character}, Frequency = {n.Count} ");
            }

        }
    }
}
