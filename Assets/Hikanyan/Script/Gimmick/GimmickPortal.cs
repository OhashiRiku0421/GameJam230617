using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx.Triggers;

public class GimmickPortal : MonoBehaviour
{
    [SerializeField] List<GameObject> _portalPrefab;

    private void Start()
    {
        foreach (var portal in _portalPrefab)
        {
            var collider = portal.GetComponent<Collider2D>();
            collider.isTrigger = true;

            // プレイヤーがポータルに触れたときの処理をSubscribe
            collider.OnTriggerEnter2DAsObservable()
                .Where(c => c.CompareTag("Player"))
                .Subscribe(_ => OnPlayerEnterPortal(portal))
                .AddTo(portal);
        }
    }

    private void OnPlayerEnterPortal(GameObject portal)
    {
        // ポータルからランダムに選択
        int randomIndex = Random.Range(0, _portalPrefab.Count);
        GameObject selectedPortal = _portalPrefab[randomIndex];

        // プレイヤーの位置を保存してから移動処理を行う
        var player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 playerPosition = player.position;

        // プレイヤーを非表示にする
        player.gameObject.SetActive(false);

        // ポータルから選択したポータルへの移動をTweenで行う
        player.DOMove(selectedPortal.transform.position, 1f)
            .SetEase(Ease.Linear)
            .OnComplete(() => OnPlayerTeleportComplete(player, playerPosition));
    }

    private void OnPlayerTeleportComplete(Transform player, Vector3 originalPosition)
    {
        // プレイヤーを再表示し、元の位置に戻す
        player.gameObject.SetActive(true);
        player.position = originalPosition;
    }
}