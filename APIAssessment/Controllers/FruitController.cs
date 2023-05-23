using APIAssessment.DTOs;
using APIAssessment.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APIAssessment.Controllers
{
    public class FruitController : Controller
    {
        IFruitService _fruitService;
        
        public FruitController(IFruitService fruitService)
        {
            _fruitService = fruitService;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// get all fruits
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/fruit/all")]
        public IActionResult GetAllFruits()
        {
            try
            {
                var fruits = _fruitService.GetFruitsList();
                if (fruits == null) return NotFound();
                return Ok(fruits);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
       
        /// <summary>
        /// save fruit
        /// </summary>
        /// <param name=fruitsModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/fruit")]
        public IActionResult SaveFruit([FromBody] FruitsDto fruitsDto)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    var model = _fruitService.SaveFruits(fruitsDto);
                    return Ok(model);                    
                }
                else
                {
                    return BadRequest();
                }
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
