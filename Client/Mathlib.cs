using System.Numerics;

class Mathlib
{

    public static float Deg2Rad(float x)
    {
        return (float)(x * Math.PI / 180.0);
    }

    public static float Rad2Deg(float x)
    {
        return (float)(x * 180.0 / Math.PI);
    }
    public static (Vector3 forward, Vector3 right, Vector3 up) AngleVectors( Vector3 angles)
    {
        Vector3 forward = new Vector3 (0,0,0), right = new Vector3(0, 0, 0), up = new Vector3(0, 0, 0); 
        double sr, sp, sy, cr, cp, cy;

        (sy, cy) = Math.SinCos(Deg2Rad(angles.Y));
        (sp, cp) = Math.SinCos(Deg2Rad(angles.X));
        (sr, cr) = Math.SinCos(Deg2Rad(angles.Z));

        forward.X = (float)cp * (float)cy;
        forward.Y = (float)cp * (float)sy;
        forward.Z = (float)-sp;
        
        right.X = (-1.0f * (float)sr * (float)sp * (float)cy + -1.0f * (float)cr * (float)-sy);
        right.Y = (-1.0f * (float)sr * (float)sp * (float)sy + -1.0f * (float)cr * (float)cy);
        right.Z = (-1.0f * (float)sr * (float)cp);
        
        up.X = ((float)cr * (float)sp * (float)cy + (float)-sr * (float)-sy);
        up.Y = ((float)cr * (float)sp * (float)sy + (float)-sr * (float)cy);
        up.Z = ((float)cr * (float)cp);
        

        return (forward, right, up);
    }
}