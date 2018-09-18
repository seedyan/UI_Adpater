using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class TextSyncWidth : MonoBehaviour {
    public float MaxWidth;
    public float Offset;
    private RectTransform _rect;
    private Text _text;
    void Awake()
    {
        _text = this.transform.GetComponent<Text>();
        _rect = this.transform.GetComponent<RectTransform>();
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Application.isPlaying)
            return;
        Modify();
	}

    void Modify()
    {
        if (_rect == null || _text == null) Awake();
        if (_text.preferredWidth > MaxWidth)
        {
            _rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, MaxWidth);
        }
        else
        {
            _rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _text.preferredWidth + Offset);
        }
    }
}
