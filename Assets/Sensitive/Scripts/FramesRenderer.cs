using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FramesRenderer : MonoBehaviour
{
    [SerializeField] private string _framesPath;
    [HideInInspector] private float _framesSpeed = 1;

    SpriteRenderer _spriteRend = null;
    Sprite[] _frames;
    [HideInInspector] int _currentFrame = 0;

    string _fallbackPath = null;
    float _fallbackInterval = 1;

    public void SetAnimTo(string newPath, float newSpeed)
    {
        CancelInvoke();

        _framesPath = newPath;
        _framesSpeed = newSpeed;

        InitializeAnim();
    }

    public void SetNextAnim(string newFallbackPath, float newSpeed)
    {
        _fallbackPath = newFallbackPath;
        _fallbackInterval = newSpeed;
    }

    void OnEnable()
    {
        _spriteRend = GetComponent<SpriteRenderer>();
        
        InitializeAnim();
    }

    void InitializeAnim()
    {
        LoadSpriteFrames();

        StopAllCoroutines();
        if (Application.isPlaying)
        {
            StartCoroutine(AnimationUpdate());
        }
            //InvokeRepeating(nameof(AnimateSprite), 0, 0.3f / _framesSpeed);
    }

    private IEnumerator AnimationUpdate()
    {
        while (true)
        {
            NextFrame();
            yield return new WaitForSeconds(0.3f / _framesSpeed);
        }
    }

    private void NextFrame()
    {
        _spriteRend.sprite = _frames[_currentFrame];
        _currentFrame++;

        if (_currentFrame >= _frames.Length)
        {
            _currentFrame = 0;
            if (_fallbackPath != null)
            {
                SetAnimTo(_fallbackPath, _fallbackInterval);
                SetNextAnim(null, 0);
            }
        }
    }

    public void LoadSpriteFrames()
    {
        var objects = Resources.LoadAll(_framesPath, typeof(Sprite));

        _frames = new Sprite[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            _frames[i] = (Sprite)objects[i];
        }

        _currentFrame = 0;
        _spriteRend.sprite = _frames[0];
    }

    enum SpriteThing
    {
        Player,
        Floor,
        Background,
        PipeTop,
        PipeBottom
    }
}
