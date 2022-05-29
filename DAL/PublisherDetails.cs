// -----------------------------------------------------------------------
// <copyright file="PublisherDetails.cs" company="Rheal Software (P.) Ltd.">
// Copyright (c) "Rheal Software (P.) Ltd.". All rights reserved.
// </copyright>
// <author>Dhirubhai Dattatrya Kulkarni</author>
// -----------------------------------------------------------------------
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Linq;
using System.Collections.Generic;
using MVCTest.Models;

namespace MVCTest.DAL
{
    public class PublisherDetails
    {
        public Database db;
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PublisherDetails class.
        /// </summary>
        public PublisherDetails()
        {
            this.db = DatabaseFactory.CreateDatabase();
        }
        #endregion

        #region Properties
        /// <summary>
       /// </summary>
         /// Gets or sets PublisherId
        public int PublisherId
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets PublisherName
        /// </summary>
        public string PublisherName
        {
            get; set;
        }

        #endregion

        //public DataSet GetList(BooksViewModel model)
        public List<PublisherDetails> GetList()
        {
            DataSet ds = null;
            try
            {
                DbCommand com = db.GetStoredProcCommand("[BooksPublisherDetailsGetList]");
                
                ds = db.ExecuteDataSet(com);
                var publisher = (from dr in ds.Tables[0].AsEnumerable()
                                 select new PublisherDetails()
                                 {
                                     PublisherId = Convert.ToInt32(dr["PublisherId"]),
                                     PublisherName = dr["PublisherName"].ToString()
                                 }).ToList();
                return publisher;
            }
            catch (Exception ex)
            {
                //To Do: Handle Exception
            }

            return null;
        }
    }
}