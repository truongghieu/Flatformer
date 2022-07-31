using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private Vector2 pl;

    void Update()
    {
        pl = GameObject.Find("Player").transform.position;
        transform.position = new Vector3(pl.x,pl.y,transform.position.z);

    }
}
