using System;
using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using UnityEngine;

public class SceneAccess : MonoBehaviour
{
    [SerializeField] 
    private MRUK mruk;

    private void Start()
    {
        mruk.RoomCreatedEvent.AddListener(a =>
        {
            //a.CeilingAnchor
        });
    }
}
