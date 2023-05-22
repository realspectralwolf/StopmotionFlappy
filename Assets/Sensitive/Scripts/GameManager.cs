using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float moveSpeed = 1;
    private float internalMoveSpeed = 3;
    private float tempMoveSpeed = 0;

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
        pipesManager.gameObject.SetActive(false);

        Application.targetFrameRate = 60;
        if (skipMenu)
        {
            skipMenu = false;
            StartGameplay();
        }
    }

    private void Update()
    {
        if (!isGameplay) return;

        internalMoveSpeed += speedChangeOverTime * Time.deltaTime;
        moveSpeed = internalMoveSpeed + tempMoveSpeed;
    }

    public void DoGameOver()
    {
        isGameplay = false;
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

    public void TempForwardBoost()
    {
        //StartCoroutine(ChangeTempSpeed());
    }

    private IEnumerator ChangeTempSpeed()
    {
        tempMoveSpeed += .1f;

        yield return new WaitForSeconds(0.1f);

        tempMoveSpeed -= .1f;
    }
}
