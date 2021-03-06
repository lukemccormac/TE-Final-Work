﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Web.DAL.AssingmentDAL;
using WebApplication.Web.DAL.ScenarioDAL;
using WebApplication.Web.Models;
using WebApplication.Web.Models.Scenario;
using WebApplication.Web.Providers.Auth;

namespace WebApplication.Web.Controllers
{
    public class ScenarioController : Controller
    {
        private IScenarioDAL scenarioDAL;
        private readonly IAuthProvider authProvider;
        private readonly IAssignmentDAL assignmentDAL;


        public ScenarioController(IScenarioDAL scenarioDAL, IAuthProvider authProvider, IAssignmentDAL assignmentDAL)
        {
            this.scenarioDAL = scenarioDAL;
            this.authProvider = authProvider;
            this.assignmentDAL = assignmentDAL;
        }

        public IActionResult Index()
        {
            User user = authProvider.GetCurrentUser();

            if(user == null)
            {
                return RedirectToAction("Login", "Account");


            }
    
            List<Scenario> scenarios = scenarioDAL.GetAllUserScenarios(user.Id);

            return View(scenarios);
        }

        public IActionResult Scenario(int id)
        {
            Scenario scenario = scenarioDAL.GetUserScenario(id);
            return View(scenario);
        }

        public IActionResult Response(int id)
        {
            User user = authProvider.GetCurrentUser();

            bool isSaved = scenarioDAL.SaveReview(user.Id, id);

            Answer response = scenarioDAL.GetResponse(id);
            return View(response);

        }

        public IActionResult NextScenario(int id)
        {
            User user = authProvider.GetCurrentUser();
            Scenario nextScenario = scenarioDAL.GetNextScenario(user.Id, id);

            if (nextScenario.Id == 0)
            {
                return RedirectToAction("Review", "Scenario");
            }
            return RedirectToAction("scenario", new { id = nextScenario.Id });
        }



        public IActionResult PreviousScenario(int id)
        {
            User user = authProvider.GetCurrentUser();
            Scenario nextScenario = scenarioDAL.ReplayScenario(user.Id, id);

            if (nextScenario.Id == 0)
            {
                return RedirectToAction("Review", "Scenario");
            }
            return RedirectToAction("scenario", new { id = nextScenario.Id });
        }

        [HttpGet]
        [AuthorizationFilter("Admin", "Teacher")]
        public IActionResult AssignScenario()

        {
            User currentUser = authProvider.GetCurrentUser();

            IList<Scenario> scenarios = scenarioDAL.GetAllScenarios();
            TempData["scenarios"] = scenarios;

            IList<User> students = assignmentDAL.GetAllStudents();
            TempData["students"] = students;

            return View();
        }

        [HttpGet]
        public IActionResult AssignScenarioToStudent(int studentId, int scenarioId)
        {

           assignmentDAL.AssignScenario(studentId, scenarioId);          
                
           return RedirectToAction("AssignScenario", "Scenario");  
        }

        [HttpGet]
        public IActionResult UnassignScenario(int studentId, int scenarioId)
        {
            assignmentDAL.UnassignScenario(studentId, scenarioId);

            return RedirectToAction("AssignScenario", "Scenario");
        }

        public IActionResult Review()
        {
            User currentUser = authProvider.GetCurrentUser();

            List<Review> reviews = new List<Review>();

            reviews = scenarioDAL.GetReview(currentUser.Id);

            return View(reviews);
        }

        public IActionResult TeacherReview(int studentId)
        {

            List<Review> studentAnswers = new List<Review>();
            studentAnswers = scenarioDAL.GetReview(studentId);

            IList<User> allStudents = assignmentDAL.GetAllStudents();
            TempData["students"] = allStudents;


            User student = new User();
            TempData["student"] = student;

            return View(studentAnswers);

        }

        [AuthorizationFilter("Admin")]
        public IActionResult UpdateScenarios()
        {
            List<Scenario> allScenarios = scenarioDAL.GetAllScenarios();
            return View(allScenarios);

        }

        [AuthorizationFilter("Admin")]
        public IActionResult Edit(int id)
        {
            Scenario scenario = scenarioDAL.GetUserScenario(id);
            List<Answer> answerList = scenarioDAL.GetScenarioAnswers(id);

            TempData["answerList"] = answerList;
            return View(scenario);
        }

        [HttpPost]
        public IActionResult Edit(int id, string name, string description, string imageName, string question, bool isActive)
        {
            bool success = scenarioDAL.UpdateScenario(id, name, description, imageName, question, isActive);

            return RedirectToAction("UpdateScenarios");
        }

        [HttpPost]
        public IActionResult EditAnswer(int id, string answerText, string responseText, string responseImage, string responseColor, string emoji)
        {
            bool success = scenarioDAL.UpdateAnswer(id, answerText, responseText, responseImage, responseColor, emoji);

            return RedirectToAction("UpdateScenarios");
        }

        [HttpGet]
        [AuthorizationFilter("Admin")]
        public IActionResult CreateScenario()
        {
            return View();
        }

        [AuthorizationFilter("Admin")]
        public IActionResult CreateScenario(string name, string description, string imageName, string question, int isActive)
        {
            bool success = scenarioDAL.CreateScenario(name, description, imageName, question, isActive);

            return RedirectToAction("CreateAnswer");
        }

        [HttpGet]
        [AuthorizationFilter("Admin")]
        public IActionResult CreateAnswer()
        {
            int maxScenario = scenarioDAL.GetMaxScenarioId();
            TempData["maxScenario"] = maxScenario;

            return View();
        }

        [AuthorizationFilter("Admin")]
        public IActionResult CreateAnswer(int scenarioId, string answerText, string responseText, string responseImage, string color, string emoji)
        {
            bool success = scenarioDAL.CreateAnswer(scenarioId, answerText, responseText, responseImage, color, emoji);

            return RedirectToAction("CreateAnswer");
        }

    }
}