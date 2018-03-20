using Newtonsoft.Json;
using Softtek.Academy.Final.Domain.Model;
using Softtek.Academy.Final.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace Softtek.Academy.Final.MVC.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64082/admin/survey");

                var result = client.GetAsync("");

                string data = result.Result.Content.ReadAsStringAsync().Result;

                List<SurveyDTO> list = JsonConvert.DeserializeObject<List<SurveyDTO>>(data);

                return View(list);
            }
        }

        [HttpPost]
        public ActionResult New(SurveyDTO survey)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64082/admin/survey");

                var content = new ObjectContent<SurveyDTO>(survey, new JsonMediaTypeFormatter());

                var result = client.PostAsync("", content).Result;

                return RedirectToAction("Index", "Survey");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64082");

                var result = client.GetAsync($"/admin/survey/{id}");
                string data = result.Result.Content.ReadAsStringAsync().Result;
                SurveyDTO survey = JsonConvert.DeserializeObject<SurveyDTO>(data);

                return View(survey);
            }
        }

        [HttpGet]
        public ActionResult Questions(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64082");

                var result = client.GetAsync($"/admin/survey/{id}");
                string data = result.Result.Content.ReadAsStringAsync().Result;
                SurveyDTO survey = JsonConvert.DeserializeObject<SurveyDTO>(data);

                return View(survey);
            }
        }

        [HttpGet]
        public ActionResult GetQuestions(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64082");

                var questions = client.GetAsync($"/admin/survey/{id}/questions");
                string questionsdata = questions.Result.Content.ReadAsStringAsync().Result;
                List<QuestionDTO> questionlist = JsonConvert.DeserializeObject<List<QuestionDTO>>(questionsdata);


                return PartialView("_SurveyQuestions", questionlist);
            }
        }

        [HttpGet]
        public ActionResult GetQuestionsNotInSurvey(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64082");

                var questions = client.GetAsync($"/admin/survey/{id}/questionsnot");
                string questionsdata = questions.Result.Content.ReadAsStringAsync().Result;
                List<QuestionDTO> questionlist = JsonConvert.DeserializeObject<List<QuestionDTO>>(questionsdata);
                List<QuestionDTO> surveyquestionlist = questionlist.Select(q => new QuestionDTO
                {
                    Id = q.Id,
                    Text = q.Text,
                    SurveyId = id,
                    QuestionTypeId = q.QuestionTypeId

                }).ToList();

                return PartialView("_AddSurveyQuestions", surveyquestionlist);
            }
        }

        [HttpGet]
        public ActionResult GetQuestionsInSurvey(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64082");

                var questions = client.GetAsync($"/admin/survey/{id}/questions");
                string questionsdata = questions.Result.Content.ReadAsStringAsync().Result;
                List<QuestionDTO> questionlist = JsonConvert.DeserializeObject<List<QuestionDTO>>(questionsdata);
                List<QuestionDTO> surveyquestionlist = questionlist.Select(q => new QuestionDTO
                {
                    Id = q.Id,
                    Text = q.Text,
                    SurveyId = id,
                    QuestionTypeId = q.QuestionTypeId

                }).ToList();

                return PartialView("_RemoveSurveyQuestions", surveyquestionlist);
            }
        }

        public ActionResult AddQuestion(QuestionDTO question)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64082");

                var content = new ObjectContent<QuestionDTO>(question, new JsonMediaTypeFormatter());

                var result = client.PutAsync($"/admin/survey/{question.SurveyId}/add", content).Result;

                return RedirectToAction("Questions", new { id = question.SurveyId });
            }
        }

        public ActionResult RemoveQuestion(QuestionDTO question)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64082");

                var content = new ObjectContent<QuestionDTO>(question, new JsonMediaTypeFormatter());

                var result = client.PutAsync($"/admin/survey/{question.SurveyId}/remove", content).Result;

                return RedirectToAction("Questions", new { id = question.SurveyId });
            }
        }

        public ActionResult Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64082/admin/survey");

                var result = client.DeleteAsync($"/admin/survey/{id}").Result;

                return RedirectToAction("Index", "Survey");
            }
        }

        [HttpPost]
        public ActionResult Update(SurveyDTO survey)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64082");

                var content1 = new ObjectContent<SurveyDTO>(survey, new JsonMediaTypeFormatter());
                var content2 = new ObjectContent<SurveyDTO>(survey, new JsonMediaTypeFormatter());
                var content3 = new ObjectContent<SurveyDTO>(survey, new JsonMediaTypeFormatter());

                if (survey.IsActive)
                {
                    var result1 = client.PutAsync($"/admin/survey/{survey.Id}/activate", content1).Result;
                }
                else
                {
                    var result2 = client.PutAsync($"/admin/survey/{survey.Id}/deactivate", content1).Result;
                }

                var result3 = client.PutAsync($"/admin/survey/{survey.Id}", content2).Result;

                var result4 = client.PutAsync($"/admin/survey/{survey.Id}/status", content3).Result;

                return RedirectToAction("Index", "Survey");
            }
        }

        [HttpGet]
        public ActionResult Report()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64082");

                var result = client.GetAsync($"/admin/survey/report");
                string data = result.Result.Content.ReadAsStringAsync().Result;
                List<Report> report = JsonConvert.DeserializeObject<List<Report>> (data);

                return View(report);
            }
        }

    }
}