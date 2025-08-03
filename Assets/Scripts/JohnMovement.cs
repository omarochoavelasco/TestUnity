using System.Collections;
using System.Collections.Generic;

//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class JohnMovement : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float Speed;
    public float JumpForce;

    private bool Grounded;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private float lastShoot;
    private int Health = 5;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

    }

    
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if(Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("Running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f)){
            Grounded = true;
        }
        else Grounded = false;
        //Horizontal *= 10.0f;
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))&&Grounded)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Q) && Time.time > lastShoot + 0.25f){
            Shoot();
            lastShoot = Time.time;
        }
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);

    }

    private void Jump(){
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
    
    private void Shoot(){
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;
            

        GameObject bullet = Instantiate(bulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<bulletScript>().SetDirection(direction);
    }

    public void Hit(){
        Health -= 1;
        if (Health == 0) Destroy(gameObject);
    }
}
