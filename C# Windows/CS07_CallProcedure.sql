void CallProcedureCostingSheet() {
            SqlCommand sqlCommand = new SqlCommand("usp_DailyLotCosting", Connection.sqlcon);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = this.dtpStart.Value.ToString("yyyy-MM-dd");
            sqlCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = this.dtpEnd.Value.ToString("yyyy-MM-dd");
            if (!cbAll.Checked)
                sqlCommand.Parameters.Add("@Party", SqlDbType.VarChar).Value = this.lblParty.Text;
            else
                sqlCommand.Parameters.Add("@Party", SqlDbType.VarChar).Value = "";
            sqlCommand.CommandTimeout = 10800; // 3 hours (3 * 60 * 60 seconds)
            sqlCommand.ExecuteNonQuery();
        }
