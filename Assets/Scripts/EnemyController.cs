using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class EnemyController : MonoBehaviour

{
    public float speed;
    private float isscale=1;

    public GameObject[] hearts;
    private int life = 3;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            PlayerController playercontroller = collision.gameObject.GetComponent<PlayerController>();
            life--;
            // Destroy(gameObject);
            if (life == 2)
            {
                Destroy(hearts[0].gameObject);
            }
            else if (life == 1)
            {
                Destroy(hearts[1].gameObject);
            }
            else if (life == 0)
            {
                Destroy(hearts[2].gameObject);
                playercontroller.KillPlayer();
            }

        }
        if (collision.gameObject.CompareTag("colliderforenemy"))
        {
            Vector3 scale = transform.localScale;
            scale.x = -1 * scale.x;
            transform.localScale = scale;
            isscale = scale.x;
        }

    }
    //move enemy
    private void MoveEnemy()
    {
        //code for moving character
        Vector3 position = transform.position;
        position.x += isscale*speed * Time.deltaTime;
        transform.position = position;

    }
    private void Update()
    {
        MoveEnemy();
       
    }
}
