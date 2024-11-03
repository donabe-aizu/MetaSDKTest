using System;
using System.Collections;
using System.Collections.Generic;
using MessagePipe;
using R3;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class UIView : MonoBehaviour
{
    [SerializeField] 
    private Button button;

    [SerializeField] 
    private Text text;
    
    [Inject]
    private readonly IPublisher<Unit> _publisher;

    private void Start()
    {
        var onPush = button.onClick.AsObservable();

        onPush.Subscribe(_publisher.Publish);
    }

    public void ChangeText(int num)
    {
        text.text = num.ToString();
    }
}
