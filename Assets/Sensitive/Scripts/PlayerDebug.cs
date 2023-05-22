using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebug : MonoBehaviour
{
    [SerializeField] GameSettings settings;
    [SerializeField] Transform spriteTransform;
    [SerializeField] Collider2D pCollider;
    [SerializeField] Color debugColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        ApplySettingsToSelf();
    }


#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        if (DataManager.instance == null) return;

        if (Application.isPlaying) return;

        ApplySettingsToSelf();

        DrawEllipseGizmo(pCollider.transform.lossyScale, 0);
    }
#endif

    void ApplySettingsToSelf()
    {
        pCollider.transform.localScale = settings.playerColliderSize;

        spriteTransform.localScale = Vector3.one * settings.playerImageSize;
    }

    private void DrawEllipseGizmo(Vector2 size, float rotation)
    {
        size *= 0.8f;

        // Calculate the ellipse position
        Vector3 position = transform.position;

        // Set the gizmo color
        Gizmos.color = Color.red;

        // Draw the ellipse gizmo
        Matrix4x4 oldMatrix = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(position, transform.rotation, new Vector3(size.x, size.y, 1f));
        Gizmos.DrawWireSphere(Vector3.zero, 1f);
        Gizmos.matrix = oldMatrix;
    }
}
