using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }
    [SerializeField] public AudioClip MenuTransition;
    [SerializeField] public AudioClip Jump;
    [SerializeField] public AudioClip Score;
    [SerializeField] public AudioClip Hit;
    [SerializeField] public AudioClip GameOver;
    [SerializeField] public GameObject MenuTransitionObject;
    [SerializeField] public GameObject JumpObject;
    [SerializeField] public GameObject ScoreObject;
    [SerializeField] public GameObject HitObject;
    [SerializeField] public GameObject GameOverObject;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void playMenuTransition()
    {
        MenuTransitionObject.GetComponent<AudioSource>().clip = MenuTransition;
        MenuTransitionObject.GetComponent<AudioSource>().Play();
    }
    public void playJump()
    {
        JumpObject.GetComponent<AudioSource>().clip = Jump;
        JumpObject.GetComponent<AudioSource>().Play();
    }
    public void playScore()
    {
        ScoreObject.GetComponent<AudioSource>().clip = Score;
        ScoreObject.GetComponent<AudioSource>().Play();
    }
    public void playHit()
    {
        if (GameManager.Instance.dead == false)
        {
            HitObject.GetComponent<AudioSource>().clip = Hit;
            HitObject.GetComponent<AudioSource>().Play();
            GameManager.Instance.dead = true;
        }

    }
    public void playGameOver()
    {
        if (GameManager.Instance.gameOver == false)
        {
            GameOverObject.GetComponent<AudioSource>().clip = GameOver;
            GameOverObject.GetComponent<AudioSource>().Play();
            GameManager.Instance.gameOver = true;
        }
    }
}
