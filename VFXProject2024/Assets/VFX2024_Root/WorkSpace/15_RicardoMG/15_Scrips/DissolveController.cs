using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DissolveController : MonoBehaviour
{
    public SkinnedMeshRenderer skinedMesh;
    public float dissolveRate=0.0125f;
    public float refreshRate=0.025f;
    public float dieDelay = 0.2f;

    public VisualEffect VFXGraph;
    private Material[] skinnedMaterials;

    // Start is called before the first frame update
    void Start()
    {
        if (skinedMesh != null) 
        {
            skinnedMaterials = skinedMesh.materials;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DisssolveCo()
    {
        yield return new WaitForSeconds(dieDelay);
        if (VFXGraph != null) 
        {
            VFXGraph.Play();
        }
        if (skinnedMaterials.Length > 0) 
        {
            float counter = 0;
            while (skinnedMaterials[0].GetFloat("_DissolveAmount") > 0) 
            {
                counter += dissolveRate;
                for (int i = 0; i < skinnedMaterials.Length; i++) 
                {
                    skinnedMaterials[i].SetFloat("_DissolveAmount", counter);
                }
                yield return new WaitForSeconds(refreshRate);
            }
        }
    }
}
