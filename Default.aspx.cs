using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeAssesment
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load and bind the data on the first page load
                DataTable dtData = GetMyData(Server.MapPath("~/MyData/DataForTest.csv"));
                myDataGrid.DataSource = dtData;
                myDataGrid.DataBind();

                // Filter and bind data for Fire and Water
                FilterAndBindData(dtData);
            }
        }

        private DataTable GetMyData(string file)
        {
            DataTable dtMyDataSet = new DataTable();
            using (StreamReader fileRead = new StreamReader(file))
            {
                string line;
                int row = 0;

                while ((line = fileRead.ReadLine()) != null) // Corrected to check for null
                {
                    Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                    string[] x = CSVParser.Split(line);

                    if (row == 0)
                    {
                        // Add columns to DataTable
                        foreach (string header in x)
                        {
                            dtMyDataSet.Columns.Add(header);
                        }
                    }
                    else
                    {
                        DataRow dRow = dtMyDataSet.NewRow();
                        for (int i = 0; i < x.Length; i++)
                        {
                            dRow[i] = x[i];
                        }
                        dtMyDataSet.Rows.Add(dRow);
                    }
                    row++;
                }
            }
            return dtMyDataSet;
        }

        private void FilterAndBindData(DataTable dtData)
        {
            // Filter for Fire data
            DataView fireView = new DataView(dtData);
            fireView.RowFilter = "Type = 'Fire'"; // Assuming 'Type' is the column name for filtering
            fireDataGrid.DataSource = fireView;
            fireDataGrid.DataBind();

            // Filter for Water data
            DataView waterView = new DataView(dtData);
            waterView.RowFilter = "Type = 'Water'"; // Assuming 'Type' is the column name for filtering
            waterDataGrid.DataSource = waterView;
            waterDataGrid.DataBind();
        }
    }
}