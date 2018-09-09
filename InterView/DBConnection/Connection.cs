using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using InterView.Controllers;
using Oracle.ManagedDataAccess.Client;


namespace InterView.DBConnection
{
    public class Connection
    {
        OracleConnection con = new OracleConnection(DBHelperController.ConnectionString);
        OracleCommand cmd;
        OracleDataAdapter da;
        public DataSet mydata()
        {
            da = new OracleDataAdapter();
            da.SelectCommand = cmd;
            DataSet myrec = new DataSet();
            da.Fill(myrec);
            return myrec;
        }

        public DataSet mydata_customer()
        {
            cmd = new OracleCommand(@"SELECT customer_id,
                                       firstname,
                                       lastname,
                                       fathername,
                                       birthday
                                  FROM c##shahriyar.customer where status=1", con);
            return mydata();
        }
        public DataSet mydata_customer(int id)
        {
            cmd = new OracleCommand(@"SELECT customer_id,
                                       firstname,
                                       lastname,
                                       fathername,
                                       birthday
                                  FROM c##shahriyar.customer where status=1 and CUSTOMER_ID='"+id+"'", con);
            return mydata();
        }

        public DataSet mydata_order(int id)
        {
            cmd = new OracleCommand(@"SELECT order_id,
                                       customer_id,
                                       ordername,
                                       salary
                                  FROM c##shahriyar.orders where customer_id"+id+"'", con);
            return mydata();
        }
    }
}