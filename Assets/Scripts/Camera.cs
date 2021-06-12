using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.6.12
/// follow player
/// </summary>

public class Camera : MonoBehaviour
{
    [Header("props")]
    [Tooltip("detect the player position")]
    [SerializeField]
    Transform player;

    [SerializeField]
    Vector3 camOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + camOffset;
    }
}
