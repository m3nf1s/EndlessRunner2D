using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject PrefabPlatrform;
    public GameObject StartZone;
    public GameObject StartPlatform;
    public float Distance;
    public Transform Player;

    private float PlatformXPosition;
    private float PlatformLength;
    private float deleteDistance = 20.0f;

    [SerializeField]
    private List<GameObject> currentPlatforms = new List<GameObject>();
        
 
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
        PlatformCheker();
    }

    /// <summary>
    /// 
    /// </summary>
    void GenerationPlatform()
    {
            GameObject platform = Instantiate(PrefabPlatrform, transform);

            PlatformXPosition = PlatformXPosition + PlatformLength + Distance;

            platform.transform.position = new Vector3(PlatformXPosition, Random.Range(-2.0f, 2.0f), 0);

            currentPlatforms.Add(platform);
    }

    /// <summary>
    /// Проверка на создание новых или удаление не нужных платформ
    /// </summary>
    void PlatformCheker()
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
    /// Уничтожение платформы
    /// </summary>
    void DestroyPlatform()
    {
        Destroy(currentPlatforms[0]);
        currentPlatforms.RemoveAt(0);
    }
    
    /// <summary>
    /// Корутин, который с промежутком времени delay генерирует случайное значение дистанции
    /// </summary>
    /// <param name="delay">Задержка по времени</param>
    /// <returns>Создание задержки</returns>
    IEnumerator RandomGenerationDistance(float delay)
    {
        while (true)
        {
            Distance = Random.Range(1.0f, 2.0f);
            yield return new WaitForSeconds(delay);
        }
    }

    public void SceneSetup()
    {

    }
}
