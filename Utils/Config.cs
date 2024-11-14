using Microsoft.Extensions.Configuration;

namespace TestProject.Utils
{
    public static class Config
    {
        private static IConfiguration Configuration { get; }

        static Config()
        {
            string configPath = Path.GetFullPath(Path.Combine(@"../../../appsettings.json"));
            Configuration = new ConfigurationBuilder()
                .AddJsonFile(configPath)
                .Build();
        }

        public static string BaseUrl => Configuration["baseUrl"];
        public static string Username => Configuration["username"];
        public static string Password => Configuration["password"];
        public static string FirstName => Configuration["firstName"];
        public static string LastName => Configuration["lastName"];
        public static string ZipCode => Configuration["zipCode"];
    }
}
