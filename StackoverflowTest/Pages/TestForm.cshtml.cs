using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace StackoverflowTest.Pages
{
  public class TestFormModel : PageModel
  {
    private readonly ILogger _logger;

    public TestFormModel(ILogger<TestFormModel> logger)
    {
      _logger = logger;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public IActionResult OnGet()
    {
      this.Input = new TestFormModel.InputModel
      {
        ShowUsername = false
      };

      return this.Page();
    }

    public IActionResult OnPost() 
    {
      if (!this.ModelState.IsValid) 
      {
        return this.Page();
      }

      _logger.LogInformation("The posted value is: {Value}", this.Input.ShowUsername);

      return this.RedirectToPage("Index");
    }

    public class InputModel 
    {
      [Display(Name = "Show User Name")]
      public bool ShowUsername { get; set; }
    }
  }
}
