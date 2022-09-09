using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    protected int currentLevel;
    protected int saveScore;
    protected int lives;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        this.saveScore = 0;
        this.lives = 3;

        LoadLevel(1);
    }
     
    void LoadLevel(int levelA)
    {
        currentLevel = levelA;

        // TODO: Check the level structure
        //SceneManager.LoadScene("string" + integer);
    }
}
