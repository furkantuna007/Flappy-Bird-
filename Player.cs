using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float jumpingSpeed = 5f;
    public float movingSpeed = 2f;
    public float verticalLimit;

    
    private Rigidbody2D playerRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         //keep the player within bounds
        if(transform.position.y > verticalLimit) {
            transform.position = new Vector3(transform.position.x, verticalLimit, transform.position.z);
            playerRigidbody .velocity = new Vector2(playerRigidbody.velocity.x, 0);
        } else if (transform.position.y < -verticalLimit) {
            transform.position = new Vector3(transform.position.x, -verticalLimit, transform.position.z);
            playerRigidbody .velocity = new Vector2(playerRigidbody.velocity.x, 0);
        }
        if(Input.GetAxis("Fire1") == 1f) {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpingSpeed);
        }

        //move horizontally
        playerRigidbody.velocity = new Vector2(movingSpeed, playerRigidbody.velocity.y);

    
    }

    void OnTriggerEnter2D (Collider2D otherCollider) {
        if(otherCollider.gameObject.tag == "Obstacle") {
            Destroy(gameObject);

        }
        }
}
