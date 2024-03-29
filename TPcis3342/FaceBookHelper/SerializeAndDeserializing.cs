﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace FaceBookHelper
{
    public class SerializeAndDeserializing
    {
        DBConnect objDB = new DBConnect();//using Utilities;
        SqlCommand objCommand = new SqlCommand();//using System.Data.SqlClient;

        public Boolean SerializingUserSettingsOBJ(int userID, String loginPreferences, String backGroundColor)
        {
            SettingsObject tempSettingsObject = new SettingsObject(loginPreferences, backGroundColor);//creates new SettingsObject OBJECT

            Boolean serialized = false;
            BinaryFormatter serializer = new BinaryFormatter();//using System.Runtime.Serialization.Formatters.Binary;
            MemoryStream memStream = new MemoryStream();//using System.IO;

            Byte[] byteArray;
            serializer.Serialize(memStream, tempSettingsObject);
            byteArray = memStream.ToArray();

            // Update the account to store the serialized object (binary data) in the database
            objCommand.CommandType = CommandType.StoredProcedure;//using System.Data;

            objCommand.CommandText = "SerializingUserSettingsOBJ";

            objCommand.Parameters.AddWithValue("@userID", userID);
            objCommand.Parameters.AddWithValue("@userSettingsOBJ", byteArray);

            int retVal = objDB.DoUpdateUsingCmdObj(objCommand);

            // Check to see whether the update was successful
            if (retVal > 0)
            {
                serialized = true;
            }
            else
            {
                serialized = false;
            }
            return serialized;
        }

        public SettingsObject Deserializing(int userID)
        {
            String strSQL = "SELECT SettingsObject FROM TP_UserAccounts WHERE UserID ='" + userID.ToString() + "'";
            objDB.GetDataSet(strSQL);
            // De-serialize the binary data to reconstruct the SettingsObject object retrieved
            // from the database
            Byte[] byteArray = (Byte[])objDB.GetField("SettingsObject", 0);

            BinaryFormatter deSerializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream(byteArray);

            SettingsObject objUserSettings = (SettingsObject)deSerializer.Deserialize(memStream);

            return objUserSettings;

        }
    }
}
