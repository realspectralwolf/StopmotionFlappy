using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FontUpdater : MonoBehaviour
{
    [SerializeField] float fontSizeMultiplier = 1;
    [SerializeField] float opacity = 1f;

    private void Start()
    {
        ApplySettingsToSelf();
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        if (DataManager.instance == null) return;

        ApplySettingsToSelf();
    }
#endif

    void ApplySettingsToSelf()
    {
        var tmpText = GetComponent<TextMeshProUGUI>();
        tmpText.fontSize = DataManager.instance.settings.fontSize * fontSizeMultiplier;
        tmpText.font = DataManager.instance.GetSelectedFont();

        Color newCol = DataManager.instance.settings.fontColor;
        newCol.a = opacity;
        tmpText.color = newCol;
    }
}
