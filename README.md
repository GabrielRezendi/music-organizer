# Music Organizer
Dead simple music files organizer

Recently I was asked by someone if I could organize a pen-drive full of musics by the album's release year. I told him yes and made this simple .net console application to accomplish the task.

### Avaible actions
1. OrderByAbumYear
 
### How to use it

Download the latest .exe version in the releases page and run it like this:

 `.\music-organizer.exe [actionName] [folderPath]` 
   
Then, the application will change the name of all the mp3 files in the `[folderPath]` variable to be ordered by the launch year of the album. 
The name of the files will look like this:

Random FileName.mp3 > 1 - 2001 - Fallin.mp3
Randomest Filename.mp3 > 2 - 2002 - How You Remind Me.mp3

Following the patterns described below:
`[orderNumber] - [albumYear] - [musicTitle].mp3`

### Adding new functions 
The actions avaibale are controlled by the `ActionsEnum`, you can index a new action by adding a new Enum.  
Then, you'll have to create a new class inside the `Actions` folder, e.g: `GroupByArtistAction`.  
Your Action Class will have to have a constructor, where by to recieve the arguments, and a Run method. <small>(This pattern is not enforced by the application, it's just a best pratice we recommend adopting)</small>
Finally, link the action class by creating a new case inside the switch that is located in the `Program.cs` file and voilà! You got yourself a new action.



### Author
Gabriel Rezende - @gabrielrezendi
