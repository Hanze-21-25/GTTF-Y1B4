using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpeedManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
        
        //Delay before the window appearing
        private float timeToWait = 0.7f;
        public void OnPointerEnter(PointerEventData eventData)
        {
            StopAllCoroutines();
            StartCoroutine(StartTimer());

        }

        public void OnPointerExit(PointerEventData eventData)
        {
            
           Time.timeScale = 1f;

        }

        private void SpeedUp()
        {
            
            Time.timeScale = 2f;
        }

        private IEnumerator StartTimer()
        {
            yield return new WaitForSeconds(timeToWait);
            SpeedUp();
        }

    }


  
