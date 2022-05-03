using System;
using UnityEngine;

public abstract class Enenmy : Entity
{
    // nearest next point to go to;
    private Vector2 target;
    
    
    private void Move()
    {
        throw new NotImplementedException();
    }

    private Waypoint locateNearestWaypoint()
    {
        throw new NotImplementedException();
        return null;
    }
}
