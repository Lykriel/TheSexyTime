﻿using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (Actions))]

public class AttackRangeEditor : Editor {

    private void OnSceneGUI()
    {
        Actions fow = (Actions)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);
        Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle / 2, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);

        Handles.color = Color.red;
        foreach (GameObject visibleTargets in fow.visibleTargets)
        {
            Handles.DrawLine(fow.transform.position, visibleTargets.transform.position);
        }
    }
}
