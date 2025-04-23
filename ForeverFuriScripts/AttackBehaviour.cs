using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour
{
    public float timer;
    public GameObject colliders;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1.5)
        {
            IsDamaging();
        }
    }

    private void IsDamaging()
    {
        colliders.SetActive(true);

        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
        {
            sr.material.color = Color.red;
        }

        if (timer >= 2)
        {
            Destroy(gameObject);
        }
    }
}
