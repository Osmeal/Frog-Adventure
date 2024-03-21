using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlantEnemy : MonoBehaviour
{
    private float waitedTime;
    public float waitTimeToAttack = 3;
    public Animator animator;
    public GameObject bulletPrefab;
    public Transform launchSpawnPoint;
    public AudioSource sound;

    public void Start()
    {
        waitedTime = waitTimeToAttack;
    }

    public void Update()
    {
        if (waitedTime <= 0)
        {
            waitedTime = waitTimeToAttack;
            animator.Play("AttackPlant");
            Invoke("LaunchBullet", 0.5f);
            sound.Play();
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }

    public void LaunchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(bulletPrefab, launchSpawnPoint.position, launchSpawnPoint.rotation);
    }
}
