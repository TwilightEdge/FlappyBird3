using System;
using UnityEngine;

public class enemyCat : MonoBehaviour
{
    public int HP;
    
    public GameObject cat;
    
    public cat classcat;

    public float timeSinceLastAttack;
    
    public float timeSinceLastDash;
    
    public float dashCD;
    
    public float attackCD;

    public int damage;
    
    private Rigidbody2D enemyRigidbody;

    public float enemySpeed;

    public float enemyDashForce;

    public bool isDashing;

    public float endOfDash;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cat = GameObject.FindWithTag("Player");
        classcat = cat.GetComponent<cat>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
        timePass();
        
        CheckDash();
        
        if(!isDashing) FollowPlayer();
        
    }

    
    private void OnCollisionStay2D(Collision2D collision) // enemy dealing damage
    {
        
        if (collision.gameObject.CompareTag("Player") && timeSinceLastAttack >= attackCD)
        {
            timeSinceLastAttack = 0;
            classcat.takeDamage(damage);
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other) // enemy taking damage
    {
        
        if (other.CompareTag("playerAttack"))
        {
            HP -= classcat.damage;
            
            isDashing = true;
            Vector2 knockbackDirection = transform.position - other.transform.position;
            enemyRigidbody.AddForce(knockbackDirection.normalized * classcat.knockbackPower, ForceMode2D.Impulse);
            
            CheckHP();
            
        }
        
    }

    void CheckHP()
    {
        if (HP <= 0)
        {
            Destroy(gameObject); // or whatever on enemy death
        }
    }
    
    void timePass()
    {
        timeSinceLastAttack += Time.deltaTime;
        
        timeSinceLastDash +=  Time.deltaTime;
        
    }

    void FollowPlayer()
    {
        
        Vector2 directionToPlayer = cat.transform.position - transform.position;

        enemyRigidbody.linearVelocity = directionToPlayer.normalized * enemySpeed;

    }

    void Dash()
    {
        isDashing = true;
        
        Vector2 directionToPlayer = cat.transform.position - transform.position;
        
        enemyRigidbody.AddForce(directionToPlayer.normalized * enemyDashForce, ForceMode2D.Impulse);
        
        
        
    }

    void CheckDash() //can dash and end of dash
    {
        if (Mathf.Abs(enemyRigidbody.linearVelocity.x) <= endOfDash && Mathf.Abs(enemyRigidbody.linearVelocity.y) <= endOfDash)
        {
            isDashing = false;
        }
        
        if(timeSinceLastDash>=dashCD)
        {
            timeSinceLastDash = 0;
            Dash();
        }
    }
    
}
