using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfigurator : MonoBehaviour
{
    CharacterJoint[] charJoints;
    Rigidbody[] bodies;
    Rigidbody body;
    [SerializeField] bool enableProjection = true;
    [SerializeField] bool enablePreprocessing = false;
    [SerializeField] float projectionDistance = 0.1f;
    [SerializeField] float projectionAngle = 180f;
    // Start is called before the first frame update
    void Awake()
    {
        bodies = GetComponentsInChildren<Rigidbody>();
        body = GetComponent<Rigidbody>();
        charJoints = GetComponentsInChildren<CharacterJoint>();
        foreach(CharacterJoint element in charJoints)
        {
            element.enableProjection = enableProjection;
            element.enablePreprocessing = enablePreprocessing;
            element.projectionDistance = projectionDistance;
            element.projectionAngle = projectionAngle;
        }
        foreach(Rigidbody element in bodies)
        {
            element.interpolation = RigidbodyInterpolation.Interpolate;
            element.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }
        body.interpolation = RigidbodyInterpolation.Interpolate;
        body.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }


}
