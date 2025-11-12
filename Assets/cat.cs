using System;
using UnityEngine;

public class cat : MonoBehaviour
{
    
    Rigidbody2D rigidBodyReference;
    
    public float speed = 0.05f;
    public float dashForce = 1000f;
    
    private Vector2 movementInput;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBodyReference = gameObject.GetComponent<Rigidbody2D>();
        //rigidBodyReference = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBodyReference.AddForce(movementInput * dashForce, ForceMode2D.Impulse);
            //rigidBodyReference.AddForce(Vector3.up * dashForce);
        }
    }
    
    void FixedUpdate()
    {
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
        
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 currentPosition = transform.position;
            currentPosition.y -= speed;

            transform.position = currentPosition;
            
            movementInput= new Vector2(0, -1);
            
            //transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 currentPosition = transform.position;
            currentPosition.y += speed;

            transform.position = currentPosition;
            
            movementInput= new Vector2(0, 1);
            
            //transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        
        if (Input.GetKey(KeyCode.D))
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

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x -= speed;

            transform.position = currentPosition;
            
            movementInput= new Vector2(-1, 0);
            
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
            
            
        }
        
    }
}