using UnityEngine;
using DG.Tweening;
public class Player : MonoBehaviour
{
    public GameObject player;
    public GameObject Splash;
    public float Power;
    public float Radius;


    private void OnCollisionEnter(Collision collision)
    {
        transform.DOMoveY(transform.position.y + 1.3f, 0.3f);
        BollEefect();

        GameObject GG = Instantiate(Splash, new Vector3(this.transform.position.x, collision.transform.position.y + 0.25f, this.transform.position.z), Quaternion.Euler(90, 0, 0));
        GG.transform.parent = collision.transform;
        Destroy(GG, 1f);

        if (collision.gameObject.tag == "Bed")
        {
            GameManager.instance.GameOverPanel.SetActive(true);
        }
        if(collision.gameObject.tag == "Last")
        {
            GameManager.instance.GameWinPanel.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        foreach(Transform child in other.transform)
        {
            child.transform.gameObject.GetComponent<MeshCollider>().convex = true;
            child.transform.gameObject.AddComponent<Rigidbody>();
            child.transform.gameObject.GetComponent<Rigidbody>().AddExplosionForce(Power, transform.position, Radius, 500f);
            Destroy(child.transform.gameObject, 0.8f);
        }
    }
    //private void Update()
    //{
    //    if (this.transform.position.y < Camera.main.transform.position.y - 4)
    //    {
    //        Vector3 Position = new Vector3(Camera.main.transform.position.x, transform.position.y + 4, Camera.main.transform.position.z);
    //        Camera.main.transform.position = Position;
    //    }
    //}
    public void BollEefect()
    {
        Sequence mySequnce = DOTween.Sequence();
        mySequnce.Append(transform.DOScaleX(0.5f, 0.1f));
        mySequnce.Append(transform.DOScaleY(0.5f, 0.1f));
        mySequnce.Append(transform.DOScaleX(0.6f, 0.1f));
        mySequnce.Append(transform.DOScaleY(0.6f, 0.1f));
    }
}