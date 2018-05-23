using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour {

    public GameObject playerObj;
    private PlayerMovement playerMovement;
    private Vector3[] frames = new Vector3[2];
    private Rigidbody2D playerBody;
   

    // Use this for initialization
    void Start () {
        playerObj = GameObject.Find("Mullet");
        playerMovement = playerObj.GetComponent<PlayerMovement>();
        frames[0] = playerObj.transform.position;
        playerBody = playerObj.GetComponent<Rigidbody2D>();

	}

    private void Update()
    {
        frames[0] = playerObj.transform.position;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerBody.MovePosition(new Vector2(frames[0].x, frames[0].y));
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
        }
    }


}
