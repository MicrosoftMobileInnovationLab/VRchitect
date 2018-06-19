using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class smoothmaker : MonoBehaviour {

    // Use this for initialization
    string jsondata;
    public class wall_stuff
    {
        public Vector2 v1;
        public Vector2 v2;

        public wall_stuff()
        {
        }

        public wall_stuff(Vector2 j, Vector2 k)
        {
            v1 = j;
            v2 = k;
        }
    }
    List<wall_stuff> wall_pairs = new List<wall_stuff>();

    void Start () {

        string path = Application.persistentDataPath + "/data_file2.json";
        jsondata = File.ReadAllText(path);
        JSONNode jsonNode = SimpleJSON.JSON.Parse(jsondata);

       
        int k = 0; ;
        int count = 0;
        while (true)
        {

            if (jsonNode["walls"][k] != null)
            {

                wall_stuff h0 = new wall_stuff();
                h0.v1.x =  jsonNode["walls"][k][0][0].AsFloat;
                h0.v1.y =  jsonNode["walls"][k][0][1].AsFloat;
                h0.v2.x =  jsonNode["walls"][k][1][0].AsFloat;
                h0.v2.y =  jsonNode["walls"][k][1][1].AsFloat;
                int check = 1;
                foreach(wall_stuff i in wall_pairs)
                {
                    if (i.v1.x==h0.v2.x && i.v2.x==h0.v1.x && i.v2.y==h0.v1.y && i.v1.x==h0.v2.x )
                    {
                        check = 0;
                        break;
                    }
                    if (i.v1.x == h0.v1.x && i.v2.x == h0.v2.x && i.v2.y == h0.v2.y && i.v1.x == h0.v1.x)
                    {
                        check = 0;
                        break;
                    }
                }
                if(check == 1)
                {
                    wall_pairs.Add(h0);
                    count++;
                }
                
            }
            else
            {
                break;
            }
            k++;
        }
        Debug.Log(count);
        wall_pairs = func1(wall_pairs);
        Debug.Log(wall_pairs.Count);


    }

    public float leng1(wall_stuff g)
    {
        float len;
        len = Mathf.Sqrt(Mathf.Pow((g.v1.x - g.v2.x), 2) + Mathf.Pow((g.v1.y - g.v2.y), 2));
        return len;
    }
    public float angle1(wall_stuff g,wall_stuff h)
    {
        float ang1;
        Vector2 c = new Vector2(g.v1.x - g.v2.x, g.v1.y - g.v2.y);
        ang1 = c.y / c.x;

        float ang2;
        Vector2 d = new Vector2(h.v1.x - h.v2.x, h.v1.y - h.v2.y);
        ang2 = d.y / d.x;

        ang1 = Mathf.Atan(ang1);
        ang1 *= Mathf.Rad2Deg;

        ang2 = Mathf.Atan(ang2);
        ang2 *= Mathf.Rad2Deg;

        return Mathf.Abs(ang1-ang2);
    }
    public List<wall_stuff> func1(List<wall_stuff> list_func)
    {
        foreach(wall_stuff a in list_func.ToArray())
        {
            foreach (wall_stuff b in list_func.ToArray())
            {
                if(leng1(a)>leng1(b))
                {
                    if (angle1(a, b)<1.0f)
                    {
                        if (a.v1 == b.v1)
                        {
                            foreach (wall_stuff c in list_func.ToArray())
                            {
                                if (leng1(a) > leng1(c))
                                {
                                    if (c.v1 == b.v2 && c.v2 == a.v2)
                                    {

                                        list_func.Remove(b);
                                        list_func.Remove(c);
                                        break;
                                    }
                                    if (c.v2 == b.v2 && c.v1 == a.v2)
                                    {

                                        list_func.Remove(b);
                                        list_func.Remove(c);
                                        break;
                                    }
                                }
                            }
                        }

                        if (a.v1 == b.v2)
                        {
                            foreach (wall_stuff c in list_func.ToArray())
                            {
                                if (leng1(a) > leng1(c))
                                {
                                    if (c.v1 == b.v1 && c.v2 == a.v2)
                                    {

                                        list_func.Remove(b);
                                        list_func.Remove(c);
                                        break;
                                    }
                                    if (c.v2 == b.v1 && c.v1 == a.v2)
                                    {

                                        list_func.Remove(b);
                                        list_func.Remove(c);
                                        break;
                                    }
                                }
                            }
                        }

                        if (a.v2 == b.v2)
                        {
                            foreach (wall_stuff c in list_func.ToArray())
                            {
                                if (leng1(a) > leng1(c))
                                {
                                    if (c.v2 == b.v1 && c.v1 == a.v1)
                                    {

                                        list_func.Remove(b);
                                        list_func.Remove(c);
                                        break;
                                    }
                                    if (c.v1 == b.v1 && c.v2 == a.v1)
                                    {

                                        list_func.Remove(b);
                                        list_func.Remove(c);
                                        break;
                                    }
                                }
                            }
                        }

                        if (a.v2 == b.v1)
                        {
                            foreach (wall_stuff c in list_func.ToArray())
                            {
                                if (leng1(a) > leng1(c))
                                {
                                    if (c.v2 == b.v2 && c.v1 == a.v1)
                                    {

                                        list_func.Remove(b);
                                        list_func.Remove(c);
                                        break;
                                    }

                                    if (c.v1 == b.v2 && c.v2 == a.v1)
                                    {

                                        list_func.Remove(b);
                                        list_func.Remove(c);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        return list_func;
    }
	
}
