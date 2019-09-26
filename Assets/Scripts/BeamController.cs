using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    public GameObject beam;
    private Transform beamTransform;

    void Start() {
        beamTransform = beam.GetComponent<Transform>();
    }

    public void FireBeam() {

    }
}
