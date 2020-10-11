using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpotlightFieldOfView))]
public class SpotlightFieldOfViewEditor : Editor
{
    void OnSceneGUI()
    {
        SpotlightFieldOfView cov = (SpotlightFieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(cov.transform.position, Vector3.forward, Vector3.up, 360, cov.viewRadius);
        Vector3 viewAngleA = cov.DirectionFromAngle(-cov.viewAngle / 2, false);
        Vector3 viewAngleB = cov.DirectionFromAngle(cov.viewAngle / 2, false);

        Handles.DrawLine(cov.transform.position, cov.transform.position + viewAngleA * cov.viewRadius);
        Handles.DrawLine(cov.transform.position, cov.transform.position + viewAngleB * cov.viewRadius);

        Handles.color = Color.green;
        foreach (Transform visibleTarget in cov.visibleTargets)
        {
            Handles.DrawLine(cov.transform.position, visibleTarget.transform.position);

        }

    }
}
