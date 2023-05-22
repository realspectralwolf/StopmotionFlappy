using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "new GameSettings")]
public class GameSettings : ScriptableObject
{
    public string gameTitle = "Skok w bok";

    [Header("Player")]
    public float playerImageSize = 1;
    public Vector2 playerColliderSize = new Vector2(1, 1);

    [Header("Floor (czerwona linia podłogi)")]
    public float floorHeight = 0;
    public float floorColliderHeight = 0;

    [Header("Animation Speed")]
    public float playerIdleAnimSpeed = 1;
    public float playerJumpAnimSpeed = 1;
    public float playerDeadAnimSpeed = 1;
    public float backgroundAnimSpeed = 1;
    public float floorAnimSpeed = 1;
    public float pipesAnimSpeed = 1;
    public float collectibleAnimSpeed = 1;

    [Header("Font")]
    public Font font;
    [HideInInspector] public float fontSize = 30;
    public Color fontColor = Color.white;

    [Header("Credits")]
    [TextArea(minLines: 2, maxLines: 12)] public string creditsText;

    [HideInInspector] public int maxVariants = 10;

    public enum Font{
        BebasNeue,
        Itim,
        Pangolin,
        Rubik,
        YatraOne
    }
}
