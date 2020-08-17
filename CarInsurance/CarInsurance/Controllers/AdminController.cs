using CarInsurance.Models;
using CarInsurance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsurance.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private InsuranceEntities db = new InsuranceEntities();

        public ActionResult Index()
        {
            List<Insuree> insureeList = db.Insurees.ToList(); //I used List but you can also use a "var" (variable) 
                                                              //to get info from the DB to prep
            List<InsureeVM> adminList = new List<InsureeVM>();//made a empty list or "var" called it adminList & instanciate it as a new <list>object the data types are like a shadow ViewModel only specific info
            foreach(var insuree in insureeList)// this foreach loop I'm creating a temporary name so I can reference each item in the list of insureeList
            {
                InsureeVM adminItem = new InsureeVM(); //created a new shadow (new view modelItem) that we will add to the list admistList calling it adminItem
                adminItem.FirstName = insuree.FirstName;
                adminItem.LastName = insuree.LastName;
                adminItem.QUOTE = insuree.QUOTE;                 // adminItem.Etcetc.. is the specific properties we want to pull from the actual View to add to the shadowview of it(viewmodel)
                adminItem.EmailAddress = insuree.EmailAddress;
                adminList.Add(adminItem); // now that the adminItem has all the properties we want we use this to add it to the adminList
            }
            return View(adminList); //all returns this view to the adminlist to actually be viewable on the webpage
        }
    }
}