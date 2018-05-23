using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 100.0f;

    private Rigidbody2D playerBody;
    private float vel;
    private float xInput;
    private float yInput;

    void Awake()
    {
        QualitySettings.vSyncCount = 1;  // VSync must be disabled
        Application.targetFrameRate = 0;

    }

    void Start()
    {
        Time.maximumDeltaTime = 0.03f;
        playerBody = gameObject.GetComponent<Rigidbody2D>();
        vel = 1.0f;
    }

    private void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate () {

        Vector2 movement = new Vector2(xInput, yInput);

        movement.Normalize();
        playerBody.velocity = new Vector3(xInput, yInput, 0) * speed;

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    playerBody.AddForce(Vector3.left * speed * Time.deltaTime);
        //}
        //else if (Input.GetKeyDown(KeyCode.W))
        //{
        //    playerBody.AddForce(Vector3.up * speed);
        //}
        //else if (Input.GetKeyDown(KeyCode.D))
        //{
        //    playerBody.AddForce(Vector3.right * speed);
        //}
        //else if (Input.GetKeyDown(KeyCode.S))
        //{
        //    playerBody.AddForce(Vector3.down * speed);
        //}






        //if (Input.GetKeyDown(KeyCode.Space))
        //{

        //}

    }

    
}
