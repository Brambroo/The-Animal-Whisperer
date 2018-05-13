using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    void Update () {
        

        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;

        
        transform.Translate(x, z, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }

    }
}
