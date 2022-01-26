# Dynamic System.CommandLine completion sample

This sample illustrates the use of `GetCompletions` to generate dynamic
completions for a command.  This command wants to suggest dates in the future,
but cannot know the current date at compile-time, only at runtime.

To test this:

* run the app with `dotnet run [suggest:20] "some appointment" --date `
* you should see the next two weeks of dates printed to the command line:

```shell
PS C:\Users\chethusk\oss\Scratch\scl-dynamic-completion> dotnet run [suggest:20] "do the thing" --date
1/27/2022
1/28/2022
1/29/2022
1/30/2022
1/31/2022
2/1/2022
2/2/2022
2/3/2022
2/4/2022
2/5/2022
2/6/2022
2/7/2022
2/8/2022
2/9/2022
```