using System;
using UnityEngine;

public class MachoCollider2 : MonoBehaviour
{
    GameObject ftipml;
    GameObject shoulderml;
    GameObject ftipmr;
    GameObject shouldermr;
    GameObject headm;
    GameObject bipml;
    GameObject bipmr;
    GameObject footml;
    GameObject footmr;

    GameObject cubemla;
    GameObject cubemra;
    GameObject cubemb;
    GameObject cubemll;
    GameObject cubemrl;

    void Start()
    {
        ftipml = GameObject.Find("fingertip_ml2");
        shoulderml = GameObject.Find("shoulder_ml2");
        ftipmr = GameObject.Find("fingertip_mr2");
        shouldermr = GameObject.Find("shoulder_mr2");
        headm = GameObject.Find("head_m2");
        bipml = GameObject.Find("bip_ml2");
        bipmr = GameObject.Find("bip_mr2");
        footml = GameObject.Find("foot_ml2");
        footmr = GameObject.Find("foot_mr2");

        cubemla = GameObject.Find("Cube_mla2");
        cubemra = GameObject.Find("Cube_mra2");
        cubemb = GameObject.Find("Cube_mb2");
        cubemll = GameObject.Find("Cube_mll2");
        cubemrl = GameObject.Find("Cube_mrl2");
    }

    void FixedUpdate()
    {
        cubemla.transform.position = new Vector3(0,  (ftipml.transform.position.y + shoulderml.transform.position.y) / 2, (ftipml.transform.position.z + shoulderml.transform.position.z) / 2);
        cubemla.transform.localScale = new Vector3(1, Math.Max(Math.Abs(ftipml.transform.position.y - shoulderml.transform.position.y), 0.1f), Math.Max(Math.Abs(ftipml.transform.position.z - shoulderml.transform.position.z), 0.12f));
        cubemra.transform.position = new Vector3(0,  (ftipmr.transform.position.y + shouldermr.transform.position.y) / 2, (ftipmr.transform.position.z + shouldermr.transform.position.z) / 2);
        cubemra.transform.localScale = new Vector3(1, Math.Max(Math.Abs(ftipmr.transform.position.y - shouldermr.transform.position.y), 0.1f), Math.Max(Math.Abs(ftipmr.transform.position.z - shouldermr.transform.position.z), 0.12f));
        cubemb.transform.position = new Vector3(0, (headm.transform.position.y + bipml.transform.position.y) / 2, (headm.transform.position.z + bipml.transform.position.z) / 2);
        cubemb.transform.localScale = new Vector3(1, Math.Max(Math.Abs(headm.transform.position.y - bipml.transform.position.y), 0.2f), Math.Max(Math.Abs(headm.transform.position.z - bipml.transform.position.z), 0.2f));
        cubemll.transform.position = new Vector3(0, (bipml.transform.position.y + footml.transform.position.y) / 2, (bipml.transform.position.z + footml.transform.position.z) / 2);
        cubemll.transform.localScale = new Vector3(1, Math.Max(Math.Abs(bipml.transform.position.y - footml.transform.position.y), 0.08f), Math.Max(Math.Abs(bipml.transform.position.z - footml.transform.position.z), 0.08f));
        cubemrl.transform.position = new Vector3(0, (bipmr.transform.position.y + footmr.transform.position.y) / 2, (bipmr.transform.position.z + footmr.transform.position.z) / 2);
        cubemrl.transform.localScale = new Vector3(1, Math.Max(Math.Abs(bipmr.transform.position.y - footmr.transform.position.y), 0.08f), Math.Max(Math.Abs(bipmr.transform.position.z - footmr.transform.position.z), 0.08f));
        Physics.SyncTransforms();
    }
}