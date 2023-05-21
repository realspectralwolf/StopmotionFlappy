using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float moveSpeed = 1;

    public static bool skipMenu = false;
    public static event System.Action OnGameplayStartAction;

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
    }

    public void DoGameOver()
    {
        moveSpeed = 0;
    }

    public void RestartGameplay()
    {
        skipMenu = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGameplay()
    {
        OnGameplayStartAction?.Invoke();
        pipesManager.gameObject.SetActive(true);
    }
}
