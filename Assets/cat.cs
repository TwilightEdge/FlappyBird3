using System;
using UnityEngine;

public class cat : MonoBehaviour
{
    
    public GameObject attack;
    private GameObject attackSpawn;
    
    Rigidbody2D rigidBodyReference;
    
    public float speed = 0.05f;
    public float dashForce = 1000f;

    private bool dashing;
    public float endOfDash = 1f;

    private float timeSinceLastDash = 5;
    private float timeSinceLastAttack = 5;
    public float dashTimer;
    public float attackTimer;
    
    private Vector2 movementInput;
    
    
    public int HP;
    
    public int maxHP;

    public int food;

    public int cuteness;
    
    public int passiveCuteness;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBodyReference = gameObject.GetComponent<Rigidbody2D>();

        food = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && timeSinceLastDash>dashTimer)
        {
            Dash();
        }
        
        if (Input.GetKeyDown(KeyCode.K) && timeSinceLastAttack>attackTimer)
        {

            Attack();

        }
        
        
        
        
    }
    
    void FixedUpdate()
    {
        timePass();
        checkDashing();
        
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            //Vector3 currentPosition = transform.position;
            //currentPosition.x += dashSpeed;
        
            //transform.position = currentPosition;
            
            
            //rigidBodyReference.AddForce(movementInput * dashForce, ForceMode2D.Impulse);
            rigidBodyReference.AddForce(new Vector2(1, 0) * dashForce, ForceMode2D.Impulse);
            
            //rigidBodyReference.linearVelocity = Vector3.zero;
            //rigidBodyReference.AddForce(Vector3.up * force);
            
            //transform.rotation = Quaternion.Euler(0, 0, 35f);
            //audioSource.PlayOneShot(jumpSound);
        }*/
        
        if (Input.GetKey(KeyCode.S) && !dashing)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.y -= speed;

            transform.position = currentPosition;
            
            movementInput= new Vector2(0, -1);
            
            //transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        
        if (Input.GetKey(KeyCode.W) && !dashing)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.y += speed;

            transform.position = currentPosition;
            
            movementInput= new Vector2(0, 1);
            
            //transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        
        if (Input.GetKey(KeyCode.D) && !dashing)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x += speed;
        
            transform.position = currentPosition;
            
            //rigidBodyReference.linearVelocity = Vector3.zero;
            //rigidBodyReference.AddForce(Vector3.up * force);
            
            movementInput= new Vector2(1, 0);
            
            transform.rotation = Quaternion.Euler(0, 180, 0);
            //audioSource.PlayOneShot(jumpSound);
        }

        if (Input.GetKey(KeyCode.A) && !dashing)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x -= speed;

            transform.position = currentPosition;
            
            movementInput= new Vector2(-1, 0);
            
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
            
            
        }
        
    }

    void checkDashing()
    {
        if (Mathf.Abs(rigidBodyReference.linearVelocity.x) <= endOfDash && Mathf.Abs(rigidBodyReference.linearVelocity.y) <= endOfDash)
        {
            dashing = false;
        }
    }

    void timePass()
    {
        timeSinceLastDash += Time.deltaTime;
        timeSinceLastAttack += Time.deltaTime;
    }

    void Attack()
    {
        timeSinceLastAttack = 0;    
        
        attackSpawn = Instantiate(attack);
    
        attackSpawn.transform.position = new Vector2(transform.position.x, transform.position.y)+movementInput;
        if (movementInput == new Vector2(1, 0))
        {
            attackSpawn.transform.rotation = Quaternion.Euler (0,0,0);
        }
        else if (movementInput == new Vector2(0, 1))
        {
            attackSpawn.transform.rotation = Quaternion.Euler (0,0,90);
        }
        else if (movementInput == new Vector2(0, -1))
        {
            attackSpawn.transform.rotation = Quaternion.Euler (0,0,-90);
        }
        Destroy(attackSpawn, 0.1f);
    
    }

    void Dash()
    {
        timeSinceLastDash = 0;
            
        rigidBodyReference.AddForce(movementInput * dashForce, ForceMode2D.Impulse);
        //rigidBodyReference.AddForce(Vector3.up * dashForce);
            
        dashing = true;
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // The core line you need:
        if (collision.gameObject.CompareTag("enemy"))
        {
            HP--;
            Debug.Log("HP: " + HP);
            CheckHP();
        }
    }
    */

    public void takeDamage(int damage)
    {
       HP -= damage; 
       
       Debug.Log("HP: " + HP);
       
       CheckHP();
    }

    void CheckHP()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void getFood(int gainedFood)
    {
        food = food + gainedFood;
    }

    public void cutenessReset()
    {
        cuteness = passiveCuteness;
    }

}