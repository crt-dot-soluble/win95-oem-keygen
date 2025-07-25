using WarTime.Win95KeyGen.Lib;

const string title = "WINDOWS 95C OEM OSR2.5 LICENSE KEY GENERATOR";
const string author = "WARTIME";
const char spanChar = '-';

const ConsoleColor titleColor = ConsoleColor.Gray;
const ConsoleColor authorColor = ConsoleColor.DarkGray;
const ConsoleColor spanColor = ConsoleColor.White;
const ConsoleColor seperatorColor = ConsoleColor.White;

Console.Title = title;
Console.CursorVisible = false;
Console.Clear();

Console.Write(new string(' ', (Console.WindowWidth - title.Length) / 2));
Console.ForegroundColor = titleColor;
Console.WriteLine(title);
Console.Write(new string(' ', (Console.WindowWidth - author.Length) / 2));
Console.ForegroundColor = authorColor;
Console.WriteLine(author);
Console.ForegroundColor = spanColor;
Console.WriteLine(new string(spanChar, Console.WindowWidth));

var quantity = 25;
if (args.Length > 0 && int.TryParse(args[0], out var parsedQuantity))
{
    quantity = parsedQuantity;
}

for (var i = 0; i < quantity; i++)
{
    var key = KeyGenerator.GenerateKey();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(
        $"{new string(' ', (Console.WindowWidth - key.ToString().Length - (key.ToString().Count(c => c == '-') * 2)) / 2)}{key.SegmentA}"
    );
    Console.ForegroundColor = seperatorColor;
    Console.Write($" - ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write($"{key.SegmentB}");
    Console.ForegroundColor = seperatorColor;
    Console.Write($" - ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write($"{key.SegmentC}");
    Console.ForegroundColor = seperatorColor;
    Console.Write($" - ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write($"{key.SegmentD}");
    Console.WriteLine();
}

Console.ForegroundColor = spanColor;
Console.WriteLine(new string(spanChar, Console.WindowWidth));
Console.ResetColor();
Console.Read();
