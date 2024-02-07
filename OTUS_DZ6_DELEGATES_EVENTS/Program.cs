namespace OTUS_DZ6_DELEGATES_EVENTS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1 пункт 
            Foo.Work();

            // 2 - 5 пункты
            var token = new CancellationTokenSource();

            Task.Run(() => { Thread.Sleep(2000); token.Cancel(); });

            Bar.Work(token.Token);
        }
    }
}
