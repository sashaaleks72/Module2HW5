using Autofac;

namespace M2HW5
{
    internal class Program
    {
        private static void Main()
        {
            var config = new DIConfig();
            var container = config.Build();
            var start = container.Resolve<Starter>();
            start.Run();
        }
    }
}
