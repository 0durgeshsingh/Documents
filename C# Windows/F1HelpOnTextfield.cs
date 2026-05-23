 void GetGrnoHelp()
        {
            string sql = @"SELECT GRNO,SRNO FROM GRRFILE WHERE Acno='" + lblPartyCode.Text + "' AND Qcode='" + lblQcode.Text + "'";
            DataTable dataTable = Vss.GetDataTableByQuery(sql, Connection.sqlcon);

            DataTable dt = new DataTable();
            dt.Columns.Add("GRNO");
            dt.Columns.Add("SRNO");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dt.Rows.Add(
                    dataTable.Rows[i]["GRNO"].ToString(),
                    dataTable.Rows[i]["srno"].ToString()
                );
            }

            helpdialog helpdialog = new helpdialog(dt, txtGrno, 0, 0, false);
            helpdialog.ShowDialog();

            if (helpdialog.list.Count > 0)
            {
                txtGrno.Text = helpdialog.list[0].ToString();
                lblGrrSrno.Text = helpdialog.list[1].ToString();
            }
        }

        private void txtGrno_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                GetGrnoHelp();
                e.Handled = true;
            }
        }
