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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying) return;

        pCollider.transform.localScale = settings.playerColliderSize;

        spriteTransform.localScale = Vector3.one * settings.playerImageSize;

        DrawEllipseGizmo(pCollider.transform.lossyScale, 0);
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
