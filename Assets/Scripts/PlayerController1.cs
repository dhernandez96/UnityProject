using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{
    public float speed = 0.01f;
    public float jumpForce;

    //Vectors to store original position and scale
    Vector3 originalPos;
    Vector3 originalScale;

    private Rigidbody2D rb2d;
    private int totalJumps = 1;
    private int jumpsRemaining;
    private SpriteRenderer spriteRenderer;

    //health for Mario
    private int health = 2;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        rb2d = this.GetComponent<Rigidbody2D>();
        jumpsRemaining = totalJumps;

        //Original Scale and Original Position get stored in two separate vectors for later use
        originalScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // When the player presses the right arrow key, MoveRight().
        // When the player presses the left arrow key, MoveLeft().
        // When the player presses the up arrow key, Jump().

        var rightIsPressed = Input.GetKey(KeyCode.RightArrow);
        var leftIsPressed = Input.GetKey(KeyCode.LeftArrow);
        var upIsPressed = Input.GetKey(KeyCode.UpArrow);
        var xIsPressed = Input.GetKeyDown(KeyCode.X);
        var cIsPressed = Input.GetKeyDown(KeyCode.C);
        
        if(cIsPressed)
        {
            SceneManager.LoadScene(sceneName:"Sources");
        }       

        if(xIsPressed)
        {
            SceneManager.LoadScene(sceneName:"Scene 2");
        }

        if (rightIsPressed)
            MoveRight();
        else if (leftIsPressed)
            MoveLeft();

        if (upIsPressed)
            Jump();
    }

    private void MoveRight()
    {
        // Movement
        // newPosition = currentPosition + speed * time
        var currentPosition = this.gameObject.GetComponent<Transform>().position;
        var time = UnityEngine.Time.deltaTime;
        var offset = Vector3.right * speed * time;

        var newPosition = currentPosition + offset;
        this.gameObject.GetComponent<Transform>().position = newPosition;

        // Graphics
        if (spriteRenderer.flipX != false)
            spriteRenderer.flipX = false;
    }

    private void MoveLeft()
    {
        // Movement
        // newPosition = currentPosition + speed * time
        var currentPosition = this.gameObject.GetComponent<Transform>().position;
        var time = UnityEngine.Time.deltaTime;
        var offset = Vector3.left * speed * time;

        var newPosition = currentPosition + offset;
        this.gameObject.GetComponent<Transform>().position = newPosition;

        // Graphics
        if (spriteRenderer.flipX != true)
            spriteRenderer.flipX = true;
    }

    //Function doing the Jumping for Player
    void Jump()
    {
        if (jumpsRemaining > 0)
        {
            rb2d.velocity += Vector2.up * jumpForce;
            jumpsRemaining -= 1;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Player collides with Hammer Bros then Player will scale down and turn red
        //Player will lose 1 life
        if (col.gameObject.name == "HammerBro1" || col.gameObject.name == "HammerBro2")
        {
            this.gameObject.transform.localScale -= new Vector3(0.0823f, 0.1013f, 0);
            this.spriteRenderer.color = Color.red;
            health -= 1;
        }

        //Player jumps on Ground, Platform, QuestionBlock then jumps reset
        if (col.gameObject.name == "Ground" ||
            col.gameObject.name == "Platform")
        {
            jumpsRemaining = totalJumps;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        //Resets color of Player back to white after collision with either Hammer Bro
        //If lives =  0, lives reset and Player position/scale will reset

        if (col.gameObject.name == "HammerBro1" || col.gameObject.name == "HammerBro2")
        {
            this.spriteRenderer.color = Color.white;
            if (health == 0)
            {
                this.gameObject.transform.position = originalPos;
                this.gameObject.transform.localScale = originalScale;
                health = 2;
            }
        }
    }
}
