using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

    public GameObject pointsPanel;
    public GameObject gameOverPanel;

    public Sprite levelOneSprite;
    public Sprite levelTwoSprite;
    public Sprite levelThreeSprite;
    public Sprite levelFourSprite;
    public Sprite levelFiveSprite;
    public Sprite levelSixSprite;
    public Sprite levelSevenSprite;
    public Sprite levelEightSprite;

    private Rigidbody2D ballRigidBody;
    public static int pointsToIncreaseDificult = 80;
    public static int pointsCurrentLevel = 0;

    public AudioClip ballHit;
    public AudioSource audioSource;

    void Start () {
        ballRigidBody = GetComponent<Rigidbody2D>();
        Invoke( "KickBall", 2.0f);
    }

    void Update()
    {
        KeepBallInicialSpeed();
    }

    /**
     * Mantem a bola na mesma velocidade do inicio do jogo.
     */
    void KeepBallInicialSpeed()
    {
        if (ballRigidBody.velocity.y > -5.0f && ballRigidBody.velocity.y < 0f)
        {
            Vector2 vel;
            vel.x = ballRigidBody.velocity.x;
            vel.y = -5.0f;
            ballRigidBody.velocity = vel;
        }

        if (ballRigidBody.velocity.y < 5.0f && ballRigidBody.velocity.y > 0f)
        {
            Vector2 vel;
            vel.x = ballRigidBody.velocity.x;
            vel.y = 5.0f;
            ballRigidBody.velocity = vel;
        }
    }

    /**
     * Aplica a força inicial na bola para ela se movimentar.
     */
    void KickBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            ballRigidBody.AddForce(new Vector2(30, -25));
        }
        else
        {
            ballRigidBody.AddForce(new Vector2(-30, -25));
        }
    }

    /**
     * No restart do jogo posiciona a bola novamente no ponto 0.
     */
    void ResetBall()
    {
        ballRigidBody.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    /**
     * Aumenta a pontuação se a bola for rebatida e verifica a pontuação atual para aumentar a dificuldade do jogo.
     */
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            audioSource.PlayOneShot(ballHit);
            Vector2 vel;
            vel.x = (ballRigidBody.velocity.x) + (other.collider.attachedRigidbody.velocity.x / 3);
            vel.y = ballRigidBody.velocity.y;
            ballRigidBody.velocity = vel;
            GameController.points += 10;
            pointsCurrentLevel += 10;
            if (pointsCurrentLevel >= pointsToIncreaseDificult && GameController.currentLevel < 8)
            {
                pointsCurrentLevel = 0;
                GameController.currentLevel += 1;
                ChangeDificult();
            }
        }
    }

    /**
     * Posiciona uma nova bola ao perder e remove uma vida. Caso o jogador esteja sem vidas chama a tela de fim de jogo.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GameOver") && GameController.lives > 0)
        {
            GameController.lives -= 1;
            Invoke("ResetBall", 1.0f);
            Invoke("KickBall", 3.0f);
        }
        else
        {
            GameOverScreen();
        }
    }

    /**
     * Ativa a tela de fim de jogo.
     */
    public void GameOverScreen()
    {
        pointsPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    /**
     * Aumenta a dificuldade do jogo, trocando de planeta e aumentando a velocidade.
     */
    public void ChangeDificult()
    {
        switch (GameController.currentLevel)
        {
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = levelOneSprite;
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = levelTwoSprite;
                break;
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = levelThreeSprite;
                break;
            case 4:
                this.GetComponent<SpriteRenderer>().sprite = levelFourSprite;
                break;
            case 5:
                this.GetComponent<SpriteRenderer>().sprite = levelFiveSprite;
                break;
            case 6:
                this.GetComponent<SpriteRenderer>().sprite = levelSixSprite;
                break;
            case 7:
                this.GetComponent<SpriteRenderer>().sprite = levelSevenSprite;
                break;
            case 8:
                this.GetComponent<SpriteRenderer>().sprite = levelEightSprite;
                break;
        }

        Vector2 vel;
        vel.x = ballRigidBody.velocity.x;
        if (ballRigidBody.velocity.y < 0)
        {
            vel.y = ballRigidBody.velocity.y - 1.0f;
        }
        else
        {
            vel.y = ballRigidBody.velocity.y + 1.0f;
        }

        ballRigidBody.velocity = vel;
    }
}
