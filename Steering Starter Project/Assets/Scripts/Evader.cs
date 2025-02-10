using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evader : Kinematic
{
    Evade myMoveType;
    LookWhereGoing myEvadeRotateType;

    void Start()
    {
        myMoveType = new Evade();
        myMoveType.character = this;
        myMoveType.target = myTarget;

        myEvadeRotateType = new LookWhereGoing();
        myEvadeRotateType.character = this;
        myEvadeRotateType.target = myTarget;
    }

    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = myEvadeRotateType.getSteering().angular;
        base.Update();
    }
}
