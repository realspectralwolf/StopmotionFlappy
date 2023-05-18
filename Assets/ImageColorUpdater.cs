using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageColorUpdater : MonoBehaviour
{
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
        Color newCol = DataManager.instance.settings.fontColor;
        newCol.a = opacity;
        GetComponent<Image>().color = newCol;
    }
}
