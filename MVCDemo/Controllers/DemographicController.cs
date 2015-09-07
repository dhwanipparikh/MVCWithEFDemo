using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MVCDemo.Models;
using MVCDemo.Repository;
using MVCDemo.Service;


namespace MVCDemo.Controllers
{
    public class DemographicController : BaseController
    {
        private DemographicService _demographicService;
        private StateService _stateService;
        private IUnitOfWork _unitOfWork;
        public DemographicController(DemographicService demographicService, StateService stateService, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _demographicService = demographicService;
            _stateService = stateService; 
        }

        [HttpGet]
        public ActionResult Index()
        {
            var members = _demographicService.GetAll();
            return View(members);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Demographic viewModel = new Demographic();
            viewModel.StateList = GetStateList();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Demographic viewModel)
        {
            
            if(SaveDemographic(viewModel))
                return RedirectToAction("index");
            else
                return View(viewModel);
        }

        private bool SaveDemographic(Demographic viewModel)
        {
            try
            {
                
                _demographicService.Save(viewModel);
                
                return true;

            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            {
                ModelState.AddModelError(string.Empty, "Record is updated by another user, please reload and try again.");
            }
            catch (Exception  ex)
            {
                ModelState.AddModelError(string.Empty,ex.Message);
            }
            viewModel.StateList = GetStateList();
            return false;
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Demographic viewModel = _demographicService.GetByID(id);
            viewModel.StateList = GetStateList();
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Demographic viewModel = _demographicService.GetByID(id);           
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Demographic viewModel)
        {
            
            if (SaveDemographic(viewModel))
                return RedirectToAction("index");
            else
                return View(viewModel);
        }

        private List<SelectListItem> GetStateList()
        {
            List<SelectListItem> lstState = new List<SelectListItem>();

            _stateService.GetStateList().ForEach(s => lstState.Add(new SelectListItem { Value = s.StateID, Text = s.StateName }));
            return lstState;

        }
    }

}