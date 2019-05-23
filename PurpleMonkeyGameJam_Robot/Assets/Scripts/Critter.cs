using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critter : MonoBehaviour
{
    public int ScorePenalty = 0;
    public bool IsAlive = true;
    public Animator CritterAnimator;

    // Start is called before the first frame update
    void Start()
    {
        IsAlive = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (IsAlive)
        {
            if (collider.tag == "Feet")
            {
                IsAlive = false;
                CritterAnimator.SetBool("DefaulttoDeath", true);
                collider.GetComponentInParent<BotController>().KilledCritter(ScorePenalty);
            }
        }
    }
}
