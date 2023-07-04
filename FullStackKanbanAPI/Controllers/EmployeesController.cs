using FullStackKanbanAPI.Data;
using FullStackKanbanAPI.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackKanbanAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // this is a route for the APIController ,
                                // this will active once a user goes to certain section of the application
                                // we use the Route in order for the HTTPGet request to trigger on THAT particular page.

                                // using a [Route] will define the place and map it to the specific controller needed , 
                                //but if its going somewhere else it will need to be specified.
    public class EmployeesController : Controller
    {
        private readonly FullStackKanBanDBContext _fullStackKanBanDBContext;

        // constructor
        public EmployeesController(FullStackKanBanDBContext fullStackKanBanDBContext) //always name the perameter within constructor
        {
           _fullStackKanBanDBContext = fullStackKanBanDBContext;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllEmployees()  // since this is a Async request it needs to be a variable in order to run 
        {
            var employees = await _fullStackKanBanDBContext.Employees.ToListAsync(); // with this you are drilling down from the database
                                                                                     // to the specific table of tentxt you wish to use ,
                                                                                     // then you impliment a method of choice.

            return Ok(employees);
        }


        [HttpPost]

        public async Task<IActionResult> AddEmployee([FromBody] KanBanEmployee employeeRequest) 
        {
            employeeRequest.Id = Guid.NewGuid();

            await _fullStackKanBanDBContext.Employees.AddAsync(employeeRequest);
            await _fullStackKanBanDBContext.SaveChangesAsync();

            return Ok(employeeRequest);

        }

        [HttpGet]  // get Employee Request to update view funcationality based off the Guid 
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetEmployee([FromRoute] Guid id )
        {
            var employee = await _fullStackKanBanDBContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);


        }

        [HttpPut]
        [Route("{id:Guid}")] // to edit and then save changed data to databse , using Guid as refrence point.

        public async Task<IActionResult> UpdateEmployees([FromRoute] Guid id , KanBanEmployee updateEmployeeRequest)
        {
            var employee = await _fullStackKanBanDBContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            } 

            employee.Name = updateEmployeeRequest.Name;
            employee.Email = updateEmployeeRequest.Email;
            employee.Phone = updateEmployeeRequest.Phone;

            await _fullStackKanBanDBContext.SaveChangesAsync();

            return Ok(employee);
        }


        [HttpDelete]
        [Route("{id:Guid}")] // deleteing the Employee from roster 

        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _fullStackKanBanDBContext.Employees.FindAsync(id);

            if(employee == null)
            {
                return NotFound();
            }

            _fullStackKanBanDBContext.Employees.Remove(employee);

            await _fullStackKanBanDBContext.SaveChangesAsync();

            return Ok(employee);
        }

    }

}
