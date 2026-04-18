using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    public float maxHp = 2f;
    public float currentHp;
    public int damageAmount = 1;
    public int scoreValue = 100;

    private bool IsDead = false;
    [SerializeField] private Transform _target;
    [SerializeField] private Rigidbody2D enemyRb;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public PlayerController playerController;

    void Start()
    {
        currentHp = maxHp;
        enemyRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
      
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        if (player != null) {
            _target = player.transform;
          
        }
        else
        {
            Debug.LogWarning($"NullRefurrence!!");
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (playerController.IsDead) return;
        if (IsDead || _target==null) return;

        Vector2 direction = (_target.position - transform.position).normalized;

        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
        // spriteRenderer.flipX=direction.x > 0;
        enemyRb.MovePosition(enemyRb.position + direction * moveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            player.GetComponent<PlayerController>().TakeDamage(damageAmount);

            Die();
        }
    }
    public void TakeDamage(int DMGAmount)
    {
        currentHp -= DMGAmount;
        
        if (currentHp <= 0)
        {
            currentHp = 0;
            IsDead = true;
            Die();
        }
        else
        {
            Debug.Log($"[MonsterTakeDamege] get hitted");
            StartCoroutine(HitEffect());
        }
    }
    private IEnumerator HitEffect()
    {
        spriteRenderer .color= Color.red;
        yield return new  WaitForSeconds(2.0f);
        spriteRenderer.color = Color.white;
        
    }
    private void Die()
    {
        IsDead = true;
        
        gameObject.SetActive(false);
      
    }
    
}
