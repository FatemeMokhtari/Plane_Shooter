using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject PlayerBullet;
    public Transform SpawnPointer1;
    public Transform SpawnPointer2;
    void Start()
    {
        
    }
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
           Instantiate(PlayerBullet, SpawnPointer1.position, UnityEngine.Quaternion.identity);
           Instantiate(PlayerBullet, SpawnPointer2.position, UnityEngine.Quaternion.identity);
        }
    }
}
