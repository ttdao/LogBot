using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAlive : MonoBehaviour
{
    bool alive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        //if (this.gameObject.tag == "Body")
        //    Debug.Log(this.gameObject.GetComponentInParent<Transform>().name + " - " + collision2D.otherCollider.gameObject.tag + " " + collision2D.collider.gameObject.tag);

        if (collision2D.otherCollider.gameObject.tag == "Body" && collision2D.collider.gameObject.tag == "FakeGround")
        {
            this.gameObject.GetComponentInParent<BotController>().GameOver();
        }
    }
}
