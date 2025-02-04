using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CollisionAvoidance : SteeringBehavior
{
    public Kinematic character;
    public Kinematic[] targets;
    public float radius = .1f;
    public float maxAccel = 2f;
    public float timeToCollision;

    public float minSepatartion;
    public float firstDist;
    public float FirstminSeparation;
    public override SteeringOutput getSteering()
    {
        float shortestTime = float.PositiveInfinity;

        Kinematic firstTarget = null;
        FirstminSeparation = float.PositiveInfinity;
        firstDist = float.PositiveInfinity;
        Vector3 firstRelativePos = Vector3.positiveInfinity;
        Vector3 firstRelativeVel = Vector3.zero;

        foreach (Kinematic target in targets)
        {
            Vector3 relativePos = target.transform.position - character.transform.position;
            Vector3 relativeVel = target.linearVelocity - character.linearVelocity;
            float relativeSpeed = relativeVel.magnitude;
            timeToCollision = (Vector3.Dot(relativePos, relativeVel) / (relativeSpeed * relativeSpeed));
            float distance = relativePos.magnitude;
            float minSeparation = distance - relativeSpeed * timeToCollision;
            if (minSeparation > 2 * radius)
            {
                continue;
            }

            if (timeToCollision > 0 && timeToCollision < shortestTime)
            {
                shortestTime = timeToCollision;
                firstTarget = target;
                FirstminSeparation = minSeparation;
                firstDist = distance;
                firstRelativePos = relativePos;
                firstRelativeVel = relativeVel;
            }
        }

            if (firstTarget == null)
            {
                return null;
            }
      
        //predictive
        SteeringOutput result = new SteeringOutput();
        float dotResult = Vector3.Dot(character.linearVelocity.normalized, firstTarget.linearVelocity.normalized);
        if(dotResult < -0.9)
        {
            result.linear = -firstTarget.transform.right;
        }
        else
        {
            result.linear = -firstTarget.linearVelocity;
        }
        result.linear.Normalize();
        result.linear *= maxAccel;
        result.angular = 0;
        return result;
    }
}
