using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web.Configuration;

namespace SE22
{
    public class DatabaseManager
    {
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
                    returnUser = new User(dataReader["USERNAME"].ToString(), dataReader["NAAM"].ToString(), dataReader["email"].ToString(), functions);
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
                    string PostQuery = "SELECT * FROM POST WHERE THREADID =" + dataReaderThread["threadID"];
                    OracleCommand threadCommand = new OracleCommand(PostQuery, conn);

                    dataReaderPosts = threadCommand.ExecuteReader();
                    while (dataReaderThread.Read())
	                {
	                    posts.Add(new Post(Convert.ToInt32(dataReaderPosts["postsID"].ToString()), dataReaderPosts["inhoud"].ToString()));
	                }

                    threads.Add(new ForumThread(Convert.ToInt32(dataReaderThread["threadID"].ToString()), posts));
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
                    string PostQuery = "SELECT * FROM POST WHERE THREADID =" + dataReaderThread["threadID"];
                    OracleCommand threadCommand = new OracleCommand(PostQuery, conn);

                    dataReaderPosts = threadCommand.ExecuteReader();
                    while (dataReaderThread.Read())
                    {
                        posts.Add(new Post(Convert.ToInt32(dataReaderPosts["postsID"].ToString()), dataReaderPosts["inhoud"].ToString()));
                    }

                    thread = new ForumThread(Convert.ToInt32(dataReaderThread["threadID"].ToString()), posts);
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

                    if(dataReader["PARENTCATEGORIE"] != null)
                    {
                        parentCategory = categorys.Find(category => category.ID == Convert.ToInt32(dataReader["PARENTCATEGORIE"].ToString()));
                    }
                    categorys.Add(new ForumCategory(Convert.ToInt32(dataReader["FORUMCATEGORIEID"].ToString()), parentCategory));
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
        private static OracleConnection MakeConnection()
        {
            //System.Configuration.Configuration rootWebConfig =
            //System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("Web.config");
            //System.Configuration.ConnectionStringSettings connstring = rootWebConfig.ConnectionStrings["DefaultConnection"];
            //return new OracleConnection(connstring.ToString());
            return new OracleConnection("User Id= dbi295793;Password= IUSCsQWJ11;Data Source=//192.168.15.50:1521/fhictora;");
        }
    }
}