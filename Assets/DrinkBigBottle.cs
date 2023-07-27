using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EvolveGames;

public class Drink : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        _playerController.SetSpeed(10f);
    }
}
