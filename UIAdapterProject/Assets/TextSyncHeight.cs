using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class TextSyncHeight : MonoBehaviour {

    public float Offset;
    private RectTransform _rect;
    private Text _text;
    void Awake()
    {
        _text = this.transform.GetComponent<Text>();
        _rect = this.transform.GetComponent<RectTransform>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isPlaying)
            return;
        Modify();
    }

    void Modify()
    {
        if (_rect == null || _text == null) Awake();
            _rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _text.preferredHeight + Offset);
    }
}
