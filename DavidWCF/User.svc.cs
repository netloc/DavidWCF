﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataAccess;

namespace DavidWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "User" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select User.svc or User.svc.cs at the Solution Explorer and start debugging.
    public class User : IUser
    {
        public Stream Login(Credentials LoginCredentials) {

            bool success;

            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            //StreamReader(xslDb.FileLocation).BaseStream;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();

            string procedureName = "[SECURITY].[VERIFYCREDENTIALS]";

            Parameters.Add("username", LoginCredentials.username);
            Parameters.Add("password", LoginCredentials.password);

            Sql Database = new Sql();

            success = Database.RunProcedure(procedureName, Parameters);

            byte[] bytearray = Encoding.UTF8.GetBytes(@"{ ""success"": """ + success.ToString() + @""" }");

            MemoryStream stream = new MemoryStream(bytearray);

            StreamReader reader = new StreamReader(stream);

            return reader.BaseStream;
        }

        public Stream AddUser(Credentials AddUserCredentials) {

        }
    }
}
