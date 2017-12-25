using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core.Contracts;

namespace Traveller.Core.Decorator
{
    class LoggingDecorator : IEngine
    {
        private readonly IEngine engine;
        private readonly IWriter writer;

        public LoggingDecorator(IEngine engine, IWriter writer)
        {
            this.engine = engine ?? throw new ArgumentNullException("command");
            this.writer = writer ?? throw new ArgumentNullException("writer");
        }

        public void Start()
        {
            Stopwatch stopwatch = new Stopwatch();
            this.writer.Write("The Engine is starting...");
            stopwatch.Start();
            this.engine.Start();
            stopwatch.Stop();
            this.writer.Write($"The Engine worked for {stopwatch.Elapsed.TotalMilliseconds:f0} miliseconds.");
        }
    }
}
