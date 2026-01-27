
//  Getting the Name Of Columns Index and Names or Header Text Of DatagridView .


StringBuilder sb = new StringBuilder();

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                sb.AppendLine(
                    "Index: " + column.Index +
                    ", Name: " + column.Name +
                    ", Header: " + column.HeaderText
                );
            }

 string columns = sb.ToString();

