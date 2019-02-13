using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VectorGraphics;



[ExecuteInEditMode]


public class SVGColliderGenerator : MonoBehaviour
{
    public TextAsset asset;


    void Start()
    {
        EdgeCollider2D[] oldEc2 = GetComponents<EdgeCollider2D>();
        foreach (var ec2 in oldEc2)
        {
            DestroyImmediate(ec2);
            //Debug.Log("deleted");
        }

        string svg = asset.text;

        var tessOptions = new VectorUtils.TessellationOptions()
        {
            StepDistance = 100.0f,
            MaxCordDeviation = 0.1f,
            MaxTanAngleDeviation = 100.0f,
            SamplingStepSize = 100.0f
        };

        // Dynamically import the SVG data, and tessellate the resulting vector scene.
        var sceneInfo = SVGParser.ImportSVG(new StringReader(svg));
        var geoms = VectorUtils.TessellateScene(sceneInfo.Scene, tessOptions);



//        var _log = ((Unity.VectorGraphics.Path)sceneInfo.Scene.Root.Children[1].Drawables[0]).Contour.Segments[1];
        /* 
        foreach (var l in _log)
       {
           Debug.Log(l);
       }*/
        // Vector2[] _v = new Vector2[] { _log.;, _log.P1, _log.P2 };
        // Debug.Log(_v);
        int c = 0, e = 0;
        foreach (var _child in sceneInfo.Scene.Root.Children)
        {
            c++;
            //Debug.Log("childre " + c);
            List<Vector2> _v = new List<Vector2>();
            try{
                foreach (var m in _child.GetType().GetMembers()) 
                Debug.Log(m);
                foreach (var _drawable in _child.Drawables)
                {
                    //Debug.Log("d_ " + _child.Drawables.Count);
                    try
                    {
                        if (_drawable is Unity.VectorGraphics.Path)
                        {
                            Unity.VectorGraphics.Path _path = (Unity.VectorGraphics.Path)_drawable;
                            foreach (var _seg in _path.Contour.Segments)
                            {
                                //Debug.Log("seg ");
                                if (_seg.P0.x + _seg.P0.y != 0) _v.Add(_seg.P0);
                                if (_seg.P1.x + _seg.P1.y != 0) _v.Add(_seg.P1);
                                if (_seg.P2.x + _seg.P2.y != 0) _v.Add(_seg.P2);

                            }
                        }

                        else
                        {
                            Unity.VectorGraphics.Shape _path = (Unity.VectorGraphics.Shape)_drawable;
                            foreach (var _con in _path.Contours)
                            {
                                foreach (var _seg in _con.Segments)
                                {
                                // Debug.Log("seg ");
                                    if (_seg.P0.x + _seg.P0.y != 0) _v.Add(_seg.P0);
                                    if (_seg.P1.x + _seg.P1.y != 0) _v.Add(_seg.P1);
                                    if (_seg.P2.x + _seg.P2.y != 0) _v.Add(_seg.P2);

                                }
                            }
                        }

                        EdgeCollider2D edge = gameObject.AddComponent<EdgeCollider2D>();
                        edge.points = _v.ToArray();
                        e++;
                    // Debug.Log("edge: " + e);
                    }
                    catch (System.InvalidCastException)
                    {
                        Debug.Log("InvalidCast" + _drawable.GetType());

                    }

                }
            }
            catch (System.Exception e1)  {
                //Debug.Log(e1);
            }

        }


        /* foreach (var geomsItem in geoms)
        {
            EdgeCollider2D edge = gameObject.AddComponent<EdgeCollider2D>();
            edge.points = geomsItem.Vertices;

        } */




    }

    void OnDisable()
    {
        GameObject.Destroy(GetComponent<MeshRenderer>());
    }
}