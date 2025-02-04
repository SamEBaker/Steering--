using UnityEngine;

public class ObstacleAvoid : Seek
{
    public float avoidDist = 50f;
    public float lookAhead = 20f;

    protected override Vector3 getTargetPosition()
    {
        RaycastHit hit;
        // collision = getCollision(character.transform.position, ray)

        if (Physics.Raycast(character.transform.position, character.linearVelocity, out hit, lookAhead))
        {
            return hit.point + (hit.normal * avoidDist);
            //target = collision.position + collision.normal * avoidDist;
        }
        else
        {
            return base.getTargetPosition();
            // return Vector3.zero;
        }
        

    }

}
