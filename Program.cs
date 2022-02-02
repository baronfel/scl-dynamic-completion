// See https://aka.ms/new-console-template for more information
using System.CommandLine;
using System.CommandLine.Completions;
using System.CommandLine.Parsing;
using System.CommandLine.Builder;

new CommandLineBuilder(new DateCommand()).UseParseDirective().UseParseErrorReporting().UseExceptionHandler().UseHelp().RegisterWithDotnetSuggest().UseSuggestDirective().Build().InvokeAsync(args);

class DateCommand : Command
{
    private Argument<string> subject = new Argument<string>("subject", "The subject of the appointment");
    private Option<DateTime> date = new Option<DateTime>("--date", "The day of week to schedule. Should be within two weeks");
    public DateCommand() : base("schedule", "makes an appointment for sometime in the next week")
    {
        this.AddArgument(subject);
        this.AddOption(date);

        this.SetHandler((string message, DateTime date) => {
            Console.WriteLine($"Scheduled \"{message}\" for {date}");
        }, subject, date);
    }

    public override IEnumerable<CompletionItem> GetCompletions(CompletionContext context)
    {   
        var today = System.DateTime.Today;
        foreach (var i in Enumerable.Range(1, 14)) {
            yield return new CompletionItem(today.AddDays(i).ToShortDateString());
        }
    }
}

