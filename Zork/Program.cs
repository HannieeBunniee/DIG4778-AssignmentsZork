//=======Hanniee Tran========//
//===DIG4778 Tool + Plugin===//

using System; //use this so u dont have to type system. over n over
using System.Collections.Generic;


namespace Zork
{

    class Program
    {
        private string mName;
        public string Name
        {
            get
            {
                return mName;
            }
        }

        private string mDescription;
        public string Description
        {
            get
            {
                return mDescription;    
            }
            set
            {
                mName = value;
            }
        }





        private static Room CurrentRoom //making this as a place to hold the array number for the current room
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }

        

        static void Main(string[] args)
        {
            InitializeRoomDescriptions();
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
                        Console.WriteLine(CurrentRoom.Description);
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

        
        private static readonly Room[,] Rooms = //this is the 2d aray of the rooms by row/column ex: rocky trail is 0,0
        {
            { new Room("Dense Woods"), new Room("North of House"), new Room("Clearing") },
            { new Room("Forest"), new Room("West of House"), new Room("Behind House") },
            { new Room("Rocky Trail"), new Room("South of House"), new Room("Canyon View") }
        };
        private static (int Row, int Column) Location = (1, 1); //this make the player start at west of the house aka array 1,1

        private static void InitializeRoomDescriptions()
        {
            Rooms[0, 0].Description = "This is a dimly lit forest, with large trees all around. To the rest, there appears to be sunlight.";             //Dense Woods
            Rooms[0, 1].Description = "You are facing the north side of a white house. There is no door here, and all the window are barred.";           //North of House
            Rooms[0, 2].Description = "You are in a clearing, with a forest surrounding you on the west and south.";                                     //Clearing

            Rooms[1, 0].Description = "This is a forest, with trees in all directions around you.";                                                      //Forest
            Rooms[1, 1].Description = "This is an open field wesst of white house, with a boarded front door.";                                          //West of House
            Rooms[1, 2].Description = "You are behind the white house. In one corner of the ouse there is a small window which is slightly ajar.";       //Behind House

            Rooms[2, 0].Description = "You are on a rock-strewn trail.";                                                                                 //Rocky Trail
            Rooms[2, 1].Description = "You are facing the south side of a white house. There is no door here, and all the windows are barred.";          //South of House
            Rooms[2, 2].Description = "You are at the top of the Great Canyon on its south wall.";                                                       //Caynon View
        }

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
