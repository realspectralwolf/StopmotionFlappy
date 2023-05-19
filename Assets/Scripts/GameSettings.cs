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

    [Header("Animation Speed")]
    public float playerIdleAnimSpeed = 1;
    public float playerJumpAnimSpeed = 1;
    public float playerDeadAnimSpeed = 1;
    public float backgroundAnimSpeed = 1;
    public float floorAnimSpeed = 1;
    public float pipesAnimSpeed = 1;

    [Header("Font")]
    public Font font;
    [HideInInspector] public float fontSize = 30;
    public Color fontColor = Color.white;

    [HideInInspector] public int maxVariants = 10;

    public enum Font{
        Atma,
        Bangers,
        Norican,
        PressStart,
        RedHat,
        ReggaeOne
    }
}
