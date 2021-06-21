using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour
{
    private Trigger tRigger;
    private enum Trigger
    {
        trigger
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tRigger == Trigger.trigger)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        tRigger = Trigger.trigger;
    }
}
