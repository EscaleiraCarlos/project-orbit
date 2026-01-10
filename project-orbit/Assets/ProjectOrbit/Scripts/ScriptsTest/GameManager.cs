using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentState { get; private set; } = GameState.Build;

    [SerializeField] 
    private BallSpawner ballSpawner;

    [SerializeField] 
    private PlacementSystem placementSystem;

    [SerializeField] 
    private GameObject buildUI;

    [SerializeField] 
    private Button startButton;


    private void Awake()
    {
        Instance = this;
    }

    public void StartLevel()
    {
        startButton.interactable = false;
        startButton.gameObject.SetActive(false);

        CurrentState = GameState.Play;

        buildUI.SetActive(false);
        placementSystem.DisablePlacement();
        ballSpawner.SpawnBall();
    }

}
