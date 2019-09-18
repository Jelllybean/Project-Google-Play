using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPatrol : MonoBehaviour
{

    public Vector3 direction;
    private float moveSpeed;
    private float distance;

    void Update()
    {
        Vector3 dsfji = new Vector3(direction.x, direction.y, direction.z);
        transform.Translate(dsfji);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Wall")
        {
            direction.x *= -1;
        }
    }
}
