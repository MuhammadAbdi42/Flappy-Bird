using System.Numerics;
using System.Collections;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    [SerializeField] public float jumpSpeed;
    [SerializeField] public float freeFallSpeed;
    [SerializeField] public float maxAngle;
    [SerializeField] public float angleAtFreeFallSpeed;
    [SerializeField] public float MinAngle;
    [SerializeField] public float speedAtMinAngleMulitiplierOfFreeFallSpeed;
    [SerializeField] public Sprite[] upFlapSprites;
    [SerializeField] public Sprite[] midFlapSprites;
    [SerializeField] public Sprite[] downFlapSprites;
    public int colorSelected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.isGameRunning = true;
        ColorSelection();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -3.5)
        {
            transform.position = new UnityEngine.Vector3(0, -3.5f, 0);
            GetComponent<Rigidbody2D>().linearVelocity = new UnityEngine.Vector2(0, 0);
        }
        if (GameManager.Instance.isGameRunning)
        {
            Jump();
            FlapOrientation();
            RotationHandler();
        }
        else
        {
            Restart();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.Instance.playHit();
        GameManager.Instance.isGameRunning = false;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        SoundManager.Instance.playScore();
        GameManager.Instance.AddScore();
    }
    void ColorSelection()
    {
        colorSelected = Random.Range(0, upFlapSprites.Length);
        GetComponent<SpriteRenderer>().sprite = midFlapSprites[colorSelected];
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.Instance.playJump();
            GetComponent<Rigidbody2D>().linearVelocity = new UnityEngine.Vector2(GetComponent<Rigidbody2D>().linearVelocityX, 0);
            GetComponent<Rigidbody2D>().linearVelocity += UnityEngine.Vector2.up * jumpSpeed;
        }
    }
    public void Restart()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.Instance.playMenuTransition();
            GameManager.Instance.RestartTheGame();
        }
    }
    void FlapOrientation()
    {
        if (GetComponent<Rigidbody2D>().linearVelocityY > 0)
        {
            GetComponent<SpriteRenderer>().sprite = upFlapSprites[colorSelected];
        }
        else if (GetComponent<Rigidbody2D>().linearVelocityY < 0 && GetComponent<Rigidbody2D>().linearVelocityY > freeFallSpeed)
        {
            GetComponent<SpriteRenderer>().sprite = midFlapSprites[colorSelected];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = downFlapSprites[colorSelected];
        }
    }
    void RotationHandler()
    {
        float angle;
        if (GetComponent<Rigidbody2D>().linearVelocityY >= 0)
        {
            angle = maxAngle * GetComponent<Rigidbody2D>().linearVelocityY / (UnityEngine.Vector2.up * jumpSpeed).magnitude;
        }
        else if (GetComponent<Rigidbody2D>().linearVelocityY >= freeFallSpeed)
        {
            angle = angleAtFreeFallSpeed * GetComponent<Rigidbody2D>().linearVelocityY / freeFallSpeed;
        }
        else if (GetComponent<Rigidbody2D>().linearVelocityY >= freeFallSpeed * speedAtMinAngleMulitiplierOfFreeFallSpeed)
        {
            angle = angleAtFreeFallSpeed + ((MinAngle - angleAtFreeFallSpeed) * ((GetComponent<Rigidbody2D>().linearVelocityY - freeFallSpeed) / (freeFallSpeed * speedAtMinAngleMulitiplierOfFreeFallSpeed - freeFallSpeed)));
        }
        else
        {
            angle = MinAngle;
        }
        transform.eulerAngles = new UnityEngine.Vector3(0, 0, angle);
    }
}
