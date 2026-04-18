using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrfab;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnTIme = 3.0f;
    [SerializeField] private float spawnDistance=10f;

    private float _timer = 0f;

    public PlayerController playerController;

    private void Start()
    {
        playerController =player.GetComponent<PlayerController>();
    }
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= spawnTIme)
        {
            _timer = 0f;
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        if (playerController.IsDead) return;

        float randomAngle = Random.Range(0f, 360f);
        float radians = randomAngle * Mathf.Deg2Rad;
        float x = Mathf.Cos(radians) * spawnDistance;
        float y = Mathf.Sin(radians) * spawnDistance;

        Vector3 spawnPos = player.position + new Vector3(x, y, 0);
        GameObject monster = Instantiate(monsterPrfab);
        monster.transform.position = spawnPos;


    }
}
