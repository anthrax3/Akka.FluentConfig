using System;
using System.Text;
using Akka.Configuration;
using Akka.Dispatch;
using Akka.Event;
using Akka.Util.Internal;

// ReSharper disable once CheckNamespace
namespace Akka
{
    public class FluentConfig : FluentConfigInternals
    {
        private readonly StringBuilder _hoconConfiguration = new StringBuilder();

        void FluentConfigInternals.AppendLine(string configString)
        {
            _hoconConfiguration.AppendLine(configString);
        }

        public static FluentConfig Begin()
        {
            return new FluentConfig();
        }

        public Config Build()
        {
            return ConfigurationFactory.ParseString(_hoconConfiguration.ToString());
        }
    }

    public interface FluentConfigInternals
    {
        void AppendLine(string configString);
    }    
}