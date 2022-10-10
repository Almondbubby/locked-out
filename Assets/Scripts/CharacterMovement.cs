using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
 
public class CharacterMovement : MonoBehaviour
{
    
    [SerializeField]
    private float movementSpeed;
    private Vector2 movement;
    private Rigidbody2D rbody;
 
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    public void Movement()
    {
        rbody.MovePosition(GetComponent<Rigidbody2D>().position + movement * movementSpeed * Time.fixedDeltaTime);

    }

    void FixedUpdate()
    {
        Movement();
    }
}