using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestPT;
using System.Net;
using System.Net.Sockets;
using Modbus.Device;
using System.Windows.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TestPT
{
    /// <summary>
    /// login.xaml에 대한 상호 작용 논리
    /// </summary>

    public partial class MainWindow : Window
    {
        ModbusIpMaster Master;
        DispatcherTimer timer;
        MainWindowsModel model;

        string connectionString = ConfigurationManager.ConnectionStrings["MYDB"].ConnectionString;
        PLCAutoControl tap = new PLCAutoControl(); // 자식 Window 생성자

        public MainWindow()
        {
            InitializeComponent();

            model = Resources["model"] as MainWindowsModel;
            Datetime();
        }

        protected void Datetime()
        {
            DBOX.Text = DateTime.Now.ToString("yyyy.MM.dd"); //현재 날짜
            NBOX.Text = GetDay(DateTime.Now);
            TBOX.Text = DateTime.Now.ToString("HH:mm"); //현재 날짜
        }

        internal void Timer()
        {
            timer = new DispatcherTimer(); // 타이머 설정
            timer.Interval = TimeSpan.FromTicks(1000000); // 1/1000000 sec
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            if ((string)BtnConnect.Content == "Connect") // Conect 버튼에 문자가 Connect일때 DisConnect로 변경
            {
                Master = ModbusIpMaster.CreateIp(new TcpClient("192.168.0.16", 502)); // 서버 통신을 위한 소켓 생성  Convert.ToInt32(TxtPort.Text)
                BtnConnect.Content = "DisConnect";
                Timer();

            }
            else // Connect 버튼에 문자가 Connect가 아닐때{(DisConnect)일때} Connect로 변경
            {
                Master = null;
                BtnConnect.Content = "Connect";
            }
        }

        private ushort[] ReadHoldingRegisters(ushort registerAddress, ushort length) // 워드를 이용한 ReadHoldingRegisters 선언
        {
            try
            {
                return Master.ReadHoldingRegisters(Convert.ToByte(1), registerAddress, length); // Convert.ToByte(TxtSlaveAddress.Text)
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool[] ReadCoils(ushort registerAddress, ushort length) // bool 값을 이용한 ReadCoils 선언
        {
            try
            {
                return Master.ReadCoils(Convert.ToByte(1), registerAddress, length); // Convert.ToByte(TxtSlaveAddress.Text)
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void WriteSingleCoil(ushort registerAddress, bool length) // bool 값을 이용한 WriteSingleCoil 선언
        {
            Master.WriteSingleCoil(Convert.ToByte(1), registerAddress, length); // Convert.ToByte(TxtSlaveAddress.Text)
        }

        internal void WriteSingleRegister(ushort registerAddress, ushort length) // 워드를 이용한 WriteSingleRegister 선언
        {
            try
            {
                Master.WriteSingleRegister(Convert.ToByte(1), registerAddress, length); // Convert.ToByte(TxtSlaveAddress.Text)
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void Timer_Tick(object sender, EventArgs e)
        {

            try // try 시도시 catch 나 try-catch-finllay로만 실행 종료 가능
            {
                var values1 = ReadHoldingRegisters(2, 1); // Values 설정 Convert.ToUInt16(TxtRegisterAddress.Text), Convert.ToUInt16(TxtRegisterCount.Text));
                //model.Value1 = (double)values1[0];
                var values2 = ReadHoldingRegisters(12, 1);
                //model.Value2 = (double)values2[0];
                var values3 = ReadHoldingRegisters(22, 1);
                //model.Value3 = (double)values3[0];
                var values4 = ReadHoldingRegisters(32, 1);
                //model.Value4 = (double)values4[0];

                model.Valued = (model.Value1 + model.Value2 + model.Value3 + model.Value4) / 10000 * 100; // Ex) 일일 생산량 만개, 설비가동률 = 생산수량 / 설비 가동시간 X 100%
                model.Valuep = (model.Value1 + model.Value2 + model.Value3 + model.Value4) / 4; // 불량 수량 불량수량 / 전체 수량 x 100%
                //bool[] coil = Master.ReadCoils(0,5);
                //TBB1.Text = coil[0].ToString();
                var coils = ReadCoils(0, 64); // ON/OFF 값 표시 Convert.ToUInt16(TxtCoilsAddress.Text), Convert.ToUInt16(TxtCoilsCount.Text));
                ON_OFF1.Content = ToBoolean(coils[2]); // 1503번 값
                ON_OFF2.Content = ToBoolean(coils[18]); // 1512번 값
                ON_OFF3.Content = ToBoolean(coils[34]); // 1522번 값
                ON_OFF4.Content = ToBoolean(coils[50]); // 1532번 값
                                                        //TBB5.Text = ToBoolean(coils[4]); // 1504번 값
                                                        //TBB6.Text = ToBoolean(coils[5]); // 1505번 값
                                                        //Master.WriteSingleRegister(1, Convert.ToUInt16(TxtBox.Text));// Convert.ToByte(TxtSendIP.Text), Convert.ToUInt16(TxtSendValue.Text)
                                                        //NTime.TextChanged(DateTime.Now.ToLongDateString());
                int[] productIntValue = new int[4] { values1[0], values2[0], values3[0], values4[0] };
                Nwvalue1.Content = productIntValue[0].ToString();
                Nwvalue2.Content = productIntValue[1].ToString();
                Nwvalue3.Content = productIntValue[2].ToString();
                Nwvalue4.Content = productIntValue[3].ToString();

                // 생산률(%) = (현재생산량 * 100) / 목표생산량  단,목표생산량이 0일경우 생산량은 100임
                int[] maxValue = new int[4] { values1[0], values2[0], values3[0], values4[0] };
                model.Value1 = maxValue[0] == 0 ? 0 : productIntValue[0] * 100 / maxValue[0];
                model.Value2 = maxValue[1] == 0 ? 0 : productIntValue[1] * 100 / maxValue[1];
                model.Value3 = maxValue[2] == 0 ? 0 : productIntValue[2] * 100 / maxValue[2];
                model.Value4 = maxValue[3] == 0 ? 0 : productIntValue[3] * 100 / maxValue[3];

                Maxvalue1.Content = maxValue[0];
                Maxvalue2.Content = maxValue[1];
                Maxvalue3.Content = maxValue[2];
                Maxvalue4.Content = maxValue[3];

                using (SqlConnection SQLCon = new SqlConnection(connectionString))
                {
                    SQLCon.ConnectionString = connectionString;
                    SQLCon.Open();

                    SqlCommand SQLcmd = new SqlCommand();
                    SQLcmd.Connection = SQLCon;
                    SQLcmd.CommandText = "INSERT INTO Sqltest(설비번호, Value, 작동) VALUES(@1,@2,@3)";
                    //Master.WriteSingleRegister(Convert.ToByte(""), Convert.ToUInt16(TBvalue));

                    SQLcmd.Parameters.AddWithValue("@1", 1);
                    SQLcmd.Parameters.AddWithValue("@2", Nwvalue1.Content);
                    SQLcmd.Parameters.AddWithValue("@3", ON_OFF1.Content);
                    SQLcmd.ExecuteNonQuery();
                    SQLCon.Close();
                }

            }
            catch (Exception ex) // 예외 설정
            {
                timer.Stop();
                BtnConnect_Click(this, new RoutedEventArgs());
                MessageBox.Show(ex.Message);
            }
        }

        private string ToDecimal(ushort value) // 
        {
            decimal val = Convert.ToDecimal(value.ToString());
            return val.ToString("0");
        }

        private string ToBoolean(bool coil)
        {
            //Boolean Bool = Convert.ToBoolean(coil.ToString());
            if (coil)
            {
                return "ON"; // Coil이 맞으면(On이면) true

            }
            else
            {
                return "OFF"; // Coil이 아니면(OFF면) False
            }

        }

        private string GetDay(DateTime dt)
        {
            string strDay = "";

            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    strDay = "Monday";
                    break;
                case DayOfWeek.Tuesday:
                    strDay = "Tuesday";
                    break;
                case DayOfWeek.Wednesday:
                    strDay = "Wednesday";
                    break;
                case DayOfWeek.Thursday:
                    strDay = "Thursday";
                    break;
                case DayOfWeek.Friday:
                    strDay = "Friday";
                    break;
                case DayOfWeek.Saturday:
                    strDay = "Saturday";
                    break;
                case DayOfWeek.Sunday:
                    strDay = "Sunday";
                    break;
            }
            return strDay;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tap.Owner = this;
            tap.DataSendEvent += new DataGetEventHandler(this.DataGet);
            tap.Show();
        }

        internal void DataGet(string TBNum, string TBvalue)
        {
            Timer();
            try
            {
                Master.WriteSingleRegister(Convert.ToByte(TBNum), Convert.ToUInt16(TBvalue));
                //bool ONF = Switch.IsChecked == "1" ?  true : false; // 불 표현식 
                //Master.WriteSingleCoil(Convert.ToByte(0), Switch.IsChecked == true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void ConnectSql()
        //{
        //    DataSet ds = new DataSet();

        //    using (SqlConnection SQLCon = new SqlConnection(connectionString))
        //    {
        //        SQLCon.ConnectionString = connectionString;
        //        SQLCon.Open();

        //        SqlCommand SQLcmd = new SqlCommand();
        //        SQLcmd.Connection = SQLCon;
        //        SQLcmd.CommandText = "INSERT INTO Sqltest(작동) VALUES(@3)";
        //        //SQLcmd.Parameters.AddWithValue("@1", double.Parse(Maxvalue1.Text));
        //        //SQLcmd.Parameters.AddWithValue("@2", double.Parse(Nwvalue1.Text));
        //        SQLcmd.Parameters.AddWithValue("@3", ON_OFF1.Content);
        //        SQLcmd.ExecuteNonQuery();
        //        SQLCon.Close();

        //    }
        //}

        //private void ConnectSql()
        //{
        //    DataSet ds = new DataSet();
        //    using (SqlConnection SQLCon = new SqlConnection(connectionString))
        //    {
        //        SQLCon.ConnectionString = connectionString;
        //        SQLCon.Open();
        //        SqlCommand SQLcmd = new SqlCommand();
        //        SQLcmd.Connection = SQLCon;
        //        SQLcmd.CommandText = ("INSERT INTO TEST1012(설비번호,Value,작동) VALUES('{0}','{1}','{2}')",);
        //        SQLcmd.ExecuteNonQuery(); SQLCon.Close();
        //    }
        //}    

    }
}

//private void Switch_Checked(object sender, RoutedEventArgs e)
//{
//    Master.WriteSingleCoil(Convert.ToByte(2), Switch1.IsChecked == true);
//    Master.WriteSingleCoil(Convert.ToByte(11), Switch2.IsChecked == true);
//    Master.WriteSingleCoil(Convert.ToByte(21), Switch3.IsChecked == true);
//    Master.WriteSingleCoil(Convert.ToByte(31), Switch4.IsChecked == true);
//    //if (Switch.IsChecked == true)
//    //{
//    //    Master.WriteSingleCoil(Convert.ToByte(0), Switch.IsChecked == true); // Check 되어 있으면(On이면) true
//    //}
//    //else
//    //{
//    //    Master.WriteSingleCoil(Convert.ToByte(0), Switch.IsChecked == false); // Check 되어 있지 않으면(OFF면) False
//    //}

//}

//private void Switch_Unchecked(object sender, RoutedEventArgs e)
//{
//    Master.WriteSingleCoil(Convert.ToByte(2), Switch1.IsChecked != false);
//    Master.WriteSingleCoil(Convert.ToByte(11), Switch2.IsChecked != false);
//    Master.WriteSingleCoil(Convert.ToByte(21), Switch3.IsChecked != false);
//    Master.WriteSingleCoil(Convert.ToByte(31), Switch4.IsChecked != false);
//}


//private void Sendbtn_Click(object sender, RoutedEventArgs e)
//{
//    try
//    {
//        Master.WriteSingleRegister(Convert.ToByte(TBNum.Text), Convert.ToUInt16(TBvalue.Text));
//        //bool ONF = Switch.IsChecked == "1" ?  true : false; // 불 표현식 
//        //Master.WriteSingleCoil(Convert.ToByte(0), Switch.IsChecked == true);
//    }
//    catch (Exception ex)
//    {
//        MessageBox.Show(ex.Message);
//    }

//    //Master.WriteSingleCoil(Convert.ToByte("0"), true);
//    //Master.WriteSingleRegister(Convert.ToByte("0"), Convert.ToUInt16(TBNum.Text));
//    //Master.WriteSingleRegister(Convert.ToByte("1"), Convert.ToUInt16(TBvalue.Text));
//}

//private void ConnectSql()
//{
//    DataSet ds = new DataSet();
//    using (SqlConnection SQLCon = new SqlConnection(connectionString))
//    {
//        SQLCon.ConnectionString = connectionString;
//        SQLCon.Open();
//        SqlCommand SQLcmd = new SqlCommand();
//        SQLcmd.Connection = SQLCon;
//        SQLcmd.CommandText = ("INSERT INTO TEST1012(설비번호,Value,작동) VALUES('{0}','{1}','{2}')",);
//        SQLcmd.ExecuteNonQuery(); SQLCon.Close();
//    }
//}    

