using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickButton : MonoBehaviour, IPointerDownHandler
{
      public void OnPointerDown(PointerEventData eventData)
      {
            UnityEngine.Debug.Log("click");
      }

      void Update()
      {

            

      }
}
