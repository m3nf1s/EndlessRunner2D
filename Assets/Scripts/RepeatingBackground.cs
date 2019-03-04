using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public GameObject prefabBackground; // префаб для генерации Background
    public GameObject startBackground; // Background относительно которого будет происходить генерация 
    public Transform Player; // позиция игрока

    private float colliderXLength; // длина Background    
    private float colliderXPosition; // позиция Background по X
    [SerializeField]
    private List<GameObject> currentBackgrounds = new List<GameObject>(); // список Background

    // Start is called before the first frame update
    void Start()
    {
        colliderXPosition = transform.position.x;
        colliderXLength = GetComponentInChildren<BoxCollider2D>().bounds.size.x;

        currentBackgrounds.Clear();

        currentBackgrounds.Add(startBackground);

        GenerationBackground();
    }

    void Update()
    {
        if (!GameManager.instance.gameOver)
            BackgroundCheker();
    }

    /// <summary>
    /// Генератор Background
    /// </summary>
    void GenerationBackground()
    {
        GameObject background = Instantiate(prefabBackground, transform);

        colliderXPosition += colliderXLength;

        background.transform.position = new Vector3(colliderXPosition, 0, 0);

        currentBackgrounds.Add(background);
    }

    /// <summary>
    /// Уничтожение Background
    /// </summary>
    void DestroyBackground()
    {
        Destroy(currentBackgrounds[0]);
        currentBackgrounds.RemoveAt(0);
    }

    /// <summary>
    /// Проверка на создание новых или удаление не нужных Backgrounds
    /// </summary>
    public void BackgroundCheker()
    {
        if(Player.transform.position.x > colliderXPosition - colliderXLength / 2)
            GenerationBackground();

        if(Player.transform.position.x - currentBackgrounds[0].transform.position.x > colliderXLength)
            DestroyBackground();
    }
}
