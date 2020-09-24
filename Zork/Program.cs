//=======Hanniee Tran========//
//===DIG4778 Tool + Plugin===//

using System; //use this so u dont have to type system. over n over
using System.Collections.Generic;


namespace Zork
{

    // made the new class Commands.cs and pasted the code

    class Program
    {
        private static string CurrentRoom //making this as a place to hold the array number for the current room
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");
            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT) //making the game keep looping and wont end unless quit
            {
                Console.WriteLine(CurrentRoom); //this make the debug write what room they are in
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.QUIT:
                        Console.WriteLine("Thanks for playing!");
                        break;
                    case Commands.LOOK:
                        Console.WriteLine("This is an open field west of a white house, with a boarded front door. A rubber mat saying 'Welcome to Zork' lies by the door.");
                        break;
                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (Move(command) == false)
                        {
                            Console.WriteLine("The way is shut!");
                        }
                        break;
                    default:
                        Console.WriteLine("Unknown Command");
                        break;
                }
            }

        }

        private static Commands ToCommand(string commandString) =>
            Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
        // ^ somewhere in there have the bool statement to ignore case so it can read lowecase without ToUpper line code

        
        private static readonly string[,] Rooms = //this is the array of the rooms by row/column ex: rocky trail is 0,0
        {
            { "Rocky Trail", "South of House", "Canyon View" },
            { "Forest", "West of House", "Behind House" },
            { "Dense Woods", "North of House", "Clearing" }
        };
        private static (int Row, int Column) Location = (1, 1); //this make the player start at west of the house aka array 1,1

        private static readonly List<Commands> Directions = new List<Commands> // idk but this is  for thr room array ^
        {
            Commands.NORTH,
            Commands.SOUTH,
            Commands.EAST,
            Commands.WEST,
        };

        private static bool IsDirection(Commands command) => Directions.Contains(command); //debug stuff


        private static bool Move(Commands command)
        {
            Assert.IsTrue(IsDirection(command), "Invalid direction."); //this is a debug stuff (create a assert.cs class)

            bool didMove = false;
            switch (command)
            {
                case Commands.NORTH when Location.Row < Rooms.GetLength(0) - 1: //allow player to move north(down) as long as the room array isnt exceed the given room length
                    Location.Row++;
                    didMove = true;
                    break;

                case Commands.SOUTH when Location.Row > 0: //allow player to move south(up) as long as the room array isnt exceed the given room length
                    Location.Row--;
                    didMove = true;
                    break;

                case Commands.EAST when Location.Column < Rooms.GetLength(1) - 1: //allow player to move east(right) as long as the room array isnt exceed the given room length
                    Location.Column++;
                    didMove = true;
                    break;

                case Commands.WEST when Location.Column > 0: //allow player to move west(left) as long as the room array isnt exceed the given room length
                    Location.Column--;
                    didMove = true;
                    break;
            }
            return didMove;

        }

    }
}
