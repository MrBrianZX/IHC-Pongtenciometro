using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadIncial;
    [SerializeField] private float velocityMultiplier;

    private Rigidbody2D ballRB;
    private bool isBallMoving = false;
    
    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {   
        if(Jugador.buttonDuino() && !isBallMoving){
            transform.parent = null;
            ballRB.velocity = velocidadIncial;
            isBallMoving = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Block")){
            Destroy(collision.gameObject);
            ballRB.velocity *= velocityMultiplier;
            GameManager.Instance.BlockDestroyed();
        }
    }
}
