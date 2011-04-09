#region Using

using System;
using System.Linq;
using Gizmox.WebGUI.Forms;
using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Linq;
#endregion

namespace KeepAcconts.Web
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _context = new LightSpeedContext<ChargeModalUnitOfWork>("default");
            LightSpeedContext.UseMediumTrustCompatibility = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //using(var da = new DataAccessAdapter() )
            //{
            //    UserinfoEntity user=new UserinfoEntity();
            //    user.LoginName = this.txtUserName.Text;
            //    user.UserName = this.txtLoginName.Text;
            //    da.SaveEntity(user);
            //}
            using (var unitOfWork = _context.CreateUnitOfWork())
            {
                var user = new UserInfo();
                user.LoginName = this.txtUserName.Text;
                user.UserName = this.txtLoginName.Text;
                unitOfWork.Add(user);
                unitOfWork.SaveChanges();

                //var user1=unitOfWork.FindById<UserInfo>(1);


            }
            Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        public  void  Refresh()
        {
            using (var unitOfWork = _context.CreateUnitOfWork())
            {
                var us = from u in unitOfWork.UserInfos select u;
                this.dataGridView1.DataSource = us.ToList();

                
            }


        }

        private static LightSpeedContext<ChargeModalUnitOfWork> _context;
    }
}