using System;
using System.Timers;
using Spectre.Console;

namespace cdbv1.Helpers
{
    internal class CustomTimer(int timeAllowance)
    {
        private static bool manualStop = false;
        private static System.Timers.Timer aTimer;
        private int timeAllowance = timeAllowance;
        private static int timeLeft;
        private static int timeElapsed = 0;
        // private static int interval = 1000;
        // 10 = 10 seconds
        // private static int timeLeft = timeAllowance;

        public async Task SolutionTimer()
        {

            SetTimer();
            DisplayTimer();
            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            StopTimer();
        }
        private static void StopTimer()
        {
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();
            manualStop = true;

            AnsiConsole.Clear();
            Console.WriteLine("Terminating the application...");
        }
        private static void SetTimer()
        {
            int interval = 1000;
            // Create a timer with a 1 second interval.
            aTimer = new System.Timers.Timer(interval);



            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            timeLeft -= interval;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            // AnsiConsole.Progress()
            //     .Start(ctx =>
            //     {
            //         var task = ctx.AddTask("Timer started...", maxValue: 10000);
            //         aTimer.Enabled = true;
            //         while (!ctx.IsFinished && !manualStop)
            //         {
            //             Thread.Sleep(10);
            //             task.Increment(1);
            //         }
            //     });
            // if (timeLeft <= 0)
            // {
            //     aTimer.Stop();
            //     aTimer.Dispose();
            // }
            // else
            // {
                timeElapsed = timeElapsed + 1;
                    Console.ReadKey();

                // Console.WriteLine($"ElapsedTime: {timeElapsed}");
                // Console.WriteLine($"TimeLeft: {timeLeft}");
            // }
        }
        public static void DisplayTimer()
        {
            AnsiConsole.Progress()
                .StartAsync(async ctx =>
                {
                    
                    var task = ctx.AddTask("Timer started...", maxValue: 100);

                    while (!ctx.IsFinished && !manualStop)
                    {
                    
                        Thread.Sleep(10);
                        // task.Increment(timeElapsed);
                        task.Value = timeElapsed;
                    }
                    // Console.ReadKey();
                    // aTimer.Stop();
                    // aTimer.Dispose();
                });

        }
    }
}