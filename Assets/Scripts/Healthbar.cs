using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
      public Transform bar;
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {

      }

      public void SetSize(float size)
      {
            bar.localScale = new UnityEngine.Vector2(size, 1f);
      }
}
