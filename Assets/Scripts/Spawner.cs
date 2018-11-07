namespace Assets.Scripts
{
    using System.Collections;

    using UnityEngine;

    public class Spawner : MonoBehaviour
    {
        public Transform enemyOrefab;

        public Transform spawnPoint;

        public float timeBetweerWaves = 2f;

        private float countdown = 3f;

        private int waveIndex = 0;

        public void Update()
        {
            if (this.countdown <= 0f)
            {
                this.StartCoroutine(this.SpawnWaves());
                this.countdown = this.timeBetweerWaves;
            }
            this.countdown -= Time.deltaTime;
        }

        public IEnumerator SpawnWaves()
        {
            this.waveIndex++;
            for (var i = 0; i < 10; i++)
            {
                i = Random.Range(1, 10);
            }
            this.SpawnEnemy();
            yield return new WaitForSeconds(0.3f);
        }

        public void SpawnEnemy()
        {
            Instantiate(this.enemyOrefab, this.spawnPoint.position, this.spawnPoint.rotation);
        }


    }
}
