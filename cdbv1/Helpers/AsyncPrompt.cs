using Spectre.Console;

namespace cdbv1.Helpers
{
    internal class AsyncPrompt
    {
        public async Task<string> WaitForInputAsync(string noun, string adjective)
        {
            return await Task.Run(() =>
            {
                AnsiConsole.MarkupLine($"Please enter a value");
                return AnsiConsole.Ask<string>($"{noun} [green]{adjective}: [/]?");
            });
        }

    }
}


//var counter = 0;
//var max = args.Length is not 0 ? Convert.ToInt32(args[0]) : -1;

//while (max is -1 || counter < max)
//{
//    Console.WriteLine($"Counter: {++counter}");

//    await Task.Delay(TimeSpan.FromMilliseconds(1_000));
//}