using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
public class SimpleMove : MonoBehaviour
{
    public Vector2 Dir;
    public Vector2 MousePos;
    public float rotationPower = 3f;
    private float CanAttack;
    public float Speed;
    public float JumpSpeed;
    public float Gravity;
    public CharacterController CharacterController;
    public float ViewRadius;
    public GameObject FollowTransform;
    public void OnMove(InputValue value)
    {
        Dir = value.Get<Vector2>();
    }
    public void OnAttack(InputValue value)
    {
        CanAttack = value.Get<float>();
        Debug.Log("CanAttack :"+CanAttack);
    }
    public void OnJump(InputValue value){
        
    }
    public void OnCameraRotate(InputValue value){
        MousePos = value.Get<Vector2>();
        FollowTransform.transform.rotation *= Quaternion.AngleAxis(MousePos.x * rotationPower, Vector3.up);
        
    }
    private void Update() {
        //Debug.Log("can attack:"+CanAttack);
        if(Dir != Vector2.zero){
            Vector3 move = new Vector3(Dir.x,0,Dir.y);
            CharacterController.Move(move * Speed);
        }
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ViewRadius);
    }
}
