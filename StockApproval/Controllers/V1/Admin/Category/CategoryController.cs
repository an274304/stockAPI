
using ApplicationLayer.IServices.Admin.Category;
using DomainLayer.V1.DTOs;
using DomainLayer.V1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace StockApproval.Controllers.V1.Admin.Category
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("save")]
        public IActionResult SaveCategory([FromForm] CategoryMaster category, [FromForm] IFormFile file)
        {
            try
            {
                var isSave = _categoryService.SaveCategory(category, file);

                if (isSave > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Category Saved",
                        result = true,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Category Failed To Save",
                        result = false,
                        data = null
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResult<object>
                {
                    message = ex.Message.ToString(),
                    result = false,
                    data = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateCategory([FromForm] CategoryMaster category, [FromForm] IFormFile file)
        {
            try
            {
                var isUpdate = _categoryService.UpdateCategory(category, file);

                if (isUpdate > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Category Updated",
                        result = true,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Category Failed To Update",
                        result = false,
                        data = null
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResult<object>
                {
                    message = ex.Message.ToString(),
                    result = false,
                    data = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpDelete("delete/{categoryId}")]
        public IActionResult DeleteCategoryById([FromRoute] int categoryId)
        {
            try
            {
                var isDeleted = _categoryService.DeleteCategoryById(categoryId);

                if (isDeleted > 0)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Category Deleted",
                        result = true,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Category Deletion Fail",
                        result = false,
                        data = null
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResult<object>
                {
                    message = ex.Message.ToString(),
                    result = false,
                    data = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet("all")]
        public IActionResult GetAllCategory()
        {
            try
            {
                var categories = _categoryService.GetAllCategory();

                if (categories == null || !categories.Any())
                {
                    var response = new ApiResult<object>
                    {
                        message = "No categories found.",
                        result = false,
                        data = null
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<CategoryMaster>
                    {
                        message = "List Of Category",
                        result = true,
                        dataList = categories.ToList()
                    };

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResult<object>
                {
                    message = ex.Message.ToString(),
                    result = false,
                    data = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet("get/{categoryId}")]
        public IActionResult GetCategoryById([FromRoute] int categoryId)
        {
            try
            {
                var category = _categoryService.GetCategoryById(categoryId);

                if (category != null)
                {
                    var response = new ApiResult<object>
                    {
                        message = "Detail Of Category",
                        result = true,
                        data = category
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new ApiResult<object>
                    {
                        message = "Fail To Get Category",
                        result = false,
                        data = null
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                var response = new ApiResult<object>
                {
                    message = ex.Message.ToString(),
                    result = false,
                    data = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
