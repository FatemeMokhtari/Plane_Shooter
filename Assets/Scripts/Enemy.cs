using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
      public GameObject CoinPrefab;
      public GameObject EnemyBullet;
      public GameObject EnemyExplosionPrefab;
      public Transform[] GunPoint;
      public float EnemyBulletTime = 0.5f;
      public float speed = 1f;
      public GameObject damageEffect;

      public Healthbar healthbar;
      public float health = 20f;
      float barSize = 1f;
      float damage = 0;

      public AudioSource audioSource;
      public AudioClip BulletSound;
      public AudioClip damageSound;
      public AudioClip ExplosionSound;
      
      void Start()
      {
            StartCoroutine(Enemyshooting());
            damage = barSize / health;
      }
      void Update()
      {
            transform.Translate(UnityEngine.Vector2.down * speed * Time.deltaTime);
      }
      void DamageHealthbar()
      {
            if (health > 0)
            {
                  health -= 1;
                  barSize = barSize - damage;
                  healthbar.SetSize(barSize);
            }
      }
      private void OnTriggerEnter2D(Collider2D other)
      {
            if (other.tag == "PlayerBullet")
            {
                  audioSource.PlayOneShot(damageSound);
                  DamageHealthbar();
                  Destroy(other.gameObject);
                  GameObject damageVfx = Instantiate(damageEffect, other.transform.position, UnityEngine.Quaternion.identity);
                  Destroy(damageVfx, 0.05f);

                  if (health <= 0)
                  {
                        AudioSource.PlayClipAtPoint(ExplosionSound,Camera.main.transform.position,0.5f);
                        Instantiate(CoinPrefab, transform.position, UnityEngine.Quaternion.identity);
                        Destroy(gameObject);
                        GameObject EnemyExplosion = Instantiate(EnemyExplosionPrefab, transform.position, UnityEngine.Quaternion.identity);
                        Destroy(EnemyExplosion, 0.4f);
                  }

            }
      }
      void EnemyFire()
      {
            for (int i = 0; i < GunPoint.Length; i++)
            {
                  Instantiate(EnemyBullet, GunPoint[i].position, UnityEngine.Quaternion.identity);
            }
            //Instantiate(EnemyBullet, GunPointer1.position, UnityEngine.Quaternion.identity);
            //Instantiate(EnemyBullet, GunPointer2.position, UnityEngine.Quaternion.identity);
      }

      IEnumerator Enemyshooting()
      {
            while (true)
            {
                  yield return new WaitForSeconds(EnemyBulletTime);
                  EnemyFire();
                  audioSource.PlayOneShot(BulletSound, 0.5f);
            }

      }
}
