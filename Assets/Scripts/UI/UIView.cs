using System;
using System.Collections;
using System.Collections.Generic;
using MessagePipe;
using R3;
using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    [SerializeField] 
    private Button button;

    [SerializeField] 
    private Text text;
    
    private readonly IPublisher<Unit> publisher;

    private void Start()
    {
        var onPush = button.onClick.AsObservable();

    }
}
