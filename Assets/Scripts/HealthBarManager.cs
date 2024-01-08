using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public int animalHealth = 0;
    public int animalHealthMaximum = 10;
    public float animalHealthRatio;

    private GameObject healthArm;
    private Slider healthBar;
    public Vector3 spin;

    void Start()
    {
		
		healthBar = GetComponent<Slider>();
        healthArm = transform.Find("Arm").gameObject;
        animalHealth = 0;
		healthArm.SetActive(false);
	}

    void LateUpdate()
    {
        if (animalHealth != 0)
        {
            healthArm.SetActive(true);
        }

		animalHealthRatio = (float)animalHealth / (float)animalHealthMaximum;
        healthBar.value = animalHealthRatio;

		transform.rotation = Quaternion.Euler(new Vector3(270f, 0f, 0f) + spin);
    }
}
