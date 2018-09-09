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
    public class OrderController : Controller
    {
        DBConnection.Connection connection = new DBConnection.Connection();
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                List<Order> lmd = new List<Order>();
                AllOrder allOrder = new AllOrder();

                DataSet ds = new DataSet();

                ds = connection.mydata_order(id);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Order order = new Order();
                    order.Id = Convert.ToInt32(dr["ORDER_ID"]);
                    order.CUSTOMERID = Convert.ToInt32(dr["CUSTOMERID"]);
                    order.ORDERNAME = dr["ORDERNAME"].ToString();
                    order.SALARY =Convert.ToDecimal(dr["SALARY"]);

                    lmd.Add(order);
                }
                allOrder.ListOrder = lmd;

                return View(allOrder);
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

       
        
    }
}
