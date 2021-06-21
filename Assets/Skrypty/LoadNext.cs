using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNext : MonoBehaviour
{
    public static int lvl = 1;

    public Transform feetPos;
    private Rigidbody2D rb;

    public float checkRadius;
    public LayerMask loadNextLevel;
    private bool isGrounded;

    Level1Logic level1;

    void Update()
    {
        OnEndLevel();
    }
    void OnEndLevel()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, loadNextLevel);

        if (isGrounded == true )
        {//&& level1.CanEndLvl()
            lvl++;
            SceneManager.LoadScene(lvl);
        }
    }
}
