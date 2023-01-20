using System.Net.Mime;
using System.Diagnostics;
using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
      public float speed = 10f;
      public float minX;
      public float minY;
      // 1.37 & -1.37
      public float maxX;
      public float maxY;

      public GameObject Explotion;
      public GameObject damageEffect;

      public PlayerHealthbar playerHealthbar;

      public CoinCount CoinCountScript;
      public float health = 20f;
      float BarFillAmount = 1f;
      float damage = 0;

      public AudioSource audioSource;
      public AudioClip damageSound;
      public AudioClip ExplosionSound;
      public AudioClip CoinSound;


      public GameObject PauseMenu;
      public GameObject PauseButton;      
      public GameObject GameOverPanel;
      
      public LevelLoader LevelLoader;
      void Start()
      {
            damage = BarFillAmount / health;
            PauseMenu.SetActive(false);
            PauseButton.SetActive(true);
            GameOverPanel.SetActive(false);
      }
      void Update()
      {
            float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

            float newXpos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
            float newYpos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);
            transform.position = new UnityEngine.Vector2(newXpos, newYpos);

            if (Input.GetButtonDown("Fire1"))
            {
                  pauseGame();
            }
            if (Input.GetButtonDown("Fire2"))
            {
                  ResumeGame();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                  Application.Quit();
            }




      }

      public void Reload()
      {
            SceneManager.LoadScene("Level1");
      }
      void pauseGame()
      {            
            PauseMenu.SetActive(true);            
            PauseButton.SetActive(false);
            Time.timeScale = 0f;
            
            
      }
      void ResumeGame()
      {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            PauseButton.SetActive(true);
      }
      void GameOver()
      {
            GameOverPanel.SetActive(true);
            PauseButton.SetActive(false);
      }
      private void OnTriggerEnter2D(Collider2D other)
      {
            if (other.gameObject.tag == "EnemyBullet")
            {
                  audioSource.PlayOneShot(damageSound, 0.5f);
                  DamagePlayerHealthbar();
                  Destroy(other.gameObject);
                  GameObject damageVfx = Instantiate(damageEffect, other.transform.position, UnityEngine.Quaternion.identity);
                  Destroy(damageVfx, 0.05f);
                  if (health <= 0)
                  {
                        GameOver();
                        Time.timeScale = 0f;
                        Invoke("Reload", 2f);
                        AudioSource.PlayClipAtPoint(ExplosionSound, Camera.main.transform.position, 0.5f);
                        audioSource.Stop();
                        Destroy(gameObject);
                        GameObject blast = Instantiate(Explotion, transform.position, UnityEngine.Quaternion.identity);
                        Destroy(blast, 2f);
                        
                  }
            }

            if (other.gameObject.tag == "Coin")
            {
                  audioSource.PlayOneShot(CoinSound, 0.5f);
                  Destroy(other.gameObject);
                  CoinCountScript.AddCount();
            }
      }

      void DamagePlayerHealthbar()
      {
            if (health > 0)
            {
                  health -= 1;
                  BarFillAmount = BarFillAmount - damage;
                  playerHealthbar.SetAmount(BarFillAmount);
            }
      }


      IEnumerator LoadScene()
      {
            while (true)
            {
                  yield return new UnityEngine.WaitForSeconds(2f);
                  SceneManager.LoadScene("Level1");
            }

      }
}
