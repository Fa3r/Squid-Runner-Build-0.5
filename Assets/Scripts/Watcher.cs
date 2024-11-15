using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watcher : MonoBehaviour
{   
    [SerializeField] private float rotationSpeed;

    private GameObject watcherObject;

    public GameManager gameManager;

    public bool isWatching { get; set; }

    void Start()
    {
        watcherObject = this.gameObject;
        gameManager = FindObjectOfType<GameManager>();
        gameManager.watcher = GetComponent<Watcher>();
    }

    void FixedUpdate()
    {
        if(!gameManager.defeat && !gameManager.finish && gameManager.UImanager.UIState == 1)        // If the game is in the game mode the watcher will stay still
        rotate();
    }

    void rotate()
    {
        float time = Time.time;

        if (gameManager.green)      //Rotates the head depending on the current bool methode
        {
            Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, gameManager.currentCharacter.transform.position - watcherObject.transform.position);
            desiredRotation = Quaternion.Euler(0, -90, 0);
            watcherObject.transform.rotation = Quaternion.RotateTowards(watcherObject.transform.rotation, desiredRotation, rotationSpeed );
        }
        else
        {
            Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, (watcherObject.transform.position + Vector3.forward) - watcherObject.transform.position);
            desiredRotation = Quaternion.Euler(0, 90, 0);
            watcherObject.transform.rotation = Quaternion.RotateTowards(watcherObject.transform.rotation, desiredRotation, rotationSpeed );
        }

        if (watcherObject.transform.eulerAngles.y > 90)     //Gives true or false based on the current rotation    
            isWatching = false;                             
        else                                                
            isWatching = true;
    }
}
