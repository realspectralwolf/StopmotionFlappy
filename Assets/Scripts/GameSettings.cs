using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "new GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Player")]
    public float playerImageSize = 1;
    public Vector2 playerColliderSize = new Vector2(1, 1);

    [Header("Floor")]
    public float floorHeight = 0;
    public float floorColliderHeight = 0;

    [Header("Animation Frame Intervals")]
    public float playerInterval = 0.3f;
    public float backgroundInterval = 0.3f;
    public float floorInterval = 0.3f;
    public float pipesInterval = 0.3f;

    [Header("Others")]
    public int maxVariants = 10;
}
