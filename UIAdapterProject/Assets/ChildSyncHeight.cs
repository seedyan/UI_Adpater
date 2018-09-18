using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ChildSyncHeight : MonoBehaviour {
    public float Offect;

    protected RectTransform _rectTransform;

    protected RectTransform RectTransform
    {
        get { return _rectTransform ?? (_rectTransform = GetComponent<RectTransform>()); }
    }

    private int preChildCount = 0;




    void Update()
    {
        if (preChildCount != transform.childCount)
        {
            SetDirty();
            preChildCount = transform.childCount;
        }
    }

    void SetDirty()
    {
        if (this.gameObject.activeSelf)
            LayoutRebuilder.MarkLayoutForRebuild(this.RectTransform);
    }
	// Use this for initialization
	void Start () {
        SetDirty();
        Modify();
	}
	
	// Update is called once per frame


    void Modify()
    {
        float height = 0f;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).gameObject.activeSelf)
            {
                RectTransform rect = transform.GetChild(i).GetComponent<RectTransform>();
                float temp = rect.rect.height - rect.anchoredPosition.y;
                if (temp > height)
                {
                    height = temp;
                }
            }
        }

        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height + Offect);
    }
}
