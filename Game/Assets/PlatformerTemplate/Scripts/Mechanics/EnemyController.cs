using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent(typeof(AnimationController), typeof(Collider2D))]
    public class EnemyController : MonoBehaviour
    {
        public PatrolPath path;
        public AudioClip ouch;
        public int health = 100;
        public int damage = 5;
        public int pontos = 10;

        internal PatrolPath.Mover mover;
        internal AnimationController control;
        internal new Collider2D collider;
        internal new AudioSource audio;
        SpriteRenderer spriteRenderer;

        public Bounds Bounds => collider.bounds;

        void Awake()
        {
            control = GetComponent<AnimationController>();
            collider = GetComponent<Collider2D>();
            audio = GetComponent<AudioSource>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                
                var ev = Schedule<PlayerEnemyCollision>();
                ev.player = player;
                ev.enemy = this;
            }
        }

        void Update()
        {
            
        }

        public void takeDamage(int damage)
        {
            health -= damage;
            if(health <= 0)
            {
                Destroy(this.gameObject);
                EnemyManager.score += pontos;
                EnemyManager.contador--;
            }
            if (damage > 0)
            {
                StartCoroutine(IsHurt());
            }

        }

        IEnumerator IsHurt()
        {
            spriteRenderer.material.SetColor("_Color", new Color(1f, 0.5f, 0.5f));

            yield return new WaitForSeconds(0.1f);

            spriteRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f));
        }

    }
}