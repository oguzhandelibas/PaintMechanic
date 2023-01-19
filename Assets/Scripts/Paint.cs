using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PaintSystem
{
    [RequireComponent(typeof(MeshFilter))]
    public class Paint : MonoBehaviour
    {
        [SerializeField] private PaintSettings paintSettings;
        [SerializeField] private Text _resultPercentText;

        private void Awake()
        {
            paintSettings.Initialize(GetComponent<MeshFilter>().mesh);
        }

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                string result = paintSettings.Paint();
                if(result != null) _resultPercentText.text = result;
            }
        }
    }
}

