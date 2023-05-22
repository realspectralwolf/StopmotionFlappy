using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

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

    private void UpdateScoreWithAnimation(int newPoints)
    {
        transform.DOPunchScale(Vector3.one * 1.25f, 0.2f);
        UpdateScore(newPoints);
    }

    private void OnEnable()
    {
        if (isDynamic)
            GameManager.OnPointsChanged += UpdateScoreWithAnimation;
    }

    private void OnDisable()
    {
        if (isDynamic)
            GameManager.OnPointsChanged -= UpdateScoreWithAnimation;
    }
}
