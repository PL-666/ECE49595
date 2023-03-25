using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : Card
{
    void Update()
    {
        if (cntdwn >= 0.0f){
            cntdwn -= Time.deltaTime;
        }
        else{
            Test();
        }
    }

    
}
