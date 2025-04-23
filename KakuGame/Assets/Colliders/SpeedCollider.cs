using System;
using UnityEngine;

public class SpeedCollider : MonoBehaviour
{
    GameObject ftipsl;
    GameObject shouldersl;
    GameObject ftipsr;
    GameObject shouldersr;
    GameObject heads;
    GameObject bipsl;
    GameObject bipsr;
    GameObject footsl;
    GameObject footsr;

    GameObject cubesla;
    GameObject cubesra;
    GameObject cubesb;
    GameObject cubesll;
    GameObject cubesrl;

    void Start()
    {
        ftipsl = GameObject.Find("fingertip_sl");
        shouldersl = GameObject.Find("shoulder_sl");
        ftipsr = GameObject.Find("fingertip_sr");
        shouldersr = GameObject.Find("shoulder_sr");
        heads = GameObject.Find("head_s");
        bipsl = GameObject.Find("bip_sl");
        bipsr = GameObject.Find("bip_sr");
        footsl = GameObject.Find("foot_sl");
        footsr = GameObject.Find("foot_sr");

        cubesla = GameObject.Find("Cube_sla");
        cubesra = GameObject.Find("Cube_sra");
        cubesb = GameObject.Find("Cube_sb");
        cubesll = GameObject.Find("Cube_sll");
        cubesrl = GameObject.Find("Cube_srl");
    }

    void FixedUpdate()
    {
        cubesla.transform.position = new Vector3(0,  (ftipsl.transform.position.y + shouldersl.transform.position.y) / 2, (ftipsl.transform.position.z + shouldersl.transform.position.z) / 2);
        cubesla.transform.localScale = new Vector3(1, Math.Max(Math.Abs(ftipsl.transform.position.y - shouldersl.transform.position.y), 0.1f), Math.Max(Math.Abs(ftipsl.transform.position.z - shouldersl.transform.position.z), 0.12f));
        cubesra.transform.position = new Vector3(0,  (ftipsr.transform.position.y + shouldersr.transform.position.y) / 2, (ftipsr.transform.position.z + shouldersr.transform.position.z) / 2);
        cubesra.transform.localScale = new Vector3(1, Math.Max(Math.Abs(ftipsr.transform.position.y - shouldersr.transform.position.y), 0.1f), Math.Max(Math.Abs(ftipsr.transform.position.z - shouldersr.transform.position.z), 0.12f));
        cubesb.transform.position = new Vector3(0, (heads.transform.position.y + bipsl.transform.position.y) / 2, (heads.transform.position.z + bipsl.transform.position.z) / 2);
        cubesb.transform.localScale = new Vector3(1, Math.Max(Math.Abs(heads.transform.position.y - bipsl.transform.position.y), 0.2f), Math.Max(Math.Abs(heads.transform.position.z - bipsl.transform.position.z), 0.2f));
        cubesll.transform.position = new Vector3(0, (bipsl.transform.position.y + footsl.transform.position.y) / 2, (bipsl.transform.position.z + footsl.transform.position.z) / 2);
        cubesll.transform.localScale = new Vector3(1, Math.Max(Math.Abs(bipsl.transform.position.y - footsl.transform.position.y), 0.08f), Math.Max(Math.Abs(bipsl.transform.position.z - footsl.transform.position.z), 0.08f));
        cubesrl.transform.position = new Vector3(0, (bipsr.transform.position.y + footsr.transform.position.y) / 2, (bipsr.transform.position.z + footsr.transform.position.z) / 2);
        cubesrl.transform.localScale = new Vector3(1, Math.Max(Math.Abs(bipsr.transform.position.y - footsr.transform.position.y), 0.08f), Math.Max(Math.Abs(bipsr.transform.position.z - footsr.transform.position.z), 0.08f));
        Physics.SyncTransforms();
    }
}