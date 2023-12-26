using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Eletron_Script : MonoBehaviour
{
    public double push_force;
    private Vector3 atom_direction, verz, horz;
    public float pos_eletron, dist_eletron, pos_player;
    public Transform player_body;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //sum_p = player_body.position.x + player_body.position.z;
        //sum_atom = transform.position.x + transform.position.z;
        pos_eletron = transform.position.z + transform.position.x;
        pos_player = player_body.position.z + player_body.position.x;
        dist_eletron = pos_player - pos_eletron;
        if (dist_eletron < 0)
        {
            dist_eletron = dist_eletron * -1.0f;
        }
        push_force = (-20 / Math.Pow(dist_eletron, 2));

        if (dist_eletron < 2)
        {
            push_force = -3f;
        }
        transform.position = Vector3.MoveTowards(transform.position, player_body.position, (float)push_force * Time.deltaTime);
    }
}
