using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private float speed = 3f;
    private Vector2 moveDerection;
    public  int maxHealth = 5;
    public int currentHealth;

    private Rigidbody2D rd;
    private SpriteRenderer _sprite;
    private Animator playerAni;
    

    private bool IsWalk;
    private bool isDead=false;

    // Start is called before the first frame update
    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        playerAni = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == true)
            return;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveDerection= new Vector2(h, v).normalized;

        if (moveDerection.magnitude > 0)
        {
            IsWalk = true;
            playerAni.SetBool("IsWalk", true);           
        }

        else
        {
            IsWalk = false;
            playerAni.SetBool("IsWalk", false);
        }
        if (h != 0)
        {
            if (h < 0)
            {
                _sprite.flipX = true;
            }
            else if (h > 0)
            {
                _sprite.flipX = false;
            }

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Die();
        }

    }
    private void Die()
    {
        isDead = true;
        playerAni.SetTrigger("IsDeath");
        GetComponent<Collider2D>().enabled=false;
    }
    public void HideAfterAnim()
    {
        gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        //rd.AddForce(moveDerection *speed*Time.deltaTime);
        if (isDead) return;
        rd.MovePosition(rd.position+moveDerection * speed * Time.deltaTime);
    }
    public void TakeDamage(int DMGAmount)
    {
        currentHealth -= DMGAmount;
        Debug.Log($"[DMG] current Player Hp is{currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(HitEffect());
        }
    }
    private IEnumerator HitEffect()
    {
        _sprite.color = Color.red;

        yield return new WaitForSeconds(0.2f);

        _sprite.color = Color.white;

    }
}
