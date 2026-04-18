using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyuRiKen : MonoBehaviour
{
    public float speed = 10;
    public int damage = 1;

    private float lifeTIme = 3f;
    private Vector2 _dirrection;
    private float _timer=0;
    private float _rotateSpeed=720f;

    public void initialize(Vector2 direction)
    {
        _dirrection = direction.normalized;
       
    }
    private void Update()
    {
        transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime);

        transform.Translate(_dirrection * speed * Time.deltaTime);
        _timer += Time.deltaTime;
        if (_timer >= lifeTIme) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision != null)
            {
                collision.GetComponent<EnemyController>().TakeDamage(damage);
                Destroy(gameObject);
            }
            
        }
    }
}
