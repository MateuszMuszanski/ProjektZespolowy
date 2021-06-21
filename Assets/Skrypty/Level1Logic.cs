using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Logic : MonoBehaviour
{
    // pierwszy keg
    private bool isOnGround1;
    public Transform positionOfObject1;
    public float checkBoxRadius1;
    public LayerMask onGround1;
    // drugi keg
    private bool isOnGround2;
    public Transform positionOfObject2;
    public float checkBoxRadius2;
    public LayerMask onGround2;
    // kolce
    new public GameObject gameObject;
    // gracz
    public Transform feetPos;
    private bool isInPortal;
    public float checkRadius;

    public LayerMask loadNextLevel;

    bool canEndLvl;

    void Update()
    {
        OnEndLevel();
    }
    void OnEndLevel()
    {
        isInPortal = Physics2D.OverlapCircle(feetPos.position, checkRadius, loadNextLevel);
        isOnGround1 = Physics2D.OverlapCircle(positionOfObject1.position, checkBoxRadius1, onGround1);
        isOnGround2 = Physics2D.OverlapCircle(positionOfObject2.position, checkBoxRadius2, onGround2);

        if (isOnGround1 == true && isOnGround2 == true)
        {
            //canEndLvl = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            gameObject.SetActive(false);
            //Debug.Log(isInPortal);
            PlayerPrefs.SetInt("lvl",SceneManager.GetActiveScene().buildIndex + 1);
            PlayerInPortal(isInPortal);
        }
        else
        {
            canEndLvl = false;
        }
    }
    public bool CanEndLvl()
    {
        return canEndLvl;
    }

    bool PlayerInPortal(bool player)
    {
        if (player == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        return player;
    }
}
