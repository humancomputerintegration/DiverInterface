using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFloorCollider : MonoBehaviour
{

    Renderer ballRenderer;

    // Start is called before the first frame update
    void Start()
    {
        ballRenderer = this.GetComponent<Renderer>();
        ballRenderer.material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Turn blue.
        // Debug.Log("I hit " + collision.gameObject.name);
        if (collision.gameObject.name == "Floor")
        {
            ballRenderer.material.color = Color.blue;
        } else if (collision.gameObject.name == "Cube")
        {
            ballRenderer.material.color = Color.yellow;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Turn red.
        //ballRenderer.material.color = Color.red;
    }

    private void OnTriggerEnter(Collider other)
    {
        ballRenderer.material.color = Color.green;
    }

    private void OnTriggerExit(Collider other)
    {
        ballRenderer.material.color = Color.red;
    }
}
