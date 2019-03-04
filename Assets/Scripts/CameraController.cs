using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraController : MonoBehaviour
{
    public float Distance; // Дистанция для смещения камеры относительно игрока
    public GameObject Player; // Игрок

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x + Distance, transform.position.y,transform.position.z);
    }
}
