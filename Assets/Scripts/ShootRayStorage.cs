using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ShootRay {

    public Vector3 origin;
    public Vector3 dir;
    public float range;

    public ShootRay(Vector3 origin, Vector3 dir, float range) {
        this.origin = origin;
        this.dir = dir;
        this.range = range;
    }
}

public static class ShootRayStorage {

    public static ArrayList shootRays;

    static ShootRayStorage() {
        shootRays = new ArrayList();
    }

    public static void SaveRay(Vector3 origin, Vector3 dir, float range) {
        shootRays.Add(new ShootRay(origin, dir, range));
        // Debug.Log("Ray saved: " + shootRays.Count);
    }

    public static void PopRay() {
        shootRays.RemoveAt(0);
        // Debug.Log("Ray popped: " + shootRays.Count);
    }
    
}
