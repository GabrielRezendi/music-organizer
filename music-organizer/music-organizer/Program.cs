using music_organizer;
using music_organizer.Actions;

string action = "";
if (args.Length == 0)
    goto invalidAction;

action = args[0];

invalidAction:
{
    if (action == "--help" || action == "-h" || string.IsNullOrEmpty(action))
    {
        Console.WriteLine("[actionCode] [folderPath]");
        Console.WriteLine($"Unkown Action, select from: {String.Join(",", Enum.GetNames(typeof(ActionsEnum)))}");
        return;
    }
}

var folderPath = args[1];
Enum.TryParse(action, out ActionsEnum actionEnum);
switch (actionEnum)
{
    case ActionsEnum.OrderByAlbumYear:
        new OrderByAlbumYearAction(folderPath).Run();
        break;
    default:
        goto invalidAction;
}