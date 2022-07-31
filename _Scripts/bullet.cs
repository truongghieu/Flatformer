using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
   
    [SerializeField] private float speed = 20f ;
    private Rigidbody2D _rb;

    void Start(){
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _rb.velocity = transform.right * speed ;
    }
}
