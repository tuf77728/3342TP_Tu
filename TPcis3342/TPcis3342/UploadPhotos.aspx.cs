using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.SqlClient;
using System.Data;
using Utilities;

using FaceBookHelper;

namespace TPcis3342
{
    public partial class UploadPhotos : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        string strSQL;
        FaceBookHelper.DataBaseRequest objDBhelper = new DataBaseRequest();


        HttpCookie myCookie;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["CIS3342_Cookie"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                myCookie = Request.Cookies["CIS3342_Cookie"];

            }

            if (!IsPostBack)
            {
                String username = myCookie.Values["UserName"];
                strSQL = "SELECT AlbumID, AlbumName FROM TP_Albums WHERE Username =" + username + ";" ;

                LoadAllYourPictures();
            }

            if (Request.Cookies["CIS3342_CookieCustom"] != null)
            {
                SetCustomSetting();
            }
        }

        public void SetCustomSetting()
        {
            HttpCookie cookieE = Request.Cookies["CIS3342_CookieCustom"];

            String backgroundColors = cookieE.Values["backgroundColors"].ToString();
            //String fontColors = cookieE.Values["fontColors"].ToString();
            //String fontTypes = cookieE.Values["fontTypes"].ToString();
            //String theme = cookieE.Values["themes"].ToString();

            //PageBody.Attributes.Add("style", fontColors);
            //PageBody.Attributes.Add("style", fontTypes);
            PageBody.Attributes.Add("style", backgroundColors);

            //if (backgroundColors != "")
            //{
            //    PageBody.Attributes.Add("style", backgroundColors);

            //}

            //if (fontColors != "")
            //{
            //    PageBody.Attributes.Add("style", fontColors);
            //}

            //if (fontTypes != "")
            //{
            //    PageBody.Attributes.Add("style", fontTypes);
            //}

            //if (theme != "")
            //{
            //    PageBody.Attributes.Add("style", theme);
            //}
        }

        public void LoadAllYourPictures()
        {
            HttpCookie cookieE = Request.Cookies["CIS3342_Cookie"];
            String userFirstName = cookieE.Values["UserName"].ToString();
            DataSet allUsersPhots = objDBhelper.GetAllPhotosForAUser(userFirstName);

            GVallYourPictures.DataSource = allUsersPhots;
            GVallYourPictures.DataBind();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if ((txtAlbumName.Text == "")||(txtTitle.Text =="")||(txtDescription.Text=="")||(!fileUpload.HasFile))
            {
                lblStatus.Text = "*All Feilds Have To Be Filled*";
            }
            else
            {
                lblStatus.Text = "";

                int result = 0, imageSize;
                string fileExtension, imageURL, imageName, imageTitle, imageDescription;

                if (txtTitle.Text == "" || txtDescription.Text == "")
                {
                    lblStatus.Text = "ERROR: All fields need to filled in, please try again!";
                }

                try
                {
                    // Use the FileUpload control to get the uploaded data
                    if (fileUpload.HasFile)
                    {
                        //imageSize = fileUpload.PostedFile.ContentLength;
                        //byte[] imageData = new byte[imageSize];

                        //fileUpload.PostedFile.InputStream.Read(imageData, 0, imageSize);

                        imageTitle = txtTitle.Text;
                        imageName = fileUpload.PostedFile.FileName;

                        String fileExtention = System.IO.Path.GetExtension(fileUpload.FileName);//get file's extention
                        fileExtension = fileExtention.ToLower();

                        fileUpload.PostedFile.SaveAs(Server.MapPath("~/Images/") + imageName);
                        imageURL = "~/Images/" + imageName;
                        imageDescription = txtDescription.Text;

                        string username = myCookie.Values["UserName"];

                        //imageType = fileUpload.PostedFile.ContentType;



                        if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".bmp" || fileExtension == ".gif")
                        {
                            //// INSERT an image (BLOB) into the database using a stored procedure 'storeProductImage'
                            //strSQL = "storeImage";
                            //objCommand.CommandText = strSQL;
                            //objCommand.CommandType = CommandType.StoredProcedure;
                            //objCommand.Parameters.AddWithValue("@ImageURL", imageURL);
                            //objCommand.Parameters.AddWithValue("@ImageTitle", txtTitle.Text);
                            //objCommand.Parameters.AddWithValue("@ImageDescription", txtDescription.Text);
                            //objCommand.Parameters.AddWithValue("@Username", username);
                            //objCommand.Parameters.AddWithValue("@AlbumID", ddlAlbums.SelectedValue); 
                            //result = objDB.DoUpdateUsingCmdObj(objCommand);

                            //lblStatus.Text = "Image was successully uploaded.";

                            objDB = new DBConnect();

                            SqlCommand objCommand = new SqlCommand();//using System.Data.SqlClient;
                            objCommand.CommandType = CommandType.StoredProcedure;//using System.Data;
                            objCommand.CommandText = "storeImage";

                            objCommand.Parameters.AddWithValue("@ImageURL", imageURL);
                            objCommand.Parameters.AddWithValue("@Title", txtTitle.Text);
                            objCommand.Parameters.AddWithValue("@ImageDescription", txtDescription.Text);
                            objCommand.Parameters.AddWithValue("@Username", username);
                            objCommand.Parameters.AddWithValue("@AlbumID", txtAlbumName.Text);

                            objDB.GetDataSetUsingCmdObj(objCommand);

                            lblStatus.Text = "Image successfully uploaded!";

                            LoadAllYourPictures();

                            txtAlbumName.Text = "";
                            txtDescription.Text = "";
                            txtTitle.Text = "";
                        }
                        else
                        {
                            lblStatus.Text = "Only jpg, bmp, and gif file formats supported.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error ocurred: [" + ex.Message + "] cmd=" + result;
                }
            }
            
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void GVallYourPictures_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int rowIndex = e.Item.ItemIndex;
            String cmd = e.CommandName;

            Label imageID = (Label)GVallYourPictures.Items[rowIndex].FindControl("lblImageId");
            String theImageIDToDelete = imageID.Text;

            if (cmd == "CmdbtnDeletePhoto")
            {
                objDBhelper.DeletePhotoWithImageId(theImageIDToDelete);
                LoadAllYourPictures();
            }
        }

    

    } //end class

} //end namespace