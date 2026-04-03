using System;
using System.Timers;
using Spectre.Console;

namespace cdbv1.Helpers
{
    internal class CustomTimer(int timeAllowance)
    {






        private static System.Timers.Timer aTimer;
        private int timeAllowance = timeAllowance;
        private static int timeLeft;
        private static int timeElapsed = 0;
        private static int interval = 1000;
        // 10 = 10 seconds
        // private static int timeLeft = timeAllowance;

        public void SolutionTimer()
        {






            // 1 = 1 second



            SetTimer();
            DisplayTimerProgressBar();
            timeLeft = timeAllowance;


            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            // Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.WriteLine($"start: time left: {timeLeft}");
            StopTimer();





        }
        private static void StopTimer()
        {
            // manual stop - input
            Console.ReadLine();

            // default stop
            // if (timeLeft < 0)
            // {
            // aTimer.Stop();
            // aTimer.Dispose();
            // Console.WriteLine("Terminating the application...");

            // }

            aTimer.Stop();
            aTimer.Dispose();
            Console.WriteLine("Terminating the application...");
        }
        private static void SetTimer()
        {
            //         AnsiConsole.Progress()
            // .Start(ctx =>
            // {
            //     var task = ctx.AddTask("Timer started...", maxValue: 100);

            //     while (!ctx.IsFinished)
            //     {
            //         task.Increment(1);
            //         Thread.Sleep(interval);
            //     }
            // });
            int tenSecondInterval = 10000;
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(interval);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            // Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
            //                   e.SignalTime);
            if (timeLeft <= 0)
            {
                aTimer.Stop();
                aTimer.Dispose();
            }
            else
            {

                timeElapsed = timeElapsed + 2;
                timeLeft = timeLeft - 2;

                Console.WriteLine($"ElapsedTime: {timeElapsed}");
                Console.WriteLine($"TimeLeft: {timeLeft}");
            }
        }
        public int GetTimeLeft()
        {
            return timeLeft;
        }

        public void DisplayTimerProgressBar()
        {
            AnsiConsole.Progress()
                .Start(ctx =>
                {
                    var task = ctx.AddTask("Timer started...", maxValue: 100);

                    while (!ctx.IsFinished)
                    {
                        Thread.Sleep(6000);
                        task.Increment(10);
                    }
                });
        }
    }
}