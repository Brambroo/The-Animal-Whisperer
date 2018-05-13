using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private SpriteRenderer player;
    private GameObject playerObj;
    private Transform point;
    private Vector3 vel;
    private Vector3[] frames = new Vector3[2];
    private Camera cam;
    private float camVertExtent;
    float camHorzExtent;


    public GameObject background;
    private SpriteRenderer backgroundSpriteRend;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Mullet").GetComponent<SpriteRenderer>();
        playerObj = GameObject.Find("Mullet");
        point = playerObj.transform;
        vel = playerObj.GetComponent<Rigidbody2D>().velocity;
        frames[0] = playerObj.transform.position;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        backgroundSpriteRend = background.GetComponent<SpriteRenderer>();
        camVertExtent = cam.orthographicSize;
        camHorzExtent = cam.aspect * camVertExtent;
    }
	
	// Update is called once per frame
	void Update () {

        float leftBound = backgroundSpriteRend.bounds.min.x + camHorzExtent + 1.0f;
        float rightBound = backgroundSpriteRend.bounds.max.x - camHorzExtent - 1.0f;
        float topBound = backgroundSpriteRend.bounds.min.y + camVertExtent + 1.0f;
        float bottomBound = backgroundSpriteRend.bounds.max.y - camVertExtent - 1.0f;

        if (transform.position.x <= leftBound || transform.position.x >= rightBound || transform.position.y <= topBound || transform.position.y >= bottomBound)
        {

            checkBounds(leftBound, rightBound, topBound, bottomBound);
           
        }
        else
        {
            Vector2 veloc = frames[0] - playerObj.transform.position;

            if (frames[0] == playerObj.transform.position)
            {
                // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(playerObj.transform.position.x, playerObj.transform.position.y, gameObject.transform.position.z), ref vel, 10f * Time.deltaTime, 30.0f);

            }
            else
            {
                //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(playerObj.transform.position.x, playerObj.transform.position.y, gameObject.transform.position.z) * veloc.magnitude, ref vel, 10f * Time.deltaTime, 30.0f);

            }
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(playerObj.transform.position.x, playerObj.transform.position.y, gameObject.transform.position.z), ref vel, 1f * Time.deltaTime, 1000.0f);

            

            frames[0] = playerObj.transform.position;
        }
    }

    public void checkBounds(float leftBound, float rightBound, float topBound, float bottomBound)
    {

        float camXPos = Mathf.Lerp(transform.position.x, Mathf.Clamp(playerObj.transform.position.x, leftBound, rightBound), 10000f);
        float camYPos = Mathf.Lerp(transform.position.y, Mathf.Clamp(playerObj.transform.position.y, topBound, bottomBound), 10000f);

        transform.position = Vector3.Lerp(transform.position, new Vector3(camXPos, camYPos, transform.position.z), 10000f);//need to fix jittering when at bounds

    }
}
