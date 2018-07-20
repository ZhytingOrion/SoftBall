using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    public int score = 100;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Ball")
        {
            ScoreManager.Instance.AddScore(score);
            Destroy(collision.gameObject);
        }
    }
}
