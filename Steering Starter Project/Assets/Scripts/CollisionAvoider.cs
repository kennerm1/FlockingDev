using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoider : Kinematic
{
    CollisionAvoidance myMoveType;
    public Kinematic[] myTargets;

    void Start()
    {
        myMoveType = new CollisionAvoidance();
        myMoveType.character = this;
        myMoveType.target = myTargets;
    }

    protected override void Update()
    {
        //steeringUpdate = new SteeringOutput(); not needed, breaks things
        steeringUpdate = myMoveType.getSteering();
        base.Update();
    }
}
