using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] public GameObject[] ScoreTMP;
    [SerializeField] public GameObject gameOverUI;
    void Update()
    {
        foreach (GameObject scoreBoard in ScoreTMP)
        {
            scoreBoard.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.score.ToString();
        }
        if (!GameManager.Instance.isGameRunning)
        {
            StartCoroutine(DelayGameOver(0.5f));
        }
    }
    private IEnumerator DelayGameOver(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameOverUI.SetActive(true);
        SoundManager.Instance.playGameOver();
    }
}
