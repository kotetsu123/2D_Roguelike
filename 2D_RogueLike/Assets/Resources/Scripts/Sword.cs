using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private int damage = 1;
    private float DMGCoolTIme=1f;

    List<Collider2D> hitMonster=new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Called");
        if (collision.CompareTag("Enemy"))
        {
            if (!hitMonster.Contains(collision))
            {
              
               EnemyController monster=collision.GetComponent<EnemyController>();
                hitMonster.Add(collision);
                if (monster != null) {
                    monster.TakeDamage(damage);
                }
                StartCoroutine(RemoveFromList(collision, DMGCoolTIme));
            }
        }
    }

    private IEnumerator RemoveFromList(Collider2D collision,float coolTIme)
    {
        coolTIme = DMGCoolTIme;
        yield return new WaitForSeconds(coolTIme);

        hitMonster.Remove(collision);
    }
}
