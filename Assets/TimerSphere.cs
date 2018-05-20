using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSphere : MonoBehaviour {
    public float blinkTime = 0.4F;
    public Color blinkColor = Color.green;

    private float _progress = 0F;
    private Material _progressMat = null;
    private Texture2D _text;
    private float _blink = -1F;
    private Color _lastColor;
    public void StartBlink() {
        if (_blink < 0F)
        {
            _blink = 0F;
            _lastColor = blinkColor;
        }
    }
    public void StopBlink() {
        if(_blink >= 0F)
        {
            _blink = -1F;
            if(_lastColor != blinkColor)
            {
                _progressMat.color = _lastColor;
                _lastColor = blinkColor;
            }
        }
    }
    public void SetProgress(float progress) {
        if (progress > 1F || progress < 0F)
        {
            Debug.LogError("invalid progress");
            return;
        }
        if (_progress == progress)
            return;
        _blink = -1F;
        if (_lastColor != blinkColor) {
            _progressMat.color = _lastColor;
            _lastColor = blinkColor;
        }
        _progress = progress;
        float f = _progress * 20;
        int i = 0;
        for (; i < f; ++i)
            _text.SetPixel(1, i, Color.white);
        Debug.Log("i = " + i.ToString());
        for (; i < 20; ++i)
            _text.SetPixel(1, i, Color.black);
        _text.Apply();
        _progressMat.mainTexture = _text;
    }
	// Use this for initialization
	void Start () {
        _lastColor = blinkColor;
        _progressMat = GetComponent<MeshRenderer>().material;
        _text = new Texture2D(1, 20, TextureFormat.ARGB32, false);
        for (int i = 0; i < 20; ++i) {
            _text.SetPixel(1, i, Color.white);
        }
        SetProgress(1F);
	}
	
	// Update is called once per frame
	void Update () {
		if(_blink >= 0F) {
            _blink += Time.deltaTime;
            if (_blink > blinkTime)
            {
                _blink -= blinkTime;
                Color c = _lastColor;
                _lastColor = _progressMat.color;
                _progressMat.color = c;
            }
        }
	}
}
