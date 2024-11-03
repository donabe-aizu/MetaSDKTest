using MessagePipe;
using UnityEngine;
using VContainer;

public class UIModel
{
    private int _number;
    
    [Inject]
    private readonly IPublisher<int> _publisher;

    public UIModel()
    {
        _number = 0;
    }
    
    public void CountNumber()
    {
        _number++;
        _publisher.Publish(_number);
    }
}