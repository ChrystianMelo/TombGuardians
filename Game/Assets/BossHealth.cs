using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int maxHP = 1000;
    public Slider healthBar;
    public GameObject Tomb;
    public GameObject TombSpawn;
    public int pontos;
    private Renderer visual;
    private AudioSource somPadrao;
    public int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        healthBar.value = currentHP;
        visual = GetComponent<Renderer>();
        somPadrao = GameObject.Find("GameController").GetComponent<AudioSource>();
        somPadrao.Pause();
    }

    public void takeDamage(int damage)
    {
        currentHP -= damage;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        healthBar.value = currentHP;

        if(currentHP <= 0)
        {
            Instantiate(Tomb, TombSpawn.transform.position, Quaternion.identity);
            EnemyManager.unleashed = false;
            EnemyManager.score += pontos;
            somPadrao.Play();
            Destroy(this.gameObject);
        }

        if(damage > 0)
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
