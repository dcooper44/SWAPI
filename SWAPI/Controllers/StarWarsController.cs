using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SWAPI.Models.ViewModels;

namespace SWAPI.Controllers
{
    public class StarWarsController : Controller
    {
        private readonly StarWarsClient _starWarsClient;

        public StarWarsController(StarWarsClient starWarsClient)
        {
            _starWarsClient = starWarsClient;
        }

        public IActionResult PlanetOrPerson()
        {
            return View();
        }

        public async Task<IActionResult> GetPersonById(PlanetOrPersonViewModel model)
        {

            var response = await _starWarsClient.GetSinglePerson(model.PeopleId);

            var viewModel = new GetPersonByIdViewModel
            {
                name = response.name,
                gender = response.gender,
                birth_year = response.birth_year,                
            };


            return View(viewModel);
        }

        public async Task<IActionResult> GetPlanetById(PlanetOrPersonViewModel model)
        {

            var response = await _starWarsClient.GetSinglePlanet(model.PlanetId);

            var viewModel = new GetPlanetByIdViewModel
            {
                name = response.name,
                rotation_period = response.rotation_period,
                orbital_period = response.orbital_period,
                climate = response.climate,
                gravity = response.gravity,
                terrain = response.terrain
            };

            return View(viewModel);
        }


    }
}