using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace UserManager.DAL
{
    public class BaseRepository
    {
        protected IDbConnection con;
        public BaseRepository()
        {
            string connectString = "Data Source=H-AITD202003013;Initial Catalog=user_management;Integrated Security=True";
            con = new SqlConnection(connectString);
        }
    }
}
