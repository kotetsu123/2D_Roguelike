using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScaner : MonoBehaviour
{
    public float scanDistance = 10f;
    public LayerMask EnemyLayer;

    Collider2D[] _hitResults=new Collider2D[0];

    public Transform GetNearestEnemy()
    {
        int hitCount = Physics2D.OverlapCircleNonAlloc(transform.position,scanDistance,_hitResults,EnemyLayer);
       
        if(hitCount<=0)
            return null;
        Transform nearest = _hitResults[0].transform;
        float minDistance = Vector2.Distance(transform.position, nearest.position);
        for(int i = 0; i < hitCount; i++)
        {
            Transform enemy= _hitResults[i].transform; 
            float distance=Vector2.Distance(enemy.position, transform.position);
            if (distance < minDistance)
            {
                nearest = enemy;
                minDistance = distance;
                
            }
        }
        return nearest;
    }
    
}
