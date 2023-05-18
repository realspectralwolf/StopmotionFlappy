using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PipeColliderScaler : MonoBehaviour
{
    [SerializeField] Color debugColor = Color.red;

    private void Start()
    {
        ApplySettingsToSelf();
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        if (Application.isPlaying) return;

        ApplySettingsToSelf();

        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider2D>().size * transform.lossyScale);
    }
#endif

    void ApplySettingsToSelf()
    {
        Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().size = S;
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
    }
}