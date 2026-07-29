using UnityEngine;

public class CharSelectManager : MonoBehaviour
{
    [SerializeField] private GameObject scoreCanvas;
    [SerializeField] private GameObject dinoSprite;
    [SerializeField] private GameObject frogSprite;
    void Start()
    {
        Time.timeScale = 0;
    }
    void BeginGame()
    {
        Time.timeScale = 1;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
    public void ChooseDino()
    {
        dinoSprite.SetActive(true);
        BeginGame();
    }
    public void ChooseFrog()
    {
        frogSprite.SetActive(true);
        BeginGame();
    }
    //Course 3 fininshed, yay!
}
