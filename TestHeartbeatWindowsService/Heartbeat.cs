
using timer = System.Timers;
namespace TestHeartbeatWindowsService
{
    public class Heartbeat
    {
        private readonly timer.Timer timer;

        public Heartbeat()
        {
            timer = new timer.Timer(1000) { AutoReset = true };
            timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object? sender, timer.ElapsedEventArgs e)
        {
            string[] lines = new string[]
            {
                DateTime.Now.ToString()

            };
            File.AppendAllLines(@"C:\Musa\deneme.txt", lines);
        }
        public void Start()
        {
            timer.Start();
        }
        public void Stop()
        {
            if (timer.Enabled == true)
            {
                timer.Stop();
            }

        }
    }
}
