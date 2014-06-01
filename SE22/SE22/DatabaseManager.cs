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

        public List<Thread> UpdateThreads()
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

            return returnUser;
        }

        public Thread UpdateThread(int id)
        {

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