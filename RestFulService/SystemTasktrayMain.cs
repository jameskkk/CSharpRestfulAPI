using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestFulService
{
    public class SystemTasktrayMain : ApplicationContext
    {
        private NotifyIcon mNotifyIcon = new NotifyIcon();
        private Configuration mConfigWindow = new Configuration();
        private WebServiceHost mServiceHost = null;
        private string mURL = "http://127.0.0.1:8081/";

        public SystemTasktrayMain()
        {
            MenuItem configMenuItem = new MenuItem("Configuration", new EventHandler(ShowConfig));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

            mNotifyIcon.Icon = RestFulService.Properties.Resources.AppIcon;
            mNotifyIcon.DoubleClick += new EventHandler(ShowMessage);
            mNotifyIcon.ContextMenu = new ContextMenu(new MenuItem[] { configMenuItem, exitMenuItem });
            mNotifyIcon.Visible = true;

            InitWebService();
        }

        private void ShowMessage(object sender, EventArgs e)
        {
            // Only show the message if the settings say we can.
            if (RestFulService.Properties.Settings.Default.ShowMessage)
            { 
                MessageBox.Show("Service is working!", "John's Restful Service", MessageBoxButtons.OK);
            }
        }

        private void ShowConfig(object sender, EventArgs e)
        {
            // If we are already showing the window meerly focus it.
            if (mConfigWindow.Visible)
            {
                mConfigWindow.Focus();
            }
            else
            {
                mConfigWindow.ShowDialog();
            }

            mConfigWindow.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            mNotifyIcon.Visible = false;
            if (mServiceHost != null && mServiceHost.State == CommunicationState.Opened)
            {
                Console.WriteLine("關閉Web Service服務！");
                mServiceHost.Close();
            }

            Application.Exit();
        }

        private void InitWebService()
        {
            try
            {
                //Console.Title = "John's Restful Service";
                PersonInfoQueryServices service = new PersonInfoQueryServices();
                //WebServiceHost _serviceHost = new WebServiceHost(service, new Uri(mURL));
                // 或者第二種方法
                mServiceHost = new WebServiceHost(typeof(PersonInfoQueryServices), new Uri(mURL));

                mServiceHost.Open();
                Console.WriteLine("Web Service已開啟...");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Web Service開啟失敗：" + ex.Message + ", " + ex.StackTrace);
            }
        }
    }
}
