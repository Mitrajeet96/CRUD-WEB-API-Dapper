using CRUD_WEB_API.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
       

        // GET: api/<EmpController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var result = DapperORM.ReturnList<EmpModel>("ViewAll");
                return Ok(result);

            }
            catch (Exception )
            {
                return BadRequest();
            }
        }

        // GET api/<EmpController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                DynamicParameters Dp = new DynamicParameters();
                Dp.Add("@Id", id);
                var result = DapperORM.ReturnList<EmpModel>("ViewById", Dp);
                return Ok(result);

            }
            catch (Exception )
            {
                return BadRequest();
            }
        }

        // POST api/<EmpController>
        [HttpPut("{id}")]
        public ActionResult AddOrEdit( EmpModel emp, int id)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@ID", id);
                param.Add("@Name",emp.Name);
                param.Add("@Age", emp.Age);
                param.Add("@Job_Location", emp.Job_Location);
                param.Add("@Salary", emp.Salary);
                var result = DapperORM.ReturnList<EmpModel>("AddorEdit", param);
                return Ok(result);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/<EmpController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
