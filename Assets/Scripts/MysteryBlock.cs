using System.Collections;
using UnityEngine;

public class MysteryBlock : MonoBehaviour
{
    [SerializeField] private GameObject coinGO;
    
    public static MysteryBlock Instance;
    
    private Material material;
    private bool coroutineIsRunning;
    private float time = 0.4f;
    private float currentOffset = 0;

    private void Awake()
    {
        Instance = this;
        material = GetComponent<MeshRenderer>().material;
        coroutineIsRunning = false;
    }

    private void Update()
    {
        if (!coroutineIsRunning)
        {
            coroutineIsRunning = true;
            StartCoroutine(MysteryBlockAnimation());
        }
    }

    private IEnumerator MysteryBlockAnimation()
    {
        material.mainTextureOffset += new Vector2(0, -0.2f);
        currentOffset += 0.2f;
        
        if (currentOffset >= 1)
            currentOffset = 0;

        yield return new WaitForSeconds(time);
        time = currentOffset == 0 ? 0.4f : 0.15f;
        coroutineIsRunning = false;
    }
    
    private IEnumerator CoinCollectionAnimation(GameObject coin)
    {
        coin.GetComponent<Rigidbody>().AddForce(Vector3.up * 500);
        yield return new WaitForSeconds(0.2f);
        Destroy(coin);
    }

    internal void OnHit(Vector3 position)
    {
        var coin = Instantiate(coinGO, position + new Vector3(0, 1f, 0), Quaternion.identity);
        StartCoroutine(CoinCollectionAnimation(coin));
    }
}
