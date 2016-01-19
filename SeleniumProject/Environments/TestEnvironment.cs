using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Environments
{
    public class TestEnvironment
    {
        private static string protocol;
        private static EnvironmentType environment;

        public TestEnvironment()
        {
            System.Configuration.Configuration config =
                  ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as Configuration;

            protocol = ConfigurationManager.AppSettings.Get("Protocol");
            environment = (EnvironmentType) Enum.Parse(typeof(EnvironmentType),ConfigurationManager.AppSettings.Get("Protocol"));

        }

        public static TestEnvironment GetEnvironment()
        {
            switch (environment)
            {
                case EnvironmentType.QA_A:
                    return new TestEnvironment(protocol+ "qa-a-iis03/");
                case EnvironmentType.QA_B:
                    return new TestEnvironment(protocol+"qa-b-all02/");
                default:
                    throw new ArgumentException("Invalid Environment Setting has been used");

            }
        }



        public string Url
        {
            get;
            private set;
        }
        public TestEnvironment(string URL)
        {
            this.Url = URL;
        }
    }
}
