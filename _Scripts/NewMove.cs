using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMove : Movement
{


    protected override void Start()
    {
        Time.timeScale = 1;
    }
    protected override void Update()
    {
        TakeDame();
    }
}
