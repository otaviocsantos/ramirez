using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ramirez
{
    public class DoUnity
    {

        /// <summary>
        /// Copy position, localPosition, rotation, localRotation and localScale, from one GameObject to antother
        /// </summary>
        /// <param name="_from"></param>
        /// <param name="_to"></param>
        public static void CopyModifiers(GameObject _from, GameObject _to)
        {
            _to.transform.position = _from.transform.position;
            _to.transform.localPosition = _from.transform.localPosition;
            _to.transform.rotation = _from.transform.rotation;
            _to.transform.localRotation = _from.transform.localRotation;
            _to.transform.localScale = _from.transform.localScale;
        }

        /// <summary>
        /// Get greatest value of a Vector3
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        public static float GetGreatest(Vector3 dim)
        {
            return Mathf.Max(dim.x, Mathf.Max(dim.y, dim.z));
        }

        /// <summary>
        /// Get smallest value of a Vector3
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        public static float GetSmallest(Vector3 dim)
        {
            return Mathf.Min(dim.x, Mathf.Min(dim.y, dim.z));
        }

        /// <summary>
        /// Render target empty by remove all its children
        /// </summary>
        /// <param name="go"></param>
        public static void RemoveChildren(GameObject go)
        {
            if (go != null)
            {
                foreach (Transform t in go.transform)
                {
                    GameObject.Destroy(t.gameObject);
                }
            }
        }

        /// <summary>
        /// Disables every child in a gameobject
        /// </summary>
        /// <param name="go">Parent Game Object</param>
        public static void HideChildren(GameObject go)
        {
            ToggleChildren(go, false);
        }

        /// <summary>
        /// Disables every child in a gameobject
        /// </summary>
        /// <param name="go">Parent Game Object</param>
        public static void ShowChildren(GameObject go)
        {
            ToggleChildren(go, true);
        }

        public static void ToggleChildren(GameObject go, bool state = true)
        {
            if (go != null)
            {
                if (go.GetComponentInChildren<Renderer>())
                {
                    Renderer[] lChildRenderers = go.GetComponentsInChildren<Renderer>();
                    foreach (Renderer lRenderer in lChildRenderers)
                    {
                        lRenderer.enabled = state;
                    }
                }
            }
            else
            {
                throw new System.Exception("ToggleChildren GameObject cannot be empty");
            }
        }


    }
}