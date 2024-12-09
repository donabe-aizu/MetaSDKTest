using Meta.XR.MRUtilityKit;
using UnityEngine;

public class DestructibleGlobalMeshTest : MonoBehaviour
{
    [SerializeField] 
    private MRUK mruk;
    [SerializeField]
    private DestructibleGlobalMeshSpawner _globalMeshSpawner;

    private void Start()
    {
        _globalMeshSpawner.OnDestructibleMeshCreated.AddListener(_ =>
        {
            Debug.Log("mesh created");
            MRUKRoom room = mruk.GetCurrentRoom();
            if (_globalMeshSpawner.TryGetDestructibleMeshForRoom(room,out var globalMesh))
            {
                Debug.Log($"mesh: {globalMesh.DestructibleMeshComponent.GetDestructibleMeshSegmentsCount()}");
                
                foreach (var mesh in globalMesh.DestructibleMeshComponent.transform.GetComponentsInChildren<Transform>())
                {
                    if(mesh == globalMesh.DestructibleMeshComponent.transform)continue;
                    mesh.gameObject.AddComponent<MeshCollider>();
                }
            }
        });
    }
}