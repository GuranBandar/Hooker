using Hooker.Affärslager;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Hooker_GUI
{
    public partial class DatabaseQuery : FormBas
    {
        private List<Table> tables = new List<Table>();
        private int currTextboxPos = 0;

        public DatabaseQuery()
        {
            InitializeComponent();
        }

        private void PopulateDataGridView(DataSet resultDS)
        {
            dgvResultTab.Columns.Clear();
            dgvResultTab.Rows.Clear();
            dgvResultTab.AutoSize = false;
            dgvResultTab.AutoGenerateColumns = false;
            dgvResultTab.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            System.Windows.Forms.DataGridViewTextBoxColumn dgvColumn;

            if (resultDS.Tables.Count == 0)
            {
                //då ska vi försöka hitta lite info att visa
            }
            else
            {
                foreach (DataColumn column in resultDS.Tables[0].Columns)
                {
                    dgvColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
                    dgvColumn.DataPropertyName = column.ColumnName;
                    dgvColumn.Name = column.ColumnName;
                    dgvResultTab.Columns.Add(dgvColumn);
                }

                string[] rowData = new string[dgvResultTab.Columns.Count];

                foreach (DataRow row in resultDS.Tables[0].Rows)
                {
                    for (int k = 0; k < dgvResultTab.Columns.Count; k++)
                    {
                        switch (row[k].GetType().FullName)
                        {
                            case "System.String":
                                rowData[k] = row[k].ToString();
                                break;
                            case "System.Byte":
                                rowData[k] = row[k].ToString();
                                break;
                            case "System.Int32":
                                rowData[k] = Convert.ToInt32(row[k]).ToString();
                                break;
                            case "System.Decimal":
                                rowData[k] = Convert.ToDecimal(row[k]).ToString();
                                break;
                            case "System.DateTime":
                                rowData[k] = Convert.ToDateTime(row[k]).ToShortDateString();
                                break;
                            case "System.DBNull":
                                rowData[k] = "NULL";
                                break;
                            default:
                                rowData[k] = row[k].ToString();
                                break;
                        }
                    }
                    dgvResultTab.Rows.Add(rowData);
                }

                string message = resultDS.Tables[0].Rows.Count.ToString() + " row(s) affected";
                lbxMessages.Items.Add(message);
            }
        }

        private void InitieraTexter()
        {
            this.Text = Översätt("Text", this.Text);
            knappkontroller1.btnKnapp0.Visible = false;
            knappkontroller1.btnKnapp1.Visible = false;
            knappkontroller1.btnKnapp2.Visible = false;
            //knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Öppna");
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_Execute");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
        }

        private void DatabaseQuery_Load(object sender, EventArgs e)
        {
            InitieraTexter();
            this.MdiParent = MdiMain;
            VisaDatabaseQuery();
        }

        private void VisaDatabaseQuery()
        {
            tables = GetAllUserTables();
            Array.ForEach(tables.OrderBy(x => x.TABLE_NAME).Select(y => y.TABLE_NAME).ToArray(), table => lbxTabeller.Items.Add(table));
            lbxTabeller.Visible = false;
            rtbQuery.Controls.Add(lbxTabeller);
            lbxTabeller.KeyUp += (menuctrl, args) =>
            {
                if (args.KeyData != System.Windows.Forms.Keys.Enter & args.KeyData != System.Windows.Forms.Keys.Tab
                    & args.KeyData != System.Windows.Forms.Keys.Escape)
                    return;

                string begin = rtbQuery.Text.Substring(0, currTextboxPos);
                string end = rtbQuery.Text.Substring(currTextboxPos);

                if (lbxTabeller.SelectedItem == null)
                {
                    return;
                }
                rtbQuery.Text = begin + (string)lbxTabeller.SelectedItem + end;
                rtbQuery.SelectionStart = currTextboxPos + ((string)lbxTabeller.SelectedItem).Length;
                lbxTabeller.Visible = false;
                rtbQuery.Focus();
            };

            lbxTabeller.LostFocus += (senderobj, args) =>
            {
                if (lbxTabeller.Visible)
                {
                    lbxTabeller.Focus();
                }
            };

            rtbQuery.GotFocus += (senderobj, args) =>
            {
                if (lbxTabeller.Visible)
                {
                    lbxTabeller.Focus();
                }
            };

            rtbQuery.KeyUp += (senderobj, args) =>
            {

                if (args.KeyData != System.Windows.Forms.Keys.Space)
                    return;

                System.Windows.Forms.RichTextBox t = (System.Windows.Forms.RichTextBox)senderobj;

                if (t.SelectionStart < 6)
                    return;

                string text = t.Text.Substring(t.SelectionStart - 6, 6);
                if (text.Trim().ToUpper().Equals("FROM") || text.Trim().ToUpper().Equals("JOIN"))
                {

                    currTextboxPos = t.SelectionStart;

                    Point p = t.GetPositionFromCharIndex(t.SelectionStart > 0 ? t.SelectionStart - 1 : 0);

                    lbxTabeller.Left = p.X;
                    lbxTabeller.Top = p.Y + 15;
                    lbxTabeller.Height = 100;
                    lbxTabeller.Visible = true;
                    lbxTabeller.Focus();
                }
            };

            rtbQuery.SelectionStart = rtbQuery.Text.Length;
            rtbQuery.Focus();
            knappkontroller1.btnKnapp2.Enabled = true;
            knappkontroller1.btnKnapp3.Enabled = false;
        }

        private List<Table> GetAllUserTables()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT t.TABLE_CATALOG, t.TABLE_SCHEMA, t.TABLE_NAME ");
            sql.Append("FROM information_schema.TABLES t ");
            sql.Append("ORDER BY t.TABLE_CATALOG, t.TABLE_SCHEMA, t.TABLE_NAME;");
            ExecuteQueryAktivitet eqa = new ExecuteQueryAktivitet();
            DataTable resultDT = eqa.ExecuteQuery(sql.ToString()).Tables[0];
            List<Table> tables = new List<Table>(resultDT.Rows.Count);
            foreach (DataRow rad in resultDT.Rows)
            {
                tables.Add(new Table()
                {
                    TABLE_CATALOG = rad["TABLE_CATALOG"].ToString(),
                    TABLE_SCHEMA = rad["TABLE_SCHEMA"].ToString(),
                    TABLE_NAME = rad["TABLE_NAME"].ToString()
                });
            }
            return tables;
        }

        private void rtbQuery_TextChanged(object sender, EventArgs e)
        {
            if (rtbQuery.Text.Length == 0)
            {
                knappkontroller1.btnKnapp3.Enabled = false;
            }
            else
            {
                knappkontroller1.btnKnapp3.Enabled = true;
            }
        }

        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            DataSet resultDS;
            ExecuteQueryAktivitet eqa = new ExecuteQueryAktivitet();

            try
            {
                if (rtbQuery.SelectedText == string.Empty)
                {
                    sql = rtbQuery.Text;
                }
                if (rtbQuery.SelectionLength > 0)
                {
                    sql = rtbQuery.SelectedText;
                }
                TimglasPå();
                resultDS = eqa.ExecuteQuery(sql);
                if (resultDS != null)
                {
                    PopulateDataGridView(resultDS);
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
            finally
            {
                TimglasAv();
                knappkontroller1.btnKnapp3.Enabled = true;
                knappkontroller1.btnKnapp2.Enabled = true;
            }
        }

        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            string fileName = string.Empty;
            //fileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            //Process process = new Process();

            //if (fileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    fileName = fileDialog.FileName;
            //}

            //if (File.Exists(fileName))
            //{
            //    process.StartInfo = new ProcessStartInfo()
            //    {
            //        UseShellExecute = true,
            //        FileName = fileName
            //    };

            //    process.Start();
            //}

        }

        private void DatabaseQuery_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
