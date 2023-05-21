using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    TextMeshProUGUI _text;
    [SerializeField] bool isDynamic = true;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        UpdateScore(GameManager.instance.points);
    }

    private void UpdateScore(int newPoints)
    {
        _text.text = $"{newPoints}";
    }

    private void OnEnable()
    {
        if (isDynamic)
            GameManager.OnPointsChanged += UpdateScore;
    }

    private void OnDisable()
    {
        if (isDynamic)
            GameManager.OnPointsChanged -= UpdateScore;
    }
}
