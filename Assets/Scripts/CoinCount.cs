using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
      public Text CoinCountText;
      int Count = 0;
      // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {
            CoinCountText.text = Count.ToString();
      }

      public void AddCount()
      {
            Count++;
      }
}
