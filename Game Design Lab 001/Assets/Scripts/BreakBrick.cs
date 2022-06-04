using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBrick : MonoBehaviour
{
    private bool brickBroken = false; //boolean to indicate if brick has been broken, starts false
    public GameObject brickDebris; // reference to the debris prefab
    // Sound Effects
    private AudioSource brickAudioSource;

    private void Start()
    {
        // brick sound effect
        brickAudioSource = GetComponent<AudioSource>();
        Debug.Log(brickAudioSource);
    }

    void OnTriggerEnter2D(Collider2D col) // OnTriggerCallback
    {
        if (col.gameObject.CompareTag("Player") && !brickBroken) //if breakable brick collides with "Player" and 
        {
            brickAudioSource.PlayOneShot(brickAudioSource.clip);
            brickBroken = true; //the brick is now broken
            // assume we have 5 debris per box
            for (int x = 0; x < 5; x++)
            {
                Instantiate(brickDebris, transform.position, Quaternion.identity); //instantiate the brickDebris prefab at the brick's position
            }
            gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled = false; //disable the sprite renderer of the parent which is the one with Breakable Brick sprite renderer
            gameObject.transform.parent.GetComponent<BoxCollider2D>().enabled = false; //disable box collider 2D of breakable brick
            GetComponent<EdgeCollider2D>().enabled = false; //disable own edge collider
        }
    }
}
