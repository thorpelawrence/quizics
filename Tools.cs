using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections.Generic;

namespace quizics
{
    static class Tools
    {
        //Connection string used for SQLite
        public static string connectionString = "Data Source=quizics.sqlite;Version=3;";

        /// <summary>
        /// Returns a dictionary containing the data for a user corresponding to the given ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static Dictionary<string, object> GetUserData(int userID)
        {
            //Object is used, multiple data types can be returned
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Users WHERE userID=@userID", connection))
                {
                    command.Parameters.AddWithValue("userID", userID);
                    try
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dictionary.Add("username", reader["username"]);
                                dictionary.Add("password", reader["password"]);
                                dictionary.Add("yearGroup", reader["yearGroup"]);
                            }
                        }
                        connection.Close();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { connection.Close(); }
                }
            }
            return dictionary;
        }

        /// <summary>
        /// Returns a dictionary containing the data for a question, uses questionID
        /// </summary>
        /// <param name="questionID">ID of question</param>
        /// <returns></returns>
        public static Dictionary<string, object> GetQuestionData(int questionID)
        {
            //Object is used, multiple data types can be returned
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Questions WHERE questionID=@questionID", connection))
                {
                    command.Parameters.AddWithValue("questionID", questionID);
                    try
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dictionary.Add("questionID", questionID);
                                dictionary.Add("questionImage", reader["questionImage"]);
                                dictionary.Add("questionName", reader["questionName"]);
                                dictionary.Add("questionAnswer", reader["questionAnswer"]);
                                dictionary.Add("questionMarks", reader["questionMarks"]);
                            }
                        }
                        connection.Close();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { connection.Close(); }
                }
            }
            return dictionary;
        }

        /// <summary>
        /// Returns a dictionary containing the data for a question, uses quizID and index of current question
        /// </summary>
        /// <param name="quizID">ID of quiz</param>
        /// <param name="quizQuestionIndex">Index of question in quiz</param>
        /// <returns></returns>
        public static Dictionary<string, object> GetQuestionData(int quizID, int quizQuestionIndex)
        {
            //Object is used, multiple data types can be returned
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                int questionID = 0;
                using (SQLiteCommand command = new SQLiteCommand("SELECT questionID FROM QuizQuestions WHERE quizID=@quizID AND questionIndex=@questionIndex", connection))
                {
                    command.Parameters.AddWithValue("quizID", quizID);
                    command.Parameters.AddWithValue("questionIndex", quizQuestionIndex);
                    try
                    {
                        connection.Open();
                        questionID = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { connection.Close(); }
                }
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Questions WHERE questionID=@questionID", connection))
                {
                    command.Parameters.AddWithValue("questionID", questionID);
                    try
                    {
                        connection.Open();
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dictionary.Add("questionID", questionID);
                                dictionary.Add("questionImage", reader["questionImage"]);
                                dictionary.Add("questionName", reader["questionName"]);
                                dictionary.Add("questionAnswer", reader["questionAnswer"]);
                                dictionary.Add("questionMarks", reader["questionMarks"]);
                            }
                        }
                        connection.Close();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { connection.Close(); }
                }
            }
            return dictionary;
        }

        /// <summary>
        /// Converts and rounds float as string to 2 decimal place string
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string To2DP(string number)
        {
            return string.Format("{0:0.00}", Math.Round(float.Parse(number), 2));
        }

        /// <summary>
        /// Converts and rounds float to 2 decimal place string
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string To2DP(float number)
        {
            return string.Format("{0:0.00}", Math.Round(number, 2));
        }

        /// <summary>
        /// Returns true if number can be parsed to float
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsFloat(string number)
        {
            float f;
            return (float.TryParse(number, out f));
        }

        /// <summary>
        /// Returns true if number can be parsed to int
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsInt(string number)
        {
            int i;
            return (int.TryParse(number, out i));
        }

        /// <summary>
        /// Shows message warning user that answer is not a number
        /// </summary>
        public static void NonNumericAnswerMessage()
        {
            MessageBox.Show("Answer must be numerical", "Invalid answer", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Shows message informing user that there is nothing to print
        /// </summary>
        public static void NothingToPrintMessage()
        {
            MessageBox.Show("Nothing to print", "Cannot print",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows message informing user that there is already a form open
        /// </summary>
        public static void AlreadyOpenMessage()
        {
            MessageBox.Show("There is already an instance of this window open\r\nOnly one can be opened at a time",
                "Already open", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Returns inverted color
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Color Invert(Color c)
        {
            return Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
        }

        /// <summary>
        /// Converts image into byte array
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Converts byte array into image
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Image ByteArrayToImage(byte[] b)
        {
            using (MemoryStream ms = new MemoryStream(b))
            {
                return Image.FromStream(ms);
            }

        }
    }
}
