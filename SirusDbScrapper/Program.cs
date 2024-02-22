// See https://aka.ms/new-console-template for more information

using Google.Protobuf;
using SirusDbScrapper.UIDatabase;

using var dbInput = File.OpenRead("Database/originalSimDb.bin");
var db = UIDatabase.Parser.ParseFrom(dbInput);

JsonFormatter formatter = new JsonFormatter(JsonFormatter.Settings.Default.WithIndentation());
var output = formatter.Format(db);

File.WriteAllText("db.json",output);

Console.WriteLine("Saved");