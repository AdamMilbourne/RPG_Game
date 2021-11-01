using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightScripts : MonoBehaviour
{
 

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Run(bool run)
    {
        if (Random.Range(1, 101) == 10)
        {
            //in unity set bool to true and close fight UI and unpause game
           
            run = true;
        }
        else
        {
            run = false;
            //miss turn here
        }
    }
    
}
