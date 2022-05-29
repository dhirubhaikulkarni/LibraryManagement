// -----------------------------------------------------------------------
// <copyright file="BooksCategories.cs" company="Rheal Software (P.) Ltd.">
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
using System.Collections.Generic;

using System.Configuration;
using System.Linq;
using MVCTest.Models;

namespace MVCTest.DAL
{
    public class BooksCategories
    {
        public Database db;
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BooksCategories class.
        /// </summary>

        public BooksCategories()
        {
            this.db = DatabaseFactory.CreateDatabase();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets BookCategoryId
        /// </summary>

        public int BookCategoryId
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets CategoryType
        /// </summary>

        public string CategoryType
        {
            get; set;
        }

        #endregion




        //public DataSet GetList(BooksViewModel model)
       public List<BooksCategories> GetList()
        {
            
            DataSet ds = null;
            try
            {
                DbCommand com = db.GetStoredProcCommand("BooksCategoriesGetList");
              
                ds = db.ExecuteDataSet(com);

                var category = (from dr in ds.Tables[0].AsEnumerable()
                                select new BooksCategories()
                                {
                                    BookCategoryId = Convert.ToInt32(dr["BookCategoryId"]),
                                    CategoryType = dr["CategoryType"].ToString()
                                }).ToList();
                return category;

            }
            catch (Exception ex)
            {
                //To Do: Handle Exception
            }

            return null;
        }
    }
}