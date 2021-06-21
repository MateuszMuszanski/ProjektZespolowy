using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Logic : MonoBehaviour
{
    // box 1
    public LayerMask layerMask1;
    public Transform objectDetection1;
    public GameObject gameObject1;
    bool destroyed1 = false;
    // box 2
    public LayerMask layerMask2;
    public Transform objectDetection2;
    public GameObject gameObject2;
    bool destroyed2 = false;
    // box 3
    public LayerMask layerMask3;
    public Transform objectDetection3;
    public GameObject gameObject3;
    bool destroyed3 = false;
    // gracz
    public Transform feetPos;
    private bool isInPortal;
    public float range;
    public LayerMask portalMask;
    // kładka
    public GameObject kladka;

    void FixedUpdate()
    {
        EndLvl();
    }

    void EndLvl()
    {
        isInPortal = Physics2D.OverlapCircle(feetPos.position, range, portalMask);

        if (destroyed1 == false)
        {
            destroyed1 = Destroyed(gameObject1, objectDetection1, feetPos, layerMask1);
        }
        if (destroyed2 == false)
        {
            destroyed2 = Destroyed(gameObject2, objectDetection2, feetPos, layerMask2);
        }
        if (destroyed3 == false)
        {
            destroyed3 = Destroyed(gameObject3, objectDetection3, feetPos, layerMask3);
        }

        if (destroyed1 == true && destroyed2 == true && destroyed3 == true)
        {
            kladka.SetActive(true);
        }

        if (isInPortal == true)
        {
            PlayerPrefs.SetInt("lvl", SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    bool Destroyed(GameObject gameObject, Transform transformObject, bool detectedFeet, LayerMask layerMask)
    {
        detectedFeet = Physics2D.OverlapBox(transformObject.position, transformObject.localScale, 0, layerMask);
        if (detectedFeet == true)
        {
            Destroy(gameObject);
        }
        return detectedFeet;
    }
}
