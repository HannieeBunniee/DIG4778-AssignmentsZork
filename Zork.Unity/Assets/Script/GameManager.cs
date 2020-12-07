using TMPro;
using UnityEngine;
using Zork;

public class GameManager : MonoBehaviour
{
    public string ZorkFileName = @"Assets\Resources\Zork.json";
    public TMP_Text LocationText;
    public TMP_Text ScoreText; 
    public TMP_Text MoveText;


    [SerializeField]
    private string ZorkGameFileAssetName = "Zork";

    [SerializeField]
    private UnityOutputService OutputService;

    [SerializeField]
    private UnityInputService InputService;

    void Awake()
    {
        TextAsset gameJsonAsset = Resources.Load<TextAsset>(ZorkGameFileAssetName);

        Game.Start(gameJsonAsset.text, InputService, OutputService);
        Game.Instance.CommandManager.PerformCommand(Game.Instance, "LOOK");
    }




    void Update()
    {
        LocationText.text = Game.Instance.Player.Location.ToString();
        ScoreText.text = "Score: " + Game.Instance.Player.Score.ToString();
        MoveText.text = "Move:  " + Game.Instance.Player.Moves.ToString();

    }

    private void LateUpdate()
    {
        if (Input.GetKey("escape"))
        {
            Debug.Log("Quitting Game by esc key");
            Application.Quit();
        }
    }
}
