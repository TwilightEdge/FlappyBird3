using System;
using UnityEngine;

public class cat : MonoBehaviour
{
    
    Rigidbody2D rigidBodyReference;
    
    float speed = 0.1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBodyReference = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x += speed;
        
            transform.position = currentPosition;
            
            //rigidBodyReference.linearVelocity = Vector3.zero;
            //rigidBodyReference.AddForce(Vector3.up * force);
            
            //transform.rotation = Quaternion.Euler(0, 0, 35f);
            //audioSource.PlayOneShot(jumpSound);
        }
        
    }
}