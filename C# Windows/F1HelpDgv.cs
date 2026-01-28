private void dgv_KeyUp(object sender, KeyEventArgs e)
        {
            if (dgv.CurrentCell == null) return;

            if (dgv.CurrentCell.ColumnIndex == 2 && e.KeyCode == Keys.F1)
            {
                GetColourHelp();
                e.Handled = true;
            }
        }

        void GetColourHelp()
        {
            string sql = @"select ShedName, Sn from MstShedEntry ";
            DataTable dataTable = Vss.GetDataTableByQuery(sql, Connection.sqlcon);

            DataTable dt = new DataTable();
            dt.Columns.Add("ShedName");
            dt.Columns.Add("Sn");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dt.Rows.Add(
                    dataTable.Rows[i]["ShedName"].ToString(),
                    dataTable.Rows[i]["Sn"].ToString()
                );
            }

            helpdialog helpdialog = new helpdialog(dt, dgv, 0, 0, false);
            helpdialog.ShowDialog();

            if (helpdialog.list.Count > 0)
            {
                dgv[3, dgv.CurrentCell.RowIndex].Value = helpdialog.list[0].ToString();
                dgv[4, dgv.CurrentCell.RowIndex].Value = helpdialog.list[1].ToString();
            }
        }
