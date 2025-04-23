using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject[] allAttacks;
    private int[] attacks1;
    private int[] attacks2;
    private int[] attacks3;
    private int[] attacks4;
    private int index;
    public float attackTimer;
    private GameObject currentAttack;
    private AudioManager audiomanager;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

        audiomanager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();

        attacks1 = new int[] { 0, 1, 4 };
        attacks2 = new int[] { 0, 1, 5 };
        attacks3 = new int[] { 0, 1, 3 };
        attacks4 = new int[] { 0, 1, 2 };
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        
        if (attackTimer >= 3)
        {
            BossIsAttacking();
        }
    }

    private void BossIsAttacking()
    {
        if (player.GetComponent<PlayerPosition>().playerPosition == 1)
        {
            index = attacks1[Random.Range(0, attacks1.Length)];
            currentAttack = allAttacks[index];
        }
        else if (player.GetComponent<PlayerPosition>().playerPosition == 2)
        {
            index = attacks2[Random.Range(0, attacks2.Length)];
            currentAttack = allAttacks[index];
        }
        else if (player.GetComponent<PlayerPosition>().playerPosition == 3)
        {
            index = attacks3[Random.Range(0, attacks3.Length)];
            currentAttack = allAttacks[index];
        }
        else if (player.GetComponent<PlayerPosition>().playerPosition == 4)
        {
            index = attacks4[Random.Range(0, attacks4.Length)];
            currentAttack = allAttacks[index];
        }

        if (player.GetComponent<PlayerPosition>().playerPosition > 0)
        {
            audiomanager.Play("Attack");
            Instantiate(currentAttack);
            attackTimer = 0;
        }
    }
}
