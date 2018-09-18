using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChildSyncWidth : MonoBehaviour {

    public float Offset;

    private RectTransform rect;

    List<RectTransform> childList = new List<RectTransform>();
	// Use this for initialization
	void Start () {
        rect = GetComponent<RectTransform>();
        for (int i = 0; i < rect.childCount; i++)
        {
            childList.Add(rect.GetChild(i).GetComponent<RectTransform>());
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Application.isPlaying) return;
        Modify();
	}

    void Modify()
    {
        float width = 0;
        for (int i = 0; i < childList.Count; i++)
        {
            float temp;
            //右上
            temp = childList[i].rect.width - childList[i].anchoredPosition.x;

            //左上
            temp = childList[i].rect.width + childList[i].anchoredPosition.x;

            if (temp > width)
                width = temp;
        }

        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Offset + width);
    }
}
