using System;
using Akka.Dispatch;
using Akka.Event;
using Akka.Util.Internal;

namespace Akka
{
    public static class FluentConfigDispatch
    {
        public static FluentConfig DefaultDispatcher(this FluentConfig self, DispatcherType dispatcherType,
            int throughput = 100, TimeSpan? throughputDeadlineTimeout = null)
        {
            var type = dispatcherType.GetName();
            self.ConfigureDispatcher(type, throughput, throughputDeadlineTimeout);

            return self;
        }

        public static FluentConfig DefaultDispatcher(this FluentConfig self, Type dispatcherType, int throughput = 100,
            TimeSpan? throughputDeadlineTimeout = null)
        {
            var type = dispatcherType.AssemblyQualifiedName;
            self.ConfigureDispatcher(type, throughput, throughputDeadlineTimeout);
            return self;
        }

        private static void ConfigureDispatcher(this FluentConfig self, string type, int throughput,
            TimeSpan? throughputDeadlineTimeout)
        {
            self.AsInstanceOf<FluentConfigInternals>()
                .AppendLine(string.Format("akka.actor.default-dispatcher.type = '{0}'", type));
            self.AsInstanceOf<FluentConfigInternals>()
                .AppendLine(string.Format("akka.actor.default-dispatcher.throughput = {0}", throughput));
            self.AsInstanceOf<FluentConfigInternals>()
                .AppendLine(string.Format("akka.actor.default-dispatcher.throughput-deadline-time = {0}ms",
                    throughputDeadlineTimeout.GetValueOrDefault(TimeSpan.FromSeconds(0)).TotalMilliseconds));
        }
    }
}