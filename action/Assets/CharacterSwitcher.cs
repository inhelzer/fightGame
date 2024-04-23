using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwitcher : MonoBehaviour
{
    
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    PlayerInputManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        manager.playerPrefab = player1;
        player1.transform.position = new Vector3(-6.6f, -3.3f, 0);
    }

    public void SwitchNext(PlayerInput input)
    {
        
        manager.playerPrefab = player2;
        player2.transform.position = new Vector3(3.1f, -3.3f, 0);
    }
}
