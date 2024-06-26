using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHighscore : MonoBehaviour
{
    [SerializeField] string prefix = "";
    TextMeshProUGUI _text;
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        UpdateScore(DataManager.instance.GetHighscore());
    }

    private void UpdateScore(int newPoints)
    {
        _text.text = prefix + $"{newPoints}";
    }
}
