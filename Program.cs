using System.CommandLine;
using System.CommandLine.Completions;
using System.CommandLine.Parsing;

await new DateCommand().InvokeAsync(args);

class DateCommand : Command
{
    private Argument<string> subject = new Argument<string>("subject", "The subject of the appointment");
    private Option<DateTime> date = new Option<DateTime>("--date", "The day of week to schedule. Should be within two weeks");
    public DateCommand() : base("schedule", "makes an appointment for sometime in the next week")
    {
        this.AddArgument(subject);
        this.AddOption(date);
        date.AddCompletions((ctx) => {
            var today = System.DateTime.Today;
            var dates = new List<CompletionItem>();
            foreach (var i in Enumerable.Range(1, 14)) {
                 dates.Add (new CompletionItem(today.AddDays(i).ToShortDateString()));
            }
            return dates;
        }
        );

        this.SetHandler((string message, DateTime date) => {
            Console.WriteLine($"Scheduled \"{message}\" for {date}");
        }, subject, date);
    }
}
