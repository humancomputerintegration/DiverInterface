using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForces : MonoBehaviour
{

    Rigidbody ballRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = this.GetComponent<Rigidbody>();

        Vector3 randomForce = 125.0f * Random.insideUnitSphere;

        ballRigidbody.AddForce(randomForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
