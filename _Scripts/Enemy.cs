using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float dis = 4f;
    [SerializeField] private float speed = 2f;


    void Start(){
        player = GameObject.Find("Player");
    }

    void Update(){

        if(UIManager.pauseGame)return;

        if(Vector2.Distance(transform.position,player.transform.position) < dis){
            transform.position = Vector2.MoveTowards(transform.position,player.transform.position,speed * Time.deltaTime);
        }
    }
    
}
