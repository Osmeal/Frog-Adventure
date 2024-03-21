using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class JumpDamage : MonoBehaviour
{
    //public Collider2D collider2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject destroyParticle;
    public float jumpForce = 2.5f;
    public int lifes = 2;
    public AudioSource sound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            LosseLifeAndHit();
            CheckLife();
        }
    }

    public void LosseLifeAndHit()
    {
        lifes--;
        animator.Play("Hit");
    }

    public void CheckLife()
    {
        if (lifes <= 0)
        {
            spriteRenderer.enabled = false;
            destroyParticle.SetActive(true);
            Invoke("EnemyDie", 0.2f);
            sound.Play();
        }
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }
}
