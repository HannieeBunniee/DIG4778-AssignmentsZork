//=======Hanniee Tran========//
//===DIG4778 Tool + Plugin===//

using System; //use this so u dont have to type system. over n over

namespace Zork
{
    
    // made the new class Commands.cs and pasted the code


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");
            string outputString;
            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT) //making the game keep looping and wont end unless quit
            {
                Console.WriteLine(Rooms[CurrentRoomIndex]); //this make the debug write what room they are in
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.QUIT:
                        outputString = "Thanks for playing!";
                        break;
                    case Commands.LOOK:
                        outputString = "This is an open field west of a white house, with a boarded front door. A rubber mat saying 'Welcome to Zork' lies by the door.";
                        break;
                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        outputString = Move(command) ? $"You move {command}" : "The way is shut!"; // ":" is to write the way is shut when there is nothing else to write in the rooms array
                        break;
                    default:
                        outputString = "Unknown Command";
                        break;
                }
                Console.WriteLine(outputString);
            }
            
        }

        private static Commands ToCommand(string commandString) => (Enum.TryParse<Commands>(commandString, true, out Commands result) ? result : Commands.UNKNOWN);
        // ^ somewhere in there have the bool statement to ignore case so it can read lowecase without ToUpper line code


        private static string[] Rooms = //this is the array of the room from 0-4
        {
            "Forest",
            "West of House",
            "Behind House",
            "Clearing",
            "Canyon View"
        };
        private static int CurrentRoomIndex = 1; //this make the player start at west of the house aka array 1


        private static bool Move(Commands command)
        {
          bool didMove = false;
          switch (command)
          {
              case Commands.EAST when CurrentRoomIndex < Rooms.Length - 1: //allow player to move east(right) as long as the room array isnt exceed the given room length
                  CurrentRoomIndex++;
                  didMove = true;
                  break;

              case Commands.WEST when CurrentRoomIndex > 0: //allow player to move west(left) as long as the room array is higher than 0
                    CurrentRoomIndex--;
                  didMove = true;
                  break;
          }
          return didMove;
        }

        
     
    }
}
