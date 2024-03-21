using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
public class PlayerRespawn : MonoBehaviour
{
    public Animator animator;
    private float checkPointPositionX, checkPointPositionY;


    void Start()
    {
        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }

    public void PlayerDamaged()
    {
        animator.Play("hit");
        Invoke("Respawn", 0.1f);
    }

    public void ReachedCheckpoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    private void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
