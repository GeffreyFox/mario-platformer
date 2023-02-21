using System;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private GameObject winDisplay;
    private Camera camera;
    private RaycastHit hit;

    private void Awake()
        => camera = Camera.main;

    private void FixedUpdate()
    {
        if (Timer.GameOver)
            return;
        
        var movement = Input.GetAxis("Horizontal");
        camera.transform.position += new Vector3(movement, 0, 0) * 0.2f;

        if (camera.transform.position.x > 205)
        {
            winDisplay.SetActive(true);
            Timer.GameOver = true;
        }
    }
    
}
