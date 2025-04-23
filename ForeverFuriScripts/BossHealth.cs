using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int minHealth = 200;
    public int maxHealth = 1200;
    public int currentHealth;

    public BossHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = minHealth;
        healthBar.SetMaxHealth(minHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            TakeDamage(200);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth += damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth >= 1500)
        {
            Destroy(gameObject);
        }
    }
}
