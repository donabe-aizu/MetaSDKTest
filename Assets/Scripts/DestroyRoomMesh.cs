using UnityEngine;

public class DestroyRoomMesh : MonoBehaviour
{
    [SerializeField] private OVRHand _hand;

    private GameObject selectObject;
    
    private void Update()
    {
        if (_hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            if (selectObject==null) return;
            
            Debug.Log("Destroy");
            selectObject.SetActive(false);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("select: " + other.gameObject);
        selectObject = other.gameObject;
    }
}