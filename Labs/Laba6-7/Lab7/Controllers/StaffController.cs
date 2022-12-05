using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Laba6DB.Models;
using Lab7.Models.DTO;
using Microsoft.Extensions.Logging.Debug;
using System.Diagnostics;

namespace Lab6API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private IConfiguration configuration;
        public StaffController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public List<Staff> GetStaff()
        {
            List<Staff> students = new List<Staff>();

            try
            {
                using (var context = new Laba6DB.Lab6DataContext(configuration))
                {
                    students = context.Staff.ToList();
                }
            }
            catch (Exception ex)
            {
                Debugger.Log(1,"Error",$"Failed while GetStaff with error:{ex.Message}");
            }

            return students;
        }

        [HttpPost]
        public Staff GetStaffById(DeleteStaffDTO staffDTO)
        {
            Staff? student = null;

            try
            {
                using (var context = new Laba6DB.Lab6DataContext(configuration))
                {
                    student = context.Staff.SingleOrDefault(s => s.StaffId == staffDTO.StaffId);
                }
            }
            catch (Exception ex)
            {
                Debugger.Log(1, "Error", $"Failed while GetStaffById with error:{ex.Message}");
            }

            return student;
        }

        [HttpPost]
        public IActionResult AddStaff([FromBody] StaffDTO staff)
        {
            try
            {
                using (var context = new Laba6DB.Lab6DataContext(configuration))
                {
                    Staff newStaff = new Staff();

                    newStaff.FirstName = staff.FirstName;
                    newStaff.MiddleName = staff.MiddleName;
                    newStaff.LastName = staff.LastName;
                    newStaff.DateOfBirth = staff.DateOfBirth;
                    newStaff.Gender = staff.Gender;
                    newStaff.Qualifications = staff.Qualifications;

                    context.Staff.Add(newStaff);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debugger.Log(1, "Error", $"Failed while AddStaff with error:{ex.Message}");
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateStaff([FromBody] StaffDTO staff)
        {
            try
            {
                using (var context = new Laba6DB.Lab6DataContext(configuration))
                {
                    Staff? existStaff = context.Staff.SingleOrDefault(d => d.StaffId == staff.StaffId);

                    if (existStaff != null)
                    {
                        existStaff.FirstName = staff.FirstName;
                        existStaff.MiddleName = staff.MiddleName;
                        existStaff.LastName = staff.LastName;
                        existStaff.DateOfBirth = staff.DateOfBirth;
                        existStaff.Gender = staff.Gender;
                        existStaff.Qualifications = staff.Qualifications;

                        context.Staff.Update(existStaff);

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Debugger.Log(1, "Error", $"Failed while UpdateStaff with error:{ex.Message}");
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult DeleteStaff([FromBody] DeleteStaffDTO deleteStaff)
        {
            try
            {


                using (var context = new Laba6DB.Lab6DataContext(configuration))
                {
                    Staff? staff = context.Staff.SingleOrDefault(s => s.StaffId == deleteStaff.StaffId);

                    if (staff != null)
                    {
                        context.Staff.Remove(staff);

                        context.SaveChanges();
                    }
                }
            }
            catch(Exception ex)
            {
                Debugger.Log(1, "Error", $"Failed while DeleteStaff with error:{ex.Message}");
            }

            return Ok();
        }
    }
}
