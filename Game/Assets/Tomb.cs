using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tomb : MonoBehaviour
{

    public int maxHP = 200;
    public Slider healthBar;
    public GameObject[] Boss;
    public GameObject BossSpawn;
    private Renderer visual;

    public int currentHP;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        healthBar.value = currentHP;
        visual = GetComponent<Renderer>();
    }

    public void takeDamage(int damage)
    {
        currentHP -= damage;
        healthBar.value = currentHP;

        if(currentHP <= 0)
        {
            Instantiate(Boss[Random.Range(0, Boss.Length)], BossSpawn.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            EnemyManager.unleashed = true;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            int c = 0;
            while(c < enemies.Length)
            {
                Destroy(enemies[c]);
                c++;
            }
            EnemyManager.contador = 0;
        }

        if (damage > 0)
        {
            StartCoroutine(IsHurt());
        }
    }

    IEnumerator IsHurt()
    {
        visual.material.SetColor("_Color", new Color(1f, 0.5f, 0.5f));

        yield return new WaitForSeconds(0.1f);

        visual.material.SetColor("_Color", new Color(1f, 1f, 1f));
    }
}
