using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CollisionAvoider : Kinematic
{
    CollisionAvoidance myMoveType;
    public Kinematic[] myTargets = new Kinematic[9];

    void Start()
    {

        myMoveType = new CollisionAvoidance();
        myMoveType.character = this;
        myMoveType.targets = myTargets;

    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate = myMoveType.getSteering();
        base.Update();
    }
}
