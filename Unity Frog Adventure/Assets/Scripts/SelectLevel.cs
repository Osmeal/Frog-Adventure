using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class SelectLevel : MonoBehaviour
{
    public AudioSource sound;
    public TextMeshProUGUI text;
    public string levelName;
    private bool goal;
    public GameObject transition;
    public GameObject canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Goal");
            text.gameObject.SetActive(true);
            goal = true;
            sound.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            text.gameObject.SetActive(false);
            goal = false;
    }

    private void Update()
    {
        if (goal && Input.GetKey("e"))
        {
            canvas.SetActive(false);
            transition.SetActive(true);
            Invoke("ChangeScene", 0.7f);
        }
    }
        void ChangeScene()
    {
        SceneManager.LoadScene(levelName);
    }
}
