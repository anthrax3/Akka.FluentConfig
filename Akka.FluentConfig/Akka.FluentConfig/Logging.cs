using Akka.Event;
using Akka.Util.Internal;

namespace Akka
{
    public static class FluentConfigLogging
    {
        public static FluentConfig LogConfigOnStart(this FluentConfig self, bool on)
        {
            if (on)
            {
                ((FluentConfigInternals) self).AppendLine("akka.log-config-on-start = on");
            }
            return self;
        }

        public static FluentConfig StdOutLogLevel(this FluentConfig self, LogLevel logLevel)
        {
            self.AsInstanceOf<FluentConfigInternals>()
                .AppendLine(string.Format("akka.stdout-loglevel = {0}", logLevel.StringFor()));

            return self;
        }

        public static FluentConfig LogLevel(this FluentConfig self, LogLevel logLevel)
        {
            self.AsInstanceOf<FluentConfigInternals>()
                .AppendLine(string.Format("akka.loglevel = {0}", logLevel.StringFor()));

            return self;
        }

        private static FluentConfig DebugReceive(this FluentConfig self, bool on)
        {
            if (on)
            {
                self.AsInstanceOf<FluentConfigInternals>().AppendLine("akka.actor.debug.receive = on");
            }
            return self;
        }

        private static FluentConfig DebugAutoReceive(this FluentConfig self, bool on)
        {
            if (on)
            {
                self.AsInstanceOf<FluentConfigInternals>().AppendLine("akka.actor.debug.autoreceive = on");
            }
            return self;
        }

        private static FluentConfig DebugLifecycle(this FluentConfig self, bool on)
        {
            if (on)
            {
                self.AsInstanceOf<FluentConfigInternals>().AppendLine("akka.actor.debug.lifecycle = on");
            }
            return self;
        }

        private static FluentConfig DebugEventStream(this FluentConfig self, bool on)
        {
            if (on)
            {
                self.AsInstanceOf<FluentConfigInternals>().AppendLine("akka.actor.debug.event-stream = on");
            }
            return self;
        }

        public static FluentConfig DebugUnhandled(this FluentConfig self, bool on)
        {
            if (on)
            {
                self.AsInstanceOf<FluentConfigInternals>().AppendLine("akka.actor.debug.unhandled = on");
            }
            return self;
        }

        public static FluentConfig LogLocal(this FluentConfig self, bool receive = false, bool autoReceive = false,
            bool lifecycle = false, bool eventStream = false, bool unhandled = false)
        {
            return self.DebugReceive(receive)
                .DebugAutoReceive(autoReceive)
                .DebugLifecycle(lifecycle)
                .DebugEventStream(eventStream)
                .DebugUnhandled(unhandled);
        }
    }
}