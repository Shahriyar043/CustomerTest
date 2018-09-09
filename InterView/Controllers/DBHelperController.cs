using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterView.Controllers
{
    public class DBHelperController : Controller
    {
        private static string connectionString;

        private DBHelperController()
        {

        }

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    connectionString = ConfigurationManager.AppSettings["connectionString"];
                }
                return connectionString;
            }
        }

        public static string TestConnection()
        {
            string result = "";
            try
            {
                OracleConnection cn = new OracleConnection(ConnectionString);
                cn.Open();
                cn.Close();
                result = "Database qoşuldu";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}