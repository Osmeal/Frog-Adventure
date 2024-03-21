using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlant : MonoBehaviour
{
    public float speed = 2;
    public float lifeTime = 5;
    public bool left;

    public void Start()
    {
        Destroy(gameObject, 5);
    }
    public void Update()
    {
        if (left)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

    }
}
