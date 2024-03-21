using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class FruitsCollected : MonoBehaviour
{
    public AudioSource sound;
    public SceneController sceneController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 0.5f);
        GetComponent<SpriteRenderer>().enabled = false;
        sceneController.FruitWeit();
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        sound.Play();
    }
}
