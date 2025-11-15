using System;
using UnityEngine;

public class cat : MonoBehaviour
{
    
    public GameObject attack;
    public GameObject dash;
    
    private GameObject attackSpawn;
    
    private GameObject dashSpawn;
    
    Rigidbody2D rigidBodyReference;
    
    public float speed = 0.05f;
    public float dashForce = 1000f;

    private bool dashing;
    public float endOfDash = 1f;

    private float timeSinceLastDash = 5;
    private float timeSinceLastAttack = 5;
    public float dashTimer;
    public float attackTimer;
    
    private Vector2 movementInput = new Vector2(-1, 0);
    
    
    public int HP;
    
    public int maxHP;

    public int food;

    public int cuteness;
    
    public int passiveCuteness;

    public int damage;

    public float knockbackPower;
    
    //[SerializeField] private Animator animator;
    
    private Animator animator;

    public bool emoting;
    
    public GameObject clock;
    
    public clock classclock;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBodyReference = gameObject.GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
        
        //food = 0;
        
        clock = GameObject.FindWithTag("clock");
        
        classclock = clock.GetComponent<clock>();

        maxHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (!emoting)
        {

            if (Input.GetKeyDown(KeyCode.Space) && timeSinceLastDash > dashTimer)
            {
                Dash();
            }

            if (Input.GetKeyDown(KeyCode.K) && timeSinceLastAttack > attackTimer && classclock.isNight)
            {

                //Attack();
                animator.SetTrigger("attack");
                Invoke("Attack", 0.15f);

            }

        }


    }
    
    void FixedUpdate()
    {
        timePass();
        checkDashing();
        
        animator.SetBool("isRunning", false); // if no button is pressed it becomes false

        if (!emoting)
        {
            Movement();
        }


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
        //animator.SetBool("isRunning", false);
        
        //animator.SetBool("isAttacking", true);
        
        
        
        timeSinceLastAttack = 0;    
        
        attackSpawn = Instantiate(attack);
        
        attackSpawn.transform.SetParent(this.transform);
    
        //attackSpawn.transform.position = new Vector2(transform.position.x , transform.position.y)+(movementInput*0.8f);
        
        attackSpawn.transform.position = new Vector2(transform.position.x , transform.position.y)+(movementInput*1.5f);
        
        if (movementInput == new Vector2(1, 0))
        {
            attackSpawn.transform.position = new Vector2(transform.position.x , transform.position.y)+(movementInput*1.5f);
            attackSpawn.transform.rotation = Quaternion.Euler (0,180,0);
        }
        else if (movementInput == new Vector2(0, 1))
        {
            attackSpawn.transform.position = new Vector2(transform.position.x , transform.position.y)+(movementInput*2f);
            attackSpawn.transform.rotation = Quaternion.Euler (0,0,-90);
        }
        else if (movementInput == new Vector2(0, -1))
        {
            attackSpawn.transform.position = new Vector2(transform.position.x , transform.position.y)+(movementInput*1.5f);
            attackSpawn.transform.rotation = Quaternion.Euler (0,0,90);
        }
        Destroy(attackSpawn, 0.15f);
        
        
        
    }

    void Dash()
    {
        timeSinceLastDash = 0;
            
        rigidBodyReference.AddForce(movementInput * dashForce, ForceMode2D.Impulse);
        //rigidBodyReference.AddForce(Vector3.up * dashForce);
        
        dashSpawn = Instantiate(dash);
        
        dashSpawn.transform.position = new Vector2(transform.position.x, transform.position.y) - (movementInput * 1.5f); // position of dash

        
        // this is for the rotation
        if (movementInput == new Vector2(1, 0))
        {
            dashSpawn.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        if (movementInput == new Vector2(-1, 0))
        {
            dashSpawn.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        if (movementInput == new Vector2(0, 1))
        {
            dashSpawn.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else
        if (movementInput == new Vector2(0, -1))
        {
            dashSpawn.transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        dashing = true;
        
        Destroy(dashSpawn, 0.2f);
        
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

    public void catEyeAnimation()
    {
        emoting = true;
        
        animator.SetTrigger("catEye");
        
        //for 1 sec it does this and cant do anything else
        
        Invoke("StopEmoting", 1.2f);
        
    }

    void Movement()
    {
        
        if (Input.GetKey(KeyCode.S) && !dashing)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.y -= speed;

            transform.position = currentPosition;
            
            movementInput= new Vector2(0, -1);
            
            animator.SetBool("isRunning", true);
            
            //transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        
        if (Input.GetKey(KeyCode.W) && !dashing)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.y += speed;

            transform.position = currentPosition;
            
            movementInput= new Vector2(0, 1);
            
            animator.SetBool("isRunning", true);
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
            
            animator.SetBool("isRunning", true);
        }
        
        if (Input.GetKey(KeyCode.A) && !dashing)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x -= speed;

            transform.position = currentPosition;
            
            movementInput= new Vector2(-1, 0);
            
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
            animator.SetBool("isRunning", true);
            
        }
        
    }

    public void StopEmoting()
    {
        emoting = false;
    }
    
    
    /*
    public void PowerUpDamageUp()
    {
        damage++;
    }
    */

}