// -----------------------------------------------------------------------
// <copyright file="BooksViewModel.cs" company="Rheal Software (P.) Ltd.">
// Copyright (c) "Rheal Software (P.) Ltd.". All rights reserved.
// </copyright>
// <author>Dhirubhai Dattatrya Kulkarni</author>
// -----------------------------------------------------------------------

using MVCTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Models
{
    public class BooksViewModel
    {
        
            public int BookId
            { get; set; }
            public string BookName
            { get; set; }
            public int BookCategoryId
            { get; set; }
            public string CategoryType
            { get; set; }
            public int PublisherId
            { get; set; }
            public string PublisherName
            { get; set; }
            public int Quantity
            { get; set; }
            public bool IsActive
            { get; set; }
            public int CreatedBy
            { get; set; }
            public DateTime CreatedOn
            { get; set; }
            public int ModifiedBy
            { get; set; }
            public DateTime ModifiedOn
            { get; set; }

            public List<BooksCategories> categorylist { get; set; }

            public List<PublisherDetails> publisherlist { get; set; }

            public List<BooksViewModel> booklist { get; set; }

            public List<int> PageSizeList
            {
                get;
                set;
            }


        public int PageNumber
            { get; set; }

            public int PageSize
            { get; set; }

            public int TotalPages { get; set;  }
            public int TotalRecords { get; set; }
            public int count { get; set; }


        //}

        //public class CategoryDetails
        //{
        //    public int BookCategoryId
        //    { get; set; }
        //    public string CategoryType
        //    { get; set; }
        //    public bool IsActive
        //    { get; set; }
        //    public int CreatedBy
        //    { get; set; }
        //    public DateTime CreatedOn
        //    { get; set; }
        //    public int ModifiedBy
        //    { get; set; }
        //    public DateTime ModifiedOn
        //    { get; set; }
        //    public List<BooksCategories> categoryinfo { get; set; }

        //}

        //public class PublisherDetail
        //{
        //    public int PublisherId
        //    { get; set; }
        //    public string PublisherName
        //    { get; set; }
        //    public bool IsActive
        //    { get; set; }
        //    public int CreatedBy
        //    { get; set; }
        //    public DateTime CreatedOn
        //    { get; set; }
        //    public int ModifiedBy
        //    { get; set; }
        //    public DateTime ModifiedOn
        //    { get; set; }
        //    public List<PublisherDetails> publisherinfo { get; set; }
        //}

    }
    //public class commom
    //{
    //    public BooksViewModel bookviewmodel
    //    {
    //        get; set;
    //    }
    //}

}
