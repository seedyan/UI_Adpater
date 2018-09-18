using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBubble : MonoBehaviour {
    public Text _content;

    public RectTransform _backGround;

    private RectTransform _contentRect;
	// Use this for initialization

   // private float _oneLineContentHeigh = 0f;
    private float _oneLineContentWidth = 0f;
    private float _bgVerticalValue = 20f;
    private float _bgHorizontalValue = 20f;
    void Awake()
    {
        _content.text = "";
        //_oneLineContentHeigh = _content.preferredHeight;
        _contentRect = _content.GetComponent<RectTransform>();
        _oneLineContentWidth = _contentRect.rect.width;
    }
    void Start()
    {
        SetContent("dsd");
        AdaptBgByContent();
    }

    public void SetStatus(bool active)
    {
        this.gameObject.SetActive(active);
    }


    public void SetContent(string content)
    {
        _content.text = content;
    }

    void AdaptBgByContent()
    {
        float curOneLineWidth = _oneLineContentWidth > _content.preferredWidth ? _content.preferredWidth : _oneLineContentWidth;
        _backGround.sizeDelta = new Vector2(_bgHorizontalValue + curOneLineWidth, _bgVerticalValue + _content.preferredHeight);
    }
}
