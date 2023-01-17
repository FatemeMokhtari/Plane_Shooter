using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

      public GameObject[] Enemy;
      public float reSpawnTime = 5f;
      // Start is called before the first frame update
      void Start()
      {
            StartCoroutine(EnemySpawner());
      }

      // Update is called once per frame
      void Update()
      {

      }

      IEnumerator EnemySpawner()
      {
            while (true)
            {
                  yield return new UnityEngine.WaitForSeconds(reSpawnTime);
                  SpawnEnemy();
            }

      }
      void SpawnEnemy()
      {
            int RandValue = UnityEngine.Random.Range(0, Enemy.Length);
            int RandPosValue = UnityEngine.Random.Range(2, -2);
            Instantiate(Enemy[RandValue], new UnityEngine.Vector2(RandPosValue, transform.position.y), UnityEngine.Quaternion.identity);


      }
}
