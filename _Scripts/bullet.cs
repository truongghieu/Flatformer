using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
   
    [SerializeField] private float speed = 20f ;
    [SerializeField] private GameObject BulletEffect;
    private Rigidbody2D _rb;
    

    void Start(){
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _rb.velocity = transform.right * speed ;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy")){
            GameObject ef = Instantiate(BulletEffect,transform.position,Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
            Destroy(ef,1);
        }
    }
}
