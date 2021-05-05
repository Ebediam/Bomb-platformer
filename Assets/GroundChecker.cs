using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{

    public LayerMask groundLayer;
    public PlayerController player;
    public float checkDistance = 0.1f;
    RaycastHit hitInfo;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray, out hitInfo, checkDistance, groundLayer))
        {
            player.isGrounded = true;
        }
        else
        {
            player.isGrounded = false;
        }

    }
}
