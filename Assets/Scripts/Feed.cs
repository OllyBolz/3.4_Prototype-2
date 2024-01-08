using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{
    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("/Player").GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Chicken"))
        {
            MoveForward moveForward = other.gameObject.GetComponent<MoveForward>();
            moveForward.AnimalHealthCount(1);

            if (moveForward.chick)
            {
                playerController.score += 100;
            }
            if (moveForward.chicken)
            {
                playerController.score += 140;
            }
            if (moveForward.rooster)
            {
                playerController.score += 200;
            }

            Destroy(this.gameObject);
        }
    }
}
