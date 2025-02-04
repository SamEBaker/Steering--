using UnityEngine;

public class Evade : Seek
{
    protected override Vector3 getTargetPosition()
    {
        flee = true;
        return base.getTargetPosition();
    }
}
