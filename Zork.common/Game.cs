using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
//using Microsoft.CodeAnalysis.CSharp.Scripting;
//using Microsoft.CodeAnalysis.Scripting;
using System.Text;


namespace Zork
{
    public class Game
    {
        [JsonIgnore]
        public static Game Instance { get; private set; }

        public World World { get; set; }

        [JsonIgnore]
        public Player Player { get; private set; }

        [JsonIgnore]
        public bool IsRunning { get; set; }

        [JsonIgnore]
        public CommandManager CommandManager { get; }

        [JsonIgnore]
        public IInputService Input { get; private set; }

        [JsonIgnore]
        public IOutputService Output { get; private set; }

        public string WelcomeMessage { get; set; }

        public Game(World world, Player player)
        {
            World = world;
            Player = player;
        }

        public Game() => CommandManager = new CommandManager();

        public static void StartFromFile(string gameFilename, IInputService input, IOutputService output)
        {
            if (!File.Exists(gameFilename))
            {
                throw new FileNotFoundException("Expected file.", gameFilename);
            }

            Start(File.ReadAllText(gameFilename),input, output);
        }

        public static void Start(string gameJsonString, IInputService input, IOutputService output)
        {
            Instance = Load(gameJsonString);
            Instance.Input = input;
            Instance.Output = output;
            Instance.LoadCommands();
            //Instance.LoadScripts();
            Instance.DisplayWelcomeMessage();
            //Instance.Run();

            Instance.IsRunning = true;
            Instance.Input.InputReceived += Instance.InputReceivedHandler;

        }

        private void InputReceivedHandler(object sender, string inputString)
        {
            Room previousRoom = Player.Location;
            if (CommandManager.PerformCommand(this, inputString.Trim()))
            {
                Player.Moves++;

                if (previousRoom != Player.Location)
                {
                    CommandManager.PerformCommand(this, "LOOK");
                }
            }
            else
            {
                Output.WriteLine("That's not a verb I recognize.");
            }
        }

        public void Restart()
        {
            IsRunning = false;
            mIsRestarting = false;
            Console.Clear();
        }

        public void Quit() => IsRunning = false;

        public static Game Load(string jsonString)
        {
            Game game = JsonConvert.DeserializeObject<Game>(jsonString);
            game.Player = game.World.SpawnPlayer();

            return game;
        }

        private void LoadCommands()
        {
            var commandMethods = (from type in Assembly.GetExecutingAssembly().GetTypes()
                                  from method in type.GetMethods()
                                  let attribute = method.GetCustomAttribute<CommandAttribute>()
                                  where type.IsClass && type.GetCustomAttribute<CommandClassAttribute>() != null
                                  where attribute != null
                                  select new Command(attribute.CommandName, attribute.Verbs,
                                  (Action<Game, CommandContext>)Delegate.CreateDelegate(typeof(Action<Game, CommandContext>), method)));

            CommandManager.AddCommands(commandMethods);
        }

        /*private void LoadScripts()
        {
            foreach (string file in Directory.EnumerateFiles(ScriptDirectory, ScriptFileExtension))
            {
                try
                {
                    var scriptOptions = ScriptOptions.Default.AddReferences(Assembly.GetExecutingAssembly());

                    scriptOptions = scriptOptions.WithEmitDebugInformation(true)
                                    .WithFilePath(new FileInfo(file).FullName)
                                    .WithFileEncoding(Encoding.UTF8);

                    string script = File.ReadAllText(file);
                    CSharpScript.RunAsync(script, scriptOptions).Wait();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error compiling script: {file}  Error: {ex.Message}");
                }
            }
        }*/

        public static bool ConfirmAction(string prompt)
        {
            return true;
            /*Instance.Output.Write(prompt);

            while (true)
            {
                string respone = Console.ReadLine().Trim().ToUpper();
                if (respone == "YES" || respone == "Y")
                {
                    return true;
                }
                else if (respone == "NO" || respone == "N")
                {
                    return false;
                }
                else
                {
                    Instance.Output.Write("Please answer yes or no.> ");
                }
            }*/
        }

        private void DisplayWelcomeMessage() => Output.WriteLine(WelcomeMessage);

        public static readonly Random Random = new Random();
        //private static readonly string ScriptDirectory = "Scripts";
        //private static readonly string ScriptFileExtension = "*.csx";

        //[JsonProperty]
        //private string WelcomeMessage = null;


        private bool mIsRestarting;
    }
}