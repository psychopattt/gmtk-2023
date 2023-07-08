using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement : MonoBehaviour
{
    public Rigidbody2D monkeyRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Monkey"; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D)){
            monkeyRigidBody.velocity += Vector2.right;
        } else if (Input.GetKeyDown(KeyCode.W)){
            monkeyRigidBody.velocity = Vector2.up*10;
        }

        

        
    }
}
