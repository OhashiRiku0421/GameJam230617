using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
public class GimmickPortal : MonoBehaviour
{
    [SerializeField] List<GameObject> _portalPrefab;
    [SerializeField] Sprite _sprite;
    private void Start()
    {
        foreach (var portal in _portalPrefab)
        {
            var collider = portal.GetComponent<Collider2D>();
            collider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            // ポータルからランダムに選択
            int randomIndex = Random.Range(0, _portalPrefab.Count);
            GameObject selectedPortal = _portalPrefab[randomIndex];

            // プレイヤーの位置を保存してから移動処理
            var player = other.transform;
            Vector3 playerPosition = player.position;
            Debug.Log(player.gameObject);
            // プレイヤーを非表示
            player.gameObject.SetActive(false);

            // ポータルのコライダーを一時的に無効化
            var portalCollider = selectedPortal.GetComponent<Collider2D>();
            portalCollider.enabled = false;
            var portalCollar = selectedPortal.GetComponent<SpriteRenderer>();
            portalCollar.sprite = _sprite;
            
            // ポータルから選択したポータルへの移動
            player.position = selectedPortal.transform.position;

            // プレイヤーを再表示
            player.gameObject.SetActive(true);
            
            
        }
        
    }
}