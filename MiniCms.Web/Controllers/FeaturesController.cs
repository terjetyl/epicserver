using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using MiniCms.Model.Entities;
using MiniCms.Model.Repositories;
using MiniCms.Web.Models.Entities;
using MiniCms.Web.Code.Filters;

namespace MiniCms.Web.Controllers
{
    public class FeaturesController : Controller
    {
        IFeatureRepository _featureRepository;

        public FeaturesController(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        [FillViewBag]
        public ActionResult Index()
        {
            var features = _featureRepository.GetAll().Select(o => new FeatureModel{Id = o.Id, Name = o.Name});
            return View(features);
        }

        [FillViewBag]
        public ActionResult Details(int id)
        {
            return View();
        }

        [FillViewBag]
        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(string name)
        {
            try
            {
                _featureRepository.Save(new Feature {Name = name});

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [FillViewBag]
        public ActionResult Edit(int id)
        {
            var feature = _featureRepository.Get(id);
            var viewModel = new FeatureModel
                                {
                                    Id = id,
                                    Name = feature.Name,
                                    FeatureStatus = feature.FeatureSwitchStatus,
                                    FeatureStatuses = new SelectList(new List<FeatureSwitchStatus>{ FeatureSwitchStatus.Disabled, FeatureSwitchStatus.EnabledForAll, FeatureSwitchStatus.EnabledForAuthenticatedUsers, FeatureSwitchStatus.EnabledForSpecifiedUsersOrGroups })
                                };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(FeatureModel featureModel)
        {
            try
            {
                var feature = _featureRepository.Get(featureModel.Id);
                feature.Name = featureModel.Name;
                feature.FeatureSwitchStatus = featureModel.FeatureStatus;
                _featureRepository.Save(feature);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
