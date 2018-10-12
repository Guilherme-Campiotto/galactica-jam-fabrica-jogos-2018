using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour {

    public bool paddleActive;
    public int speed;

	void Update () {
        InputControls();
    }

    /**
     * Controle das raquetes. Movimentação e troca. 
     */
    void InputControls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangePaddleActive();
        }

        if (paddleActive)
        {
            float direction = Input.GetAxisRaw("Horizontal");
            CheckMovementBlock(direction);
        }
    }

    /**
     * Limita a movimentação das raquetes para não ultrapassar os limites da tela.
     */

    void CheckMovementBlock(float diretion)
    {
        float nextPosX = Mathf.Abs((new Vector2(diretion, 0) * speed * Time.deltaTime).x + transform.position.x);

        if (nextPosX > -5.47f && nextPosX < 5.7f)
        {
            transform.Translate(new Vector2(diretion, 0) * speed * Time.deltaTime);
        }
    }

    /**
     * Muda o controle da raquete, fazendo a outra ficar inativa(sem controle, colisão desativada e transparente).
     */
    void ChangePaddleActive()
    {
        Color color = this.GetComponent<SpriteRenderer>().color;
        if (paddleActive)
        {
            color.a = 0.2f;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            color.a = 1.0f;
            this.GetComponent<BoxCollider2D>().enabled = true;
        }

        paddleActive = !paddleActive;
        this.GetComponent<SpriteRenderer>().color = color;
    }
}
