using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Logic : MonoBehaviour
{
    // keg
    private bool isOnGround1;
    public Transform positionOfObject1;
    public float checkBoxRadius1;
    public LayerMask onGround1;
    // box
    private bool playerOnBox;
    public Transform boxCollider;
    public float playerRadius;
    public LayerMask playerMask;
    // portale
    public GameObject portalActivate;
    public GameObject portalDesactivate;
    // platforma
    public GameObject boxToDestroy;
    public GameObject platformToActivate;
    // player
    public Transform feetPos;
    private bool isInPortal;
    public float range;
    public LayerMask portalMask;

    bool destroyed = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isOnGround1 = Physics2D.OverlapCircle(positionOfObject1.position, checkBoxRadius1, onGround1);
        isInPortal = Physics2D.OverlapCircle(feetPos.position, range, portalMask);

        if (isOnGround1 == true)
        {
            portalActivate.SetActive(true);
            portalDesactivate.SetActive(false);
            //Debug.Log("jest git");
        }
        else
        {
            portalActivate.SetActive(false);
            portalDesactivate.SetActive(true);
        }

        if (destroyed == false)
        {
            destroyed = Destroyed(boxToDestroy, boxCollider, playerOnBox, playerMask);
        }
        else if (destroyed == true)
        {
            platformToActivate.SetActive(true);
        }

        if (isInPortal == true)
        {
            //PlayerPrefs.SetInt("lvl", SceneManager.GetActiveScene().buildIndex + 1);
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
