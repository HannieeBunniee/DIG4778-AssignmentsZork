//=======Hanniee Tran========//
//===DIG4778 Tool + Plugin===//

using System; //use this so u dont have to type system. over n over
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace Zork
{

    class Program
    {
       
        public static Room CurrentRoom //making this as a place to hold the array number for the current room
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }

        

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            const string defaultRoomsFilename = "Rooms.txt";
            string roomsFilename = (args.Length > 0 ? args[(int)CommandLineArguments.RoomsFilename] : defaultRoomsFilename);

            //string roomsFilename = "Rooms.txt"; /////////
            InitializeRoomDescriptions(roomsFilename);


            Room previousRoom = null;
            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT) //making the game keep looping and wont end unless quit
            {
                Console.WriteLine(CurrentRoom); //this make the debug write what room they are in
                // v have to write this if statement after console.writeline currentroom and before console.write("> "); or it wont print stuff out
                if (previousRoom != CurrentRoom) //making it auto write the description of the room but wont rewrite again if the way is shut
                {
                    Console.WriteLine(CurrentRoom.Description);
                    previousRoom = CurrentRoom;
                }

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
            { new Room("Rocky Trail"), new Room("South of House"), new Room("Canyon View") },
            { new Room("Forest"), new Room("West of House"), new Room("Behind House") },
            { new Room("Dense Woods"), new Room("North of House"), new Room("Clearing") }
        };
        private static (int Row, int Column) Location = (1, 1); //this make the player start at west of the house aka array 1,1


        private static readonly Dictionary<string, Room> RoomMap; ///
        static Program() /////
        {
            RoomMap = new Dictionary<string, Room>();
            foreach (Room room in Rooms)
            {
                RoomMap[room.Name] = room;
            }
        }

        private enum Fields ///////
        {
            Name = 0,
            Description
        }

        private enum CommandLineArguments
        {
            RoomsFilename = 0
        }

        private static void InitializeRoomDescriptions (string roomsFilename)  ////////
        {
            const string fieldDelimiter = "##";
            const int expectedFieldCount = 2;

            var roomQuery = from line in File.ReadLines(roomsFilename)
                            let fields = line.Split(fieldDelimiter)
                            where fields.Length == expectedFieldCount
                            select (Name: fields[(int)Fields.Name],
                                    Description: fields[(int)Fields.Description]);
            foreach (var (Name, Description) in roomQuery)
            {
                RoomMap[Name].Description = Description;
            }    
            
        }

        private static readonly List<Commands> Directions = new List<Commands> // idk but this is  for thr room array ^
        {
            Commands.NORTH,
            Commands.SOUTH,
            Commands.EAST,
            Commands.WEST,
            Commands.LOOK
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
