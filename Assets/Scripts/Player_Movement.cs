using System.Diagnostics;
using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 10f;
    public float minX;
    public float minY;
    // 1.37 & -1.37
    public float maxX;
    public float maxY;
    void Start()
    {
        
    }

    
    void Update()
    {        
        
        float deltaY = Input.GetAxis("Vertical")* Time.deltaTime * speed;
        float deltaX = Input.GetAxis("Horizontal")* Time.deltaTime * speed;

        float newXpos =Mathf.Clamp(transform.position.x + deltaX,minX,maxX);
        float newYpos = Mathf.Clamp(transform.position.y + deltaY,minY,maxY);
        transform.position = new UnityEngine.Vector2(newXpos, newYpos);  
    }

     
}
