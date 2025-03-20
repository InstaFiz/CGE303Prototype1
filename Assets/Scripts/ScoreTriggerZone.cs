using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    bool active = true;

    public AudioClip collectSound;
    private AudioSource playerAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Player")
        {
            active = false;
            ScoreManager.score++;
            GetComponent<Renderer>().enabled = false;
            playerAudio.PlayOneShot(collectSound, 1.0f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
