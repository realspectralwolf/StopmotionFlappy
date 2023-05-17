using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FramesRenderer : MonoBehaviour
{
    [SerializeField] public string _framesPath;
    [SerializeField] public float _framesInterval;

    SpriteRenderer _spriteRend;
    Sprite[] _frames;
    int _currentFrame = 0;


    // Start is called before the first frame update
    void Start()
    {
        LoadSpriteFrames();

        if (Application.isPlaying)
            InvokeRepeating(nameof(AnimateSprite), 0, _framesInterval);
    }

    private void AnimateSprite()
    {
        _spriteRend.sprite = _frames[_currentFrame];
        _currentFrame++;
        _currentFrame = (_currentFrame >= _frames.Length) ? 0 : _currentFrame;
    }

    public void LoadSpriteFrames()
    {
        _spriteRend = GetComponent<SpriteRenderer>();

        var objects = Resources.LoadAll(_framesPath, typeof(Sprite));

        _frames = new Sprite[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            _frames[i] = (Sprite)objects[i];
        }

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
