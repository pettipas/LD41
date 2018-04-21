using UnityEngine;

[System.Serializable]
public class ProjectileMotion {

    public Vector3 origin; // origin point
    public Vector3 target; // target point

    // parabola has the form y = a*x^2 + b*x
    public float a;
    public float b;
    public float ymax;

    // Physical parameters:
    // x(t) = vx*t
    // y(t) = vy*t - 0.5*g*t^2

    public float g; // gravity in m/s^2
    public float vx; // initial horizontal speed
    public float vy; // initial vertical speed
    public float tmax; // time at imapct

    // relevant vectors:
    public Vector2 PlaneDir; // vector in x-z plane from origin to target
    public Vector2 Target2; // vector mapped in plane of motion

    // creator function:
    public ProjectileMotion(Vector3 o, Vector3 t){
        origin = o;
        target = t;

        // Set up the vectors:
        PlaneDir = new Vector2(target.x-origin.x, target.z-origin.z); // vector in horizontal x-z plane
        Target2 = new Vector2 (PlaneDir.magnitude, target.y-origin.y); // horizontal distance, vertical distance

        g = Mathf.Abs(Physics.gravity.y*2.0f);
    }

    // Sets the parameters by specifying the maximum height:
    public void SetParamsHeight(float maxheight){

        float dx = Target2.x;
        float dy = Target2.y;

        ymax = maxheight;
        b = 2f * (ymax + Mathf.Sqrt (ymax * ymax - dy * ymax) ) / dx;
        a = b * b / (4f * ymax);

        vx = Mathf.Sqrt (g / (2f * a));
        vy = vx * b;

        tmax = dx / vx;
    }

    // Sets the parameters by specifying the initial slope
    public void SetParamsSlope(float slope){

        float dx = Target2.x;
        float dy = Target2.y;

        b = slope;
        a = (b * dx - dy) / (dx * dx);
        ymax = b * b / (4f * a);

        vx = Mathf.Sqrt (g / (2f * a));
        vy = vx * b;

        tmax = dx / vx;
    }

    // Return the position as a function of time:
    public Vector3 GetTimePos(float t){

        float x2 = vx * t; // x position in plane of motion
        float y2 = vy * t - 0.5f*g*t*t; // y position in plane of motion

        // Now that we have the position in this plane, we need to map it into real world space:

        float yr = y2 + origin.y; // actual vertical position.

        float xr = PlaneDir.normalized.x * x2 + origin.x; 
        float zr = PlaneDir.normalized.y * x2 + origin.z;

        return new Vector3(xr, yr, zr);
    }


}

