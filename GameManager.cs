using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Character[] characters; // Opsional jika ingin memilih karakter
    public Character currentCharacter;
    public GameObject playerPrefab;
    public GameObject cameraPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Pilih karakter default jika ada
        if (characters.Length > 0)
        {
            currentCharacter = characters[0];
        }

        SpawnPlayerAndCamera(); // Spawn Player dan Camera di level awal
    }

    public void SpawnPlayerAndCamera()
    {
        // Cek apakah Player sudah ada
        if (FindObjectOfType<Player3>() == null)
        {
            Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }

        // Cek apakah Camera sudah ada
        if (FindObjectOfType<CameraController>() == null)
        {
            GameObject camera = Instantiate(cameraPrefab);
            CameraController cameraController = camera.GetComponent<CameraController>();
            Player3 player = FindObjectOfType<Player3>();

            if (player != null)
            {
                cameraController.target = player.transform;
            }
        }
    }
}
