using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerRespawn>().ReachedCheckpoint(transform.position.x, transform.position.y);

            GetComponent<Animator>().enabled = true;
        }
    }
}
