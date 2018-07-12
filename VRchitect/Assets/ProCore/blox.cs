using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;
using System.Linq;
using Dynagon;


public class blox : MonoBehaviour {

    // Use this for initialization

    //original and scale factors of the plot/image
    public float len_o;
    public float bre_o;
    public float len_s;
    public float bre_s;

    //used for reading json file
    string jsondata;

    //prefabs of the doors windows and stairs
    public Transform doorb;
    public Transform sc;
    public Transform windowprefab;

    //vectors used in the function
    Vector2 a;
    Vector2 b;

    //classes of all the objects 
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
    public class door_stuff
    {
        public Vector2 v1;
        public Vector2 v2;

        public door_stuff()
        {
        }

        public door_stuff(Vector2 j, Vector2 k)
        {
            v1 = j;
            v2 = k;
        }
    }
    public class window_stuff
    {
        public Vector2 v1;
        public Vector2 v2;

        public window_stuff()
        {
        }

        public window_stuff(Vector2 j, Vector2 k)
        {
            v1 = j;
            v2 = k;
        }
    }
    public class stair_stuff
    {
        public Vector2 v1;
        public Vector2 v2;

        public stair_stuff()
        {
        }

        public stair_stuff(Vector2 j, Vector2 k)
        {
            v1 = j;
            v2 = k;
        }
    }

    //lists of the classes of all objects
    List<wall_stuff> wall_pairs = new List<wall_stuff>();
    List<door_stuff> door_pairs = new List<door_stuff>();
    List<stair_stuff> stair_pairs = new List<stair_stuff>();
    List<window_stuff> window_pairs = new List<window_stuff>();


    
    void Start() {

        //scaling factors used to scale the model
        float x_scale = len_s / len_o;
        float y_scale = bre_s / bre_o;

        #if UNITY_EDITOR
        //reading the json file
        string path = Application.streamingAssetsPath + "/data_file.json";
        string path2 = Application.persistentDataPath + "/jar_loc.txt";
        File.WriteAllText(path2, path);
        // string path = "Resources/data_file.json";
        jsondata = File.ReadAllText(path);


        #elif UNITY_ANDROID
            string  path = "jar:file://" + Application.dataPath + "!/assets/data_file.json";
            string path2 = Application.persistentDataPath + "/jar_loc.txt";
            File.WriteAllText(path2,path);
            WWW wwwfile = new WWW(path);
            while (!wwwfile.isDone) { }
            var filepath = string.Format("{0}/{1}", Application.persistentDataPath, "data_file.json");
            File.WriteAllBytes(filepath, wwwfile.bytes);

            StreamReader wr = new StreamReader(filepath);
            string line;
            while ((line = wr.ReadLine()) != null)
            {
                jsondata += line;
            }
#endif



        JSONNode jsonNode = SimpleJSON.JSON.Parse(jsondata);
        
        //adding each wall instance into the list and using the wallmaker() to render walls
        int k = 0; ;
        while (true)
        {
             
             if (jsonNode["walls"][k]!= null)
            {

                wall_stuff h0 = new wall_stuff();
                h0.v1.x =x_scale* jsonNode["walls"][k][0][0].AsFloat;
                h0.v1.y = y_scale * jsonNode["walls"][k][0][1].AsFloat;
                h0.v2.x = x_scale * jsonNode["walls"][k][1][0].AsFloat;
                h0.v2.y = y_scale * jsonNode["walls"][k][1][1].AsFloat;

                wall_pairs.Add(h0);
            }
            else
            {
                break;
            }
            k++;
        }

        int j = 0;
        GameObject wall_parent = new GameObject();
        wall_parent.name = "wall parent";
        foreach (wall_stuff i in wall_pairs)
        {
            wallmaker(i.v1, i.v2,j,wall_parent);
            j++;
        }


        //adding door instances to the list and using the dormaker() to render the doors
        
        k = 0; 
        while (true)
        {

            if (jsonNode["door"][k] != null)
            {

                door_stuff h0 = new door_stuff();
                h0.v1.x = x_scale * jsonNode["door"][k][0][0].AsFloat;
                h0.v1.y = y_scale * jsonNode["door"][k][0][1].AsFloat;
                h0.v2.x = x_scale * jsonNode["door"][k][1][0].AsFloat;
                h0.v2.y = y_scale * jsonNode["door"][k][1][1].AsFloat;

                door_pairs.Add(h0);
            }
            else
            {
                break;
            }
            k++;
        }

        j = 0;
        GameObject door_parent = new GameObject();
        door_parent.name = "door parent";
        foreach (door_stuff i in door_pairs)
        {
            dormaker(i.v1, i.v2, j, door_parent);
            j++;
        }

        //adding window instances to the list and using windowmaker() to render the windows
        window_stuff h2 = new window_stuff();
        h2.v1 = new Vector2(-5, 2);
        h2.v2 = new Vector2(-5, -2);
        window_pairs.Add(h2);


        j = 0;
        foreach (window_stuff i in window_pairs)
        {
            windowmaker(i.v1, i.v2, j);
            j++;
        }


        //adding stair instances to the list and using stairmaker() to render the stairs

        stair_stuff h3 = new stair_stuff();
        h3.v1 = new Vector2(-6, -6);
        h3.v2 = new Vector2(-6, -8);
        stair_pairs.Add(h3);


        j = 0;
        foreach (stair_stuff i in stair_pairs)
        {
            stairmaker(i.v1, i.v2, j);
            j++;
        }


        //floor and cieling maker
        var floor_vertices = new List<Vector3>();
        k = 0;
        while (true)
        {

            if (jsonNode["floor"][k] != null)
            {

                Vector3 h0;
                h0.x = x_scale * jsonNode["door"][k][0][0].AsFloat;
                h0.y = y_scale * jsonNode["door"][k][0][1].AsFloat;
                h0.z = 0.0f;

                Vector3 h1;
                h1.x = x_scale * jsonNode["door"][k][0][0].AsFloat;
                h1.y = y_scale * jsonNode["door"][k][0][1].AsFloat;
                h1.z = 0.0f;



                floor_vertices.Add(h0);
                floor_vertices.Add(h0);
            }
            else
            {
                break;
            }
            k++;
        }


        floor_vertices.Add(new Vector3(0, 0, 0));
        floor_vertices.Add(new Vector3(0, 5, 0));
        floor_vertices.Add(new Vector3(5, 5, 0));
        floor_vertices.Add(new Vector3(2.5f, 10, 0));
        floor_vertices.Add(new Vector3(5, 0, 0));

        floor_vertices.Add(new Vector3(0, 0, 5));
        floor_vertices.Add(new Vector3(0, 5, 5));
        floor_vertices.Add(new Vector3(5, 5, 5));
        floor_vertices.Add(new Vector3(2.5f, 10, 5));
        floor_vertices.Add(new Vector3(5, 0, 5));


        Factory.Create("Floor", floor_vertices);

       

        Factory.Create("Cieling", floor_vertices);

    }

    //functions for generation

    public float Leng(Vector2 a, Vector2 b)
        {
        float len;
        len = Mathf.Sqrt(Mathf.Pow((a.x-b.x),2)+ Mathf.Pow((a.y - b.y), 2));
        return len;
        }
    public Vector2 midpoint(Vector2 a, Vector2 b)
    {
        Vector2 mp;
        mp.x = (a.x + b.x) / 2;
        mp.y = (a.y + b.y) / 2;
        return mp;
        
    }
    public float angle(Vector2 a, Vector2 b)
    {
        float ang;
        Vector2 c = new Vector2(a.x - b.x, a.y-b.y);
        ang = c.y/c.x;
        ang = Mathf.Atan(ang);
        ang *=Mathf.Rad2Deg;
        return ang;
    }
    void wallmaker(Vector2 a, Vector2 b, int count, GameObject wp)
    {

        Vector2 m;
        float ang;
        float len;
        m = midpoint(a, b);
        ang = angle(a, b);
        len = Leng(a, b);
        if (len < 2.0f)
        {
            return;
        }
        GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall.transform.parent = wp.transform;
        wall.transform.position = new Vector3(m.x, 2.5f, m.y);
        wall.transform.localRotation = Quaternion.Euler(0f, -ang, 0f);
        wall.transform.localScale = new Vector3(len + 1, 5, 2);
        wall.name = "wall" + count;
    }
    void dormaker(Vector2 a, Vector2 b, int count,GameObject dp)
    {
        Vector2 m;
        float ang;
        float  door_length = Leng(a,b);
        m = midpoint(a, b);
        ang = angle(a, b);
        Vector3 s = doorb.localScale;
        

        var derp = Instantiate(doorb, new Vector3(m.x, 0, m.y), Quaternion.Euler(-90, ang, 0));
        //derp.transform.parent = dp.transform;
        derp.name = "door" + count;
        doorb.transform.Rotate(new Vector3(-90, 90, 0));
        derp.transform.localScale = new Vector3(door_length/s.x, 50, s.z);
    }
    void windowmaker(Vector2 a, Vector2 b, int count)
    {
        Vector2 m;
        float ang;
        m = midpoint(a, b);
        ang = angle(a, b);
        var derp = Instantiate(windowprefab, new Vector3(m.x, 0, m.y), Quaternion.Euler(0, 270 - ang, 0));
        derp.name = "window" + count;
        
    }
    void stairmaker(Vector2 a, Vector2 b, int count)
    {
        
        float ang;
        ang = angle(a, b);
        var derp = Instantiate(sc, new Vector3(a.x, 0, a.y), Quaternion.Euler(0, 180 + ang, 0));
        derp.name = "stair" + count;
        
    }

    //function for smoothing

    public float leng1(wall_stuff g)
    {
        float len;
        len = Mathf.Sqrt(Mathf.Pow((g.v1.x - g.v2.x), 2) + Mathf.Pow((g.v1.y - g.v2.y), 2));
        return len;
    }
    public float angle1(wall_stuff g)
    {
        float ang;
        Vector2 c = new Vector2(g.v1.x - g.v2.x, g.v1.y - g.v2.y);
        ang = c.y / c.x;
        ang = Mathf.Atan(ang);
        ang *= Mathf.Rad2Deg;
        return ang;
    }
    public List<wall_stuff> func1(List<wall_stuff> list_func)
    {
        foreach (wall_stuff a in list_func.ToArray())
        {
            foreach (wall_stuff b in list_func.ToArray())
            {
                if (leng1(a) > leng1(b))
                {
                    if (angle1(a) - 1f < angle1(b) && angle1(b) > angle1(a) + 1f)
                    {
                        if (a.v1 == b.v1)
                        {
                            foreach (wall_stuff c in list_func.ToArray())
                            {
                                if (leng1(a) > leng1(c))
                                {
                                    if (c.v1 == b.v2 && c.v2 == a.v2)
                                    {
                                        Debug.Log(-2);
                                        list_func.Remove(b);
                                        list_func.Remove(c);
                                        break;
                                    }
                                    if (c.v2 == b.v2 && c.v1 == a.v2)
                                    {
                                        Debug.Log(-2);
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
                                        Debug.Log(-2);
                                        list_func.Remove(b);
                                        list_func.Remove(c);
                                        break;
                                    }
                                    if (c.v2 == b.v1 && c.v1 == a.v2)
                                    {
                                        Debug.Log(-2);
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
                                        Debug.Log(-2);
                                        list_func.Remove(b);
                                        list_func.Remove(c);
                                        break;
                                    }
                                    if (c.v1 == b.v1 && c.v2 == a.v1)
                                    {
                                        Debug.Log(-2);
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
                                        Debug.Log(-2);
                                        list_func.Remove(b);
                                        list_func.Remove(c);
                                        break;
                                    }

                                    if (c.v1 == b.v2 && c.v2 == a.v1)
                                    {
                                        Debug.Log(-2);
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
