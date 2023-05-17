using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDebug : MonoBehaviour
{
    [SerializeField] Color debugColor = Color.red;
    [SerializeField] GameSettings settings;

    private void OnDrawGizmos()
    {
        if (Application.isPlaying) return;

        GetComponent<BoxCollider2D>().offset = new Vector2(0, settings.floorColliderHeight);
        transform.position = new Vector3(0, -4.3f + settings.floorHeight, 0);

        // Gizmos
        var collider = gameObject.GetComponent<BoxCollider2D>();

        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(transform.position + (Vector3)collider.offset, collider.size * transform.lossyScale);
    }
}