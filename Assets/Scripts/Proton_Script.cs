using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Proton_Script : MonoBehaviour
{
    public double pull_force;
    public Transform player_body;
    private Vector3 atom_direction, verz, horz;
    public float pos_proton, pos_player, dist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //sum_p = player_body.position.x + player_body.position.z;
        //sum_atom = transform.position.x + transform.position.z;
        pos_proton = transform.position.z + transform.position.x;
        pos_player = player_body.position.z + player_body.position.x;
        dist = pos_player - pos_proton;
        if(dist < 0)
        {
            dist = dist * -1.0f;
        }
        pull_force = (20/Math.Pow(dist, 2));
        
        if(dist < 2)
        {
            pull_force = 3f;
        }

        
        /*if(sum > 10)
        {
            push_force = 0.5f;
        } else
        {
            push_force = 3f;
        }*/

        transform.position = Vector3.MoveTowards(transform.position, player_body.position, (float)pull_force * Time.deltaTime);
    }
}
