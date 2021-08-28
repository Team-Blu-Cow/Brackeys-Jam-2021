using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private AnimationCurve HealthScale;
    [SerializeField] private AnimationCurve DamageScale;
    [SerializeField] private AnimationCurve SpawnTimeScale;
    [SerializeField] private AnimationCurve SpawnAmountScale;

    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private float spawnDistance;

    [SerializeField] public int waveNo;

    [SerializeField] private Transform _player;

    private int amountSpawned = 0;

    private GameObject[] enemies;

    [SerializeField] private bool showGizmo;

    // Start is called before the first frame update
    private void Start()
    {
        enemies = Resources.LoadAll<GameObject>("prefabs/enemies");

        SpawnNewWave();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void SpawnNewWave()
    {
        amountSpawned = 0;

        StartCoroutine(SpawnEnemies(SpawnTimeScale.Evaluate(waveNo), (int)SpawnAmountScale.Evaluate(waveNo)));

        waveNo++;
    }

    private IEnumerator SpawnEnemies(float SpawnInterval, int spawnAmount)
    {
        while (amountSpawned <= spawnAmount)
        {
            amountSpawned++;
            _player.GetComponent<PlayerController>()._enemiesRemaining++;

            Vector3 spawnPos;
            int K = 0;
            do
            {
                spawnPos = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
                K++;
            } while (Vector3.Distance(spawnPos, _player.position) < spawnDistance || K < 10);

            GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
            BaseEnemy enemyBase = enemy.GetComponent<BaseEnemy>();
            enemyBase.Health = (int)HealthScale.Evaluate(waveNo);
            enemyBase._player = _player;

            yield return new WaitForSeconds(SpawnInterval);
        }
    }

    private void OnDrawGizmos()
    {
        if (showGizmo)
        {
            foreach (Transform transform in spawnPoints)
            {
                Gizmos.DrawWireSphere(transform.position, spawnDistance);
            }
        }
    }
}