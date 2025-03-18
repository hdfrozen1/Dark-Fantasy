using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovementScript : MonoBehaviour
{
    private CapsuleCollider _collider;
    private Rigidbody _rigidBody;
    private bool isGrounded;

    [Header("Ground Detection Settings")]
    public LayerMask groundLayer; // Layer for ground detection
    public float groundCheckDistance = 0.3f; // How far below the player to check
    public float RayCastPos = 0.1f;
    void Awake()
    {
        _collider = GetComponent<CapsuleCollider>();
        _rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        GroundDetection();
    }
    private void GroundDetection(){
        Vector3 origin = transform.position;
        origin.y += RayCastPos; // Slightly above the bottom of the player
        RaycastHit hit;

        Debug.DrawRay(origin, Vector3.down * groundCheckDistance, Color.red, 0.5f, false);
        Vector3 targetPos = transform.position;
        if (Physics.Raycast(origin, Vector3.down, out hit, groundCheckDistance, groundLayer))
        {
            
            isGrounded = true;
            
            Vector3 tp = hit.point;
            targetPos.y = tp.y;
            
            Debug.Log("targetpos:" + targetPos);
            Debug.Log("hit name :" + hit.transform.name);
            Debug.Log("hit point :" +hit.point);
        }
        else
        {
            isGrounded = false;
        }
        if(isGrounded)
        {
            transform.position = targetPos;
        }
    }
    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Vector3 newPos = new Vector3(transform.position.x,transform.position.y +RayCastPos,transform.position.z);
    //     Gizmos.DrawRay(newPos,Vector3.down * groundCheckDistance);
    // }
}
