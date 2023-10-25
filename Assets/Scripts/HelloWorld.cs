using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public int numberVariable; // Variable Declaration
    public bool isDoingSomething = false; // Variable initialisation
    public float speed = 10.0f;

    public Transform CubeTransform;
    public Vector3 position;
    public Vector3 RotateAmount;


    // Start is called before the first frame update
    void Start()
    {
        isDoingSomething = true; // Variable Assignment
        Debug.Log("Hello from Start");
        Debug.Log("The new variables are " + this);

        CubeTransform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("The number variable is: " + numberVariable);

        if(5> 3 && isDoingSomething == true)
        {
            CubeTransform.Rotate(Vector3.forward * Time.deltaTime * speed);

        }
        // CubeTransform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
