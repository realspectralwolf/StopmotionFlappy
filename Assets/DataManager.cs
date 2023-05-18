using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class DataManager : MonoBehaviour
{
    [SerializeField] public GameSettings settings;
    [SerializeField] private TMP_FontAsset[] fonts;

    public static DataManager instance;

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        instance = this;
    }
#endif

    public TMP_FontAsset GetSelectedFont()
    {
        return fonts[(int)settings.font];
    }
}
