using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform arrow;
    public Transform northMarker;
    
    public Transform target;
    public Transform player;

    private Vector3 northDirection = Vector3.zero;
    private Quaternion targetDirection;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(arrow.up);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateNorthDirection();
        UpdateTargetDirection();
    }
    
    void UpdateNorthDirection()
    {
        northDirection.y = player.eulerAngles.y;
        northMarker.localEulerAngles = northDirection;
    }

    void UpdateTargetDirection()
    {
        Vector3 direction = target.position - player.position;

        targetDirection = Quaternion.LookRotation(direction);

        targetDirection.y = -targetDirection.y;
        targetDirection.x = 0;
        targetDirection.z = 0;
        

        arrow.localRotation = targetDirection * Quaternion.Euler(northDirection);
    }
}
