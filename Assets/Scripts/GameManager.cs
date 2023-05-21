using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float moveSpeed = 1;
    [SerializeField] private float speedChangeOverTime = 0.05f;
    [SerializeField] private int difficultyStepPointsReq = 5;
    public int difficulty = 0;

    public static bool skipMenu = false;
    public static event System.Action OnGameplayStartAction;
    public static event System.Action<int> OnPointsChanged;
    public static event System.Action OnGameEnded;

    public int points = 0;

    private bool isGameplay = false;

    [SerializeField] PipesManager pipesManager;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        if (skipMenu)
        {
            skipMenu = false;
            //StartGameplay();
        }

        pipesManager.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!isGameplay) return;

        moveSpeed += speedChangeOverTime * Time.deltaTime;
    }

    public void DoGameOver()
    {
        moveSpeed = 0;
    }

    public void OpenMenu()
    {
        skipMenu = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartGameplay()
    {
        skipMenu = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGameplay()
    {
        OnGameplayStartAction?.Invoke();
        isGameplay = true;
        pipesManager.gameObject.SetActive(true);
    }

    public void PointCollected()
    {
        points++;

        if (points % difficultyStepPointsReq == 0)
        {
            difficulty = (difficulty < 10) ? difficulty + 1: 10;
        }

        OnPointsChanged?.Invoke(points);
    }

    public void PlayerDied()
    {
        if (points > DataManager.instance.GetHighscore())
        {
            DataManager.instance.SetHighscore(points);
        }

        OnGameEnded?.Invoke();
    }

    public void CollectedMirrorObject()
    {
        Matrix4x4 mat = Camera.main.projectionMatrix;
        mat *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
        Camera.main.projectionMatrix = mat;
    }
}
