using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
      public GameObject EnemyBullet;
      public GameObject EnemyExplosionPrefab;
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
      private void OnTriggerEnter2D(Collider2D other)
      {
            if (other.tag == "PlayerBullet")
            {
                  Destroy(gameObject);
                  GameObject EnemyExplosion = Instantiate(EnemyExplosionPrefab, transform.position, UnityEngine.Quaternion.identity);
                  Destroy(EnemyExplosion,0.4f);
            }
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
