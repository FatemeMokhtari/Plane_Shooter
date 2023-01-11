using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float deltaY = Input.GetAxis("Vertical");
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        //float newYpos = transform.position.y + deltaY;
        float newXpos = transform.position.x + deltaX;

        transform.position = new UnityEngine.Vector2(newXpos, transform.position.y);
        /* Input.GetAxis("Horizontal");
        Movment();
        Clamp(); */
    }

    /* void Movment() {
        if (Input.GetKey(KeyCode.RightArrow) || Input.KeyCode.D) {
            transform.position += new Vector3(speed * Time.deltaTime ,0,0);
        }

         if (Input.GetKey(KeyCode.LeftArrow) || Input.KeyCode.A) {
            transform.position -= new Vector3(speed * Time.deltaTime ,0,0);
        }

        if (transform.rotation.z != 90) {
             transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,90), rotationSpeed * Time.deltaTime);
        }
    }

    void Clamp() {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x,minX, maxX);
        transform.position = pos;
    } */
}
