using System.CommandLine;
using System.CommandLine.Completions;
using System.CommandLine.Parsing;
using System.CommandLine.Builder;

new CommandLineBuilder(new DateCommand())
    .UseSuggestDirective()
    .Build()
    .InvokeAsync(args);

class DateCommand : Command
{
    private Argument<string> subject = new Argument<string>("subject", "The subject of the appointment");
    private Option<DateTime> date =
        new Option<DateTime>("--date", "The day of week to schedule. Should be within two weeks")
        .AddCompletions(
            (CompletionContext ctx) =>
            {
                var today = System.DateTime.Today;
                return Enumerable.Range(1, 14).Select(i => new CompletionItem(today.AddDays(i).ToShortDateString()));
            });
    public DateCommand() : base("schedule", "makes an appointment for sometime in the next week")
    {
        this.AddArgument(subject);
        this.AddOption(date);

        this.SetHandler((string message, DateTime date) =>
        {
            Console.WriteLine($"Scheduled \"{message}\" for {date}");
        }, subject, date);
    }
}

