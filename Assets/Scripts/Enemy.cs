using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
      public GameObject EnemyBullet;
      public Transform GunPointer1;
      public Transform GunPointer2;
      public float EnemyBulletTime = 0.5f;
      public float speed = 1f;
      void Start()
      {
            StartCoroutine(Enemyshooting());
      }
      void Update()
      {
            transform.Translate(UnityEngine.Vector2.down * speed * Time.deltaTime);
      }
      void EnemyFire()
      {
            Instantiate(EnemyBullet, GunPointer1.position, UnityEngine.Quaternion.identity);
            Instantiate(EnemyBullet, GunPointer2.position, UnityEngine.Quaternion.identity);
      }

      IEnumerator Enemyshooting()
      {
            while (true)
            {
                  yield return new WaitForSeconds(EnemyBulletTime);
                  EnemyFire();                           
            }

      }
}
