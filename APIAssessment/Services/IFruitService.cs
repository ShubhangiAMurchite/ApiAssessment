using APIAssessment.DTOs;
using APIAssessment.Model;
using System.Collections.Generic;

namespace APIAssessment.Services
{
    public interface IFruitService
    {
        /// <summary>
        /// get list of all fruits
        /// </summary>
        /// <returns></returns>
        IEnumerable<Fruits> GetFruitsList();

        /// <summary>
        /// get fruit details by fruit id
        /// </summary>
        /// <param name="fruitId"></param>
        /// <returns></returns>
        Fruits GetFruitsDetailsById(int fruitId);

        /// <summary>
        ///  add edit fruits
        /// </summary>
        /// <param name="FruitsModel"></param>
        /// <returns></returns>
        Response SaveFruits(FruitsDto fruitsDto);
    }
}
