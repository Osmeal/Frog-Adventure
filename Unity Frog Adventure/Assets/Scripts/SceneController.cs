using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public TextMeshProUGUI textFruitsTotal;
    public TextMeshProUGUI textFruitsCollected;

    public GameObject transition;

    private int totalFruitsInLevel;
    private int fruitsCollected;

    void Start()
    {
        totalFruitsInLevel = transform.childCount;
        UpdateFruitsText();
    }

    public void FruitWeit()
    {
        Invoke("FruitCollected", 0.5f);
    }

    public void FruitCollected()
    {
        fruitsCollected = totalFruitsInLevel - transform.childCount;
        UpdateFruitsText();
        if (fruitsCollected == totalFruitsInLevel)
        {
            transition.SetActive(true);
            Invoke("ChangeScene", 1);
        }
    }

    void UpdateFruitsText()
    {
        textFruitsTotal.text = totalFruitsInLevel.ToString();
        textFruitsCollected.text = fruitsCollected.ToString();
    }

    public void ChangeScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;


        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
