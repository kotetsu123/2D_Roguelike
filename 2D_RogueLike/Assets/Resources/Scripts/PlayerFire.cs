using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject syurikenPrefab;
    [SerializeField] private float FireRate = 1f;
    [SerializeField] private Transform firePos;

    private EnemyScaner scaner;
    private float _timer;

    private void Start()
    {
        scaner = GetComponent<EnemyScaner>();
        if (scaner == null) Debug.Log("none");

        if (firePos == null)
            firePos = transform;
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > FireRate)
        {
             FireSyuRiKen();
           // Syuriken();
            _timer = 0;
           
        }
    }

    private void FireSyuRiKen()
    {
        Transform Enemy = scaner.GetNearestEnemy();

        //if (Enemy == null) return;
        Vector2 direction = (Enemy.position - firePos.position).normalized;

        GameObject Syuriken = Instantiate(syurikenPrefab, firePos.position, Quaternion.identity);

        Syuriken.GetComponent<SyuRiKen>().initialize(direction);
    }

    private void Syuriken()
    {
        Instantiate(syurikenPrefab, firePos.position, Quaternion.identity);
    }
}
