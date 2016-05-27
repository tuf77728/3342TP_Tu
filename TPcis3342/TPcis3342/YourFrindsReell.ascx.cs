using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPcis3342
{
    public partial class YourFrindsReell : System.Web.UI.UserControl
    {
        FaceBookHelper.DataBaseRequest objDBhelper = new FaceBookHelper.DataBaseRequest();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //lblInfo.Text = DateTime.Now.ToString();
            DataSet allUserDataSet = new DataSet();

                allUserDataSet = objDBhelper.GetAllUsersInTable();

                Random random = new Random();

                int index = random.Next(0, allUserDataSet.Tables[0].Rows.Count);

         
                    lblUserID.Text = allUserDataSet.Tables[0].Rows[index]["UserID"].ToString();
                    lblFirstName.Text = allUserDataSet.Tables[0].Rows[index]["FirstName"].ToString();
                    lblLastName.Text = allUserDataSet.Tables[0].Rows[index]["LastName"].ToString();

                    lblCity.Text  = allUserDataSet.Tables[0].Rows[index]["City"].ToString();
                    lblState.Text = allUserDataSet.Tables[0].Rows[index]["State"].ToString();

                    profilePicture.ImageUrl  = allUserDataSet.Tables[0].Rows[index]["PhotoPath"].ToString();
                     lblLikes.Text = allUserDataSet.Tables[0].Rows[index]["Likes"].ToString();

                
            
        }
    }
}