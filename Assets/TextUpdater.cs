using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUpdater : MonoBehaviour
{
    private void Start()
    {
        ApplySettingsToSelf();
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        if (DataManager.instance == null)
        {
            return;
        };

        ApplySettingsToSelf();
    }
#endif

    void ApplySettingsToSelf()
    {
        var tmpText = GetComponent<TextMeshProUGUI>();
        tmpText.text = DataManager.instance.settings.creditsText;
    }
}
