using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TuDInputCheckers;

namespace TPcis3342
{
    public partial class PreferencesSettings : System.Web.UI.Page
    {
        FaceBookHelper.DataBaseRequest objDBhelper;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnFindAccount_Click(object sender, EventArgs e)
        {
            objDBhelper = new FaceBookHelper.DataBaseRequest();

            if (txtEmailAddress.Text == "")
            {
                lblFindAccountInfo.Visible = true;
                lblFindAccountInfo.Text = "*Input Feild Is Empty*";
            }
            else if (!Checker.GoodEmailAddress(txtEmailAddress.Text))
            {
                lblFindAccountInfo.Visible = true;
                lblFindAccountInfo.Text = "*Invaild Email Format* <br/> Correct Format: <br/> abc@temple.edu or xyz@yahoo.com or tuv@gmail.com";
            }

            else
            {
                lblFindAccountInfo.Visible = false;

                String userEmail = txtEmailAddress.Text;

                int tempUserID = objDBhelper.GetUserIDWithEmail(userEmail);

                if (tempUserID == 0)
                {
                    lblFindAccountInfo.Visible = true;
                    lblFindAccountInfo.Text = "*" + userEmail + " is not a known email address in the system*";
                }
                else
                {
                    lblFindAccountInfo.Visible = false;

                    GridViewSecurityQuestions.Visible = true;
                    btnSumbitAnswers.Visible = true;

                    DataSet tempUserRecord = objDBhelper.GetUserRecordByEmail(userEmail);

                    GridViewSecurityQuestions.DataSource = tempUserRecord;
                    GridViewSecurityQuestions.DataBind();


                    Session["userEmail"] = userEmail;

                    txtEmailAddress.Text = "";//clears feild 
                }
            }
        }

        protected void btnSumbitAnswers_Click(object sender, EventArgs e)
        {
            objDBhelper = new FaceBookHelper.DataBaseRequest();

            String question1 = "";
            String answer1 = "";
            String question2 = "";
            String answer2 = "";
            String question3 = "";
            String answer3 = "";

            for (int i = 0; i < GridViewSecurityQuestions.Rows.Count; i++)//loops through GridView
            {
                question1 = GridViewSecurityQuestions.Rows[i].Cells[0].Text;
                TextBox tboxAnswer1 = (TextBox)GridViewSecurityQuestions.Rows[i].FindControl("txtAnswer1");
                answer1 = tboxAnswer1.Text;

                question2 = GridViewSecurityQuestions.Rows[i].Cells[2].Text;
                TextBox tboxAnswer2 = (TextBox)GridViewSecurityQuestions.Rows[i].FindControl("txtAnswer2");
                answer2 = tboxAnswer2.Text;

                question3 = GridViewSecurityQuestions.Rows[i].Cells[4].Text;
                TextBox tboxAnswer3 = (TextBox)GridViewSecurityQuestions.Rows[i].FindControl("txtAnswer3");
                answer3 = tboxAnswer3.Text;
            }

            String userEmail = (String)Session["userEmail"];

            //0 = no match found question/answer combo is incorrect 
            //1 = match found question/answer combo is correct
            int question1correct = objDBhelper.GetSecurityQuestion1Response(userEmail, question1, answer1);
            int question2correct = objDBhelper.GetSecurityQuestion2Response(userEmail, question2, answer2);
            int question3correct = objDBhelper.GetSecurityQuestion3Response(userEmail, question3, answer3);
            //0 = no match found question/answer combo is incorrect 
            //1 = match found question/answer combo is correct

            if ((question1correct != 0) && (question2correct != 0) && (question3correct != 0))//all questions must return a value of 1 
            {
                lblSumbitAnswersInfo.Visible = false;
                lblUsername.Visible = true;
                lblUserPassword.Visible = true;

                lblCredentials.Visible = true;
                lblCredentials.Text += userEmail;

                DataSet tempUserRecord = objDBhelper.GetUserRecordByEmail(userEmail);
                for (int i = 0; i < tempUserRecord.Tables.Count; i++)//loops through DataSet
                {
                    lblUsername.Text += tempUserRecord.Tables[0].Rows[i]["UserName"].ToString();
                    lblUserPassword.Text += tempUserRecord.Tables[0].Rows[i]["PassWord"].ToString();

                }

            }
            else
            {
                lblUsername.Visible = false;
                lblUserPassword.Visible = false;
                lblCredentials.Visible = false;
                lblSumbitAnswersInfo.Visible = true;

                lblSumbitAnswersInfo.Text = "*One or more of your responses are incorrect*";
            }
        }

        

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        } 
    }
}