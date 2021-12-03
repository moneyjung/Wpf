using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace TestPT
{
    /// <summary>
    /// PLCAutoControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public delegate void DataGetEventHandler(string TBNum, string TBvalue);

    public partial class PLCAutoControl : Window
    {
        // 자식 Window EventHandler
        //public delegate void OnChildTextInputHandler(string TBNum, string TBvalue);
        //public event OnChildTextInputHandler OnChildTextInputEvent;
        public DataGetEventHandler DataSendEvent;
        string connectionString = ConfigurationManager.ConnectionStrings["MYDB"].ConnectionString;

        public PLCAutoControl()
        {
            InitializeComponent();
        }

        private void Sendbtn_Click(object sender, EventArgs e)
        {
            DataSendEvent(TBNum.Text, TBvalue.Text);
            //if (OnChildTextInputEvent != null) OnChildTextInputEvent(TBNum.Text, TBvalue.Text);
        }

        private void ConnectSql()
        {
            DataSet ds = new DataSet();

            using (SqlConnection SQLCon = new SqlConnection(connectionString))
            {
                SQLCon.ConnectionString = connectionString;
                SQLCon.Open();

                SqlCommand SQLcmd = new SqlCommand();
                SQLcmd.Connection = SQLCon;
                SQLcmd.CommandText = "INSERT INTO TEST1012(설비번호,Value) VALUES(@1,@2)";
                SQLcmd.Parameters.AddWithValue("@1", double.Parse(TBNum.Text));
                SQLcmd.Parameters.AddWithValue("@2", double.Parse(TBvalue.Text));
                SQLcmd.ExecuteNonQuery();
                SQLCon.Close();

            }
        }
    }
}
