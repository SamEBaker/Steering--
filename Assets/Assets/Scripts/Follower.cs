using UnityEngine;

public class Follower : Kinematic
{
    FollowPath myMoveType;
    Face mySeekRotateType;


   public GameObject[] myPath = new GameObject[4];

    void Start()
    {

        myMoveType = new FollowPath();
        myMoveType.character = this;
        myMoveType.myPath = myPath;

        mySeekRotateType = new Face();
        mySeekRotateType.character = this;
        mySeekRotateType.target = myTarget;

    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        base.Update();
    }
}
