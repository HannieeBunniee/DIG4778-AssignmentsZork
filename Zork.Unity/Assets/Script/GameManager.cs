using UnityEngine;
using Zork;

public class GameManager : MonoBehaviour
{
    
    void Awake()
    {
        TextAsset gameJsonAsset = Resources.Load<TextAsset>(ZorkGameFileAssetName);

        Game.Start(gameJsonAsset.text, Input, Output);
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    [SerializeField]
    private string ZorkGameFileAssetName = "Zork";

    [SerializeField]
    private UnityOutputService Output;

    [SerializeField]
    private UnityInputService Input;
}
