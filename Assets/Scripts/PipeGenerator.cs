using UnityEditor;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    [SerializeField] public GameObject pipe;
    [SerializeField] public float timeInterval;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameRunning)
        {
            CreatePipe();
        }
    }
    private void CreatePipe()
    {
        timer += Time.deltaTime;
        if (timer >= timeInterval)
        {
            timer = 0;
            Instantiate(pipe, transform.position, transform.rotation);
        }
    }
}
