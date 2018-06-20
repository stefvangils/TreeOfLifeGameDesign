using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using UnityEngine.UI;
using System;

public class TreeOfLife : MonoBehaviour
{
    public Text score;
    public List<GameObject> trees;
    public GameObject rain;
    public GameObject spit;
    float timePassed;
    public float updatesPerSecond;

    string connectionString = "Server=tcp:treeoflife.database.windows.net,1433;Initial Catalog=TreeOfLife;Persist Security Info=False;User ID=LifeOfTree;Password=treeoflife1!;Connection Timeout=30;";
    //Leaf methods
    public void CreateTree(int health)
    {
        string query = "insert into tree (maxhealth) values (@health)";
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@health", health);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
    public void AddAction()
    {
        string query = "insert into [log] values (1,@name,@points)";
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@name", "Stef van Gils");
            command.Parameters.AddWithValue("@points", 9);
            connection.Open();
            command.ExecuteNonQuery();
        }
        Debug.Log(query);
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > (1 / updatesPerSecond))
        {
            timePassed -= (1 / updatesPerSecond);
            ScoreUpdater();
        }
    }

    public void ScoreUpdater()
    {
        string query = "SELECT currenthealth FROM tree where id = @id";
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            connection.Open();
            command.Parameters.AddWithValue("@id", 1);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    int treelife = (int)reader[0];
                    score.text = "Tree HP: " + treelife.ToString() + " / 500";
                    if (treelife < 50)
                    {
                        foreach (GameObject tree in trees)
                        {
                            tree.SetActive(false);
                        }
                        rain.SetActive(true);
                        spit.SetActive(true);
                        trees[9].SetActive(true);
                    }

                    else if (treelife > 49 && treelife < 100)
                    {
                        foreach (GameObject tree in trees)
                        {
                            tree.SetActive(false);
                        }
                        trees[0].SetActive(true);
                    }

                    else if (treelife > 99 && treelife < 150)
                    {
                        foreach (GameObject tree in trees)
                        {
                            tree.SetActive(false);
                        }
                        trees[1].SetActive(true);

                    }

                    else if (treelife > 149 && treelife < 200)
                    {
                        foreach (GameObject tree in trees)
                        {
                            tree.SetActive(false);
                        }
                        trees[2].SetActive(true);

                    }

                    else if (treelife > 199 && treelife < 250)
                    {
                        foreach (GameObject tree in trees)
                        {
                            tree.SetActive(false);
                        }
                        rain.SetActive(false);
                        spit.SetActive(false);
                        trees[3].SetActive(true);
                    }

                    else if (treelife > 249 && treelife < 300)
                    {
                        foreach (GameObject tree in trees)
                        {
                            tree.SetActive(false);
                        }
                        rain.SetActive(false);
                        spit.SetActive(false);
                        trees[4].SetActive(true);
                    }

                    else if (treelife > 299 && treelife < 350)
                    {
                        foreach (GameObject tree in trees)
                        {
                            tree.SetActive(false);
                        }
                        rain.SetActive(false);
                        spit.SetActive(false);
                        trees[5].SetActive(true);
                    }

                    else if (treelife > 349 && treelife < 400)
                    {
                        foreach (GameObject tree in trees)
                        {
                            tree.SetActive(false);
                        }
                        rain.SetActive(false);
                        spit.SetActive(false);
                        trees[6].SetActive(true);
                    }

                    else if (treelife > 399 && treelife < 450)
                    {
                        foreach (GameObject tree in trees)
                        {
                            tree.SetActive(false);
                        }
                        rain.SetActive(false);
                        spit.SetActive(false);
                        trees[7].SetActive(true);
                    }

                    else if (treelife > 449)
                    {
                        foreach (GameObject tree in trees)
                        {
                            tree.SetActive(false);
                        }
                        rain.SetActive(false);
                        spit.SetActive(false);
                        trees[8].SetActive(true);
                    }

                }
            }
        }
    }
}
