using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PipeColliderScaler : MonoBehaviour
{
    [SerializeField] Color debugColor = Color.red;

    private void OnDrawGizmos()
    {
        if (Application.isPlaying) return;

        Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().size = S;
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);

        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(transform.position, S * transform.lossyScale);
    }
}