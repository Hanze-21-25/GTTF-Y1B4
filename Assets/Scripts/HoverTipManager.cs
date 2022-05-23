using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HoverTipManager : MonoBehaviour
{
    public TextMeshProUGUI tipText;
    public RectTransform tipWindow;

    public static Action<string, Vector2> OnMouseHover;
    public static Action OnMouseLoseFocus;


    //OnEnable|OnDisable is a structure of the tip windows being active or not active
    private void OnEnable()
    {
        OnMouseHover += ShowTip;
        OnMouseLoseFocus += HideTip;

    }

    private void OnDisable()
    {
        OnMouseHover -= ShowTip;
        OnMouseLoseFocus -= HideTip;
    }


    void Start()
    {
        //Tip window is ramains hidden in the begining
        HideTip();
    }

    //String tip is created to include the tip into
    private void ShowTip(string tip, Vector2 mousePos)
    {
        tipText.text = tip;
        //The preferred size of the window appearing
        tipWindow.sizeDelta = new Vector2(tipText.preferredWidth > 200 ? 200 : tipText.preferredWidth, tipText.preferredHeight);

        tipWindow.gameObject.SetActive(true);
        
        //This part is removed so tip would always appear in the same spot instead of appearing at the mouse position
        //transform.position = new Vector2(mousePos.x, mousePos.y);
    }

    //Hides the tip window (in the start and when its not active)
    private void HideTip()
    {
        tipText.text = default;
        tipWindow.gameObject.SetActive(false);
    }


}
