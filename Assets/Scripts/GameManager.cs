using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float moveSpeed = 1;

    private void Awake()
    {
        instance = this;
    }

    public void DoGameOver()
    {
        moveSpeed = 0;
    }
}
