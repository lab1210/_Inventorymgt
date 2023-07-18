using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_App.Services;
using Inventory_App.Models;
using System.Web.Mvc;
using System.IO;
using Inventory_App.Resources;

namespace Inventory_App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly CategoryService _categoryService;
        private readonly UnitService _unitService;
        private readonly ProductService _productservice;
        private readonly BrandService _brandService;



        public ProductsController()
        {
            _categoryService = new CategoryService();
            _unitService = new UnitService();
            _productservice = new ProductService();
            _brandService = new BrandService();

        }
        // GET: Product
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(CategoryResource category)
        {
            string filepath = "";
            if (ModelState.IsValid)
            {
                if (category.Image != null && category.Image.ContentLength > 0)
                {

                    var allowedFileTypes = new[] { "image/jpeg", "image/png" };
                    if (!allowedFileTypes.Contains(category.Image.ContentType))
                    {

                        //ModelState.AddModelError("file", "Only JPEG and PNG file types are allowed.");
                    }
                    var filename = Path.GetFileName(category.Image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads"), filename);
                    category.Image.SaveAs(path);
                    filepath = "/Uploads/" + filename;
                }
                var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;
                
                _categoryService.SaveCategory(new Category
                {
                    Id = category.Id,
                    Name = category.Name,
                    ImagePath = filepath,
                    CreatedBy=loggedInUserName,
                });
                return RedirectToAction("CategoryList");
            }
            return View(new Category());

        }
        public ActionResult CategoryList(string searchname)
        {
            var categorys = _categoryService.GetCategoryByName();
            if (!string.IsNullOrEmpty(searchname))
            {
                categorys = categorys.Where(c => c.Name.Contains(searchname)).ToList();
            }
            return View(categorys);
        }
        public ActionResult editcategory(int id)
        {
            Category category = _categoryService.GetCategoryByID(id);

            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editcategory(CategoryResource category)
        {
            if (ModelState.IsValid)
            {
                string filepath = category.ImagePath;
                if (category.Image != null && category.Image.ContentLength > 0)
                {

                    var allowedFileTypes = new[] { "image/jpeg", "image/png" };
                    if (!allowedFileTypes.Contains(category.Image.ContentType))
                    {

                        //ModelState.AddModelError("file", "Only JPEG and PNG file types are allowed.");
                    }

                    var filename = Path.GetFileName(category.Image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads"), filename);
                    category.Image.SaveAs(path);
                    filepath = "/Uploads/" + filename;
                }
                _categoryService.UpdateCategory(new Category
                {
                    Id=category.Id,
                    Name=category.Name,
                    ImagePath=category.ImagePath,

                });
                return RedirectToAction("CategoryList");
            }
            return View(category);

        }
        [HttpGet]
        public ActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("CategoryList");
        }
        public ActionResult AddBrand()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBrand([Bind(Include = "Id,Name,Description")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;
                brand.CreatedBy= loggedInUserName;
                _brandService.SaveBrand(brand);
                return RedirectToAction("BrandList");
            }
            return View(brand);
        }
        public ActionResult BrandList(string searchname, string searchbydescr)
        {
            var search = _brandService.GetBrandByName();
            if (!String.IsNullOrEmpty(searchname))
            {
                search = search.Where(c => c.Name.Contains(searchname));
            }
            if (!String.IsNullOrEmpty(searchbydescr))
            {
                search = search.Where(c => c.Name.Contains(searchbydescr));
            }
            return View(search);
        }
        public ActionResult editbrand(int id)
        {
            Brand brand = _brandService.GetBrandByID(id);
            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editbrand( Brand brand)
        {
            if (ModelState.IsValid)
            {
                _brandService.UpdateBrand(brand);
                return RedirectToAction("BrandList");
            }
            return View(brand);

        }
        [HttpGet]
        public ActionResult DeleteBrand(int id)
        {
            _brandService.DeleteBrand(id);
            return RedirectToAction("BrandList");
        }
        public ActionResult AddProduct()
        {
            IEnumerable<Unit> unitList = _unitService.GetAllUnits();
            ViewBag.UnitList = new SelectList(unitList, "Id", "Name");
            IEnumerable<Brand> brandList = _brandService.GetAllBrands();
            ViewBag.BrandList = new SelectList(brandList, "Id", "Name");
            IEnumerable<Category> categoryList = _categoryService.GetAllCategories();
            ViewBag.CategoryList = new SelectList(categoryList, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(ProductResource productResources)
        {
            string filePath = "";
            if (ModelState.IsValid)
            {
                if (productResources.Image != null && productResources.Image.ContentLength > 0)
                {

                    var allowedFileTypes = new[] { "image/jpeg", "image/png" };
                    if (!allowedFileTypes.Contains(productResources.Image.ContentType))
                    {

                        //ModelState.AddModelError("file", "Only JPEG and PNG file types are allowed.");
                    }

                    var filename = Path.GetFileName(productResources.Image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads"), filename);
                    productResources.Image.SaveAs(path);
                    filePath = "/Uploads/" + filename;
                }
                var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;


                _productservice.SaveProduct(new Product
                {
                    CategoryID = productResources.CategoryID,
                    Image = filePath,
                    BrandID = productResources.BrandID,
                    Name = productResources.Name,
                    Price = productResources.Price,
                    StockKeepingUnit = productResources.StockKeepingUnit,
                    UnitID = productResources.UnitID,
                    CreatedBy=loggedInUserName
                });
                return RedirectToAction("ProductList");
            }
            return View(new Product());
        }
        public ActionResult ProductList(string searchname, string searchbrand, string searchcategory, int? SearchPrice)
        {
            var search = _productservice.GetProductByName();
            if (!String.IsNullOrEmpty(searchname))
            {
                search = search.Where(x => x.Name.Contains(searchname));
            }
            if (!String.IsNullOrEmpty(searchbrand))
            {
                search = search.Where(x => x.Brand.Name.Contains(searchbrand));
            }
            if (!String.IsNullOrEmpty(searchcategory))
            {
                search = search.Where(x => x.Category.Name.Contains(searchcategory));
            }
            if (SearchPrice != null)
            {
                search = search.Where(x => x.Price == SearchPrice);
            }


            return View(search);
        }
        public ActionResult editproduct(int id)
        {
            IEnumerable<Unit> unitList = _unitService.GetAllUnits();
            ViewBag.UnitList = new SelectList(unitList, "Id", "Name");
            IEnumerable<Brand> brandList = _brandService.GetAllBrands();
            ViewBag.BrandList = new SelectList(brandList, "Id", "Name");
            IEnumerable<Category> categoryList = _categoryService.GetAllCategories();
            ViewBag.CategoryList = new SelectList(categoryList, "Id", "Name");
            ProductResource product = _productservice.GetProductByID(id);

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editproduct(ProductResource productResource)
        {
            if (ModelState.IsValid)
            {
                string filepath = productResource.ImagePath;
                if (productResource.Image != null && productResource.Image.ContentLength > 0)
                {

                    var allowedFileTypes = new[] { "image/jpeg", "image/png" };
                    if (!allowedFileTypes.Contains(productResource.Image.ContentType))
                    {

                        //ModelState.AddModelError("file", "Only JPEG and PNG file types are allowed.");
                    }

                    var filename = Path.GetFileName(productResource.Image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads"), filename);
                    productResource.Image.SaveAs(path);
                    filepath = "/Uploads/" + filename;
                }
                _productservice.UpdateProduct(new Product
                {
                    CategoryID = productResource.CategoryID,
                    Image = filepath,
                    BrandID = productResource.BrandID,
                    Name = productResource.Name,
                    Price = productResource.Price,
                    StockKeepingUnit = productResource.StockKeepingUnit,
                    UnitID = productResource.UnitID,
                    ID = productResource.ID

                });
                return RedirectToAction("ProductList");
            }
            return View(productResource);

        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            _productservice.DeleteProduct(id);
            return RedirectToAction("ProductList");
        }

        public ActionResult AddUnit()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUnit(Unit unit)
        {
            if (ModelState.IsValid)
            {
                var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;
                unit.CreatedBy = loggedInUserName;
                _unitService.SaveUnit(unit);
                return RedirectToAction("UnitList");
            }
            return View(unit);
        }
        public ActionResult UnitList()
        {
            return View(_unitService.GetAllUnits().ToList());
        }
        public ActionResult EditUnit(int id)
        {
            Unit unit = _unitService.GetUnitByID(id);

            return View(unit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUnit([Bind(Include = "Id,Name")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                _unitService.UpdateUnit(unit);
                return RedirectToAction("UnitList");
            }
            return View(unit);

        }
        [HttpGet]
        public ActionResult DeleteUnit(int id)
        {
            _unitService.Deleteunit(id);
            return RedirectToAction("UnitList");
        }
    }
}