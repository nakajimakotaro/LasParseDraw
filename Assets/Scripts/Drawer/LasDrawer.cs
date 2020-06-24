using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using LasR;
using LasR.Data;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Drawer
{
    public sealed class LasDrawer : MonoBehaviour
    {
        [SerializeField] Material Material;
        [SerializeField] float Duration;
        bool BufferReady;
        Matrix4x4[] Matrices;
        LasData LasData;
        ComputeBuffer PosBuffer;
        ComputeBuffer ColBuffer;
        
        [SerializeField] float Timer;
        [SerializeField] Text Text;

        public void Show()
        {
            StartCoroutine(SetCommand());
        }

        IEnumerator SetCommand()
        {
            using (var request = UnityWebRequest.Get("https://cloudpointdrawer.s3-ap-northeast-1.amazonaws.com/data.las"))
            {
                yield return request.SendWebRequest();
                
                using (var stream = new MemoryStream(request.downloadHandler.data))
                {
                    LasReader.Read(stream, out LasData);

                    var extends = new Vector3(
                        (float) (LasData.Header.MaxX + LasData.Header.MinX),
                        (float) (LasData.Header.MaxY + LasData.Header.MinY),
                        (float) (LasData.Header.MaxZ + LasData.Header.MinZ)) / 2;
                    var positions = LasData.LasPointDataRecordFormats.Select(_ =>
                        new Vector3(
                            (float)(_.X*LasData.Header.XScaleFactor + LasData.Header.XOffset) - extends.x,
                            (float)(_.Z*LasData.Header.ZScaleFactor + LasData.Header.ZOffset) - extends.z,
                            (float)(_.Y*LasData.Header.YScaleFactor + LasData.Header.YOffset) - extends.y
                            )).ToList();
                    var colors = LasData.LasPointDataRecordFormats.Select(_ => new Vector3(_.Red, _.Green, _.Blue)).ToList();
                    int size = Marshal.SizeOf<Vector3>();
                    PosBuffer = new ComputeBuffer(positions.Count, size);
                    ColBuffer = new ComputeBuffer(colors.Count, size);
                    PosBuffer.SetData(positions);
                    ColBuffer.SetData(colors);
                    Material.SetBuffer("posBuffer", PosBuffer);
                    Material.SetBuffer("colBuffer", ColBuffer);
                    BufferReady = true;
                }
            }
            Text.gameObject.SetActive(false);
        }

        void OnRenderObject()
        {
            if (BufferReady)
            {
                Timer += Time.deltaTime;
                Material.SetPass(0);
                Material.SetFloat("_T", Timer/Duration);
                Graphics.DrawProceduralNow(MeshTopology.Points, LasData.LasPointDataRecordFormats.Length);
            }
        }

        void OnDisable()
        {
            PosBuffer.Dispose();
            ColBuffer.Dispose();
        }
    }
}