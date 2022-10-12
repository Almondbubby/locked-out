using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
 
public class CharacterMovement : MonoBehaviour
{
    
    [SerializeField]
    private float movementSpeed;
    private Vector2 movement;
    private Rigidbody2D rbody;
    private Animator anim;

    private bool hasKey = false;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        hasKey = false;
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
        if(movement.y > 0){
            anim.Play("Player_Walk_Forwards");
        }
        if(movement.y < 0){
            anim.Play("Player_Walk_Back");
        }
        if(movement.y == 0){
            if(movement.x < 0){
                anim.Play("Player_Walk_Left");
            }
            if(movement.x > 0){
                anim.Play("Player_Walk_Right");
            }
        }
    }

    public void Movement()
    {
        rbody.MovePosition(GetComponent<Rigidbody2D>().position + movement * movementSpeed * Time.fixedDeltaTime);

    }

    void FixedUpdate()
    {
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Key")
        {
            hasKey = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "Door" && hasKey)
        {
            SceneManager.LoadScene("ApartmentLobby");
        }
    }
}