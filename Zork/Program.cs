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
            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT) //making the game keep looping and wont end unless quit
            {
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
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
                        outputString = $"You moved {command}";
                        break;
                    default:
                        outputString = "Unknown Command";
                        break;
                }
                Console.WriteLine(outputString);
            }
            //string inputString = Console.ReadLine(); //ReadLine take no arguements and return player's input as string (literally rewrite the command we input

            //professor, at this point you already confused me with a bunch of codes that could do the same...

            /*
            inputString = inputString.ToUpper(); // this line make sure the string case-sensitive are the same(so u can use look instead of typing LOOK) 
            //('ToUpper' transformed all case to CAP and 'ToLower' do oppisite)
            if (inputString == "QUIT")
            {
                Console.WriteLine("Thank you for playing.");
            }    
            else if (inputString == "LOOK")
            {
                Console.WriteLine("This is an open field west of white house, with a boarded front door.\nA rybber mat saying 'Welcome to Zork!' lies by the door."); // \n is to skip a line
            }
            else
            {
                Console.WriteLine("Unrecognized command.");
            }
            */

            //Commands command = ToCommand(inputString.Trim().ToUpper()); //calling the ToCommand function v
            //Console.WriteLine(command);
        }
        /*
        private static Commands ToCommand(string commandString) //This method will accept, as parameter, a string to attempt to convert into commands enum value
        {
            Commands command;
            switch (commandString)
            {
                case "QUIT":
                    command = Commands.QUIT;
                    break;

                case "LOOK":
                    command = Commands.LOOK;
                    break;

                case "NORTH":
                    command = Commands.NORTH;
                    break;

                case "SOUTH":
                    command = Commands.SOUTH;
                    break;

                case "EAST":
                    command = Commands.EAST;
                    break;

                case "WEST":
                    command = Commands.WEST;
                    break;

                default:
                    command = Commands.UNKNOWN;
                    break;
            };
            return command;
            /*
            if (commandString == "QUIT")
            {
                command = Commands.QUIT;
            }
            else if (commandString == "LOOK")
            {
                command = Commands.LOOK;
            }
            else if (commandString == "NORTH")
            {
                command = Commands.NORTH;
            }
            else if (commandString == "SOUTH")
            {
                command = Commands.SOUTH;
            }
            else if (commandString == "EAST")
            {
                command = Commands.EAST;
            }
            else if (commandString == "WEST")
            {
                command = Commands.WEST;
            }
            else
            {
                command = Commands.UNKNOWN;
            }
            return command; 
            // close this

        }*/
        private static Commands ToCommand(string commandString) => (Enum.TryParse<Commands>(commandString, true, out Commands result) ? result : Commands.UNKNOWN);
        // ^ somewhere in there have the bool statement to ignore case so it can read lowecase without ToUpper line code
    }
}
