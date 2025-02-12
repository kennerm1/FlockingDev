using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocker : Kinematic
{
    public bool avoidObj = false;
    public GameObject myCohereTarget;
    BlendedSteering mySteering;
    Kinematic[] birds;
    PrioritySteering myAdvancedSteering;

    void Start()
    {
        Separation separate = new Separation();
        separate.character = this;
        GameObject[] goBirds = GameObject.FindGameObjectsWithTag("birds");
        birds = new Kinematic[goBirds.Length - 1];
        int j = 0;

        for (int i = 0; i < goBirds.Length; i++)
        {
            if (goBirds[i] == this)
            {
                continue;
            }

            birds[j++] = goBirds[i].GetComponent<Kinematic>();
        }

        separate.targets = birds;

        LookWhereGoing myRotateType = new LookWhereGoing();
        myRotateType.character = this;

        Separation separation = new Separation();
        separation.character = this;

        Arrive cohere = new Arrive();
        cohere.character = this;
        cohere.target = myCohereTarget;

        mySteering = new BlendedSteering();
        mySteering.behaviors = new BehaviorAndWeight[3];

        mySteering.behaviors[0] = new BehaviorAndWeight();
        mySteering.behaviors[0].behavior = separate;
        mySteering.behaviors[0].weight = 1f; //3

        mySteering.behaviors[1] = new BehaviorAndWeight();
        mySteering.behaviors[1].behavior = cohere;
        mySteering.behaviors[1].weight = 1f; //.5

        mySteering.behaviors[2] = new BehaviorAndWeight();
        mySteering.behaviors[2].behavior = myRotateType;
        mySteering.behaviors[2].weight = 1f;
    }

    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate = mySteering.getSteering();
        base.Update();
    }
}
