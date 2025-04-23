using System;
using UnityEngine;

public class SpeedCollider2 : MonoBehaviour
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
        ftipsl = GameObject.Find("fingertip_sl2");
        shouldersl = GameObject.Find("shoulder_sl2");
        ftipsr = GameObject.Find("fingertip_sr2");
        shouldersr = GameObject.Find("shoulder_sr2");
        heads = GameObject.Find("head_s2");
        bipsl = GameObject.Find("bip_sl2");
        bipsr = GameObject.Find("bip_sr2");
        footsl = GameObject.Find("foot_sl2");
        footsr = GameObject.Find("foot_sr2");

        cubesla = GameObject.Find("Cube_sla2");
        cubesra = GameObject.Find("Cube_sra2");
        cubesb = GameObject.Find("Cube_sb2");
        cubesll = GameObject.Find("Cube_sll2");
        cubesrl = GameObject.Find("Cube_srl2");
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