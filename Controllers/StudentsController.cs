using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using school_server.Data;
using school_server.Models;

namespace school_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _retrievesRepository;
        private readonly IChangesRepository _changesRepository;
        public StudentsController( IStudentsRepository retrievesRepository, IChangesRepository changesRepository )
        {
            _retrievesRepository = retrievesRepository;
            _changesRepository = changesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                Student[] entities = await _retrievesRepository.RetrieveAll();
                return Ok( entities );
            }
            catch( Exception e )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ForegroundColor = ConsoleColor.White;

                return StatusCode( StatusCodes.Status500InternalServerError, e.Message );
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get( int id )
        {
            try
            {
                dynamic entity = await _retrievesRepository.RetrieveDetailed( id );
                
                if( entity == null ) return NotFound();
                
                return Ok( entity );
            }
            catch( Exception e )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ForegroundColor = ConsoleColor.White;

                return StatusCode( StatusCodes.Status500InternalServerError, e.Message );
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post( [FromBody] Student entity )
        {
            try
            {
                _changesRepository.Create( entity );

                if( await _changesRepository.SaveChanges() ) 
                {
                    entity = await _retrievesRepository.Retrieve( entity.Id );

                    // return Created();
                    return StatusCode( StatusCodes.Status201Created, $"{entity.Id}" );
                }
            }
            catch( Exception e )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ForegroundColor = ConsoleColor.White;

                return StatusCode( StatusCodes.Status500InternalServerError, e.Message );
            }
            
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put( [FromBody] Student entity )
        {
            try
            {
                if( await _retrievesRepository.Retrieve( entity.Id ) == null ) 
                    return NotFound();
                
                _changesRepository.Update( entity );

                if( await _changesRepository.SaveChanges() ) 
                {
                    entity = await _retrievesRepository.Retrieve( entity.Id );

                    // return Created();
                    return StatusCode( StatusCodes.Status201Created, $"{entity.Id}" );
                }
            }
            catch( Exception e )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ForegroundColor = ConsoleColor.White;

                return StatusCode( StatusCodes.Status500InternalServerError, e.Message );
            }
            
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete( [FromQuery] int id )
        {
            try
            {
                Student entity = await _retrievesRepository.Retrieve( id );

                if( entity == null ) return NotFound();
                
                _changesRepository.Delete( entity );

                if( await _changesRepository.SaveChanges() ) 
                {
                    return Ok( entity );
                }
            }
            catch( Exception e )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ForegroundColor = ConsoleColor.White;

                return StatusCode( StatusCodes.Status500InternalServerError, e.Message );
            }
            
            return BadRequest();
        }
    }
}