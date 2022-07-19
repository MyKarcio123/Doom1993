using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10f;
    public float momentumDamping = 5f; 
    public CharacterController CC;
    public float gravity = 10f;
    private Vector3 inputVector;
    private Vector3 movmentVector;

    void Update()
    {
        GetInput();
        MovePlayer();
    }
    void GetInput()
    {
        if (Input.GetKey(KeyCode.W) ||
           Input.GetKey(KeyCode.A) ||
           Input.GetKey(KeyCode.S) ||
           Input.GetKey(KeyCode.D))
        {
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            inputVector.Normalize();
            inputVector = transform.TransformDirection(inputVector);
        }
        else
        {
            inputVector = Vector3.Lerp(inputVector, Vector3.zero, momentumDamping * Time.deltaTime);
        }
        movmentVector = (inputVector * playerSpeed) - (gravity * Vector3.up);
    }
    void MovePlayer()
    {
        CC.Move(movmentVector * Time.deltaTime);
    }
}
