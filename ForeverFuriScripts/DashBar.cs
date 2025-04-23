using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    public Slider slider;
    public float coolDown;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        coolDown = player.GetComponent<Movement>().dashCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = coolDown;

        if (player.GetComponent<Movement>().isDashing == true)
        {
            coolDown = 0;
        }
        else
        {
            if (coolDown < player.GetComponent<Movement>().dashCooldown)
            {
                coolDown += Time.deltaTime;
            }
        }
    }
}
