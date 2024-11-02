using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayerSync : NetworkBehaviour
{
    [SerializeField] 
    private Transform head;
    [SerializeField] 
    private Transform leftHand;
    [SerializeField] 
    private Transform rightHand;
    
    private Transform _localPlayerHead;
    private Transform _localLeftHead;
    private Transform _localRightHead;
    
    // PlayerPrefabスポーン時に実行
    public override void OnNetworkSpawn()
    {
        // ローカルのプレイヤーかどうか
        if (IsOwner)
        {
            LocalPlayerSync localPlayerSync = Camera.main.transform.root.GetComponent<LocalPlayerSync>();
            _localPlayerHead = Camera.main.transform;
            _localLeftHead = localPlayerSync.leftHand;
            _localRightHead = localPlayerSync.rightHand;
        }
    }

    private void Update()
    {
        if(!IsOwner) return;
        
        // ローカルの顔の位置に合わせて、NetworkObjectの顔も動かす。
        head.position = _localPlayerHead.position;
        leftHand.position = _localLeftHead.position;
        rightHand.position = _localRightHead.position;
    }
}
