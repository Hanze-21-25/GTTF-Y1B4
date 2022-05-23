using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Hover tip is the info that appears when mouse is hovered above the info button next to the animal in the shop
public class HoverTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string tipToShow;
    //Delay before the window appearing
    private float timeToWait = 0.4f;
    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(StartTimer());
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        HoverTipManager.OnMouseLoseFocus();
        Time.timeScale = 1f;

    }

    private void ShowMessage()
    {
        //Reference to the HoverTipManger to display the message
        HoverTipManager.OnMouseHover(tipToShow, Input.mousePosition);
        Time.timeScale = 0f;
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(timeToWait);
        ShowMessage();
    }

}
