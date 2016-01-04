using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unvell.ReoGrid;
using unvell.ReoGrid.CellTypes;
using unvell.ReoGrid.DataFormat;
using unvell.ReoGrid.Events;

namespace ParallelSPSS
{
    public partial class Form1 : Form
    {
        public string[,] DataView = new string[10000, 13];
        public string[,] VariableView = new string[100, 100];

        public static List<double> results = new List<double>();
        public static List<string> columnChoosen = new List<string>();


        private string filePath;

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                int j = i + 1;
                Data.variableView.Add(new VariableView { nama = "VAR00"+j, type = "Numeric", label = "" });
            }
            init();
        }

        private void init()
        {
            var sheet = reoGridDataView.CurrentWorksheet;
            sheet.CellMouseDown += sheet_CellMouseDown;
            sheet.SelectionRangeChanged += sheet_SelectionRangeChanged;
            sheet.FocusPosChanged += dataViewSheet_FocusPosChanged;
            var sheet2 = reoGridVarView.CurrentWorksheet;
            sheet2.Rows = 100;
            ButtonCell button = new ButtonCell();
            button.Click += Button_Click;
            for (int i = 0; i < 100; i++)
            {   if(sheet.ColumnHeaders[i]!=null)
                sheet.ColumnHeaders[i].Text = "VAR";
                button = new ButtonCell();
                button.Click += Button_Click;
                sheet2[i, 4] = button;
                sheet2[i, 4] = "...";

                button = new ButtonCell();
                button.Click += Missing_Click;
                sheet2[i, 3] = button;
                sheet2[i, 3] = "...";
                Data.variableView[i].missing = new List<string>();
                Data.variableView[i].missingRange = new List<string>();

            }
            
            sheet.CellMouseDown += columnKeyDown;
            sheet.CellDataChanged += Sheet_CellDataChanged;
            sheet2.CellDataChanged += Sheet2_CellDataChanged1;
   
            sheet2.SetCols(5);
            sheet2.ColumnHeaders[0].Text = "Name";
            sheet2.ColumnHeaders[1].Text = "Type";
            sheet2.ColumnHeaders[2].Text = "Label";
            sheet2.ColumnHeaders[3].Text = "Missing";
            sheet2.ColumnHeaders[4].Text = "Values"; 
            
            for(int i=0;i<Data.variableView.Count()-100;i++)
            {
                sheet2[i, 0] = Data.variableView[i].nama;
                sheet2[i, 1] = Data.variableView[i].type;
                sheet2[i, 2] = Data.variableView[i].label;
           //     sheet2[i, 3] = Data.variableView[i].Decimal;
                sheet.ColumnHeaders[i].Text = Data.variableView[i].nama;

            }
           
                //            sheet.ColumnHeaders[1].DefaultCellBody = typeof(unvell.ReoGrid.CellTypes.RadioButtonGroup);
                sheet2.CellDataChanged += Sheet2_CellDataChanged;
            sheet2.CellMouseDown += Sheet2_CellMouseDown;
            sheet2.SelectionRangeChanged += sheet2_SelectionRangeChanged;

  //          sheet.SetRangeDataFormat(ReoGridRange.EntireRange, CellDataFormatFlag.Number,
  //           new NumberDataFormatter.NumberFormatArgs()
  //{
  //    // decimal digit places 0.1234
  //    DecimalPlaces = 4,

  //    // negative number style: (123) 
  //    NegativeStyle = NumberDataFormatter.NumberNegativeStyle.RedBrackets,

  //    // use separator: 123,456
  //    UseSeparator = true,
  //});
        }

        #region interfaceFunction
        private void Missing_Click(object sender, EventArgs e)
        {

        }

        private void dataViewSheet_FocusPosChanged(object sender, CellPosEventArgs e)
        {
            var sheet = reoGridDataView.CurrentWorksheet;

            if (sheet[e.Position] != null)
                textBox1.Text = sheet[e.Position].ToString();
            else
                textBox1.Text = "";

            string temp = sheet.ColumnHeaders[e.Position.Col].Text;
            if (temp == "VAR")
                temp = "";
            label1.Text = e.Position.Row + 1 + " : " + temp;
            if (sheet[e.Position] != null)
                textBox1.Text = sheet[e.Position].ToString();
            else
                textBox1.Text = "";
        }

        private void sheet2_SelectionRangeChanged(object sender, RangeEventArgs e)
        {
            var sheet = reoGridDataView.CurrentWorksheet;
            var sheet2 = reoGridVarView.CurrentWorksheet;

            if (e.Range.Cols == sheet2.ColumnCount)
            {
                // MessageBox.Show("Selection changed: " + args.Range.ToAddress());
                tabControl1.SelectedIndex = 0;
                sheet.FocusPos = new unvell.ReoGrid.ReoGridPos(0, e.Range.Row);
            }
        }
       
        private void Sheet2_CellDataChanged1(object sender, CellEventArgs e)
        {
                var sheet2 = reoGridVarView.CurrentWorksheet;
                sheet2.CellDataChanged -= Sheet2_CellDataChanged1;
                for (int i = 0; i < e.Cell.Position.Row+1 ; i++)
                    for (int j = 0; j < 3; j++)
                        if (sheet2[i, j] == null || sheet2[i, j] == "")
                            if (j == 0)
                                sheet2[i, j] = Data.variableView[i].nama;
                            else if (j == 1)
                                sheet2[i, j] = Data.variableView[i].type;
                            else if (j == 2)
                                sheet2[i, j] = Data.variableView[i].label;
                            //else if (j == 3)
                            //    sheet2[i, j] = Data.variableView[i].Missing;

                Data.variableView[e.Cell.Position.Row].nama = sheet2[e.Cell.Position.Row, 0].ToString();
                Data.variableView[e.Cell.Position.Row].type = sheet2[e.Cell.Position.Row, 1].ToString();
                Data.variableView[e.Cell.Position.Row].label = sheet2[e.Cell.Position.Row, 2].ToString();
                sheet2.CellDataChanged += Sheet2_CellDataChanged1;
                //   Data.variableView[e.Cell.Position.Row].Decimal = sheet2[e.Cell.Position.Row, 3].ToString();
        
        }

        private void Sheet2_CellMouseDown(object sender, CellMouseEventArgs e)
        {
            Data.indexRow = e.CellPosition.Row;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Size newSize = new Size(control.Size.Width -20, control.Size.Height - 70);
            reoGridDataView.Size = newSize;
            reoGridVarView.Size = newSize;
            tabControl1.Size = new Size(newSize.Width+5,newSize.Height+5);
        }
        
        private void Button_Click(object sender, EventArgs e)
        {

        }

        private void Sheet2_CellDataChanged(object sender, CellEventArgs e)
        {
            if(e.Cell.Position.Col==0 && e.Cell.Data!=null)
            {
                var sheet = reoGridDataView.CurrentWorksheet;
                sheet.ColumnHeaders[e.Cell.Position.Row].Text = e.Cell.Data.ToString();
            }
            if(e.Cell.Position.Col==1 && e.Cell.Data!=null)
            {
                //var sheet = reoGridControl2.CurrentWorksheet;
             //   sheet.ColumnHeaders[e.Cell.Position.Row].DefaultCellBody = typeof(unvell.ReoGrid.CellTypes.);
            }
            if (e.Cell.Position.Col == 2 && e.Cell.Data != null)
            {
                //var sheet = reoGridControl2.CurrentWorksheet;
                //sheet.SetColumnsWidth(Data.indexRow, 1, (ushort)Data.variableView[2].label);
            }

        }

        private void Sheet_CellDataChanged(object sender, CellEventArgs e)
        {
            if (e.Cell.Data != null)
            {
                var sheet2 = reoGridVarView.CurrentWorksheet;
                if ( sheet2[e.Cell.Column,1]== "Numeric" && !IsDigitsOnly(e.Cell.Data.ToString())
                    || sheet2[e.Cell.Column, 1] == "String" && IsDigitsOnly(e.Cell.Data.ToString()))
                {
                    var sheet = reoGridDataView.CurrentWorksheet;
                    sheet[e.Cell.Position] = null;
                    textBox1.Text = "";
                }

                if (e.Cell.Data != null)
                textBox1.Text = e.Cell.Data.ToString();                
            }

        }

        void sheet_CellMouseDown(object sender, CellMouseEventArgs e)
        {
            var sheet = reoGridDataView.CurrentWorksheet;
            string temp = sheet.ColumnHeaders[e.CellPosition.Col].Text;
            if (temp == "VAR")
                temp = "";
            label1.Text = e.CellPosition.Row+1 + " : " + temp ;
            if (e.Cell != null && e.Cell.Data!=null)
                textBox1.Text = e.Cell.Data.ToString();
            else
                textBox1.Text = "";

            if (e.CellPosition.Row == sheet.RowCount-1)
                sheet.InsertRows(sheet.RowCount-1, 100);

        }

        void sheet_SelectionRangeChanged(object sender, RangeEventArgs args)
        {
            var sheet = reoGridDataView.CurrentWorksheet;
            var sheet2 = reoGridVarView.CurrentWorksheet;

            if (args.Range.Rows == sheet.RowCount)
            {
                // MessageBox.Show("Selection changed: " + args.Range.ToAddress());
                tabControl1.SelectedIndex = 1;
                sheet2.FocusPos = new unvell.ReoGrid.ReoGridPos(args.Range.Col, 0);
            }
        }
        //private void parseCell(Worksheet sheet, int column)
        //{
        //    for (int i = 0; i < sheet.RowCount; i++)
        //    {
        //        if (sheet[i, column] != null && sheet[i, column].ToString() != "")
        //        {
        //            float.TryParse(sheet[i, column].ToString(), out a[i]);
        //        }
        //        if (sheet[i + n, column] != null && sheet[i + n, column].ToString() != "")
        //        {
        //            float.TryParse(sheet[i + sheet.RowCount, column].ToString(), out b[i]);
        //        }
        //    }
        //}
        void columnKeyDown(object sender, CellMouseEventArgs e)
        {
            
        }
        #endregion

        #region FileMenuStripMethod
        private void newMenuClicked(object sender, EventArgs e)
        {
            
        }

        private void openMenuClicked(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = ".sp";
            dlg.Filter = "SPSS Parallel format(*.sp)|*.sp";

            // Process open file dialog box results 
            if (dlg.ShowDialog()==DialogResult.OK)
            {
                // Open document 
                if (File.Exists(dlg.FileName)) {
                    try
                    {
                        //    reoGridControl2.Load(dlg.FileName);
                        string json = File.ReadAllText(dlg.FileName);
                        JToken obj = JToken.Parse(json);
                        JToken temp = obj["Data"];
                        string temp2 = temp[0]["DataView"].ToString();
                        string temp3 = temp[1]["VariableView"].ToString();
                        var sheet1 = reoGridDataView.CurrentWorksheet;
                        var sheet2 = reoGridVarView.CurrentWorksheet;
                        //        DataView = =temp2.Select(jv => (string)jv).ToArray();
                        DataView = JsonConvert.DeserializeObject<string[,]>(temp2);
                        Data.variableView = JsonConvert.DeserializeObject<List<VariableView>>(temp3);
                        sheet1.AppendRows(DataView.GetLength(0) - 200);
                        //     Debug.Write(DataView.GetLength(0)+ " , "+ DataView.GetLength(1));
                        for (int i = 0; i < DataView.GetLength(0); i++)
                            for (int j = 0; j < DataView.GetLength(1); j++)
                                sheet1[i,j] = DataView[i,j];

                        //for (int x = 0; x < Data.variableView.GetLength(0); x++)
                        //    for (int y = 0; y < VariableView.GetLength(1); y++)
                        //        sheet2[x, y] = VariableView[x, y];
                        int y = 0;
                        for(int x=0;x<Data.variableView.Count;x++)
                        {
                            y = x + 1;
                            if (Data.variableView[x].nama != "VAR00" + y)
                            {
                                sheet2[x, 0] = Data.variableView[x].nama;
                                sheet2[x, 1] = Data.variableView[x].type;
                                sheet2[x, 2] = Data.variableView[x].label;
                                //      sheet2[x, 3] = Data.variableView[x].missing;
                            }
                            
                        }
                        filePath = dlg.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Loading error: " + ex.Message, "Error");
                    }
                }
            }
        }

        private async void saveMenuClicked(object sender, EventArgs e)
        {
            //SaveFileDialog dlg = new SaveFileDialog();
            //dlg.DefaultExt = ".rgf";
            //dlg.Filter = "Reo Grid F|*.rgf";

            //// Process open file dialog box results 
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    // Open document 
            //    //     reoGridControl2.Save(dlg.FileName);
            //    //    reoGridControl3.Save(dlg.FileName);
            //    //    System.Diagnostics.Process.Start(dlg.FileName);
            //    var worksheet = this.reoGridControl2.CurrentWorksheet;
            //    worksheet.Save(dlg.FileName);

            //}

            string json;
            json = "{\"Data\":[{\"DataView\": ";
            var sheet1 = reoGridDataView.CurrentWorksheet;
            var sheet2 = reoGridVarView.CurrentWorksheet;
            for (int i = 0; i < sheet1.RowCount; i++)
                for (int j = 0; j < sheet1.ColumnCount; j++)
                    if (sheet1[i, j] != null)
                        DataView[i, j] = sheet1[i, j].ToString();

            json += await JsonConvert.SerializeObjectAsync(DataView);
            json += " }, {\"VariableView\": ";

            for (int i = 0; i < sheet2.RowCount; i++)
                for (int j = 0; j < sheet2.ColumnCount; j++)
                    if (sheet2[i, j] != null)
                        VariableView[i, j] = sheet2[i, j].ToString();
            json += await JsonConvert.SerializeObjectAsync(Data.variableView);
            json += " }]}";


            //Debug.WriteLine(json);
            if (filePath == null || filePath == "")
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".sp";
                dlg.Filter = "SPSS Sistem Paralel|*.sp";

                // Process open file dialog box results 
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    filePath = dlg.FileName;
                    System.IO.File.WriteAllText(filePath, json);
                }
            }
            else
                System.IO.File.WriteAllText(filePath, json);
            
        }

        private async void saveAsClicked(object sender, EventArgs e)
        {
            string json;
            json = "{\"Data\":[{\"DataView\": ";
            var sheet1 = reoGridDataView.CurrentWorksheet;
            var sheet2 = reoGridVarView.CurrentWorksheet;
            for (int i = 0; i < sheet1.RowCount; i++)
                for (int j = 0; j < sheet1.ColumnCount; j++)
                    if (sheet1[i, j] != null)
                        DataView[i, j] = sheet1[i, j].ToString();

            json += await JsonConvert.SerializeObjectAsync(DataView);
            json += " }, {\"VariableView\": ";

            for (int i = 0; i < sheet2.RowCount; i++)
                for (int j = 0; j < sheet2.ColumnCount; j++)
                    if (sheet2[i, j] != null)
                        VariableView[i, j] = sheet2[i, j].ToString();
            json += await JsonConvert.SerializeObjectAsync(Data.variableView);
            json += " }]}";


            //Debug.WriteLine(json);

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".sp";
            dlg.Filter = "SPSS Sistem Paralel|*.sp";

            // Process open file dialog box results 
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filePath = dlg.FileName;
                System.IO.File.WriteAllText(filePath, json);
            }

        }

        private void importExcelMenuClicked(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = ".xlsx";
            dlg.Filter = "Excel 2007 Document(*.xlsx)|*.xlsx";
            int jumlahKolom=0;
            // Process open file dialog box results 
            if (dlg.ShowDialog()==DialogResult.OK)
            {
                // Open document 
                try
                {
                    reoGridDataView.Load(dlg.FileName);
                    var sheet1 = reoGridDataView.CurrentWorksheet;
                    for (int i = 0; i < sheet1.Columns; i++)
                        if (sheet1[0, i] != null && sheet1[0, i] != "")
                        {
                            sheet1.ColumnHeaders[i].Text = sheet1[0, i].ToString();
                            Data.variableView[i].nama = sheet1[0, i].ToString();
                            Data.variableView[i].label = sheet1[0, i].ToString();

                            jumlahKolom++;
                        }
           //         Debug.Write(jumlahKolom);
                    sheet1.DeleteRows(0,1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Loading error: " + ex.Message, "Error");
                }

                var sheet = reoGridDataView.CurrentWorksheet;
                var sheet2 = reoGridVarView.CurrentWorksheet;
                for (int j = 0; j < jumlahKolom; j++)
                {
                    // int jumlahBaris = 0;
                    bool onlyNumber = true;
                    for (int i = 0; i < 10; i++)
                        if (sheet[i, j] != null && !IsDigitsOnly(sheet[i, j].ToString()))
                        {
                            onlyNumber = false;
                            //         jumlahBaris++;
                        }

                    if (onlyNumber)
                    {
                        Data.variableView[j].type = "Numeric";
                    }
                    else
                    {
                        Data.variableView[j].type = "String";
                    }

                    sheet2.CellDataChanged -= Sheet2_CellDataChanged1;
                    sheet2.CellDataChanged -= Sheet2_CellDataChanged;
                    sheet2[j, 0] = Data.variableView[j].nama;
                    sheet2[j, 1] = Data.variableView[j].type;
                    sheet2[j, 2] = Data.variableView[j].label;
                    //sheet2[jumlahBaris, 3] = Data.variableView[j].type;
                    sheet2.CellDataChanged += Sheet2_CellDataChanged;
                    sheet2.CellDataChanged += Sheet2_CellDataChanged1;
                    sheet.CellMouseDown += columnKeyDown;
                    sheet.CellMouseDown += sheet_CellMouseDown;
                    sheet.SelectionRangeChanged += sheet_SelectionRangeChanged;
                    sheet2.SelectionRangeChanged += sheet2_SelectionRangeChanged;
                    sheet.FocusPosChanged += dataViewSheet_FocusPosChanged;
                    if (sheet.RowCount % 2 != 0)
                        sheet.AppendRows(1);
                }


            }
        }

        private void exportAsExcelMenuClicked(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".xlsx";
            dlg.Filter = "Excel 2007 Document|*.xlsx";
            var sheet = reoGridDataView.CurrentWorksheet;

            // Process open file dialog box results 
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Open document 

                sheet.InsertRows(0, 1);
                for (int i = 0; i < sheet.ColumnCount; i++)
                        sheet[0, i] = sheet.ColumnHeaders[i].Text;

                    reoGridDataView.Save(dlg.FileName);
            //    reoGridControl3.Save(dlg.FileName);
                System.Diagnostics.Process.Start(dlg.FileName);
                sheet.DeleteRows(0, 1);

            }
            
        }

        private void importCSVMenuClicked(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = ".CSV";
            dlg.Filter = "Comma Separated Value(*.CSV)|*.CSV";
            int jumlahKolom = 0;

            // Process open file dialog box results 
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Open document 
                try
                {
                    reoGridDataView.Load(dlg.FileName);
                    var sheet1 = reoGridDataView.CurrentWorksheet;
                    for (int i = 0; i < sheet1.Columns; i++)
                        if (sheet1[0, i] != null && sheet1[0, i] != "")
                        {
                            sheet1.ColumnHeaders[i].Text = sheet1[0, i].ToString();
                            Data.variableView[i].nama = sheet1[0, i].ToString();
                            Data.variableView[i].label = sheet1[0, i].ToString();

                            jumlahKolom++;
                        }
              //      Debug.Write(jumlahKolom);
                    sheet1.DeleteRows(0, 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Loading error: " + ex.Message, "Error");
                }

                var sheet = reoGridDataView.CurrentWorksheet;
                var sheet2 = reoGridVarView.CurrentWorksheet;
                for (int j = 0; j < jumlahKolom; j++)
                {
                    // int jumlahBaris = 0;
                    bool onlyNumber = true;
                    for (int i = 0; i < 10; i++)
                        if (sheet[i, j] != null && !IsDigitsOnly(sheet[i, j].ToString()))
                        {
                            onlyNumber = false;
                            //         jumlahBaris++;
                        }

                    if (onlyNumber)
                    {
                        Data.variableView[j].type = "Numeric";
                    }
                    else
                    {
                        Data.variableView[j].type = "String";
                    }

                    sheet2.CellDataChanged -= Sheet2_CellDataChanged1;
                    sheet2.CellDataChanged -= Sheet2_CellDataChanged;
                    sheet2[j, 0] = Data.variableView[j].nama;
                    sheet2[j, 1] = Data.variableView[j].type;
                    sheet2[j, 2] = Data.variableView[j].label;
                    //sheet2[jumlahBaris, 3] = Data.variableView[j].type;
                    sheet2.CellDataChanged += Sheet2_CellDataChanged;
                    sheet2.CellDataChanged += Sheet2_CellDataChanged1;
                    sheet.CellMouseDown += columnKeyDown;
                    sheet.CellMouseDown += sheet_CellMouseDown;
                    sheet.SelectionRangeChanged += sheet_SelectionRangeChanged;
                    sheet2.SelectionRangeChanged += sheet2_SelectionRangeChanged;
                    sheet.FocusPosChanged += dataViewSheet_FocusPosChanged;
                    if (sheet.RowCount % 2 != 0)
                        sheet.AppendRows(1);
                }

            }
        }

        private void exportAsCSVMenuClicked(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".CSV";
            dlg.Filter = "Comma Separated Value|*.CSV";
            var sheet = reoGridDataView.CurrentWorksheet;

            // Process open file dialog box results 
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Open document 
                sheet.InsertRows(0, 1);
                for (int i = 0; i < sheet.ColumnCount; i++)
                    sheet[0, i] = sheet.ColumnHeaders[i].Text;
                //     reoGridControl2.Save(dlg.FileName);
                //    reoGridControl3.Save(dlg.FileName);
                //    System.Diagnostics.Process.Start(dlg.FileName);
                var worksheet = this.reoGridDataView.CurrentWorksheet;
                worksheet.ExportAsCSV(dlg.FileName, 0, Encoding.Unicode);
                sheet.DeleteRows(0, 1);

            }
        }

        private void exitMenuClicked(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c.Equals('.'))
                    return true;
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        #region AnalyzeMenuStripMethod
        private bool analyzeOption(Form dlg1)
        {
            DialogResult dr = new DialogResult();            
            dr = dlg1.ShowDialog();
            for (int ix = 0; ix < Data.columnChoosen.Length; ix++)
            {
                if (Data.columnChoosen[ix] != -1)
                    columnChoosen.Add(Data.variableView[Data.columnChoosen[ix]].nama);
            }

            return dr == DialogResult.OK;
        }

        private void removeEmptyRow(double[] data, int length, out double[] nonEmptyData)
        {
            nonEmptyData = new double[length];
            for(int i = 0; i < length; i++)
            {
                nonEmptyData[i] = data[i];
            }
        }

        private void createDataArr(int column, out double[] nonEmptyRowData, out int missingCount, out int dataLength)
        {
            missingCount = 0;
            dataLength = 0;           
            double temp, temp2;
            Worksheet sheet = reoGridDataView.CurrentWorksheet;
            int N = sheet.RowCount;
            Debug.WriteLine("banyak angka" + N);
            double[] data = new double[N];
            double datTmp;

            if (Data.variableView[column].missing.Count > 0)
            {
                foreach (string missing in Data.variableView[column].missing)
                {
                    int j = 0;
                    dataLength = 0;
                    for (int i = 0; i < N; i++)
                    {
                        if (sheet[i, column] != null && sheet[i, column].ToString() != "")
                        {
                            double.TryParse(sheet[i, column].ToString(), out datTmp);
                            dataLength++;
                        }
                        else datTmp = double.NaN;

                        double.TryParse(missing, out temp);
                        if (datTmp == temp)
                        {
                            missingCount++;
                        }
                        else
                        {
                            data[j] = datTmp;
                            j++;
                        }
                    }
                }
            }
            else if (Data.variableView[column].missingRange.Count > 1)
            {
                int j = 0;
                for (int i = 0; i < N; i++)
                {
                    if (sheet[i, column] != null && sheet[i, column].ToString() != "")
                    {
                        double.TryParse(sheet[i, column].ToString(), out datTmp);
                        dataLength++;
                    }
                    else datTmp = double.NaN;

                    double.TryParse(Data.variableView[column].missingRange[0], out temp);
                    double.TryParse(Data.variableView[column].missingRange[1], out temp2);
                    if (data[i] >= temp && data[i] <= temp2)
                    {
                        missingCount++;
                    }
                    else
                    {
                        data[j] = datTmp;
                        j++;
                    }
                }
            }
            else
            {
                for(int i=0;i< N; i++)
                {
                    if (sheet[i, column] != null && sheet[i, column].ToString() != "")
                    {
                        double.TryParse(sheet[i, column].ToString(), out data[i]);
                        //Debug.Write(data[i] + " ");
                        dataLength++;
                    }
                    //else
                    //{
                    //    data[i] = double.NaN;
                    //}
                }
                //Debug.WriteLine("");
            }
            removeEmptyRow(data, dataLength, out nonEmptyRowData);
        }

        private void meanClick(object sender, EventArgs e)
        {
            string operatorType = "Mean";
            Form dlg1 = new AnalyzeForm();
            if (analyzeOption(dlg1))
            {
                for (int i = 0; i < Data.columnChoosen.Length; i++)
                {
                    if (Data.columnChoosen[i] != -1)
                    {
                        int column = Data.columnChoosen[i];
                        double[] data;
                        int miss, dataSize;
                        double result;

                        createDataArr(column, out data, out miss, out dataSize);
                        Debug.WriteLine(miss);

                        result = FunctionClass.Mean(data, miss, dataSize);
                        Debug.WriteLine("mean-nya adalah " + result);
                        results.Add(result);                        
                    }
                }
                DialogResult dialog = new DialogResult();
                Form dialogResult = new ResultForm(operatorType);
                dialog = dialogResult.ShowDialog();
                results.Clear();
            }
            else dlg1.Close();
        }

        private void medianClicked(object sender, EventArgs e)
        {
            string operatorType = "Median";
            Form dlg1 = new AnalyzeForm();
            if (analyzeOption(dlg1))
            {
                for (int i = 0; i < Data.columnChoosen.Length; i++)
                {
                    if (Data.columnChoosen[i] != -1)
                    {
                        int column = Data.columnChoosen[i];
                        double[] data;
                        int miss, dataSize;
                        double result;

                        createDataArr(column, out data, out miss, out dataSize);
                        Debug.WriteLine(miss);

                        result = FunctionClass.Median(data, miss, dataSize);
                        Debug.WriteLine("median-nya adalah " + result);
                        results.Add(result);
                    }
                }
                DialogResult dialog = new DialogResult();
                Form dialogResult = new ResultForm(operatorType);
                dialog = dialogResult.ShowDialog();
                results.Clear();
            }
            else dlg1.Close();
        }

        private void modesClicked(object sender, EventArgs e)
        {
            string operatorType = "Modes";
            Form dlg1 = new AnalyzeForm();
            if (analyzeOption(dlg1))
            {
                for (int i = 0; i < Data.columnChoosen.Length; i++)
                {
                    if (Data.columnChoosen[i] != -1)
                    {
                        int column = Data.columnChoosen[i];
                        double[] data;
                        int miss, dataSize;
                        double result;

                        createDataArr(column, out data, out miss, out dataSize);
                        Debug.WriteLine(miss);

                        result = FunctionClass.Modes(data, miss, dataSize);
                        Debug.WriteLine("modus-nya adalah " + result);
                        results.Add(result);
                    }
                }
                DialogResult dialog = new DialogResult();
                Form dialogResult = new ResultForm(operatorType);
                dialog = dialogResult.ShowDialog();
                results.Clear();
            }
            else dlg1.Close();
        }

        private void standardDeviationClicked(object sender, EventArgs e)
        {
            string operatorType = "SD";
            Form dlg1 = new AnalyzeForm();
            if (analyzeOption(dlg1))
            {
                for (int i = 0; i < Data.columnChoosen.Length; i++)
                {
                    if (Data.columnChoosen[i] != -1)
                    {
                        int column = Data.columnChoosen[i];
                        double[] data;
                        int miss, dataSize;
                        double result;

                        createDataArr(column, out data, out miss, out dataSize);
                        Debug.WriteLine(miss);

                        result = FunctionClass.StandardDeviation(data, miss, dataSize);
                        Debug.WriteLine("deviasi standar-nya adalah " + result);
                        results.Add(result);
                    }
                }
                DialogResult dialog = new DialogResult();
                Form dialogResult = new ResultForm(operatorType);
                dialog = dialogResult.ShowDialog();
                results.Clear();
            }
            else dlg1.Close();
        }

        private void varianceClicked(object sender, EventArgs e)
        {
            string operatorType = "Variance";
            Form dlg1 = new AnalyzeForm();
            if (analyzeOption(dlg1))
            {
                for (int i = 0; i < Data.columnChoosen.Length; i++)
                {
                    if (Data.columnChoosen[i] != -1)
                    {
                        int column = Data.columnChoosen[i];
                        double[] data;
                        int miss, dataSize;
                        double result;

                        createDataArr(column, out data, out miss, out dataSize);
                        Debug.WriteLine(miss);

                        result = FunctionClass.Variance(data, miss, dataSize);
                        Debug.WriteLine("variansi-nya adalah " + result);
                        results.Add(result);
                    }
                }
                DialogResult dialog = new DialogResult();
                Form dialogResult = new ResultForm(operatorType);
                dialog = dialogResult.ShowDialog();
                results.Clear();
            }
            else dlg1.Close();
        }

        private void rangeClicked(object sender, EventArgs e)
        {
            string operatorType = "Range";
            Form dlg1 = new AnalyzeForm();
            if (analyzeOption(dlg1))
            {
                for (int i = 0; i < Data.columnChoosen.Length; i++)
                {
                    if (Data.columnChoosen[i] != -1)
                    {
                        int column = Data.columnChoosen[i];
                        double[] data;
                        int miss, dataSize;
                        double result;

                        createDataArr(column, out data, out miss, out dataSize);
                        Debug.WriteLine(miss);

                        result = FunctionClass.Range(data, miss, dataSize);
                        Debug.WriteLine("range-nya adalah " + result);
                        results.Add(result);
                    }
                }
                DialogResult dialog = new DialogResult();
                Form dialogResult = new ResultForm(operatorType);
                dialog = dialogResult.ShowDialog();
                results.Clear();
            }
            else dlg1.Close();
        }

        private void regresionClicked(object sender, EventArgs e)
        {
            string operatorType = "Linear Regression";
            Form dlg1 = new AnalyzeForm();
            if (analyzeOption(dlg1))
            {
                for (int i = 0; i < Data.columnChoosen.Length; i++)
                {
                    if (Data.columnChoosen[i] != -1)
                    {
                        int column = Data.columnChoosen[i];
                        double[] data;
                        int miss, dataSize;
                        double result;

                        createDataArr(column, out data, out miss, out dataSize);
                        Debug.WriteLine(miss);

                        result = FunctionClass.Mean(data, miss, dataSize);
                        Debug.WriteLine("regresi linear-nya adalah " + result);
                        results.Add(result);
                    }
                }
                DialogResult dialog = new DialogResult();
                Form dialogResult = new ResultForm();
                dialog = dialogResult.ShowDialog();
                results.Clear();
            }
            else dlg1.Close();
        }
        #endregion
    }
}

//float meanSequential = 0;
//for (int i = 0; i < n; i++)
//    meanSequential += a[i] + b[i];
//meanSequential = meanSequential / (sum - missingCount);
//float[] dev_a = _gpu.CopyToDevice(a);
//float[] dev_b = _gpu.CopyToDevice(b);
//float[] dev_c = _gpu.Allocate<float>(c);


//bool first = true;
//int N_awal = n;
//while (n > 1)
//{
//    if (!first)
//    {
//        a = new float[n];
//        b = new float[n];
//        // c = new int[N];
//        float[] baru = new float[n];
//        for (int i = 0; i < (c.Count() - n); i++)
//            baru[i] = c[n + i];

//        dev_a = _gpu.CopyToDevice(c.Take(n).ToArray());
//        dev_b = _gpu.CopyToDevice(baru);
//        c = new float[n];
//        dev_c = _gpu.Allocate<float>(c);
//    }

//    float[] d = new float[n];

//    if (n % 2 == 0)
//        n = n / 2;
//    else
//        n = (n + 1) / 2;

//    first = false;
//}////for (int i = 0; i < N; i++)
////    Debug.Assert(a[i] + b[i] == c[i]);