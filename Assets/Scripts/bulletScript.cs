using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public AudioClip Sound;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;

    public float Speed;
    

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate(){
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction){
        Direction = direction;
    }

    public void DestroyBullet(){
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        JohnMovement john = collision.GetComponent<JohnMovement>();
        EnemyScript enemy = collision.GetComponent<EnemyScript>();
        if(john != null){
            john.Hit();
        }
        if(enemy != null){
            enemy.Hit();
        }
        DestroyBullet();
    }
}
