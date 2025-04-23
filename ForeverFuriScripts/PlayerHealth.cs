using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;
    public bool canTakeDamage = true;
    public SceneFader scenceFader;
    private float addHealth;
    private float playerDead;
    
   

    public PlayerHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        addHealth += Time.deltaTime;
        healthBar.SetHealth(currentHealth + (addHealth * 2));

        playerDead = currentHealth + addHealth + 40;
        Debug.Log(playerDead);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Boss attack" && canTakeDamage == true)
        {
            TakeDamage(20);
            Debug.Log("Player takes damage!");

            canTakeDamage = false;
            StartCoroutine(WaitAfterDamage());
        }
    }

    private void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (playerDead <= 10)
        {
            scenceFader.FadeToLevel(2);
            
        }

    }

    IEnumerator WaitAfterDamage()
    {
        yield return new WaitForSeconds(2);
        canTakeDamage = true;
    }
}
