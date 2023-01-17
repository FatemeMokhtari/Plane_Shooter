using System.IO;
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
      public float BulletSpawnTime = 1f;
      void Start()
      {
            StartCoroutine(shoot());
      }

      void Update()
      {
      }
      void Fire()
      {
            Instantiate(PlayerBullet, SpawnPointer1.position, UnityEngine.Quaternion.identity);
            Instantiate(PlayerBullet, SpawnPointer2.position, UnityEngine.Quaternion.identity);
      }

      IEnumerator shoot()
      {
            while (true)
            {
                  yield return new WaitForSeconds(BulletSpawnTime);
                  Fire();
                  //StartCoroutine(shoot());                  
            }

      }
}