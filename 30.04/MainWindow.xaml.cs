using Microsoft.Data.SqlClient;
using System;
using System.Windows;

namespace _30._04
{
    public partial class MainWindow : Window
    {
        private readonly string connectionString = "YourConnectionStringHere"; 
        private SqlConnection connection;

        public MainWindow()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
        }

        private void ConnectToDatabase()
        {
            try
            {
                connection.Open();
                MessageBox.Show("Connected to database successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message);
            }
        }

        private void DisconnectFromDatabase()
        {
            try
            {
                connection.Close();
                MessageBox.Show("Disconnected from database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disconnecting from database: " + ex.Message);
            }
        }

        private void ShowAllVegetablesAndFruitsInfo()
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM VegetablesAndFruits", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    string type = reader.GetString(1);
                    string color = reader.GetString(2);
                    int calories = reader.GetInt32(3);

                    MessageBox.Show($"Name: {name}, Type: {type}, Color: {color}, Calories: {calories}");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data: " + ex.Message);
            }
        }

        private int CountVegetables()
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM VegetablesAndFruits WHERE Type = 'Vegetable'", connection);
                return (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error counting vegetables: " + ex.Message);
                return -1;
            }
        }

        private int CountFruits()
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM VegetablesAndFruits WHERE Type = 'Fruit'", connection);
                return (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error counting fruits: " + ex.Message);
                return -1;
            }
        }

        private int CountVegetablesAndFruitsByColor(string color)
        {
            try
            {
                SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM VegetablesAndFruits WHERE Color = '{color}'", connection);
                return (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error counting vegetables and fruits by color {color}: " + ex.Message);
                return -1;
            }
        }

        private void ShowVegetablesAndFruitsByCaloriesRange(int minCalories, int maxCalories)
        {
            try
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM VegetablesAndFruits WHERE Calories BETWEEN {minCalories} AND {maxCalories}", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    string type = reader.GetString(1);
                    string color = reader.GetString(2);
                    int calories = reader.GetInt32(3);

                    MessageBox.Show($"Name: {name}, Type: {type}, Color: {color}, Calories: {calories}");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data: " + ex.Message);
            }
        }

        private void ShowVegetablesAndFruitsByColor(string color)
        {
            try
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM VegetablesAndFruits WHERE Color = '{color}'", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    string type = reader.GetString(1);
                    string fruitColor = reader.GetString(2);
                    int calories = reader.GetInt32(3);

                    MessageBox.Show($"Name: {name}, Type: {type}, Color: {fruitColor}, Calories: {calories}");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data: " + ex.Message);
            }
        }



    }
}