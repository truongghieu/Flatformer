using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{

    [SerializeField] private GameObject bullet;

    [SerializeField] private float bulletTime = .5f;
    [SerializeField] private Transform pos;

    void Start()
    {   
        pos = GameObject.Find("Player").transform.GetChild(4);
        GameManager.instance.StartGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        shoot();    
    }

    protected virtual void shoot(){
        if(InputManager.instance.ShootPress()){
            ///
            GameObject bul = Instantiate(bullet,pos.position,pos.rotation);
        
            Destroy(bul,bulletTime);
        }
    }


}
