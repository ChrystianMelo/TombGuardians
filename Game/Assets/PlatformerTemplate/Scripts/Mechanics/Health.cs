using System;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using Platformer.Core;
using UnityEngine.UI;
using System.Collections;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Represebts the current vital statistics of some game entity.
    /// </summary>
    public class Health : MonoBehaviour
    {
        /// <summary>
        /// The maximum hit points for the entity.
        /// </summary>
        public int maxHP = 100;
        PlayerController player;
        public Slider healthSlider;
        public bool IsDead = false;
        internal Animator animator;
        internal Collider2D collider;
        float deadTimer = 0f;
        public bool attainable = true;
        private SpriteRenderer visual;

        /// <summary>
        /// Indicates if the entity should be considered 'alive'.
        /// </summary>
        public bool IsAlive => currentHP > 0;

        public int currentHP;
        public bool hurt = false;
        float hurtTime = 0f;
        /// <summary>
        /// Increment the HP of the entity.
        /// </summary>
        public void Increment()
        {
            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
        }

        /// <summary>
        /// Decrement the HP of the entity. Will trigger a HealthIsZero event when
        /// current HP reaches 0.
        /// </summary>
        /*public void Decrement()
        {
            currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);
            if (currentHP == 0)
            {
                var ev = Schedule<HealthIsZero>();
                ev.health = this;
            }
        }*/

        /// <summary>
        /// Decrement the HP of the entitiy until HP reaches 0.
        /// </summary>
        public void Die()
        {
            IsDead = true;//Nao funfaaaaaaa
            Destroy(this.gameObject);
            animator.SetBool("dead", IsDead);//Nao funfaaaaaaaa
            //collider.enabled = false;
        }

        public void takeDamage(int damage)
        {
            if(!attainable && damage > 0)
            {
                damage = 0;
            }

            if (damage > 0)
            {
                StartCoroutine(IsHurt());
            }
            currentHP -= damage;
            healthSlider.value = currentHP;

            if(currentHP > maxHP)
            {
                currentHP = maxHP;
                healthSlider.value = currentHP;
            }

            if (currentHP <= 0)
            {
                Die();
            }
            
            
        }

        void Awake()
        {
            currentHP = maxHP;
            healthSlider.value = currentHP;
            player = GetComponent<PlayerController>();
            animator = GetComponent<Animator>();
            collider = GetComponent<BoxCollider2D>();
            visual = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if(IsDead)
            {
                Debug.Log("Era pra ta morrendo");
                deadTimer += Time.deltaTime;
                if(deadTimer >= 3f)
                {
                    Destroy(this.gameObject);
                }
            }
        }

        IEnumerator IsHurt()
        {
            hurt = true;
            //visual.material.SetColor("_Color", new Color(1f, 0.5f, 0.5f));

            yield return new WaitForSeconds(0.1f);

            hurt = false;
            //visual.material.SetColor("_Color", new Color(1f, 1f, 1f));
        }
    }
}
