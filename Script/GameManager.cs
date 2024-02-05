using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel, GameWinPanel;
    public GameObject Parent , player;
    public GameObject[] Rings;
    private float yPos;
    public float Distance = 3f;
    private Vector3 Point;
    private Vector3 Diffpoint;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        int ring = PlayerPrefs.GetInt("Ring", 10);
        for(int i = 0; i < ring; i++)
        {
            if (i == 0)
            {
                RingGanarate(0);
            }
            else
            {
                RingGanarate(Random.Range(1 , Rings.Length - 1));
            }
        }
        RingGanarate(Rings.Length - 1);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Point = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Diffpoint = Point - Input.mousePosition;
            player.transform.Rotate(new Vector3(0, Diffpoint.x * Time.deltaTime * 20, 0));
            Point = Input.mousePosition;
        }
    }
    public void RingGanarate(int index)
    {
        GameObject GG = Instantiate(Rings[index], new Vector3(transform.position.x, yPos, transform.position.z), Quaternion.identity, Parent.transform);
        yPos -= Distance;
    }
    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }
    public void GameWin()
    {
        SceneManager.LoadScene(0);
        int ring = PlayerPrefs.GetInt("Ring", 10);
        ring++;
        PlayerPrefs.SetInt("Ring", ring);
    }
}