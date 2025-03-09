using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private int count;
    public int lives;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI livesText;

    public bool isGameActive;

    public Button startButton;

    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button backButton;

    public GameObject powerUp;
    private float spawnRangex = 20;
    private float timer = 10f; // ��ʱ����ʼֵΪ5��
    public float lifetime = 5f; // ���ߵ�����ʱ��

    // Start is called before the first frame update
    void Start()
    {
        //startButton = GetComponent<Button>();
        //startButton.onClick.AddListener(StartGame);
        StartGame();
    }
    public void StartGame()
    {
        isGameActive = true;
        lives = 5;
        count = 0;
        UpdateCount(0);
        UpdateLive(0);

        UnityEngine.Cursor.lockState = CursorLockMode.Locked; // ������굽��Ļ����
        //��ֹ ����Ӱ�� ��ͷ��ת
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
         StartCoroutine(SpawnItem());
    }

    // ���ɵ��ߵ�Э��
    IEnumerator SpawnItem()
    {
        while (true)
        {
            if (isGameActive)
            {
                // ���ɵ���
                GameObject item = Instantiate(powerUp, GenerateSpawnPosition(), powerUp.transform.rotation);
                // �ȴ���������ʱ�����
                yield return new WaitForSeconds(lifetime);
                // ���ٵ���
                Destroy(item);
                // �ȴ����ɼ��ʱ��
                yield return new WaitForSeconds(timer - lifetime);
            }
        }
    }

    public Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangex, spawnRangex);
        float spawnPosZ = Random.Range(25, 40);
        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void UpdateCount(int num)
    {
        if (isGameActive)
        {
            count += num;
            countText.text = "Count:" + count;
        }
        
    }

    public void UpdateLive(int num)
    {
        if (isGameActive)
        {
            lives -= num;
            livesText.text = "Lives:" + lives;
        }
    }
    public void GameOver()
    {
        if (MenuManager.Instance.bestScore < count)
        {
            MenuManager.Instance.SaveName(count);
        }
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        UnityEngine.Cursor.lockState = CursorLockMode.None;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BackGame()
    {
        SceneManager.LoadScene(0);
    }
}
