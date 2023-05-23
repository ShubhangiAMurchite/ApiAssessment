using APIAssessment.DTOs;
using APIAssessment.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIAssessment.Services
{
    public class FruitService :IFruitService
    {
        private FruitsContext _context;
        private IMapper _mapper;
        public FruitService(FruitsContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

        /// <summary>
        /// get list of all fruits
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Fruits> GetFruitsList()
        {
            
            try
            {
                var fruitsList = (from f in _context.Fruits
                           join n in _context.Nutritions on f.Id equals n.FruitsId
                           select new Fruits()
                           {                               
                               Genus=f.Genus,
                               Name=f.Name,
                               Id = f.Id,
                               Family=f.Family,
                               Order=f.Order,
                               Nutritions=f.Nutritions
                           }).ToList();

                return fruitsList;
            }
            catch (Exception)
            {
                throw;
            }           
        }

        /// <summary>
        /// get fruit details by fruit id
        /// </summary>
        /// <param name="fruitId"></param>
        /// <returns></returns>
        public Fruits GetFruitsDetailsById(int fruitId)
        {
            Fruits fruit;
            try
            {
                fruit = _context.Find<Fruits>(fruitId);
            }
            catch (Exception)
            {
                throw;
            }
            return fruit;
        }

        /// <summary>
        ///  add edit fruits
        /// </summary>
        /// <param name="fruitsModel"></param>
        /// <returns></returns>
        public Response SaveFruits(FruitsDto fruitsDto)
        {
            Fruits fruitsModel = _mapper.Map<Fruits>(fruitsDto);
            Response responseModel = new Response();
            try
            {
                Fruits _temp = GetFruitsDetailsById(fruitsModel.Id);
                if (_temp != null)
                {                    
                    responseModel.Messsage = "Fruit already exist in the database";
                }
                else
                {
                    _context.Add<Fruits>(fruitsModel);
                    responseModel.Messsage = "Fruit Inserted Successfully";
                }
                _context.SaveChanges();
                responseModel.IsSuccess = true;
            }
            catch (Exception ex)
            {
                responseModel.IsSuccess = false;
                responseModel.Messsage = "Error : " + ex.Message;
            }
            return responseModel;
        }
    }
}
