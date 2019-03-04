using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject PrefabPlatrform; // Префаб для генерации платформ
    public GameObject StartZone; // Платформа на которой начинает игрок 
    public GameObject StartPlatform; // Платформа относительно которой идет генерация других платформ
    public Transform Player; // Позиция игрока
    

    private float PlatformXPosition; // Позиция по Х для генерации платформы
    private float PlatformLength; // Длина платформы
    private const float deleteDistance = 20.0f; // Дистанция для удаления не нужных платформ
    private float Distance = 3.5f; // Переменная отвечающая за дистанцию между генерируемыми платформами

    [SerializeField]
    private List<GameObject> currentPlatforms = new List<GameObject>(); // Список в котором буду храниться существующие платформы
        
    void Start()
    {
        PlatformXPosition = StartPlatform.transform.position.x;
        PlatformLength = StartPlatform.GetComponent<BoxCollider2D>().bounds.size.x;

        currentPlatforms.Clear();

        currentPlatforms.Add(StartZone);
        currentPlatforms.Add(StartPlatform);

        GenerationPlatform();

        StartCoroutine(RandomGenerationDistance(1));
    }

    void Update()
    {
        if(!GameManager.instance.gameOver)
            PlatformCheker();
    }

    /// <summary>
    /// Генератор платформ
    /// </summary>
    void GenerationPlatform()
    {
            GameObject platform = Instantiate(PrefabPlatrform, transform);

            PlatformXPosition = PlatformXPosition + PlatformLength + Distance;

            platform.transform.position = new Vector3(PlatformXPosition, Random.Range(-2.0f, 2.0f), 0);

            currentPlatforms.Add(platform);
    }

    /// <summary>
    /// Уничтожение платформы
    /// </summary>
    void DestroyPlatform()
    {
        Destroy(currentPlatforms[0]);
        currentPlatforms.RemoveAt(0);
    }

    /// <summary>
    /// Проверка на создание новых или удаление не нужных платформ
    /// </summary>
    public void PlatformCheker()
    {
        if (Player.transform.position.x > (PlatformXPosition - PlatformLength * 3))
        {
            GenerationPlatform();
        }

        if (Player.position.x - currentPlatforms[0].transform.position.x > deleteDistance)
        {
            DestroyPlatform();
        }
    }

    /// <summary>
    /// Корутин, который с промежутком времени delay генерирует случайное значение дистанции между платформами
    /// </summary>
    /// <param name="delay">Задержка по времени</param>
    /// <returns>Создание задержки</returns>
    IEnumerator RandomGenerationDistance(float delay)
    {
        while (true)
        {
            Distance = Random.Range(2.5f, 4.0f);
            yield return new WaitForSeconds(delay);
        }
    }
}
