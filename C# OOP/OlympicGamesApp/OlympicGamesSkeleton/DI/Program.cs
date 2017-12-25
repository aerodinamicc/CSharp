using ConsoleApp1.Ninject;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Salutation : ISalutation
    {
        //it's readonly, as we get it from the constructor we won't touch it further
        private readonly IMessageWriter writer;

        public Salutation(IMessageWriter writer)
        {
            //validation at the first possible location
            //fail at the first possible moment
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            this.writer = writer;
        }

        public static void Main()
        {
            IMessageWriter writer = new ConsoleMessageWriter(); // ConsoleMessageWriter
            //would e.g. be the class that takes the data from the database, shapes it
            //and gives it to whoever is visualizing them
            IMessageWriter writerFile = new FileMessageWriter();
            IKernel kernel = new StandardKernel(new HelloWorldModule());
            Salutation salutation = kernel.Get<Salutation>();
            Salutation zdarsti = kernel.Get<Salutation>();
            Salutation salut2 = kernel.Get<Salutation>();
            salutation.Exclaim("FirstEverDependencyInjection"); //salutation-a would be the service data layer

        }

        public void Exclaim(string text)
        {
            this.writer.Writing(text);
        }
    }
}
