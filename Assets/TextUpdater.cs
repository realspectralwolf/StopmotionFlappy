using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class TextUpdater : MonoBehaviour
{
    private void Start()
    {
        ApplySettingsToSelf();
    }

#if UNITY_EDITOR
    void Update()
    {
        ApplySettingsToSelf();
    }
#endif

    void ApplySettingsToSelf()
    {
        if (DataManager.instance == null)
        {
            return;
        };

        var tmpText = GetComponent<TextMeshProUGUI>();
        tmpText.text = DataManager.instance.settings.creditsText;
    }
}
