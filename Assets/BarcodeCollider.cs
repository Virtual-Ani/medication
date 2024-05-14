using UnityEngine;
using Vuforia;

public class BarcodeCollider : MonoBehaviour
{
    BarcodeBehaviour mBarcodeBehaviour;
    MeshCollider mMeshCollider;
    public GameObject clova;
    public Transform createPos;
    public int clovacnt= 0;


    void Start()
    {
        mBarcodeBehaviour = GetComponent<BarcodeBehaviour>();
        if (mBarcodeBehaviour != null)
        {
            mBarcodeBehaviour.OnBarcodeOutlineChanged += OnBarcodeOutlineChanged;
        }
    }

    void OnBarcodeOutlineChanged(Vector3[] vertices)
    {
        UpdateMeshCollider(vertices);
    }

    void UpdateMeshCollider(Vector3[] vertices)
    {
        if (!mMeshCollider)
        {
            mMeshCollider = gameObject.AddComponent<MeshCollider>();
            mMeshCollider.cookingOptions = MeshColliderCookingOptions.None;
        }

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 }; // Creates 2 triangles

        mMeshCollider.sharedMesh = mesh;
    }

    private void Update()
    {
        if (mBarcodeBehaviour != null && mBarcodeBehaviour.InstanceData != null)
        {
            Debug.Log(mBarcodeBehaviour.InstanceData.Text);
            if(clovacnt == 0)
            {
                Instantiate(clova, createPos.transform.position, createPos.transform.rotation);
                clovacnt++;
            }
        }
    }
}