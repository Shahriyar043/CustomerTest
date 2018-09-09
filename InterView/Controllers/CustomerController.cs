using InterView.Models;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterView.Controllers
{
    public class CustomerController : Controller
    {
        DBConnection.Connection connection = new DBConnection.Connection();
        // GET: Customer
        [HttpGet]
        public ActionResult GetAllCustomers(AllCustomer model)
        {
            try
            {
                List<Customer> lmd = new List<Customer>();
                AllCustomer allCustomer = new AllCustomer();

                DataSet ds = new DataSet();

                ds = connection.mydata_customer();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Customer customer = new Customer();
                    customer.Id = Convert.ToInt32(dr["CUSTOMER_ID"]);
                    customer.FIRSTNAME = dr["FIRSTNAME"].ToString();
                    customer.LASTNAME = dr["LASTNAME"].ToString();
                    customer.FATHERNAME = dr["FATHERNAME"].ToString();
                    customer.BIRTHDAY = Convert.ToDateTime(dr["BIRTHDAY"]);

                    lmd.Add(customer);
                }
                allCustomer.ListCustomer = lmd;
                
                return View(allCustomer);
            }
            catch (OracleException ex)
            {
                return RedirectToAction(ex.ToString());
            }
            catch (Exception ex)
            {
                return RedirectToAction(ex.ToString());
            }
            
        }

        

        

        // POST: Employeer/Create
        [HttpPost]
        public ActionResult CreateCustomer(FormCollection collection)
        {
            string FIRSTNAME = collection["FIRSTNAME"];
            string LASTNAME = collection["LASTNAME"];
            string FATHERNAME = collection["FATHERNAME"];
            string BIRTHDAY = collection["BIRTHDAY"];

            try
            {
                using (OracleConnection oc = new OracleConnection(DBHelperController.ConnectionString))
                {
                    OracleCommand cmd = oc.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = string.Format("{0}.{1}", "CUSTOMERORDER", "customer_operation");

                    cmd.Parameters.Add("P_CUSTOMER_ID", OracleDbType.Int32, null, ParameterDirection.Input);
                    cmd.Parameters.Add("P_FIRSTNAME", OracleDbType.Varchar2, FIRSTNAME, ParameterDirection.Input);
                    cmd.Parameters.Add("P_LASTNAME", OracleDbType.Varchar2, LASTNAME, ParameterDirection.Input);
                    cmd.Parameters.Add("P_FATHERNAME", OracleDbType.Varchar2, FATHERNAME, ParameterDirection.Input);
                    cmd.Parameters.Add("P_BIRTHDAY", OracleDbType.Date, Convert.ToDateTime(BIRTHDAY), ParameterDirection.Input);
                    cmd.Parameters.Add("P_TYPE", OracleDbType.Int32, 0, ParameterDirection.Input);
                    oc.Open();

                    OracleDataReader reader;
                    reader = cmd.ExecuteReader();
                    oc.Close();

                }
            }
            catch (OracleException ex)
            {
                RedirectToAction(ex.ToString());
            }
            catch (Exception ex)
            {
                RedirectToAction(ex.ToString());
            }

            return RedirectToAction("GetAllCustomers", "Customer");

        }

        // GET: Employeer/Edit/5
        [HttpGet]
        public ActionResult GetEditCustomer(int id)
        {
            try
            {
                List<Customer> lmd = new List<Customer>();
                AllCustomer allCustomer = new AllCustomer();

                DataSet ds = new DataSet();

                ds = connection.mydata_customer(id);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Customer customer = new Customer();
                    customer.Id = Convert.ToInt32(dr["CUSTOMER_ID"]);
                    customer.FIRSTNAME = dr["FIRSTNAME"].ToString();
                    customer.LASTNAME = dr["LASTNAME"].ToString();
                    customer.FATHERNAME = dr["FATHERNAME"].ToString();
                    customer.BIRTHDAY = Convert.ToDateTime(dr["BIRTHDAY"]);

                    lmd.Add(customer);
                }
                allCustomer.ListCustomer = lmd;

                return View(allCustomer);
            }
            catch (OracleException ex)
            {
                return RedirectToAction(ex.ToString());
            }
            catch (Exception ex)
            {
                return RedirectToAction(ex.ToString());
            }

        }

        // POST: Customer/Edit/1
        [HttpPost]
        public ActionResult EditCustomer(FormCollection collection)
        {
            string CUSTOMER_ID = collection["CUSTOMER_ID"];
            string FIRSTNAME = collection["FIRSTNAME"];
            string LASTNAME = collection["LASTNAME"];
            string FATHERNAME = collection["FATHERNAME"];
            string BIRTHDAY = collection["BIRTHDAY"];

            try
            {
                using (OracleConnection oc = new OracleConnection(DBHelperController.ConnectionString))
                {
                    OracleCommand cmd = oc.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = string.Format("{0}.{1}", "CUSTOMERORDER", "customer_operation");

                    cmd.Parameters.Add("P_CUSTOMER_ID", OracleDbType.Int32,Convert.ToInt32(CUSTOMER_ID), ParameterDirection.Input);
                    cmd.Parameters.Add("P_FIRSTNAME", OracleDbType.Varchar2, FIRSTNAME, ParameterDirection.Input);
                    cmd.Parameters.Add("P_LASTNAME", OracleDbType.Varchar2, LASTNAME, ParameterDirection.Input);
                    cmd.Parameters.Add("P_FATHERNAME", OracleDbType.Varchar2, FATHERNAME, ParameterDirection.Input);
                    cmd.Parameters.Add("P_BIRTHDAY", OracleDbType.Date, Convert.ToDateTime(BIRTHDAY), ParameterDirection.Input);
                    cmd.Parameters.Add("P_TYPE", OracleDbType.Int32, 1, ParameterDirection.Input);
                    oc.Open();

                    OracleDataReader reader;
                    reader = cmd.ExecuteReader();
                    oc.Close();

                }
            }
            catch (OracleException ex)
            {
                RedirectToAction(ex.ToString());
            }
            catch (Exception ex)
            {
                RedirectToAction(ex.ToString());
            }

            return RedirectToAction("GetAllCustomers", "Customer");
          
        }

        // POST: Customer/Delete/1
        [HttpPost]
        public ActionResult GetDeleteCustomer(int id)
        {
            try
            {
                using (OracleConnection oc = new OracleConnection(DBHelperController.ConnectionString))
                {
                    OracleCommand cmd = oc.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = string.Format("{0}.{1}", "CUSTOMERORDER", "customer_operation");

                    cmd.Parameters.Add("P_CUSTOMER_ID", OracleDbType.Int32, id, ParameterDirection.Input);
                    cmd.Parameters.Add("P_FIRSTNAME", OracleDbType.Varchar2, null, ParameterDirection.Input);
                    cmd.Parameters.Add("P_LASTNAME", OracleDbType.Varchar2, null, ParameterDirection.Input);
                    cmd.Parameters.Add("P_FATHERNAME", OracleDbType.Varchar2, null, ParameterDirection.Input);
                    cmd.Parameters.Add("P_BIRTHDAY", OracleDbType.Date, null, ParameterDirection.Input);
                    cmd.Parameters.Add("P_TYPE", OracleDbType.Int32, 2, ParameterDirection.Input);
                    oc.Open();

                    OracleDataReader reader;
                    reader = cmd.ExecuteReader();
                    oc.Close();

                }
            }
            catch (OracleException ex)
            {
                RedirectToAction(ex.ToString());
            }
            catch (Exception ex)
            {
                RedirectToAction(ex.ToString());
            }

            return RedirectToAction("GetAllCustomers", "Customer");

        }


    }
}
