using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] GameSettings settings;

    private void Start()
    {
        GetComponent<FramesRenderer>().SetAnimTo("Collectible (512x512)", settings.collectibleAnimSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.PointCollected();
            gameObject.SetActive(false);
        }
    }
}
