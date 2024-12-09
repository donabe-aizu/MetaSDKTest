using Meta.XR;
using UnityEngine;

public class SceneRaycastTest : MonoBehaviour
{
    [SerializeField] 
    private EnvironmentRaycastManager _raycastManager;

    [SerializeField] 
    private Transform originTransform;

    [SerializeField] private GameObject pointer;

    private Ray _ray;
    
    private void Start()
    {
        _ray = new Ray(originTransform.position, originTransform.forward);
    }

    private void Update()
    {
        _ray.origin = originTransform.position;
        _ray.direction = originTransform.forward;

        if (_raycastManager.Raycast(_ray, out var hit))
        {
            if (hit.status == EnvironmentRaycastHitStatus.Hit)
            {
                //Debug.Log($"hit: {hit.point}, {hit.normal}");
                pointer.transform.position = hit.point;
                pointer.transform.rotation = Quaternion.LookRotation(hit.normal);
            }
        }
    }
}