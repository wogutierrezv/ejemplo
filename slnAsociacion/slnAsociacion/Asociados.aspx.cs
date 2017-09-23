using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace slnAsociacion
{
    public partial class Asociados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection("DSN=asociados");

            OdbcDataAdapter ad = new OdbcDataAdapter("select * from Asociados", conn);

            DataSet ds = new DataSet();
            ad.Fill(ds);

            dvAsociados.DataSource = ds;
            dvAsociados.DataBind();

            DataTable dt = ds.Tables[0];

            foreach (DataRow item in dt.Rows)
            {


            }
        }
    }
}