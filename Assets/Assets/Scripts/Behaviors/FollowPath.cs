using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FollowPath : Seek
{

    public int targetPt;
    float targetRadius = 0.5f;
    public GameObject[] myPath;

    public override SteeringOutput getSteering()
    {
        
        if(target == null)
        {
            targetPt = 0;
            target = myPath[targetPt];
        }



        float currPos = (target.transform.position - character.transform.position).magnitude;
        if(currPos  <  targetRadius )
        {
            targetPt++;
            if(targetPt >= myPath.Length )
            {
                targetPt = 0;
            }
            target = myPath[targetPt];
        }
        return base.getSteering();
    }
}
