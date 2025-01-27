using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BackgroundSlider : MonoBehaviour
{
    [SerializeField] public float CitySlidingSpeed;
    [SerializeField] public float groundSlidingSpeed;
    [SerializeField] public float xPositionOfTrasnport;
    [SerializeField] public GameObject[] cityBackground;
    [SerializeField] public GameObject[] groundBackground;
    [SerializeField] public Sprite[] cityBackgroundSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CityBackgroundSelecting();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Welcome")
        {
            BackgroundSliding();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SoundManager.Instance.playMenuTransition();
                SceneManager.LoadScene("Game");
            }
        }
        else
        {
            if (GameManager.Instance.isGameRunning)
            {
                BackgroundSliding();
            }
        }
    }
    public void BackgroundSliding()
    {
        foreach (GameObject cityBG in cityBackground)
        {
            cityBG.transform.position = new Vector3(cityBG.transform.position.x + CitySlidingSpeed * Time.deltaTime, cityBG.transform.position.y, cityBG.transform.position.z);
            if (cityBG.transform.position.x <= xPositionOfTrasnport)
            {
                cityBG.transform.position = new Vector3(cityBG.transform.position.x + 3 * 21, cityBG.transform.position.y, cityBG.transform.position.z);
            }
        }
        foreach (GameObject groundBG in groundBackground)
        {
            groundBG.transform.position = new Vector3(groundBG.transform.position.x + groundSlidingSpeed * Time.deltaTime, groundBG.transform.position.y, groundBG.transform.position.z);
            if (groundBG.transform.position.x <= xPositionOfTrasnport)
            {
                groundBG.transform.position = new Vector3(groundBG.transform.position.x + 3 * 21, groundBG.transform.position.y, groundBG.transform.position.z);
            }
        }
    }
    public void CityBackgroundSelecting()
    {
        DateTime currentTime = DateTime.Now;
        int currentHour = currentTime.Hour;
        if (currentHour >= 6 && currentHour < 18)
        {
            foreach (GameObject cityBG in cityBackground)
            {
                cityBG.GetComponent<SpriteRenderer>().sprite = cityBackgroundSprite[0];
            }
        }
        else
        {
            foreach (GameObject cityBG in cityBackground)
            {
                cityBG.GetComponent<SpriteRenderer>().sprite = cityBackgroundSprite[1];
            }
        }
    }
}
