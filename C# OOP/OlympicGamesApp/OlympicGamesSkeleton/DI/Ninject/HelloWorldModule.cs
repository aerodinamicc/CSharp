using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Ninject
{
    public class HelloWorldModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMessageWriter>()
                .To<ConsoleMessageWriter>()
                .Named("ConsoleWriter");

            this.Bind<IMessageWriter>()
                .To<FileMessageWriter>()
                .Named("FileWriter");

            this.Bind<ISalutation>()
                .To<Salutation>()
                .InSingletonScope()
                .WithConstructorArgument(
                "ConsoleWriter");

        }
    }
}
