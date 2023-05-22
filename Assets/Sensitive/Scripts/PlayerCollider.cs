using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    Player playerLifeScript;

    // Start is called before the first frame update
    void Start()
    {
        playerLifeScript = GetComponentInParent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerLifeScript.Collided(collision);
    }
}