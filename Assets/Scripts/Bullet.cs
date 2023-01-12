using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(UnityEngine.Vector2.up * speed * Time.deltaTime);
    }
}
