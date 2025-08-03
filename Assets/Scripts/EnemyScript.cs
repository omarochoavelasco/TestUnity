using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject John;
    public GameObject bulletPrefab;
    private float lastShoot;
    private int Health = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (John == null) return;
        Vector3 direction = John.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale   = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > lastShoot + 0.30f)
        {
            Shoot();
            lastShoot = Time.time;
        }
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
