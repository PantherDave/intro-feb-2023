// See https://aka.ms/new-console-template for more informationcw
Console.WriteLine("How many minutes is your break?");
var minutes = int.Parse(Console.ReadLine());
Console.WriteLine("How long is the song (minutes:seconds)?");
var songLength = Console.ReadLine();
string[] song = songLength.Split(':');
var songMinutes = int.Parse(song[0]);
var songSeconds = int.Parse(song[1]);
var now = DateTime.Now;
var endOfBreak = now + TimeSpan.FromMinutes(minutes);
var startOfSong = endOfBreak - TimeSpan.FromMinutes(songMinutes) - TimeSpan.FromSeconds(songSeconds);
Console.WriteLine($"End of break: {endOfBreak}");
Console.WriteLine($"Suggested start of the song: {startOfSong}");
