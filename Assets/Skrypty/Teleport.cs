using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject playerObject1;
    public GameObject playerObject2;
    public GameObject teleportPlace;
    //public float x, y;

    private Trigger tRigger;
    private enum Trigger
    {
        trigger
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerObject1.tag))
        {
            Teleporter(playerObject1);
        }
        if (collision.CompareTag(playerObject2.tag))
        {
            Teleporter(playerObject2);
        }
    }
    void Start()
    {
        tRigger = Trigger.trigger;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Teleporter(GameObject gameObjectN)
    {
        if (tRigger == Trigger.trigger)
        {
            gameObjectN.transform.position = new Vector2(teleportPlace.transform.position.x, teleportPlace.transform.position.y);
        }
    }
}
