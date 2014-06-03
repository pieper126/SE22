namespace SE22
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Oracle.DataAccess.Client;
    using Oracle.DataAccess.Types;
    using System.Web.Configuration;

    /// <summary>
    /// manages all data in the database
    /// </summary>
    public class DatabaseManager
    {
        /// <summary>
        /// checks if the given user 
        /// </summary>
        /// <param name="username">username of the user you are trying to log in</param>
        /// <param name="password">password of the user you are trying to log in</param>
        /// <returns>Gives back the user if he is verified</returns>
        public static User LogIn(string username, string password)
        {
            OracleConnection conn = MakeConnection();
            conn.Open();

            string mainQuery = "SELECT * FROM GEBRUIKER WHERE USERNAME = :USERNAME AND PASSWORD = :PASSWORD";
            string redactorQuery = "SELECT * FROM REDACTEUR WHERE USERNAME = :USERNAME";
            string moderatoryQuery = "SELECT * FROM MODERATOR WHERE USERNAME = :USERNAME";

            OracleCommand command = new OracleCommand(mainQuery, conn);
            command.Parameters.Add(new OracleParameter("USERNAME", username));
            command.Parameters.Add(new OracleParameter("PASSWORD", password));
            OracleCommand redactorCommand = new OracleCommand(redactorQuery, conn);
            redactorCommand.Parameters.Add(new OracleParameter("USERNAME", username));
            OracleCommand moderatorCommand = new OracleCommand(moderatoryQuery, conn);
            moderatorCommand.Parameters.Add(new OracleParameter("USERNAME", username));
            OracleDataReader dataReader;
            User returnUser = null;

            List<Rights> functions = new List<Rights>();

            try
            {
                dataReader = redactorCommand.ExecuteReader();
                if (dataReader.HasRows)
	            {
		            functions.Add(Rights.Editor);
	            }

                dataReader = moderatorCommand.ExecuteReader();
                if (dataReader.HasRows)
	            {
		            functions.Add(Rights.Moderator);
	            }

                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    returnUser = new User(dataReader["USERNAME"].ToString(), dataReader["email"].ToString(), functions);
                }
            }
            catch (Exception)
            {                
                throw;
            }
            finally
            {
                conn.Close();
            }

            return returnUser;
        }

        /// <summary>
        /// gives the most recent 
        /// </summary>
        /// <returns>most recent version of all threads</returns>
        public static List<ForumThread> UpdateThreads()
        {
            OracleConnection conn = MakeConnection();
            conn.Open();

            string mainQuery = "SELECT * FROM THREAD";

            OracleCommand command = new OracleCommand(mainQuery, conn);
            OracleDataReader dataReaderThread;
            OracleDataReader dataReaderPosts;

            List<ForumThread> threads = new List<ForumThread>();

            try
            {
                dataReaderThread = command.ExecuteReader();
                while (dataReaderThread.Read())
                {
                    List<Post> posts = new List<Post>();
                    string threadID = dataReaderThread["threadID"].ToString();
                    string postQuery = "SELECT * FROM POST WHERE THREADID =" + threadID;
                    OracleCommand threadCommand = new OracleCommand(postQuery, conn);

                    dataReaderPosts = threadCommand.ExecuteReader();
                    while (dataReaderPosts.Read())
	                {
	                    posts.Add(new Post(Convert.ToInt32(dataReaderPosts["postID"].ToString()), dataReaderPosts["inhoud"].ToString()));
	                }

                    ForumCategory category = MainAdministration.Categorys.Find(x => x.ID == Convert.ToInt32(dataReaderThread["FORUMCATEGORIEID"].ToString()));

                    threads.Add(new ForumThread(Convert.ToInt32(dataReaderThread["threadID"].ToString()), posts, category));
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return threads;
        }

        /// <summary>
        /// Gives the most recent version of the given thread
        /// </summary>
        /// <param name="id">id is used to identify the thread</param>
        /// <returns>the most recent version of the thread</returns>
        public static ForumThread UpdateThread(int id)
        {
            OracleConnection conn = MakeConnection();
            conn.Open();

            string mainQuery = "SELECT * FROM THREAD WHERE THREADID = :THREADID";

            OracleCommand command = new OracleCommand(mainQuery, conn);
            command.Parameters.Add(new OracleParameter("THREADID", id));
            OracleDataReader dataReaderThread;
            OracleDataReader dataReaderPosts;

            ForumThread thread = null;

            try
            {
                dataReaderThread = command.ExecuteReader();
                while (dataReaderThread.Read())
                {
                    List<Post> posts = new List<Post>();
                    string postQuery = "SELECT * FROM POST WHERE THREADID =" + dataReaderThread["threadID"];
                    OracleCommand threadCommand = new OracleCommand(postQuery, conn);

                    dataReaderPosts = threadCommand.ExecuteReader();
                    while (dataReaderThread.Read())
                    {
                        posts.Add(new Post(Convert.ToInt32(dataReaderPosts["postsID"].ToString()), dataReaderPosts["inhoud"].ToString()));
                    }

                    ForumCategory category = MainAdministration.Categorys.Find(x => x.ID == Convert.ToInt32(dataReaderThread["FORUMCATEGORIEID"].ToString()));

                    thread = new ForumThread(Convert.ToInt32(dataReaderThread["threadID"].ToString()), posts, category);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return thread;
        }

        /// <summary>
        /// Deletes the given post
        /// </summary>
        /// <param name="id">id used to identify the post</param>
        public static void DeletePost(int id)
        {
            OracleConnection conn = MakeConnection();
            conn.Open();

            string mainQuery = "DELETE FROM POST WHERE POSTID = :POSTID";

            OracleCommand command = new OracleCommand(mainQuery, conn);
            command.Parameters.Add(new OracleParameter("POSTID", id));

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// deletes the given thread
        /// </summary>
        /// <param name="id"> id used to identify the thread</param>
        public static void DeleteThread(int id)
        {
            OracleConnection conn = MakeConnection();
            conn.Open();

            string mainQuery = "DELETE FROM THREAD WHERE THREADID = :THREADID";

            OracleCommand command = new OracleCommand(mainQuery, conn);
            command.Parameters.Add(new OracleParameter("POSTID", id));

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Changes the thread
        /// </summary>
        /// <param name="id">id used too identify the</param>
        /// <param name="changes">all changes in the same order as the parameters</param>
        /// <param name="paramaterToChanged">all parameters in the same order as the changes</param>
        public static void AlterThread(int id, List<string> changes, List<string> paramaterToChanged)
        {
            OracleConnection conn = MakeConnection();
            conn.Open();

            string mainQuery = "UPDATE THREAD SET";

            for (int i = 0; i < changes.Count; i++)
			{
			    mainQuery += paramaterToChanged[i];
                mainQuery += " = " + changes[i];
			}

            mainQuery += "WHERE POSTID = :POSTID";

            OracleCommand command = new OracleCommand(mainQuery, conn);
            command.Parameters.Add(new OracleParameter("POSTID", id));

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Gets the most recent Forum Category's
        /// </summary>
        /// <returns>forum category's</returns>
        public static List<ForumCategory> UpdateCategorys()
        {
            OracleConnection conn = MakeConnection();
            conn.Open();

            string mainQuery = "SELECT * FROM FORUMCATEGORIE";

            OracleCommand command = new OracleCommand(mainQuery, conn);
            OracleDataReader dataReader;

            List<ForumCategory> categorys = new List<ForumCategory>();

            try
            {
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    ForumCategory parentCategory = null;

                    if (dataReader["PARENTCATEGORIE"] != DBNull.Value)
                    {
                        parentCategory = categorys.Find(category => category.ID == Convert.ToInt32(dataReader["PARENTCATEGORIE"].ToString()));
                    }

                    categorys.Add(new ForumCategory(Convert.ToInt32(dataReader["FORUMCATEGORIEID"].ToString()), parentCategory, dataReader[2].ToString()));
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return categorys;
        }

        /// <summary>
        /// gives back the most recent version of a category
        /// </summary>
        /// <param name="ID">ID used to identify the Category</param>
        /// <returns>Most recent version of category</returns>
        public static List<ForumThread> GiveAllThreadsOfAGivenCategory(int id)
        {
            OracleConnection conn = MakeConnection();
            conn.Open();

            string mainQuery = "SELECT * FROM THREAD WHERE FORUMCATEGORIEID = :ID";

            OracleCommand command = new OracleCommand(mainQuery, conn);
            command.Parameters.Add(new OracleParameter("FORUMCATEGORIEID", id));
            OracleDataReader dataReaderThread;
            OracleDataReader dataReaderPosts;

            List<ForumThread> threads = new List<ForumThread>();

            try
            {
                dataReaderThread = command.ExecuteReader();
                while (dataReaderThread.Read())
                {
                    List<Post> posts = new List<Post>();
                    string postQuery = "SELECT * FROM POST WHERE THREADID =" + dataReaderThread["threadID"];
                    OracleCommand threadCommand = new OracleCommand(postQuery, conn);

                    dataReaderPosts = threadCommand.ExecuteReader();
                    while (dataReaderThread.Read())
                    {
                        posts.Add(new Post(Convert.ToInt32(dataReaderPosts["postsID"].ToString()), dataReaderPosts["inhoud"].ToString()));
                    }

                    ForumCategory category = MainAdministration.Categorys.Find(x => x.ID == Convert.ToInt32(dataReaderThread["FORUMCATEGORIEID"].ToString()));

                    threads.Add(new ForumThread(Convert.ToInt32(dataReaderThread["threadID"].ToString()), posts, category));
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return threads;
        }

        /// <summary>
        /// Makes the Database connection
        /// </summary>
        /// <returns>Returns the database connection</returns>
        private static OracleConnection MakeConnection()
        {
            return new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
    }
}