using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] public Sprite[] pipeSprite;
    [SerializeField] public GameObject topPipe;
    [SerializeField] public GameObject bottomPipe;
    [SerializeField] public float pipeMovingSpeed;
    [SerializeField] public float xPositionOfDemolish;
    [SerializeField] public float openingLength;
    [SerializeField] public float minPlace;
    [SerializeField] public float maxPlace;
    private int pipeColorSelected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitialPlace();
        ColorSelection();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameRunning)
        {
            MovePipes();
        }
    }
    private void ColorSelection()
    {
        pipeColorSelected = Random.Range(0, pipeSprite.Length);
        topPipe.GetComponent<SpriteRenderer>().sprite = pipeSprite[pipeColorSelected];
        bottomPipe.GetComponent<SpriteRenderer>().sprite = pipeSprite[pipeColorSelected];
    }
    private void MovePipes()
    {
        topPipe.transform.position = new Vector3(topPipe.transform.position.x + pipeMovingSpeed * Time.deltaTime, topPipe.transform.position.y, topPipe.transform.position.z);
        bottomPipe.transform.position = new Vector3(bottomPipe.transform.position.x + pipeMovingSpeed * Time.deltaTime, bottomPipe.transform.position.y, bottomPipe.transform.position.z);
        if (topPipe.transform.position.x <= xPositionOfDemolish)
        {
            Destroy(gameObject);
        }
    }
    private void InitialPlace()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(minPlace, maxPlace), transform.position.z);
        bottomPipe.transform.localPosition = new Vector3(0, -openingLength, 0);
    }
}
