using UnityEngine;

public class Wanderer : Kinematic
{

    Wander myMoveType;
    Face mySeekRotateType;
    LookWhereGoing myFleeRotateType;

    public bool flee = false;
    public float rate = 10f;
    public float radius = 30f;
    public float maxAcceleration = 3f;
    public float offset = 15f;

    // Start is called before the first frame update
    void Start()
    {

        myMoveType = new Wander();
        myMoveType.character = this;
       myMoveType.target = myTarget;
        myMoveType.wanderOffset = offset;
        myMoveType.wanderRadius = radius;
        myMoveType.wanderRate = rate;
        myMoveType.maxAcceleration = maxAcceleration;


        mySeekRotateType = new Face();
        mySeekRotateType.character = this;
        mySeekRotateType.target = myTarget;

        myFleeRotateType = new LookWhereGoing();
        myFleeRotateType.character = this;
        myFleeRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = flee ? myFleeRotateType.getSteering().angular : mySeekRotateType.getSteering().angular;
        base.Update();
    }
}