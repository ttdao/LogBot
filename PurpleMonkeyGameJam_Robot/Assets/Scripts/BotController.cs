using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public Transform RightLeg;
    public Transform LeftLeg;
    public Transform Simulation;
    public string NextStep = "Start";
    public float Speed;
    public bool Alive = true;
    public GameObject GameOverPanel;
    public GameObject LevelCompletePanel;
    public Animator HeadAnimator;
    public float LegImpulse = .05f;
    public float LegConstantForce = .02f;
    public float LegRetractConstant = .06f;
    public float LegMax = 1f;
    public int Score = 0;
    public float YDistanceFromStart = 0;
    public float YStartPosition;
    public int ScorePenalty = 0;
    public Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        YStartPosition = gameObject.transform.position.y;   
        Speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Alive == true)
        {
            ////
            ///Left Leg Pressed
            ///
            if (Input.GetKeyDown(KeyCode.S) == true)
            {
                LeftLeg.localPosition = new Vector3(LeftLeg.localPosition.x, LeftLeg.localPosition.y - LegImpulse, LeftLeg.localPosition.z);

                body.AddForce(new Vector2(.5f, .5f), ForceMode2D.Impulse);

                if (NextStep == "left")
                {
                    Speed += .5f;
                }
                else
                {
                    Speed = 0.0f;
                }

                NextStep = "right";
            }
            else
            {
                if (Input.GetKey(KeyCode.S) == true && RightLeg.localPosition.y < LegMax)
                {
                    LeftLeg.localPosition = new Vector3(LeftLeg.localPosition.x, LeftLeg.localPosition.y - LegConstantForce, LeftLeg.localPosition.z);
                    body.AddForce(new Vector2(.1f, .1f), ForceMode2D.Impulse);
                }
                else if (LeftLeg.localPosition.y < 0)
                {
                    LeftLeg.localPosition = new Vector3(LeftLeg.localPosition.x, LeftLeg.localPosition.y + LegRetractConstant, LeftLeg.localPosition.z);
                    if (LeftLeg.localPosition.y > 0)
                        LeftLeg.localPosition = new Vector3(LeftLeg.localPosition.x, 0f, LeftLeg.localPosition.z);

                }
            }

            ////
            /// Right Leg Pressed
            ///

            if (Input.GetKeyDown(KeyCode.L))
            {
                RightLeg.localPosition = new Vector3(RightLeg.localPosition.x, RightLeg.localPosition.y - LegImpulse, RightLeg.localPosition.z);

                body.AddForce(new Vector2(-.5f, .5f), ForceMode2D.Impulse);

                if (NextStep == "right")
                {
                    Speed += .5f;
                }
                else
                {
                    Speed = 0.0f;
                }

                NextStep = "left";
            }
            else
            {
                if (Input.GetKey(KeyCode.L) == true && RightLeg.localPosition.y < LegMax)
                {
                    RightLeg.localPosition = new Vector3(RightLeg.localPosition.x, RightLeg.localPosition.y - LegConstantForce, RightLeg.localPosition.z);
                    body.AddForce(new Vector2(-.1f, .1f), ForceMode2D.Impulse);
                }
                else if (RightLeg.localPosition.y < 0)
                {
                    RightLeg.localPosition = new Vector3(RightLeg.localPosition.x, RightLeg.localPosition.y + LegRetractConstant, RightLeg.localPosition.z);

                    if (RightLeg.localPosition.y > 0)
                        RightLeg.localPosition = new Vector3(RightLeg.localPosition.x, 0f, RightLeg.localPosition.z);
                }
            }
        }
    }

    public void FixedUpdate()
    {
        Score = (int)(YStartPosition - gameObject.transform.position.y) - ScorePenalty;

        Simulation.position = new Vector3(Simulation.position.x, Simulation.position.y - Speed*Time.deltaTime, Simulation.position.z);
    }


    public void GameOver()
    {
        Speed = 0f;
        Alive = false;
        GameOverPanel.SetActive(true);
        HeadAnimator.SetBool("FallOver", true);
    }

    public void KilledCritter(int myScorePenalty)
    {
        ScorePenalty += myScorePenalty;
    }

    public void YouWin()
    {

    }
}
