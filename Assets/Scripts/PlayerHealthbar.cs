using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
      public Image bar;
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {

      }
      public void SetAmount(float amount)
      {
            bar.fillAmount = amount;

      }
}
