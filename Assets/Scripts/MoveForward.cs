using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveForward : MonoBehaviour
{
    private float speed = 5f;
    private float turnSpeed = 30f;
    private float xBounds = 30f;
    private float zBounds = 30f;

    private PlayerController playerController;

    public bool chick;
    public bool chicken;
    public bool rooster;

    private GameObject health;
    private HealthBarManager healthBarManager;


    void Awake()
    {
        playerController = GameObject.Find("/Player").GetComponent<PlayerController>();

        if (this.gameObject.CompareTag("Pizza"))
        {
            speed *= 4f;
        }

        turnSpeed *= Random.Range(-1f, 1f);

        if (this.gameObject.CompareTag("Chicken"))
        {
            health = transform.Find("HealthBar").gameObject;
            healthBarManager = health.GetComponent<HealthBarManager>();

            if (chick)
            {
                healthBarManager.animalHealthMaximum = 2;
                speed *= 0.5f;
            }
            if (chicken)
            {
                healthBarManager.animalHealthMaximum = 3;
                speed *= 0.9f;
            }
            if (rooster)
            {
                healthBarManager.animalHealthMaximum = 4;
                speed *= 0.75f;
            }

        }

    }

    void Update()
    {

        if (transform.position.x < -xBounds || transform.position.x > xBounds || transform.position.z < -zBounds || transform.position.z > zBounds)
        {
            if (this.gameObject.CompareTag("Pizza"))
            {
                playerController.score -= 30;
            }
            Destroy(this.gameObject);
            return;
        }

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (this.gameObject.CompareTag("Chicken"))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
        }

        if (health != null)
        {
            healthBarManager.spin = transform.rotation.eulerAngles;

            if (healthBarManager.animalHealth == healthBarManager.animalHealthMaximum + 1)
            {
                Destroy(this.gameObject);
            }

        }

    }

    public void AnimalHealthCount(int animalHealthCount)
    {
        healthBarManager.animalHealth += animalHealthCount;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (this.gameObject.CompareTag("Chicken") && other.gameObject.CompareTag("Pizza"))
        {
            health.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.CompareTag("Chicken") && other.gameObject.CompareTag("ProtectZone"))
        {
            playerController.lives = 0;
            speed = 0f;
            turnSpeed = 360f;
        }
    }

}
