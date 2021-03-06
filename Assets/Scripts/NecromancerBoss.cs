using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerBoss : Enemy
{
    public float[] skullSpeed = { 2.5f, -2.5f };
    public float distance = 0.25f;
    public Transform[] skulls;

    //This controls the little skulls floating around this boss
    private void Update()
    {
        for (int i = 0; i < skulls.Length; i++)
        {
            skulls[i].position = transform.position + new Vector3(-Mathf.Cos(Time.time * skullSpeed[i]) * distance, Mathf.Sin(Time.time * skullSpeed[i]) * distance, 0);
        }
            
        
        
    }
}
