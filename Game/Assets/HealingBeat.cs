using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBeat : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController ally = collision.GetComponent<PlayerController>();
        if(ally)
        {
            ally.health.takeDamage(-1);
        }
    }
}
