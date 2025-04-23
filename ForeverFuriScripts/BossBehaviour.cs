using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{

    [SerializeField] private int maxHealth;
    public Canvas sceneCanvas;
    private BossHealthBar healthBar; 
    public GameObject player;
    private GameObject audioManager;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        /* Assigns initial variables*/
        currentHealth = 200;
        healthBar = sceneCanvas.GetComponentInChildren<BossHealthBar>();
        healthBar.SetMaxHealth(200);
        audioManager = GameObject.FindWithTag("AudioManager");


        if (!audioManager.GetComponent<AudioManager>().sounds[1].source.isPlaying)
        {
            audioManager.GetComponent<AudioManager>().Play("Battle");
        }
        if (audioManager.GetComponent<AudioManager>().sounds[0].source.isPlaying)
        {
            audioManager.GetComponent<AudioManager>().Stop("Title");
        }
        if (audioManager.GetComponent<AudioManager>().sounds[2].source.isPlaying)
        {
            audioManager.GetComponent<AudioManager>().Stop("Morning");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeHugDamage() // takes melee damage
    {
        currentHealth += 20;
        if (currentHealth >= 1200)
        {
            healthBar.SetHealth(1200);
            Victory();
        }
        else
        {
            healthBar.SetHealth(currentHealth);
        }
    }

    public void TakeKissDamage() // takes ranged damage (may not be used)
    {
        currentHealth -= 50;
        if (currentHealth <= 0)
        {
            healthBar.SetHealth(0);
            Victory();
        }
        else
        {
            healthBar.SetHealth(currentHealth);
        }
    }

    public void Victory() // Victory function, disables the ability to take more damage, sets next scene
    {

        Debug.Log("You won!");
        player.GetComponent<Movement>().DisableFireEvents();
        audioManager.GetComponent<AudioManager>().Stop("Battle");
        sceneCanvas.GetComponentInChildren<SceneFader>().FadeToLevel(3);
    }

}
