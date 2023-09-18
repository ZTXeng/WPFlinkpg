using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFlnkPG
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //reader用来填入查询sql语句
            var data = DPHelper.SelectForReader("SELECT * FROM public.revituser");
            //Updata用来填入 增删改语句
            DPHelper.Updata("INSERT INTO revituser (userid, password, lastlogtime, onlinestateid, level, onlinetime) VALUES ('18', '4455', '2023-07-19 10:00:00', 1, 3, '2023-07-19 10:00:00')");
            var dt = new DataTable();
            dt.Load(data);
            grid.ItemsSource = dt.DefaultView;
        }
    }
}
