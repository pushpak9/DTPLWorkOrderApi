using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using WorkOrderAPI.Models;

namespace WorkOrderAPI.DataLayer
{
    public class DL_Common
    {
        Common obj = new Common();
        SqlCommand cmd = null;

        public DataTable SaveOrderJsonDetails(OrderRequestModel model)
        {
            DataTable dtResult = new DataTable();

            dtResult.Columns.Add("Result", typeof(string));

            string connectionString =
                ConfigurationManager.ConnectionStrings[
                    "DefaultConnectionString"
                ].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_ORDERJSON", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // ACTION
                        cmd.Parameters.Add("@Action", SqlDbType.VarChar, 20)
                            .Value = "SAVE";

                        // ORDER NUMBER
                        cmd.Parameters.Add("@OrderNumber", SqlDbType.NVarChar, 100)
                            .Value = string.IsNullOrWhiteSpace(model.OrderNumber)
                                ? (object)DBNull.Value
                                : model.OrderNumber;

                        // ORDER DATE
                        DateTime orderDate;

                        if (DateTime.TryParse(model.OrderDate, out orderDate))
                        {
                            cmd.Parameters.Add("@OrderDate", SqlDbType.Date)
                                .Value = orderDate.Date;
                        }
                        else
                        {
                            cmd.Parameters.Add("@OrderDate", SqlDbType.Date)
                                .Value = DBNull.Value;
                        }

                        // ORDER QTY
                        cmd.Parameters.Add("@OrderQty", SqlDbType.Int)
                            .Value = model.OrderQty;

                        // PART CODE
                        cmd.Parameters.Add("@PartCode", SqlDbType.NVarChar, 100)
                            .Value = model.PartDetails != null &&
                                     !string.IsNullOrWhiteSpace(model.PartDetails.Code)
                                ? (object)model.PartDetails.Code
                                : DBNull.Value;

                        // PART CONTENT
                        cmd.Parameters.Add("@PartContent", SqlDbType.NVarChar, 500)
                            .Value = model.PartDetails != null &&
                                     !string.IsNullOrWhiteSpace(model.PartDetails.Content)
                                ? (object)model.PartDetails.Content
                                : DBNull.Value;

                        // PACK SIZE
                        cmd.Parameters.Add("@PackSize", SqlDbType.Int)
                            .Value = model.PartDetails != null
                                ? model.PartDetails.PackSize
                                : 0;

                        // MC BOX JSON
                        string jsonData = JsonConvert.SerializeObject(
                            model.MCBox ?? new List<MCBoxModel>()
                        );

                        cmd.Parameters.Add("@MCBoxJsonData", SqlDbType.NVarChar, -1)
                            .Value = jsonData;

                        // OPEN CONNECTION
                        con.Open();

                        // EXECUTE PROCEDURE
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtResult);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dtResult.Rows.Add("ERROR~" + ex.Message);
            }

            return dtResult;
        }
    }
}