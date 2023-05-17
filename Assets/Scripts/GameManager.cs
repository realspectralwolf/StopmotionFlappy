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

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Resources.LoadAll($"Pipes/Variant 2").Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
