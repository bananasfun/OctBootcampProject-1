using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10.0f;
    public float sprintSpeed = 10.0f;
    public bool isSprintSpeedActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isSprintSpeedActive == true)
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = 10.0f;
        }

        //Vector3 you use the coordinate system, transform you use the coordinates of the object

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * -1 * speed * Time.deltaTime);

        } 
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * -1 * speed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

        }
 


    }
}
