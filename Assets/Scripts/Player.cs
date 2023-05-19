using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PolygonCollider2D _collider;

    bool isAlive = true;

    public static event System.Action OnPlayerDied;

    public void Collided(Collider2D collision)
    {
        if (isAlive && (collision.CompareTag("Floor") || collision.CompareTag("PipeCollider")))
        {
            DoDie();
        }
        
        else if (collision.CompareTag("ScoreTrigger"))
        {

        }
    }

    void DoDie()
    {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = false;

        isAlive = false;
        _collider.isTrigger = false;
        GameManager.instance.DoGameOver();
        OnPlayerDied?.Invoke();
    }

    private void EnableMovement()
    {
        GetComponent<PlayerMovement>().enabled = true;
    }

    private void OnEnable()
    {
        GameManager.OnGameplayStartAction += EnableMovement;
    }

    private void OnDisable()
    {
        GameManager.OnGameplayStartAction -= EnableMovement;
    }
}
