using MVCTest.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using MVCTest.Models;



namespace MVCTest.Controllers
{
    public class BooksController : Controller
    {

        //GET: Books
        //Using dataset

        //   public ActionResult Index()
        //    {
        //        BooksViewModel model = new BooksViewModel();
        //        Books obj = new Books();
        //        DataSet ds = obj.GetList();
        //        var books = (from DataRow dr in ds.Tables[0].Rows
        //                     select new Books()
        //                     {
        //                         BookId = Convert.ToInt32(dr["BookId"]),
        //                         BookName = dr["BookName"].ToString()
        //                     }).ToList();
        //        model.booklist = books;
        //        //BooksCategories categories = new BooksCategories();
        //        //DataSet ds_cat = categories.GetList();
        //        //var category = (from DataRow dr in ds_cat.Tables[0].Rows
        //        //                select new BooksCategories()
        //        //                {
        //        //                    BookCategoryId = Convert.ToInt32(dr["BookCategoryId"]),
        //        //                    CategoryType = dr["CategoryType"].ToString()
        //        //                }).ToList();
        //        //model.categorylist = category;
        //        //PublisherDetails Publisher = new PublisherDetails();
        //        //DataSet ds_pub = Publisher.GetList();
        //        //var Publishers = (from DataRow dr in ds_pub.Tables[0].Rows
        //        //                  select new PublisherDetails()
        //        //                  {
        //        //                      PublisherId = Convert.ToInt32(dr["PublisherId"]),
        //        //                      PublisherName = dr["PublisherName"].ToString()
        //        //                  }).ToList();
        //        //model.publisherlist = Publishers;
        //        return View(model);
        //}




        //public ActionResult Index1()
        //{
        //{
        //    Books obj = new Books();
        //    var a = obj.GetList();
        //    return View(a);
        //}


        //public ActionResult Index()
        //{

        //Books obj = new Books();
        //DataSet ds = obj.GetList();
        //IEnumerable<Books> list = (from DataRow dr in ds.Tables[0].Rows
        //                           select new Books()
        //                           {
        //                               BookId = Convert.ToInt32(dr["BookId"]),
        //                               BookName = dr["Name"].ToString(),
        //                               BookCategoryId = Convert.ToInt32(dr["BookCategoryId"].ToString()),
        //                               PublisherId = Convert.ToInt32(dr["PublisherId"].ToString()),
        //                               CategoryType = dr["CategoryType"].ToString(),
        //                               PublisherName = dr["PublisherName"].ToString(),
        //                               Quantity = Convert.ToInt32(dr["Quantity"].ToString())
        //                           }).ToList();

        /// <summary>
        /// GET: Books, Dropdown for Category and Publisher.
        /// Using ListView and Viewbag property.
        /// </summary>

        //For Books
        //Books obj = new Books();
        //DataSet ds = obj.GetList();
        //var books = (from DataRow dr in ds.Tables[0].Rows
        //             select new Books()
        //             {
        //                 BookId = Convert.ToInt32(dr["BookId"]),
        //                 BookName = dr["BookName"].ToString()
        //             }).ToList();
        //obj.bookinfo = books;

        //For Categories
        //BooksCategories categories = new BooksCategories();
        //DataSet ds_cat = categories.GetList();
        //IEnumerable<BooksCategories> category = (from DataRow dr in ds_cat.Tables[0].Rows
        //                           select new BooksCategories()
        //                           { 
        //                               BookCategoryId = Convert.ToInt32(dr["BookCategoryId"]),
        //                               CategoryType = dr["CategoryType"].ToString()
        //                           }).ToList();
        //ViewBag.Categorylist = new SelectList(category.Select(m => m.CategoryType).Distinct());

        //For Publisher
        //PublisherDetails Publisher = new PublisherDetails();
        //DataSet ds_pub = Publisher.GetList();
        //IEnumerable<PublisherDetails> Publishers = (from DataRow dr in ds_pub.Tables[0].Rows
        //                                         select new PublisherDetails()
        //                                         {
        //                                             PublisherId = Convert.ToInt32(dr["PublisherId"]),
        //                                             PublisherName = dr["PublisherName"].ToString()
        //                                         }).ToList();
        //ViewBag.Publisherlist = new SelectList(Publishers.Select(m => m.PublisherName).Distinct());


        /// <summary>
        /// GET: Books, Dropdown for Category and Publisher.
        /// Using Model object passed to the view.
        /// </summary>


        //Books obj = new Books();
        //DataSet ds = obj.GetList();
        //var books = (from DataRow dr in ds.Tables[0].Rows
        //             select new Books()
        //             {
        //                 BookId = Convert.ToInt32(dr["BookId"]),
        //                 BookName = dr["BookName"].ToString()
        //             }).ToList();
        //obj.bookinfo = books;


        //BooksCategories categories = new BooksCategories();
        //DataSet ds_cat = categories.GetList();
        //var category = (from DataRow dr in ds_cat.Tables[0].Rows
        //                select new BooksCategories()
        //                {
        //                    BookCategoryId = Convert.ToInt32(dr["BookCategoryId"]),
        //                    CategoryType = dr["CategoryType"].ToString()
        //                }).ToList();
        //obj.categoryinfo = category;

        //PublisherDetails Publisher = new PublisherDetails();
        //DataSet ds_pub = Publisher.GetList();
        //var Publishers = (from DataRow dr in ds_pub.Tables[0].Rows
        //                  select new PublisherDetails()
        //                  {
        //                      PublisherId = Convert.ToInt32(dr["PublisherId"]),
        //                      PublisherName = dr["PublisherName"].ToString()
        //                  }).ToList();
        //obj.publisherinfo = Publishers;
        //return View(obj);


        //return View();
        //}




        [HttpGet]
        //Fetching data from index file.
        public ActionResult Index()
        {

            BooksViewModel model = new BooksViewModel();
            Books books = new Books();
            BooksCategories categories = new BooksCategories();
            PublisherDetails publishers = new PublisherDetails();
            model.PageNumber = 1; //Default PageNumber
            model.PageSize= 3; //Default Page Size
            if (Session["BooksViewModel"] != null)
            {
                model = (BooksViewModel)Session["BooksViewModel"];
            }
           
           
            model.categorylist = categories.GetList();   //CategoryData();
            model.publisherlist = publishers.GetList();  //PublisherData();
            //Using DropDownListFor select the pagesize
            model.PageSizeList = new List<int>() { 3, 5, 10 };

            //Used for pagination purpose.
            //model.count = Convert.ToInt32(model.booklist[0].TotalRecords);                            //assign the zeroth row value of TotalRecords to count
            //model.TotalPages = (int)Math.Ceiling((double)model.count / model.PageSize);                //Using Pagination TotalRecords 
            return View(model);
        }
        
        [HttpPost]
        //Fetching value from index file and passed to model for searhing the values.
        public ActionResult Index(BooksViewModel model)  //string BookName = "", int BookCategoryId = 0, int PublisherId = 0)
        {
            Session["BooksViewModel"] = model;
            //BooksViewModel BookModel = new BooksViewModel();
            Books books = new Books();
            //Session["PageNumber"] = model.PageNumber;
            //Session["PageSize"] = model.PageSize;

            model.booklist = books.GetList(model);
            //Session["booklist"] = books.GetList(model);
            model.count = Convert.ToInt32(model.booklist[0].TotalRecords);                            //assign the zeroth row value of TotalRecords to count
            model.TotalPages = (int)Math.Ceiling((double)model.count / model.PageSize);               //Using Pagination TotalRecords 
            // return Json(model, JsonRequestBehavior.AllowGet );
            //return View(model);
            return PartialView("Partial", model);
        }

        public ActionResult Insertdata(int Id)
        {
            BooksViewModel model = new BooksViewModel();
            Books books = new Books();
            BooksCategories categories = new BooksCategories();
            PublisherDetails publishers = new PublisherDetails();
            model.categorylist = categories.GetList();   //CategoryData();
            model.publisherlist = publishers.GetList();  //PublisherData();
            books.BookId = Id;
            books.Load();
            model.BookId = books.BookId;
            model.BookName = books.BookName;
            model.BookCategoryId = books.BookCategoryId;
            model.PublisherId = books.PublisherId;
            model.Quantity = books.Quantity;
            model.IsActive = books.IsActive;
            // this is a custome object holding user data
            return Json(model, JsonRequestBehavior.AllowGet );
            //return View(model);
        }

        
        [HttpPost]
        public ActionResult Insertdata(BooksViewModel model)
        {
            Books books = new Books();
            BooksCategories categories = new BooksCategories();
            PublisherDetails publishers = new PublisherDetails();
            model.categorylist = categories.GetList();   //CategoryData();
            model.publisherlist = publishers.GetList();  //PublisherData();
            books.BookId = model.BookId;
            books.BookName = model.BookName;
            books.BookCategoryId = model.BookCategoryId;
            books.PublisherId = model.PublisherId;
            books.Quantity = model.Quantity;
            books.IsActive = model.IsActive;
            books.Save();
            return Json(model, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Index");
            //return View(model);
        }


        //public ActionResult Edit(int Id)
        //{
           
        //    BooksViewModel model = new BooksViewModel();
        //    Books books = new Books();
        //    BooksCategories categories = new BooksCategories();
        //    PublisherDetails publishers = new PublisherDetails();
        //    model.categorylist = categories.GetList();   //CategoryData();
        //    model.publisherlist = publishers.GetList();  //PublisherData();
        //    books.BookId = Id;
        //    books.Load();
        //    model.BookId = books.BookId;
        //    model.BookName = books.BookName;
        //    model.BookCategoryId = books.BookCategoryId;
        //    model.PublisherId = books.PublisherId;
        //    model.Quantity = books.Quantity;
        //    model.IsActive = books.IsActive;

        //    return View("Insertdata",model);
        //}

        //[HttpPost]
        //public ActionResult Edit(BooksViewModel model, int Id)
        //{

        //    Books books = new Books();
        //    BooksCategories categories = new BooksCategories();
        //    PublisherDetails publishers = new PublisherDetails();
        //    model.categorylist = categories.GetList();   //CategoryData();
        //    model.publisherlist = publishers.GetList();  //PublisherData();

        //    books.BookId = model.BookId;
        //    books.BookName = model.BookName;
        //    books.BookCategoryId = model.BookCategoryId;
        //    books.PublisherId = model.PublisherId;
        //    books.Quantity = model.Quantity;
        //    books.IsActive = model.IsActive;

        //    books.Save();

        //    return RedirectToAction("Index",model); 
        //}


        //[HttpPost]
        //public JsonResult GetData(BooksViewModel model)
        //{
        //    Books books = new Books();
        //    model.booklist = books.GetList(model);
        //    BooksCategories categories = new BooksCategories();
        //    model.categorylist = categories.GetList();   //CategoryData();
        //    PublisherDetails publishers = new PublisherDetails();
        //    model.publisherlist = publishers.GetList();//PublisherData();
        //    //Using DropDownListFor selct the pagesize
        //    model.PageSizeList = new List<int>() { 3, 5, 10 };
        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}


        //[HttpGet]
        //public JsonResult Getdata(BooksViewModel model)
        //{
        //    //BooksViewModel model = new BooksViewModel();
        //    Books books = new Books();
        //    model.booklist = books.GetList(model);
        //    BooksCategories categories = new BooksCategories();
        //    model.categorylist = categories.GetList();   //CategoryData();
        //    PublisherDetails publishers = new PublisherDetails();
        //    model.publisherlist = publishers.GetList();//PublisherData();
        //    var json = JsonConvert.SerializeObject(model.booklist);
        //    return Json(new { data = model }, JsonRequestBehavior.AllowGet);
        //    //    //return View();

        //}

        //Retrieving Data from Book Table whcih user wnat from index file
        //public List<BooksViewModel> BookData( BooksViewModel model)  //string BookName = "", int BookCategoryId = 0, int PublisherId = 0)
        //{
        //    //List<Books> obj = new List<Books>();
        //    Books objbook = new Books();
        //    DataSet ds_book = objbook.GetList(model);
        //    //var books = (from DataRow dr in ds_book.Tables[0].Rows
        //    //             select new BooksViewModel()
        //    //             {
        //    //                 BookId = Convert.ToInt32(dr["BookId"]),
        //    //                 BookName = dr["BookName"].ToString(),
        //    //                 BookCategoryId = Convert.ToInt32(dr["BookCategoryId"].ToString()),
        //    //                 PublisherId = Convert.ToInt32(dr["PublisherId"].ToString()),
        //    //                 CategoryType = dr["CategoryType"].ToString(),
        //    //                 PublisherName = dr["PublisherName"].ToString(),
        //    //                 Quantity = Convert.ToInt32(dr["Quantity"].ToString())

        //    //             }).ToList();
        //    //return books;
        //}
        //Fetching data from BookCategories  table.
        //public List<BooksCategories> CategoryData()
        //{
        //    //List<BooksCategories> obj = new List<BooksCategories>();
        //    BooksCategories categories = new BooksCategories();
        //    DataSet ds_cat = categories.GetList();
        //    var category = (from DataRow dr in ds_cat.Tables[0].Rows
        //                    select new BooksCategories()
        //                    {
        //                        BookCategoryId = Convert.ToInt32(dr["BookCategoryId"]),
        //                        CategoryType = dr["CategoryType"].ToString()
        //                    }).ToList();
        //    return category;
        //}

        //Fetching data from PublisherDetails table.
        //public List<PublisherDetails> PublisherData()
        //{
        //    //List<PublisherDetails> obj = new List<PublisherDetails>();
        //    PublisherDetails publishers = new PublisherDetails();
        //    DataSet ds_pub = publishers.GetList();
        //    var publisher = (from DataRow dr in ds_pub.Tables[0].Rows
        //                     select new PublisherDetails()
        //                     {
        //                         PublisherId = Convert.ToInt32(dr["PublisherId"]),
        //                         PublisherName = dr["PublisherName"].ToString()
        //                     }).ToList();
        //    return publisher;
        //}

        //[HttpGet]
        //public ActionResult Index()
        //{
        //    //string BookName = Request["BookName"].ToString();
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Index(FormCollection form)
        //{
        //    string BookName = form["BookName"].ToString();
        //    BooksViewModel BookModel = new BooksViewModel();
        //    BookModel.booklist = BookData();
        //    return View(BookModel);
        //}

        //public List<BooksViewModel> BookData()
        //{
        //    //List<Books> obj = new List<Books>();
        //    Books objbook = new Books();
        //    DataSet ds_book = objbook.GetList();
        //    var books = (from DataRow dr in ds_book.Tables[0].Rows
        //                 select new BooksViewModel()
        //                 {
        //                     BookId = Convert.ToInt32(dr["BookId"]),
        //                     BookName = dr["BookName"].ToString(),
        //                     BookCategoryId = Convert.ToInt32(dr["BookCategoryId"].ToString()),
        //                     PublisherId = Convert.ToInt32(dr["PublisherId"].ToString()),
        //                     CategoryType = dr["CategoryType"].ToString(),
        //                     PublisherName = dr["PublisherName"].ToString(),
        //                     Quantity = Convert.ToInt32(dr["Quantity"].ToString())

        //                 }).ToList();
        //    return books;

        //}
    }
    }





    